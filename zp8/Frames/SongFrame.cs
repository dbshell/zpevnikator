using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.TextEditor.Document;
using System.Xml;
using DatAdmin;

namespace zp8.Frames
{
    public partial class SongFrame : UserControl
    {
        SongDatabase m_db;
        SongData m_song;
        SongFormMode m_mode = SongFormMode.View;
        SongDatabaseWrapper m_dbwrap;

        public SongFrame()
        {
            InitializeComponent();
        }

        public event EventHandler TabChanged;
        public event EventHandler TitleChanged;
        public event EventHandler SongSaved;

        public void LoadSong(SongDatabase db, SongData song)
        {
            m_db = db;
            m_song = song;

            if (m_song == null)
            {
                tbxTitle.Text = "";
                tbxAuthor.Text = "";
                tbxGroup.Text = "";
                textEditorControl1.Text = "";
                tbxRemark.Text = "";
                songView1.SongText = "";
                Unmodify();
                return;
            }

            LoadCurrentSong();

            SetResourceHighlight("song", StdResources.syntax, false);
        }

        public void LoadCurrentSong()
        {
            tbxTitle.Text = m_song.Title;
            tbxAuthor.Text = m_song.Author;
            tbxGroup.Text = m_song.GroupName;
            textEditorControl1.Text = m_song.SongText ?? "";
            tbxRemark.Text = m_song.Remark;
            songView1.SongText = m_song.OrigText;
            lbxLinks.Items.Clear();
            foreach (var data in m_song.GetData(SongDataType.Link))
            {
                lbxLinks.Items.Add(data.TextData);
            }
            cbxServer.Database = m_db;
            object o = m_db.ExecuteScalar("select server_id from song where id=@id", "id", m_song.LocalID);
            if (o == DBNull.Value || o == null) cbxServer.ServerID = null;
            else cbxServer.ServerID = Int32.Parse(o.ToString());

            
            if (m_song.LocalID == 0) Modify(); // new song
            else Unmodify();
        }

        public bool Modified = false;

        public void SetResourceHighlight(string name, string data, bool forceLoad)
        {
            if (!HighlightingManager.Manager.HighlightingDefinitions.ContainsKey(name) || forceLoad)
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(data);

                using (XmlNodeReader reader = new XmlNodeReader(doc.DocumentElement))
                {
                    var strategy = HighlightingDefinitionParser.Parse(
                        new SyntaxMode(name + ".xml", name, new string[] { }), reader);
                    HighlightingManager.Manager.HighlightingDefinitions[name] = strategy;
                    strategy.ResolveReferences();
                    textEditorControl1.Document.HighlightingStrategy = strategy;
                }
            }
            else
            {
                textEditorControl1.Document.HighlightingStrategy = (IHighlightingStrategy)HighlightingManager.Manager.HighlightingDefinitions[name];
            }
        }

        private void btnAddLink_Click(object sender, EventArgs e)
        {
            if (openLinkDialog.ShowDialog() == DialogResult.OK)
            {
                lbxLinks.Items.Add(openLinkDialog.FileName);
                Modify();
            }
        }

        private void btnRemoveLink_Click(object sender, EventArgs e)
        {
            if (lbxLinks.SelectedIndex >= 0)
            {
                lbxLinks.Items.RemoveAt(lbxLinks.SelectedIndex);
                Modify();
            }
        }

        private void btnOpenLink_Click(object sender, EventArgs e)
        {
            if (lbxLinks.SelectedIndex >= 0)
            {
                openLinkDialog.FileName = lbxLinks.Items[lbxLinks.SelectedIndex].ToString();
                if (openLinkDialog.ShowDialog() == DialogResult.OK)
                {
                    lbxLinks.Items[lbxLinks.SelectedIndex] = openLinkDialog.FileName;
                }
                Modify();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabChanged != null) TabChanged(sender, e);
        }

        public void ChangeMode(SongFormMode mode)
        {
            m_mode = mode;
            tabControl1.SelectedIndex = (int)m_mode;
            tabControl1_SelectedIndexChanged(this, EventArgs.Empty);
        }

        public TabControl GetTabControl()
        {
            return tabControl1;
        }

        public void TranspText(int d)
        {
            textEditorControl1.Text = Chords.Transpose(textEditorControl1.Text, (d + 12) % 12);
            songView1.SongText = textEditorControl1.Text;
        }

        private void btnTransDown_Click(object sender, EventArgs e)
        {
            TranspText(-1);
        }

        private void btnTranspUp_Click(object sender, EventArgs e)
        {
            TranspText(1);
        }

        private void btnTraspDown5_Click(object sender, EventArgs e)
        {
            TranspText(-7);
        }

        private void btnTraspUp5_Click(object sender, EventArgs e)
        {
            TranspText(7);
        }

        public SongData Song { get { return m_song; } }

        public int SongID
        {
            get
            {
                if (m_song != null) return m_song.LocalID;
                return 0;
            }
        }

        public SongDatabaseWrapper SongDb
        {
            get { return m_dbwrap; }
            set
            {
                if (m_dbwrap != null) m_dbwrap.ChangedSongDatabase -= m_dbwrap_ChangedSongDatabase;
                if (m_dbwrap != null) m_dbwrap.SongChanged -= m_dbwrap_SongChanged;

                m_dbwrap = value;

                if (m_dbwrap != null) m_dbwrap.ChangedSongDatabase += m_dbwrap_ChangedSongDatabase;
                if (m_dbwrap != null) m_dbwrap.SongChanged += m_dbwrap_SongChanged;

                m_db = null;
                if (m_dbwrap != null) m_db = m_dbwrap.Database;
                if (m_db != null) LoadSong(m_db, m_dbwrap.CurrentSong);
                else LoadSong(null, null);
            }
        }

        void m_dbwrap_ChangedSongDatabase(object sender, EventArgs e)
        {
            m_db = m_dbwrap.Database;
        }

        private void m_dbwrap_SongChanged(object sender, EventArgs e)
        {
            if (!AllowClose()) return;
            LoadSong(m_db, m_dbwrap.CurrentSong);
        }

        public bool AllowClose()
        {
            if (!Modified) return true;
            var dr = MessageBox.Show("Píseň změněna, uložit?", VersionInfo.ProgramTitle, MessageBoxButtons.YesNoCancel);
            switch (dr)
            {
                case DialogResult.Yes:
                    Save();
                    return true;
                case DialogResult.No:
                    return true;
                default:
                    return false;
            }
        }

        public void Save()
        {
            m_song.Title = tbxTitle.Text;
            m_song.Author = tbxAuthor.Text;
            m_song.GroupName = tbxGroup.Text;
            m_song.OrigText = textEditorControl1.Text;
            m_song.Remark = tbxRemark.Text;
            m_song.DeleteData(SongDataType.Link);
            foreach (object link in lbxLinks.Items) m_song.AddLink(link.ToString());
            m_db.SaveSong(m_song, cbxServer.ServerID);
            if (TitleChanged != null) TitleChanged(this, EventArgs.Empty);
            Unmodify();
            if (m_dbwrap != null) m_dbwrap.DispatchReloadSongs();
            if (SongSaved != null) SongSaved(this, EventArgs.Empty);
        }

        private void Unmodify()
        {
            Modified = false;
            ModifiedChanged();
        }

        public void CancelChanges()
        {
            LoadCurrentSong();
        }

        private void textEditorControl1_TextChanged(object sender, EventArgs e)
        {
            Modify();
        }

        private void Modify()
        {
            Modified = true;
            ModifiedChanged();
        }

        private void ModifiedChanged()
        {
            btnSave.Enabled = btnCancelChanges.Enabled = Modified;
        }

        private void btnCancelChanges_Click(object sender, EventArgs e)
        {
            CancelChanges();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnInsertChordsText_Click(object sender, EventArgs e)
        {
            InsertChordsText();
        }

        public void InsertChordsText()
        {
            var props = new SongTextAnalyseProperties();
            string text = SongTextAnalyser.NormalizeSongText(Clipboard.GetText(), props).Replace("\n", "\r\n");
            textEditorControl1.Document.Insert(textEditorControl1.ActiveTextAreaControl.Caret.Offset, text);
        }
    }
}
