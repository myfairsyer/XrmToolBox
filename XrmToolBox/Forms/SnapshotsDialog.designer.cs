namespace XrmToolBox.Forms
{
    partial class SnapshotsDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SnapshotsDialog));
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsbRestore = new System.Windows.Forms.ToolStripButton();
            this.lbSnapshots = new System.Windows.Forms.ListBox();
            this.tsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbRestore});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(278, 32);
            this.tsMain.TabIndex = 0;
            this.tsMain.Text = "toolStrip1";
            // 
            // tsbRestore
            // 
            this.tsbRestore.Image = ((System.Drawing.Image)(resources.GetObject("tsbRestore.Image")));
            this.tsbRestore.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRestore.Name = "tsbRestore";
            this.tsbRestore.Size = new System.Drawing.Size(200, 29);
            this.tsbRestore.Text = "Restore selected item";
            this.tsbRestore.Click += new System.EventHandler(this.tsbRestore_Click);
            // 
            // lbSnapshots
            // 
            this.lbSnapshots.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSnapshots.FormattingEnabled = true;
            this.lbSnapshots.ItemHeight = 20;
            this.lbSnapshots.Location = new System.Drawing.Point(0, 32);
            this.lbSnapshots.Name = "lbSnapshots";
            this.lbSnapshots.Size = new System.Drawing.Size(278, 212);
            this.lbSnapshots.TabIndex = 1;
            // 
            // SnapshotsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 244);
            this.Controls.Add(this.lbSnapshots);
            this.Controls.Add(this.tsMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "SnapshotsDialog";
            this.Text = "Snapshots";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SnapshotsDialog_Load);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ListBox lbSnapshots;
        private System.Windows.Forms.ToolStripButton tsbRestore;
    }
}