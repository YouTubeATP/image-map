﻿namespace ImageMap
{
    partial class IDInputDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IDInputDialog));
            this.MapIDLabel = new System.Windows.Forms.Label();
            this.IDInput = new System.Windows.Forms.NumericUpDown();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.AutoButton = new System.Windows.Forms.Button();
            this.MapLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.IDInput)).BeginInit();
            this.SuspendLayout();
            // 
            // MapIDLabel
            // 
            this.MapIDLabel.AutoSize = true;
            this.MapIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.MapIDLabel.Location = new System.Drawing.Point(9, 7);
            this.MapIDLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MapIDLabel.Name = "MapIDLabel";
            this.MapIDLabel.Size = new System.Drawing.Size(115, 24);
            this.MapIDLabel.TabIndex = 0;
            this.MapIDLabel.Text = "Input Map ID";
            // 
            // IDInput
            // 
            this.IDInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.IDInput.Location = new System.Drawing.Point(66, 45);
            this.IDInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.IDInput.Maximum = new decimal(new int[] {
            -1,
            2147483647,
            0,
            0});
            this.IDInput.Minimum = new decimal(new int[] {
            -1,
            2147483647,
            0,
            -2147483648});
            this.IDInput.Name = "IDInput";
            this.IDInput.Size = new System.Drawing.Size(206, 32);
            this.IDInput.TabIndex = 13;
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ConfirmButton.Location = new System.Drawing.Point(9, 84);
            this.ConfirmButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(110, 36);
            this.ConfirmButton.TabIndex = 14;
            this.ConfirmButton.Text = "Confirm";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.CancelButton.Location = new System.Drawing.Point(193, 84);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(79, 36);
            this.CancelButton.TabIndex = 15;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // AutoButton
            // 
            this.AutoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.AutoButton.Location = new System.Drawing.Point(124, 84);
            this.AutoButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AutoButton.Name = "AutoButton";
            this.AutoButton.Size = new System.Drawing.Size(64, 36);
            this.AutoButton.TabIndex = 16;
            this.AutoButton.Text = "Auto";
            this.AutoButton.UseVisualStyleBackColor = true;
            this.AutoButton.Click += new System.EventHandler(this.AutoButton_Click);
            // 
            // MapLabel
            // 
            this.MapLabel.AutoSize = true;
            this.MapLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.MapLabel.Location = new System.Drawing.Point(9, 49);
            this.MapLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MapLabel.Name = "MapLabel";
            this.MapLabel.Size = new System.Drawing.Size(57, 24);
            this.MapLabel.TabIndex = 17;
            this.MapLabel.Text = "map_";
            // 
            // IDInputDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 126);
            this.Controls.Add(this.MapLabel);
            this.Controls.Add(this.AutoButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.IDInput);
            this.Controls.Add(this.MapIDLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IDInputDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change map ID";
            this.Load += new System.EventHandler(this.IDInputDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.IDInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MapIDLabel;
        private System.Windows.Forms.NumericUpDown IDInput;
        private System.Windows.Forms.Button ConfirmButton;
        new private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button AutoButton;
        private System.Windows.Forms.Label MapLabel;
    }
}