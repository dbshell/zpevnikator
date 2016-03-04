namespace zp8
{
    partial class SongForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SongForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.píseňToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.konecToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.zavřítToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTransp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTranspDown = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTrasnpUp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTranspDown5 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTrasnpUp5 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.vložitTextSAkordyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.songFrame1 = new zp8.Frames.SongFrame();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.píseňToolStripMenuItem,
            this.mnuTransp,
            this.mnuEdit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(734, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // píseňToolStripMenuItem
            // 
            this.píseňToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSave,
            this.konecToolStripMenuItem,
            this.zavřítToolStripMenuItem});
            this.píseňToolStripMenuItem.Name = "píseňToolStripMenuItem";
            this.píseňToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.píseňToolStripMenuItem.Text = "Píseň";
            // 
            // mnuSave
            // 
            this.mnuSave.Image = global::zp8.StdResources.save;
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuSave.Size = new System.Drawing.Size(144, 22);
            this.mnuSave.Text = "Uložit";
            this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
            // 
            // konecToolStripMenuItem
            // 
            this.konecToolStripMenuItem.Name = "konecToolStripMenuItem";
            this.konecToolStripMenuItem.Size = new System.Drawing.Size(141, 6);
            // 
            // zavřítToolStripMenuItem
            // 
            this.zavřítToolStripMenuItem.Name = "zavřítToolStripMenuItem";
            this.zavřítToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.zavřítToolStripMenuItem.Text = "Zavřít";
            this.zavřítToolStripMenuItem.Click += new System.EventHandler(this.zavřítToolStripMenuItem_Click);
            // 
            // mnuTransp
            // 
            this.mnuTransp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTranspDown,
            this.mnuTrasnpUp,
            this.mnuTranspDown5,
            this.mnuTrasnpUp5});
            this.mnuTransp.Name = "mnuTransp";
            this.mnuTransp.Size = new System.Drawing.Size(82, 20);
            this.mnuTransp.Text = "Transpozice";
            // 
            // mnuTranspDown
            // 
            this.mnuTranspDown.Image = global::zp8.StdResources.down1;
            this.mnuTranspDown.Name = "mnuTranspDown";
            this.mnuTranspDown.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mnuTranspDown.Size = new System.Drawing.Size(160, 22);
            this.mnuTranspDown.Text = "Dolů";
            this.mnuTranspDown.Click += new System.EventHandler(this.mnuTranspDown_Click);
            // 
            // mnuTrasnpUp
            // 
            this.mnuTrasnpUp.Image = global::zp8.StdResources.up1;
            this.mnuTrasnpUp.Name = "mnuTrasnpUp";
            this.mnuTrasnpUp.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.mnuTrasnpUp.Size = new System.Drawing.Size(160, 22);
            this.mnuTrasnpUp.Text = "Nahoru";
            this.mnuTrasnpUp.Click += new System.EventHandler(this.mnuTrasnpUp_Click);
            // 
            // mnuTranspDown5
            // 
            this.mnuTranspDown5.Image = global::zp8.StdResources.down2;
            this.mnuTranspDown5.Name = "mnuTranspDown5";
            this.mnuTranspDown5.Size = new System.Drawing.Size(160, 22);
            this.mnuTranspDown5.Text = "Dolů o kvintu";
            this.mnuTranspDown5.Click += new System.EventHandler(this.mnuTranspDown5_Click);
            // 
            // mnuTrasnpUp5
            // 
            this.mnuTrasnpUp5.Image = global::zp8.StdResources.up2;
            this.mnuTrasnpUp5.Name = "mnuTrasnpUp5";
            this.mnuTrasnpUp5.Size = new System.Drawing.Size(160, 22);
            this.mnuTrasnpUp5.Text = "Nahoru o kvintu";
            this.mnuTrasnpUp5.Click += new System.EventHandler(this.mnuTrasnpUp5_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vložitTextSAkordyToolStripMenuItem});
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(56, 20);
            this.mnuEdit.Text = "Úpravy";
            // 
            // vložitTextSAkordyToolStripMenuItem
            // 
            this.vložitTextSAkordyToolStripMenuItem.Name = "vložitTextSAkordyToolStripMenuItem";
            this.vložitTextSAkordyToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.vložitTextSAkordyToolStripMenuItem.Text = "Vložit text s akordy";
            this.vložitTextSAkordyToolStripMenuItem.Click += new System.EventHandler(this.vložitTextSAkordyToolStripMenuItem_Click);
            // 
            // songFrame1
            // 
            this.songFrame1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.songFrame1.Location = new System.Drawing.Point(0, 24);
            this.songFrame1.Name = "songFrame1";
            this.songFrame1.Size = new System.Drawing.Size(734, 508);
            this.songFrame1.SongDb = null;
            this.songFrame1.TabIndex = 2;
            this.songFrame1.TitleChanged += new System.EventHandler(this.songFrame1_TitleChanged);
            this.songFrame1.SongSaved += new System.EventHandler(this.songFrame1_SongSaved);
            this.songFrame1.TabChanged += new System.EventHandler(this.songFrame1_TabChanged);
            // 
            // SongForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 532);
            this.Controls.Add(this.songFrame1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "SongForm";
            this.Text = "SongForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SongForm_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SongForm_FormClosing);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.SongForm_PreviewKeyDown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SongForm_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem píseňToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.ToolStripSeparator konecToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zavřítToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuTransp;
        private System.Windows.Forms.ToolStripMenuItem mnuTranspDown;
        private System.Windows.Forms.ToolStripMenuItem mnuTrasnpUp;
        private System.Windows.Forms.ToolStripMenuItem mnuTranspDown5;
        private System.Windows.Forms.ToolStripMenuItem mnuTrasnpUp5;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem vložitTextSAkordyToolStripMenuItem;
        private zp8.Frames.SongFrame songFrame1;
    }
}