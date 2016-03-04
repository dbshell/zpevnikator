using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DatAdmin;
using ICSharpCode.TextEditor.Document;
using System.Xml;

namespace zp8
{
    public partial class SongForm : Form
    {
        SongDatabase m_db;
        SongData m_song;
        SongDatabaseWrapper m_dbwrap;
        Tuple<SongDatabase, int> m_key;

        public static Dictionary<Tuple<SongDatabase, int>, SongForm> m_openedWindows = new Dictionary<Tuple<SongDatabase, int>, SongForm>();

        public SongForm(SongDatabaseWrapper dbwrap, SongDatabase db, SongData song, SongFormMode mode)
        {
            InitializeComponent();

            m_db = db;
            m_song = song;

            m_dbwrap = dbwrap;

            songFrame1.LoadSong(db, song);
            songFrame1.ChangeMode(mode);

            UpdateTitle();
        }

        private void UpdateTitle()
        {
            Text = String.Format("{0} - {1}", m_song.Title, m_song.GroupName);
        }

        public static void Run(SongDatabaseWrapper dbwrap, SongDatabase db, SongData song, SongFormMode mode)
        {
            var key = new Tuple<SongDatabase, int>(db, song.LocalID);
            if (m_openedWindows.ContainsKey(key))
            {
                m_openedWindows[key].BringToFront();
                m_openedWindows[key].songFrame1.ChangeMode(mode);
                return;
            }
            var win = new SongForm(dbwrap, db, song, mode);
            win.m_key = key;
            m_openedWindows[key] = win;
            win.Show();
        }

        private void songFrame1_TabChanged(object sender, EventArgs e)
        {
            mnuTransp.Visible = mnuEdit.Visible = songFrame1.GetTabControl().SelectedIndex == 1;
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            songFrame1.Save();
        }

        private void zavřítToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SongForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!songFrame1.AllowClose()) e.Cancel = true;
        }

        private void mnuTranspDown_Click(object sender, EventArgs e)
        {
            songFrame1.TranspText(-1);
        }

        private void mnuTrasnpUp_Click(object sender, EventArgs e)
        {
            songFrame1.TranspText(1);
        }

        private void mnuTranspDown5_Click(object sender, EventArgs e)
        {
            songFrame1.TranspText(-7);
        }

        private void mnuTrasnpUp5_Click(object sender, EventArgs e)
        {
            songFrame1.TranspText(7);
        }

        private void vložitTextSAkordyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            songFrame1.InsertChordsText();
        }

        private void songFrame1_SongSaved(object sender, EventArgs e)
        {
            if (m_dbwrap != null) m_dbwrap.DispatchReloadSongs();
        }

        private void SongForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }

        private void SongForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }

        private void SongForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_openedWindows.Remove(m_key);
        }

        private void songFrame1_TitleChanged(object sender, EventArgs e)
        {
            UpdateTitle();
        }
    }

    public enum SongFormMode { View, Edit, Properties }
}
