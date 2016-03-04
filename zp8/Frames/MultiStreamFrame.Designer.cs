namespace zp8
{
    partial class MultiStreamFrame
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
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lbxFiles = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rbtFiles = new System.Windows.Forms.RadioButton();
            this.tbxUrl = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rbtDownload = new System.Windows.Forms.RadioButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemove.Location = new System.Drawing.Point(114, 298);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 16;
            this.btnRemove.Text = "Odebrat";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(33, 298);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 15;
            this.btnAdd.Text = "Přidat";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lbxFiles
            // 
            this.lbxFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxFiles.FormattingEnabled = true;
            this.lbxFiles.Location = new System.Drawing.Point(33, 114);
            this.lbxFiles.Name = "lbxFiles";
            this.lbxFiles.Size = new System.Drawing.Size(508, 173);
            this.lbxFiles.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Soubory";
            // 
            // rbtFiles
            // 
            this.rbtFiles.AutoSize = true;
            this.rbtFiles.Checked = true;
            this.rbtFiles.Location = new System.Drawing.Point(10, 78);
            this.rbtFiles.Name = "rbtFiles";
            this.rbtFiles.Size = new System.Drawing.Size(112, 17);
            this.rbtFiles.TabIndex = 12;
            this.rbtFiles.TabStop = true;
            this.rbtFiles.Text = "Načíst ze souboru";
            this.rbtFiles.UseVisualStyleBackColor = true;
            this.rbtFiles.CheckedChanged += new System.EventHandler(this.rbtDownload_CheckedChanged);
            // 
            // tbxUrl
            // 
            this.tbxUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxUrl.Location = new System.Drawing.Point(81, 41);
            this.tbxUrl.Name = "tbxUrl";
            this.tbxUrl.Size = new System.Drawing.Size(460, 20);
            this.tbxUrl.TabIndex = 11;
            this.tbxUrl.TextChanged += new System.EventHandler(this.tbxUrl_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "URL";
            // 
            // rbtDownload
            // 
            this.rbtDownload.AutoSize = true;
            this.rbtDownload.Location = new System.Drawing.Point(10, 12);
            this.rbtDownload.Name = "rbtDownload";
            this.rbtDownload.Size = new System.Drawing.Size(120, 17);
            this.rbtDownload.TabIndex = 9;
            this.rbtDownload.Text = "Stáhnout z internetu";
            this.rbtDownload.UseVisualStyleBackColor = true;
            this.rbtDownload.CheckedChanged += new System.EventHandler(this.rbtDownload_CheckedChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            // 
            // MultiStreamFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lbxFiles);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rbtFiles);
            this.Controls.Add(this.tbxUrl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rbtDownload);
            this.Name = "MultiStreamFrame";
            this.Size = new System.Drawing.Size(571, 335);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lbxFiles;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbtFiles;
        private System.Windows.Forms.TextBox tbxUrl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbtDownload;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}
