namespace zp8
{
    partial class AddServerWizard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddServerWizard));
            this.wizard1 = new Gui.Wizard.Wizard();
            this.wizardPage3 = new Gui.Wizard.WizardPage();
            this.endpage = new Gui.Wizard.InfoPage();
            this.wizardPage2 = new Gui.Wizard.WizardPage();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.header2 = new Gui.Wizard.Header();
            this.wizardPage1 = new Gui.Wizard.WizardPage();
            this.label2 = new System.Windows.Forms.Label();
            this.description = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.servertype = new System.Windows.Forms.ListBox();
            this.header1 = new Gui.Wizard.Header();
            this.wizard1.SuspendLayout();
            this.wizardPage3.SuspendLayout();
            this.wizardPage2.SuspendLayout();
            this.wizardPage1.SuspendLayout();
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
            this.wizard1.Size = new System.Drawing.Size(476, 366);
            this.wizard1.TabIndex = 0;
            // 
            // wizardPage3
            // 
            this.wizardPage3.Controls.Add(this.endpage);
            this.wizardPage3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardPage3.IsFinishPage = false;
            this.wizardPage3.Location = new System.Drawing.Point(0, 0);
            this.wizardPage3.Name = "wizardPage3";
            this.wizardPage3.Size = new System.Drawing.Size(476, 318);
            this.wizardPage3.TabIndex = 3;
            this.wizardPage3.ShowFromNext += new System.EventHandler(this.wizardPage3_ShowFromNext);
            // 
            // endpage
            // 
            this.endpage.BackColor = System.Drawing.Color.White;
            this.endpage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.endpage.Image = ((System.Drawing.Image)(resources.GetObject("endpage.Image")));
            this.endpage.Location = new System.Drawing.Point(0, 0);
            this.endpage.Name = "endpage";
            this.endpage.PageText = "This wizard enables you to...";
            this.endpage.PageTitle = "Dokon�en� p�id�n� serveru";
            this.endpage.Size = new System.Drawing.Size(476, 318);
            this.endpage.TabIndex = 0;
            // 
            // wizardPage2
            // 
            this.wizardPage2.Controls.Add(this.propertyGrid1);
            this.wizardPage2.Controls.Add(this.header2);
            this.wizardPage2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardPage2.IsFinishPage = false;
            this.wizardPage2.Location = new System.Drawing.Point(0, 0);
            this.wizardPage2.Name = "wizardPage2";
            this.wizardPage2.Size = new System.Drawing.Size(476, 318);
            this.wizardPage2.TabIndex = 2;
            this.wizardPage2.ShowFromNext += new System.EventHandler(this.wizardPage2_ShowFromNext);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 64);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(476, 254);
            this.propertyGrid1.TabIndex = 1;
            // 
            // header2
            // 
            this.header2.BackColor = System.Drawing.SystemColors.Control;
            this.header2.CausesValidation = false;
            this.header2.Description = "Vlastnosti serveru";
            this.header2.Dock = System.Windows.Forms.DockStyle.Top;
            this.header2.Image = ((System.Drawing.Image)(resources.GetObject("header2.Image")));
            this.header2.Location = new System.Drawing.Point(0, 0);
            this.header2.Name = "header2";
            this.header2.Size = new System.Drawing.Size(476, 64);
            this.header2.TabIndex = 0;
            this.header2.Title = "P�id�n� serveru";
            // 
            // wizardPage1
            // 
            this.wizardPage1.Controls.Add(this.label2);
            this.wizardPage1.Controls.Add(this.description);
            this.wizardPage1.Controls.Add(this.label1);
            this.wizardPage1.Controls.Add(this.servertype);
            this.wizardPage1.Controls.Add(this.header1);
            this.wizardPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardPage1.IsFinishPage = false;
            this.wizardPage1.Location = new System.Drawing.Point(0, 0);
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.Size = new System.Drawing.Size(476, 318);
            this.wizardPage1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(190, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Popis";
            // 
            // description
            // 
            this.description.Location = new System.Drawing.Point(228, 117);
            this.description.Multiline = true;
            this.description.Name = "description";
            this.description.ReadOnly = true;
            this.description.Size = new System.Drawing.Size(211, 147);
            this.description.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Typ serveru";
            // 
            // servertype
            // 
            this.servertype.FormattingEnabled = true;
            this.servertype.Location = new System.Drawing.Point(51, 117);
            this.servertype.Name = "servertype";
            this.servertype.Size = new System.Drawing.Size(123, 147);
            this.servertype.TabIndex = 1;
            this.servertype.SelectedIndexChanged += new System.EventHandler(this.servertype_SelectedIndexChanged);
            // 
            // header1
            // 
            this.header1.BackColor = System.Drawing.SystemColors.Control;
            this.header1.CausesValidation = false;
            this.header1.Description = "Typ serveru";
            this.header1.Dock = System.Windows.Forms.DockStyle.Top;
            this.header1.Image = ((System.Drawing.Image)(resources.GetObject("header1.Image")));
            this.header1.Location = new System.Drawing.Point(0, 0);
            this.header1.Name = "header1";
            this.header1.Size = new System.Drawing.Size(476, 64);
            this.header1.TabIndex = 0;
            this.header1.Title = "P�id�n� serveru";
            // 
            // AddServerWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 366);
            this.Controls.Add(this.wizard1);
            this.Name = "AddServerWizard";
            this.Text = "Pr�vodce p�id�n�m serveru";
            this.wizard1.ResumeLayout(false);
            this.wizardPage3.ResumeLayout(false);
            this.wizardPage2.ResumeLayout(false);
            this.wizardPage1.ResumeLayout(false);
            this.wizardPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Gui.Wizard.Wizard wizard1;
        private Gui.Wizard.WizardPage wizardPage1;
        private Gui.Wizard.Header header1;
        private Gui.Wizard.WizardPage wizardPage2;
        private Gui.Wizard.WizardPage wizardPage3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox description;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox servertype;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private Gui.Wizard.Header header2;
        private Gui.Wizard.InfoPage endpage;

    }
}