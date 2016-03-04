using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace zp8
{
    public partial class MultiStreamFrame : UserControl
    {
        MultipleStreamImporterProperties m_props;

        public MultiStreamFrame(MultipleStreamImporterProperties props)
        {
            InitializeComponent();
            UpdateFilesEnabling();
        }

        private void rbtDownload_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFilesEnabling();
            Save();
        }

        private void UpdateFilesEnabling()
        {
            tbxUrl.Enabled = rbtDownload.Checked;
            lbxFiles.Enabled = btnAdd.Enabled = btnRemove.Enabled = rbtFiles.Checked;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (string fn in openFileDialog1.FileNames)
                {
                    lbxFiles.Items.Add(fn);
                }
            }
            Save();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lbxFiles.SelectedIndex >= 0) lbxFiles.Items.RemoveAt(lbxFiles.SelectedIndex);
            Save();
        }

        private void Save()
        {
            var lst = new List<string>();
            foreach (object item in lbxFiles.Items) lst.Add(item.ToString());
            m_props.FileNames = rbtFiles.Checked ? new FileCollection(lst.ToArray()) : new FileCollection();
            m_props.URL = rbtDownload.Checked ? tbxUrl.Text : null;
        }

        private void tbxUrl_TextChanged(object sender, EventArgs e)
        {
            Save();
        }
    }
}
