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
    public partial class ImportForm : Form
    {
        List<ISongParser> m_types = new List<ISongParser>();
        SongDatabase m_db;
        object m_dynamicProperties;
        InetSongDb m_xmldb;

        public ImportForm(SongDatabase db)
        {
            InitializeComponent();
            m_db = db;
            cbxServer.Database = db;
            foreach (ISongParser type in SongFilters.EnumFilters<ISongParser>())
            {
                m_types.Add(type);
                imptype.Items.Add(type.Title);
            }
            imptype.SelectedIndex = 0;
        }

        private void imptype_SelectedIndexChanged(object sender, EventArgs e)
        {
            description.Text = m_types[imptype.SelectedIndex].Description;
            m_dynamicProperties = m_types[imptype.SelectedIndex].CreateDynamicProperties();
            propertyFrame1.SelectedObject = m_dynamicProperties;
        }

        private void Work()
        {
            using (MessageLogForm dlg = MessageLogForm.Show("Importuji p�sn�", false))
            {
                m_db.ImportNewSongs(m_xmldb, cbxServer.ServerID, dlg);
                dlg.FinishAndWait();
            }
        }

        public static bool Run(SongDatabase db)
        {
            ImportForm frm = new ImportForm(db);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                frm.Work();
                return true;
            }
            return false;
        }

        private void wizardPage2_ShowFromNext(object sender, EventArgs e)
        {
            try
            {
                ISongParser type = m_types[imptype.SelectedIndex];
                m_xmldb = new InetSongDb();
                using (IWaitDialog wait = WaitForm.Show("Import p�sn�", true))
                {
                    type.Parse(m_dynamicProperties, m_xmldb, wait);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("P�i importu nastala chyba:\n" + err.Message, "Zp�vn�k�tor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataGridView1.DataSource = m_xmldb.GetAsTable();
        }
    }
}