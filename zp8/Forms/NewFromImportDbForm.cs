using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace zp8
{
    public partial class NewFromImportDbForm : Form
    {
        public NewFromImportDbForm()
        {
            InitializeComponent();
        }

        public static string Run(ISongFilter format, string infile)
        {
            var win = new NewFromImportDbForm();
            win.tbxDbName.Text = Path.GetFileNameWithoutExtension(infile);
            win.labFormat.Text = format.Title;
            if (win.ShowDialog() == DialogResult.OK) return win.tbxDbName.Text;
            return null;
        }
    }
}
