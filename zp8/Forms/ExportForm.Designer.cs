namespace zp8
{
    partial class ExportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportForm));
            this.wizard1 = new Gui.Wizard.Wizard();
            this.wizardPage2 = new Gui.Wizard.WizardPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.header2 = new Gui.Wizard.Header();
            this.wizardPage1 = new Gui.Wizard.WizardPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbcondition = new System.Windows.Forms.TextBox();
            this.rbcondition = new System.Windows.Forms.RadioButton();
            this.rbwholedb = new System.Windows.Forms.RadioButton();
            this.rbselectedsongs = new System.Windows.Forms.RadioButton();
            this.rbcurrentsong = new System.Windows.Forms.RadioButton();
            this.header1 = new Gui.Wizard.Header();
            this.wizardPage3 = new Gui.Wizard.WizardPage();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbformat = new System.Windows.Forms.ListBox();
            this.header3 = new Gui.Wizard.Header();
            this.wizard1.SuspendLayout();
            this.wizardPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.wizardPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.wizardPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // wizard1
            // 
            this.wizard1.Controls.Add(this.wizardPage1);
            this.wizard1.Controls.Add(this.wizardPage2);
            this.wizard1.Controls.Add(this.wizardPage3);
            this.wizard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizard1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wizard1.Location = new System.Drawing.Point(0, 0);
            this.wizard1.Name = "wizard1";
            this.wizard1.Pages.AddRange(new Gui.Wizard.WizardPage[] {
            this.wizardPage1,
            this.wizardPage2,
            this.wizardPage3});
            this.wizard1.Size = new System.Drawing.Size(593, 450);
            this.wizard1.TabIndex = 0;
            // 
            // wizardPage2
            // 
            this.wizardPage2.Controls.Add(this.dataGridView1);
            this.wizardPage2.Controls.Add(this.header2);
            this.wizardPage2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardPage2.IsFinishPage = false;
            this.wizardPage2.Location = new System.Drawing.Point(0, 0);
            this.wizardPage2.Name = "wizardPage2";
            this.wizardPage2.Size = new System.Drawing.Size(593, 402);
            this.wizardPage2.TabIndex = 2;
            this.wizardPage2.ShowFromNext += new System.EventHandler(this.wizardPage2_ShowFromNext);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 64);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(593, 338);
            this.dataGridView1.TabIndex = 1;
            // 
            // header2
            // 
            this.header2.BackColor = System.Drawing.SystemColors.Control;
            this.header2.CausesValidation = false;
            this.header2.Description = "Prohl�en� exportovan�ch p�sn�";
            this.header2.Dock = System.Windows.Forms.DockStyle.Top;
            this.header2.Image = ((System.Drawing.Image)(resources.GetObject("header2.Image")));
            this.header2.Location = new System.Drawing.Point(0, 0);
            this.header2.Name = "header2";
            this.header2.Size = new System.Drawing.Size(593, 64);
            this.header2.TabIndex = 0;
            this.header2.Title = "Export p�sn�";
            // 
            // wizardPage1
            // 
            this.wizardPage1.Controls.Add(this.groupBox1);
            this.wizardPage1.Controls.Add(this.header1);
            this.wizardPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardPage1.IsFinishPage = false;
            this.wizardPage1.Location = new System.Drawing.Point(0, 0);
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.Size = new System.Drawing.Size(593, 402);
            this.wizardPage1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tbcondition);
            this.groupBox1.Controls.Add(this.rbcondition);
            this.groupBox1.Controls.Add(this.rbwholedb);
            this.groupBox1.Controls.Add(this.rbselectedsongs);
            this.groupBox1.Controls.Add(this.rbcurrentsong);
            this.groupBox1.Location = new System.Drawing.Point(12, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(569, 329);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Zdroj p�sn�";
            // 
            // tbcondition
            // 
            this.tbcondition.Enabled = false;
            this.tbcondition.Location = new System.Drawing.Point(25, 112);
            this.tbcondition.Name = "tbcondition";
            this.tbcondition.Size = new System.Drawing.Size(216, 21);
            this.tbcondition.TabIndex = 4;
            // 
            // rbcondition
            // 
            this.rbcondition.AutoSize = true;
            this.rbcondition.Location = new System.Drawing.Point(6, 89);
            this.rbcondition.Name = "rbcondition";
            this.rbcondition.Size = new System.Drawing.Size(130, 17);
            this.rbcondition.TabIndex = 3;
            this.rbcondition.Text = "Podmno�ina datab�ze";
            this.rbcondition.UseVisualStyleBackColor = true;
            this.rbcondition.CheckedChanged += new System.EventHandler(this.rbcondition_CheckedChanged);
            // 
            // rbwholedb
            // 
            this.rbwholedb.AutoSize = true;
            this.rbwholedb.Location = new System.Drawing.Point(6, 66);
            this.rbwholedb.Name = "rbwholedb";
            this.rbwholedb.Size = new System.Drawing.Size(94, 17);
            this.rbwholedb.TabIndex = 2;
            this.rbwholedb.Text = "Cel� datab�ze";
            this.rbwholedb.UseVisualStyleBackColor = true;
            // 
            // rbselectedsongs
            // 
            this.rbselectedsongs.AutoSize = true;
            this.rbselectedsongs.Location = new System.Drawing.Point(6, 43);
            this.rbselectedsongs.Name = "rbselectedsongs";
            this.rbselectedsongs.Size = new System.Drawing.Size(93, 17);
            this.rbselectedsongs.TabIndex = 1;
            this.rbselectedsongs.Text = "Vybran� p�sn�";
            this.rbselectedsongs.UseVisualStyleBackColor = true;
            // 
            // rbcurrentsong
            // 
            this.rbcurrentsong.AutoSize = true;
            this.rbcurrentsong.Checked = true;
            this.rbcurrentsong.Location = new System.Drawing.Point(6, 20);
            this.rbcurrentsong.Name = "rbcurrentsong";
            this.rbcurrentsong.Size = new System.Drawing.Size(91, 17);
            this.rbcurrentsong.TabIndex = 0;
            this.rbcurrentsong.TabStop = true;
            this.rbcurrentsong.Text = "Aktu�ln� p�se�";
            this.rbcurrentsong.UseVisualStyleBackColor = true;
            // 
            // header1
            // 
            this.header1.BackColor = System.Drawing.SystemColors.Control;
            this.header1.CausesValidation = false;
            this.header1.Description = "Zdroj p�sn� pro export";
            this.header1.Dock = System.Windows.Forms.DockStyle.Top;
            this.header1.Image = ((System.Drawing.Image)(resources.GetObject("header1.Image")));
            this.header1.Location = new System.Drawing.Point(0, 0);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(593, 64);
            this.header1.TabIndex = 0;
            this.header1.Title = "Export p�sn�";
            // 
            // wizardPage3
            // 
            this.wizardPage3.Controls.Add(this.propertyGrid1);
            this.wizardPage3.Controls.Add(this.label2);
            this.wizardPage3.Controls.Add(this.label1);
            this.wizardPage3.Controls.Add(this.lbformat);
            this.wizardPage3.Controls.Add(this.header3);
            this.wizardPage3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardPage3.IsFinishPage = false;
            this.wizardPage3.Location = new System.Drawing.Point(0, 0);
            this.wizardPage3.Name = "wizardPage3";
            this.wizardPage3.Size = new System.Drawing.Size(593, 402);
            this.wizardPage3.TabIndex = 3;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGrid1.Location = new System.Drawing.Point(235, 105);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(346, 258);
            this.propertyGrid1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(231, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "V�stupn� soubor / slo�ka";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Form�ty exportu";
            // 
            // lbformat
            // 
            this.lbformat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lbformat.FormattingEnabled = true;
            this.lbformat.Location = new System.Drawing.Point(12, 105);
            this.lbformat.Name = "lbformat";
            this.lbformat.Size = new System.Drawing.Size(180, 251);
            this.lbformat.TabIndex = 1;
            this.lbformat.SelectedIndexChanged += new System.EventHandler(this.lbformat_SelectedIndexChanged);
            // 
            // header3
            // 
            this.header3.BackColor = System.Drawing.SystemColors.Control;
            this.header3.CausesValidation = false;
            this.header3.Description = "Form�t exportu";
            this.header3.Dock = System.Windows.Forms.DockStyle.Top;
            this.header3.Image = ((System.Drawing.Image)(resources.GetObject("header3.Image")));
            this.header3.Location = new System.Drawing.Point(0, 0);
            this.header3.Name = "header3";
            this.header3.Size = new System.Drawing.Size(593, 64);
            this.header3.TabIndex = 0;
            this.header3.Title = "Export p�sn�";
            // 
            // ExportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 450);
            this.Controls.Add(this.wizard1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export p�sn�";
            this.wizard1.ResumeLayout(false);
            this.wizardPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.wizardPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.wizardPage3.ResumeLayout(false);
            this.wizardPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Gui.Wizard.Wizard wizard1;
        private Gui.Wizard.WizardPage wizardPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbcondition;
        private System.Windows.Forms.RadioButton rbcondition;
        private System.Windows.Forms.RadioButton rbwholedb;
        private System.Windows.Forms.RadioButton rbselectedsongs;
        private System.Windows.Forms.RadioButton rbcurrentsong;
        private Gui.Wizard.Header header1;
        private Gui.Wizard.WizardPage wizardPage2;
        private Gui.Wizard.WizardPage wizardPage3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbformat;
        private Gui.Wizard.Header header3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Gui.Wizard.Header header2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn authorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn langDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn songtextDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn publishedDataGridViewTextBoxColumn;
    }
}