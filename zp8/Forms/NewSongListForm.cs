using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace zp8
{
    public partial class NewSongListForm : Form
    {
        public NewSongListForm()
        {
            InitializeComponent();

            foreach (string name in BookStyle.GetSbTypes())
                cbxSongListType.Items.Add(name);
        }

        public string SongBookStyle
        {
            get
            {
                if (cbxSongListType.SelectedItem != null) return cbxSongListType.SelectedItem.ToString();
                return null;
            }
        }

        public string SongBookName
        {
            get
            {
                return textBox1.Text;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                DatAdmin.StdDialog.ShowError("Prosím vyplňte název zpěvníku");
                textBox1.Focus();
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void NewSongListForm_Shown(object sender, EventArgs e)
        {
            textBox1.Focus();
        }
    }
}
