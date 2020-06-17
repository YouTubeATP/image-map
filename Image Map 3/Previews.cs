﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageMap
{
    public enum MapStatus
    {
        Importing,
        Existing
    }

    public abstract class HalfPreview
    {
        public event EventHandler ControlsChanged;
        public abstract IReadOnlyDictionary<long, Map> GetMaps();
        public virtual bool HasAnyMaps() => GetMaps().Any();
        public virtual IEnumerable<long> GetTakenIDs() => GetMaps().Keys;
        public ContextMenuStrip ContextMenu;
        private readonly List<MapIDControl> Controls = new List<MapIDControl>();
        public IReadOnlyCollection<MapIDControl> MapIDControls => Controls.AsReadOnly();
        public IEnumerable<MapIDControl> SelectedControls => Controls.Where(x => x.IsSelected);

        public void SelectAll()
        {
            foreach (var box in Controls)
            {
                box.SetSelected(true);
            }
        }

        public void DeselectAll()
        {
            foreach (var box in Controls)
            {
                box.SetSelected(false);
            }
        }

        protected void UpdateControlsFromMaps()
        {
            var maps = GetMaps();
            Controls.RemoveAll(x => !maps.ContainsKey(x.ID));
            foreach (var map in maps)
            {
                if (!Controls.Any(x => x.ID == map.Key))
                    Controls.Add(CreateMapIdControl(map.Key, map.Value));
            }
            UpdateControls(Controls);
            SignalControlsChanged();
        }

        protected virtual void UpdateControls(List<MapIDControl> pending_controls) { }

        protected void SignalControlsChanged()
        {
            ControlsChanged?.Invoke(this, EventArgs.Empty);
        }

        protected MapIDControl CreateMapIdControl(long id)
        {
            var box = new MapIDControl(id);
            box.MouseDown += Box_MouseDown;
            return box;
        }

        protected MapIDControl CreateMapIdControl(long id, Map map)
        {
            var box = CreateMapIdControl(id);
            box.SetBox(new MapPreviewBox(map));
            return box;
        }

        private void Box_MouseDown(object sender, MouseEventArgs e)
        {
            var box = (MapIDControl)sender;
            if (e.Button == MouseButtons.Right)
            {
                if (!box.IsSelected)
                {
                    DeselectAll();
                    box.SetSelected(true);
                }
                var context = ContextMenu;
                context.Show(box, new Point(e.X, e.Y));
            }
            else
                ClickSelect(box);
        }

        private MapIDControl LastSelected;
        private void ClickSelect(MapIDControl box)
        {
            var current = LastSelected;
            box.ToggleSelected();
            if (Control.ModifierKeys == Keys.Shift && current != null)
            {
                bool state = current.IsSelected;
                int first = Controls.IndexOf(current);
                int last = Controls.IndexOf(box);
                for (int i = Math.Min(first, last); i < Math.Max(first, last); i++)
                {
                    Controls[i].SetSelected(state);
                }
            }
            LastSelected = box;
        }
    }

    public class ImportPreview : HalfPreview
    {
        private readonly Dictionary<long, Map> ImportingMaps = new Dictionary<long, Map>();
        private readonly Dictionary<long, MapIDControl> EmptyWaitingControls = new Dictionary<long, MapIDControl>();
        // simulate a threadsafe set
        private readonly ConcurrentDictionary<PendingMapsWithID, PendingMapsWithID> ProcessingMaps = new ConcurrentDictionary<PendingMapsWithID, PendingMapsWithID>();

        public override IReadOnlyDictionary<long, Map> GetMaps()
        {
            return ImportingMaps;
        }
        public override bool HasAnyMaps()
        {
            return base.HasAnyMaps() || ProcessingMaps.Any();
        }
        public override IEnumerable<long> GetTakenIDs()
        {
            return base.GetTakenIDs().Concat(ProcessingMaps.SelectMany(x => x.Key.IDs));
        }

        public void AddPending(PendingMapsWithID pending)
        {
            CreateEmptyIDControls(pending.IDs);
            pending.Finished += Pending_Finished;
            ProcessingMaps.TryAdd(pending, pending);
        }

        public void RemoveMaps(IEnumerable<long> ids)
        {
            foreach (var id in ids)
            {
                ImportingMaps.Remove(id);
            }
            UpdateControlsFromMaps();
        }

        public void ClearMaps()
        {
            ImportingMaps.Clear();
            UpdateControlsFromMaps();
        }

        protected override void UpdateControls(List<MapIDControl> pending_controls)
        {
            pending_controls.AddRange(EmptyWaitingControls.Values);
        }

        private void CreateEmptyIDControls(IEnumerable<long> ids)
        {
            foreach (var id in ids)
            {
                var box = CreateMapIdControl(id);
                EmptyWaitingControls.Add(id, box);
            }
            UpdateControlsFromMaps();
        }

        private void Pending_Finished(object sender, EventArgs e)
        {
            var pending = (PendingMapsWithID)sender;
            ProcessingMaps.TryRemove(pending, out _);
            foreach (var item in pending.ResultMaps)
            {
                ImportingMaps[item.Key] = item.Value;
            }
            FillEmptyControls(pending.IDs);
        }

        private void FillEmptyControls(IEnumerable<long> ids)
        {
            var maps = GetMaps();
            foreach (var id in ids)
            {
                if (EmptyWaitingControls.TryGetValue(id, out var box))
                {
                    if (maps.TryGetValue(id, out var map))
                        box.SetBox(new MapPreviewBox(map));
                    EmptyWaitingControls.Remove(id);
                }
            }
        }
    }

    public class WorldPreview : HalfPreview
    {
        protected readonly MinecraftWorld World;

        public WorldPreview(MinecraftWorld world)
        {
            World = world;
            World.MapsChanged += World_MapsChanged;
            UpdateControlsFromMaps();
        }

        private void World_MapsChanged(object sender, EventArgs e)
        {
            UpdateControlsFromMaps();
        }

        public override IReadOnlyDictionary<long, Map> GetMaps()
        {
            return World.WorldMaps;
        }
    }
}
