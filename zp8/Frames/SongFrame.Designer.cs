namespace zp8.Frames
{
    partial class SongFrame
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.songView1 = new zp8.SongView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textEditorControl1 = new ICSharpCode.TextEditor.TextEditorControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnTransDown = new System.Windows.Forms.ToolStripButton();
            this.btnTranspUp = new System.Windows.Forms.ToolStripButton();
            this.btnTraspDown5 = new System.Windows.Forms.ToolStripButton();
            this.btnTraspUp5 = new System.Windows.Forms.ToolStripButton();
            this.btnInsertChordsText = new System.Windows.Forms.ToolStripButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOpenLink = new System.Windows.Forms.Button();
            this.btnRemoveLink = new System.Windows.Forms.Button();
            this.btnAddLink = new System.Windows.Forms.Button();
            this.lbxLinks = new System.Windows.Forms.ListBox();
            this.tbxRemark = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxGroup = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxAuthor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxServer = new zp8.ServerComboBox();
            this.openLinkDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnCancelChanges = new System.Windows.Forms.ToolStripButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(674, 409);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.songView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(666, 383);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Prohlížení";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // songView1
            // 
            this.songView1.AutoScroll = true;
            this.songView1.BackColor = System.Drawing.SystemColors.Window;
            this.songView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.songView1.Location = new System.Drawing.Point(3, 3);
            this.songView1.Name = "songView1";
            this.songView1.Size = new System.Drawing.Size(660, 377);
            this.songView1.SongDb = null;
            this.songView1.SongText = null;
            this.songView1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textEditorControl1);
            this.tabPage2.Controls.Add(this.toolStrip1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(666, 383);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Editor";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textEditorControl1
            // 
            this.textEditorControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEditorControl1.IsReadOnly = false;
            this.textEditorControl1.Location = new System.Drawing.Point(3, 3);
            this.textEditorControl1.Name = "textEditorControl1";
            this.textEditorControl1.Size = new System.Drawing.Size(660, 377);
            this.textEditorControl1.TabIndex = 1;
            this.textEditorControl1.Text = "textEditorControl1";
            this.textEditorControl1.TextChanged += new System.EventHandler(this.textEditorControl1_TextChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTransDown,
            this.btnTranspUp,
            this.btnTraspDown5,
            this.btnTraspUp5,
            this.btnInsertChordsText});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(660, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.Visible = false;
            // 
            // btnTransDown
            // 
            this.btnTransDown.Image = global::zp8.StdResources.down1;
            this.btnTransDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTransDown.Name = "btnTransDown";
            this.btnTransDown.Size = new System.Drawing.Size(52, 22);
            this.btnTransDown.Text = "Dolů";
            this.btnTransDown.Click += new System.EventHandler(this.btnTransDown_Click);
            // 
            // btnTranspUp
            // 
            this.btnTranspUp.Image = global::zp8.StdResources.up1;
            this.btnTranspUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTranspUp.Name = "btnTranspUp";
            this.btnTranspUp.Size = new System.Drawing.Size(67, 22);
            this.btnTranspUp.Text = "Nahoru";
            this.btnTranspUp.Click += new System.EventHandler(this.btnTranspUp_Click);
            // 
            // btnTraspDown5
            // 
            this.btnTraspDown5.Image = global::zp8.StdResources.down2;
            this.btnTraspDown5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTraspDown5.Name = "btnTraspDown5";
            this.btnTraspDown5.Size = new System.Drawing.Size(98, 22);
            this.btnTraspDown5.Text = "Dolů o kvintu";
            this.btnTraspDown5.Click += new System.EventHandler(this.btnTraspDown5_Click);
            // 
            // btnTraspUp5
            // 
            this.btnTraspUp5.Image = global::zp8.StdResources.up2;
            this.btnTraspUp5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTraspUp5.Name = "btnTraspUp5";
            this.btnTraspUp5.Size = new System.Drawing.Size(113, 22);
            this.btnTraspUp5.Text = "Nahoru o kvintu";
            this.btnTraspUp5.Click += new System.EventHandler(this.btnTraspUp5_Click);
            // 
            // btnInsertChordsText
            // 
            this.btnInsertChordsText.Image = global::zp8.StdResources.paste;
            this.btnInsertChordsText.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInsertChordsText.Name = "btnInsertChordsText";
            this.btnInsertChordsText.Size = new System.Drawing.Size(125, 22);
            this.btnInsertChordsText.Text = "Vložit text s akordy";
            this.btnInsertChordsText.Click += new System.EventHandler(this.btnInsertChordsText_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Controls.Add(this.tbxRemark);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.tbxGroup);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.tbxAuthor);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.tbxTitle);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.cbxServer);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(666, 383);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Vlastnosti";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOpenLink);
            this.groupBox1.Controls.Add(this.btnRemoveLink);
            this.groupBox1.Controls.Add(this.btnAddLink);
            this.groupBox1.Controls.Add(this.lbxLinks);
            this.groupBox1.Location = new System.Drawing.Point(22, 164);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 178);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Odkazy";
            // 
            // btnOpenLink
            // 
            this.btnOpenLink.Image = global::zp8.StdResources.pen;
            this.btnOpenLink.Location = new System.Drawing.Point(169, 133);
            this.btnOpenLink.Name = "btnOpenLink";
            this.btnOpenLink.Size = new System.Drawing.Size(75, 23);
            this.btnOpenLink.TabIndex = 34;
            this.btnOpenLink.UseVisualStyleBackColor = true;
            this.btnOpenLink.Click += new System.EventHandler(this.btnOpenLink_Click);
            // 
            // btnRemoveLink
            // 
            this.btnRemoveLink.Image = global::zp8.StdResources.remove;
            this.btnRemoveLink.Location = new System.Drawing.Point(88, 133);
            this.btnRemoveLink.Name = "btnRemoveLink";
            this.btnRemoveLink.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveLink.TabIndex = 33;
            this.btnRemoveLink.UseVisualStyleBackColor = true;
            this.btnRemoveLink.Click += new System.EventHandler(this.btnRemoveLink_Click);
            // 
            // btnAddLink
            // 
            this.btnAddLink.Image = global::zp8.StdResources.add;
            this.btnAddLink.Location = new System.Drawing.Point(7, 134);
            this.btnAddLink.Name = "btnAddLink";
            this.btnAddLink.Size = new System.Drawing.Size(75, 23);
            this.btnAddLink.TabIndex = 32;
            this.btnAddLink.UseVisualStyleBackColor = true;
            this.btnAddLink.Click += new System.EventHandler(this.btnAddLink_Click);
            // 
            // lbxLinks
            // 
            this.lbxLinks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxLinks.FormattingEnabled = true;
            this.lbxLinks.Location = new System.Drawing.Point(6, 19);
            this.lbxLinks.Name = "lbxLinks";
            this.lbxLinks.Size = new System.Drawing.Size(263, 108);
            this.lbxLinks.TabIndex = 31;
            // 
            // tbxRemark
            // 
            this.tbxRemark.Location = new System.Drawing.Point(115, 90);
            this.tbxRemark.Name = "tbxRemark";
            this.tbxRemark.Size = new System.Drawing.Size(182, 20);
            this.tbxRemark.TabIndex = 26;
            this.tbxRemark.TextChanged += new System.EventHandler(this.textEditorControl1_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Poznámka";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Server";
            // 
            // tbxGroup
            // 
            this.tbxGroup.Location = new System.Drawing.Point(115, 64);
            this.tbxGroup.Name = "tbxGroup";
            this.tbxGroup.Size = new System.Drawing.Size(182, 20);
            this.tbxGroup.TabIndex = 23;
            this.tbxGroup.TextChanged += new System.EventHandler(this.textEditorControl1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Skupina";
            // 
            // tbxAuthor
            // 
            this.tbxAuthor.Location = new System.Drawing.Point(115, 38);
            this.tbxAuthor.Name = "tbxAuthor";
            this.tbxAuthor.Size = new System.Drawing.Size(182, 20);
            this.tbxAuthor.TabIndex = 21;
            this.tbxAuthor.TextChanged += new System.EventHandler(this.textEditorControl1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Autor";
            // 
            // tbxTitle
            // 
            this.tbxTitle.Location = new System.Drawing.Point(115, 12);
            this.tbxTitle.Name = "tbxTitle";
            this.tbxTitle.Size = new System.Drawing.Size(182, 20);
            this.tbxTitle.TabIndex = 19;
            this.tbxTitle.TextChanged += new System.EventHandler(this.textEditorControl1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Název";
            // 
            // cbxServer
            // 
            this.cbxServer.Database = null;
            this.cbxServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxServer.Enabled = false;
            this.cbxServer.FormattingEnabled = true;
            this.cbxServer.Location = new System.Drawing.Point(115, 116);
            this.cbxServer.Name = "cbxServer";
            this.cbxServer.ServerID = null;
            this.cbxServer.Size = new System.Drawing.Size(182, 21);
            this.cbxServer.TabIndex = 32;
            this.cbxServer.SelectedIndexChanged += new System.EventHandler(this.textEditorControl1_TextChanged);
            // 
            // openLinkDialog
            // 
            this.openLinkDialog.Filter = "MP3 soubory|*.mp3|Všechny soubory|*.*";
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.btnCancelChanges});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(674, 25);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnSave
            // 
            this.btnSave.Image = global::zp8.StdResources.save;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(57, 22);
            this.btnSave.Text = "Uložit";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancelChanges
            // 
            this.btnCancelChanges.Image = global::zp8.StdResources.cancel;
            this.btnCancelChanges.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelChanges.Name = "btnCancelChanges";
            this.btnCancelChanges.Size = new System.Drawing.Size(95, 22);
            this.btnCancelChanges.Text = "Zrušit změny";
            this.btnCancelChanges.Click += new System.EventHandler(this.btnCancelChanges_Click);
            // 
            // SongFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip2);
            this.Name = "SongFrame";
            this.Size = new System.Drawing.Size(674, 434);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private SongView songView1;
        private System.Windows.Forms.TabPage tabPage2;
        private ICSharpCode.TextEditor.TextEditorControl textEditorControl1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOpenLink;
        private System.Windows.Forms.Button btnRemoveLink;
        private System.Windows.Forms.Button btnAddLink;
        private System.Windows.Forms.ListBox lbxLinks;
        private System.Windows.Forms.TextBox tbxRemark;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxGroup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxAuthor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxTitle;
        private System.Windows.Forms.Label label1;
        private ServerComboBox cbxServer;
        private System.Windows.Forms.OpenFileDialog openLinkDialog;
        private System.Windows.Forms.ToolStripButton btnTransDown;
        private System.Windows.Forms.ToolStripButton btnTranspUp;
        private System.Windows.Forms.ToolStripButton btnTraspDown5;
        private System.Windows.Forms.ToolStripButton btnTraspUp5;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnCancelChanges;
        private System.Windows.Forms.ToolStripButton btnInsertChordsText;
    }
}
