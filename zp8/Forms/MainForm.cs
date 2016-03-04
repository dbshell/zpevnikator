using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SQLite;
using DatAdmin;
using System.Xml;

namespace zp8
{
    public partial class MainForm : Form
    {
        Dictionary<int, SongDatabase> m_loaded_dbs = new Dictionary<int, SongDatabase>();
        Dictionary<string, int> m_loaded_dbs_name_to_index = new Dictionary<string, int>();
        //bool m_updating_state = false;
        int? m_activeDbPage, m_activeSbPage;
        SongBook m_currentBook;

        static MainForm m_form;
        static Graphics m_mainGraphics;

        public MainForm()
        {
            m_form = this;
            m_mainGraphics = Graphics.FromHwnd(Handle);

            InitializeComponent();
            Text = VersionInfo.ProgramTitle + " " + VersionInfo.VERSION;
            try { WindowState = global::zp8.Properties.Settings.Default.MainWindowState; }
            catch { }

            TabControl1.TabPages.Remove(tbsongbook);
        }

        public static IntPtr HDC
        {
            get { return m_mainGraphics.GetHdc(); }
        }
        public static Graphics MainGraphics
        {
            get { return m_mainGraphics; }
        }
        public static MainForm Form { get { return m_form; } }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDbList();

            string db = GlobalCfg.Default.currentdb;
            if (m_loaded_dbs_name_to_index.ContainsKey(db))
            {
                cbdatabase.SelectedIndex = m_loaded_dbs_name_to_index[db];
            }

            LoadSbList();
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 0) e.Cancel = true;
        }

        private static string GetDbTitle(SongDatabase db)
        {
            return db.Name;
            //return (db.Modified ? "*" : "") + db.Name;
        }

        private void LoadDbList()
        {
            SongDatabase lastdb = SelectedDatabase;
            DbManager.Manager.Refresh();
            cbdatabase.Items.Clear();
            m_loaded_dbs.Clear();
            m_loaded_dbs_name_to_index.Clear();
            foreach (SongDatabase db in DbManager.Manager.GetDatabases())
            {
                m_loaded_dbs[cbdatabase.Items.Count] = db;
                m_loaded_dbs_name_to_index[db.Name] = cbdatabase.Items.Count;
                cbdatabase.Items.Add(GetDbTitle(db));
            }
            if (lastdb != null) cbdatabase.SelectedIndex = m_loaded_dbs_name_to_index[lastdb.Name];
        }

        public SongDatabase SelectedDatabase
        {
            get
            {
                try { return m_loaded_dbs[cbdatabase.SelectedIndex]; }
                catch (Exception) { return null; }
            }
            set
            {
                if (m_loaded_dbs_name_to_index.ContainsKey(value.Name) && SelectedDatabase != value)
                {
                    cbdatabase.SelectedIndex = m_loaded_dbs_name_to_index[value.Name];
                    songDatabaseWrapper1.Database = value;
                }
            }
        }

        int m_changingSb = 0;
        public SongBook SelectedSongBook
        {
            get
            {
                if (m_currentBook == null)
                {
                    SongBookHolder holder = cbsongbook.SelectedItem as SongBookHolder;
                    if (holder != null) m_currentBook = new SongBook(SelectedDatabase, holder.ID);
                }
                return m_currentBook;
            }
            set
            {
                m_changingSb++;
                LoadSbList();
                SelectSongBookById(value.ID);
                if (cbsongbook.SelectedIndex >= 0) m_currentBook = value;
                else m_currentBook = null;
                m_changingSb--;
            }
        }

        private void SelectSongBookById(int id)
        {
            int index = 0;
            foreach (object ohld in cbsongbook.Items)
            {
                var hld = ohld as SongBookHolder;
                if (hld == null)
                {
                    index++;
                    continue;
                }
                if (hld.ID == id) cbsongbook.SelectedIndex = index;
                index++;
            }
        }

        private void dblist_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (m_updating_state) return;
            //songTable1.Bind(SelectedDb);
            //serversFrame1.Bind(SelectedDb);
            //rbdatabase.Checked = true;
            //LoadCurrentDbOrSb();
            if (SelectedDatabase != null) GlobalCfg.Default.currentdb = SelectedDatabase.Name;
            songDatabaseWrapper1.Database = SelectedDatabase;
            LoadSbList();
            cbsongbook_SelectedIndexChanged(sender, e);
            UpdateDbState();
        }

        //private void LoadCurrentDbOrSb()
        //{
        //    if (rbsongbook.Checked)
        //    {
        //        if (!TabControl1.TabPages.Contains(tbsongbook))
        //        {
        //            m_activeDbPage = TabControl1.SelectedIndex;
        //            TabControl1.TabPages.Add(tbsongbook);
        //            if (m_activeSbPage.HasValue) TabControl1.SelectedIndex = m_activeSbPage.Value;
        //        }
        //        cbdatabase.BackColor = SystemColors.Window;
        //        cbsongbook.BackColor = Color.Yellow;
        //    }
        //    else
        //    {
        //        if (TabControl1.TabPages.Contains(tbsongbook))
        //        {
        //            m_activeSbPage = TabControl1.SelectedIndex;
        //            TabControl1.TabPages.Remove(tbsongbook);
        //            if (m_activeDbPage.HasValue) TabControl1.SelectedIndex = m_activeDbPage.Value;
        //        }
        //        cbsongbook.BackColor = SystemColors.Window;
        //        cbdatabase.BackColor = Color.Yellow;
        //    }
        //    songDatabaseWrapper1.Database = SelectedDbOrSb;
        //    UpdateDbState();
        //    songView1.LoadSong();
        //}

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //foreach (SongBook book in SongBook.Manager.SongBooks)
            //{
            //    if (book.Modified)
            //    {
            //        DialogResult res = MessageBox.Show("Zp�vn�k " + book.Title + " zm�n�n, ulo�it?", "Zp�vn�k�tor", MessageBoxButtons.YesNoCancel);
            //        if (res == DialogResult.No) continue;
            //        if (res == DialogResult.Cancel)
            //        {
            //            e.Cancel = true;
            //            return;
            //        }
            //        if (book.FileName != null && book.FileName != "")
            //        {
            //            book.Save();
            //        }
            //        else
            //        {
            //            if (saveZP.ShowDialog() == DialogResult.OK)
            //            {
            //                book.FileName = saveZP.FileName;
            //            }
            //            else
            //            {
            //                e.Cancel = true;
            //                return;
            //            }
            //            book.Save();
            //        }
            //    }
            //}

            //string dbs = "";
            //foreach (SongDatabase db in DbManager.Manager.GetDatabases())
            //{
            //    if (db.Modified)
            //    {
            //        if (dbs != "") dbs += ",";
            //        dbs += db.Name;
            //    }
            //}
            //if (dbs != "")
            //{
            //    DialogResult res= MessageBox.Show("Datab�ze " + dbs + " zm�n�ny, ulo�it?", "Zp�vn�k�tor", MessageBoxButtons.YesNoCancel);
            //    if (res == DialogResult.Cancel)
            //    {
            //        e.Cancel = true;
            //        return;
            //    }
            //    if (res == DialogResult.No) return;
            //    if (res == DialogResult.Yes)
            //    {
            //        foreach (SongDatabase db in DbManager.Manager.GetDatabases())
            //            if (db.Modified)
            //                db.Commit();
            //    }
            //}
        }

        private void UpdateDbState()
        {
            //    try
            //    {
            //        if (SelectedDatabase != null)
            //        {
            //            m_updating_state = true;
            //            cbdatabase.Items[cbdatabase.SelectedIndex] = GetDbTitle(SelectedDatabase);
            //            dbstatus.Text = SelectedDatabase.Modified ? "Zm�n�no" : "";
            //            dbsize.Text = String.Format("{0} p�sn�", SelectedDatabase.DataSet.song.Rows.Count);
            //            dbname.Text = SelectedDatabase.Name;
            //        }
            //        else
            //        {
            //            dbstatus.Text = dbsize.Text = dbname.Text = "";
            //        }
            //    }
            //    finally
            //    {
            //        m_updating_state = false;
            //    }
        }

        private void newSongList_Click(object sender, EventArgs e)
        {
            var dialog  = new NewSongListForm();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SelectedDatabase.ExecuteNonQuery("insert into songlist (name) values (@name)", "name", dialog.SongBookName);
                int id = SelectedDatabase.LastInsertId();
                SongBook sb = new SongBook(SelectedDatabase, id);
                if (dialog.SongBookStyle != null)
                {
                    sb.SetBookStyle(dialog.SongBookStyle);
                    sb.ClearCaches();
                    sb.Modified();
                }
                SelectedSongBook = sb;
                cbsongbook_SelectedIndexChanged(sender, e);
            }
        }

        private void LoadSbList()
        {
            SongBookHolder lastsb = cbsongbook.SelectedItem as SongBookHolder;
            cbsongbook.Items.Clear();
            cbsongbook.Items.Add("(Vyberte zp�vn�k)");
            cbsongbook.SelectedIndex = 0;
            if (SelectedDatabase == null) return;
            using (var reader = SelectedDatabase.ExecuteReader("select id, name from songlist"))
            {
                while (reader.Read())
                {
                    cbsongbook.Items.Add(new SongBookHolder { ID = reader.SafeInt(0), Name = reader.SafeString(1) });
                }
            }
            if (lastsb != null) SelectSongBookById(lastsb.ID);
        }

        private void cbsongbook_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_changingSb > 0) return;
            m_currentBook = null;
            if (cbsongbook.SelectedIndex > 0)
            {
                if (!TabControl1.TabPages.Contains(tbsongbook)) TabControl1.TabPages.Add(tbsongbook);
            }
            else
            {
                if (TabControl1.TabPages.Contains(tbsongbook)) TabControl1.TabPages.Remove(tbsongbook);
            }
            if (SelectedSongBook != null) songBookFrame1.SongBook = SelectedSongBook;
        }

        //private void rbsongbook_CheckedChanged(object sender, EventArgs e)
        //{
        //    LoadCurrentDbOrSb();
        //}

        /*
        private void p�idatDoZp�vn�kuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SongBook sb = SelectedSongBook;
            SongDatabase db = SelectedDatabase;
            if (sb != null && db != null)
            {
                foreach (SongDb.songRow row in songTable1.GetSelectedSongs())
                {
                    SongDb.songRow newrow = sb.DataSet.song.NewsongRow();
                    foreach (DataColumn col in sb.DataSet.song.Columns)
                    {
                        if (col.ColumnName != "ID") newrow[col.ColumnName] = row[col.ColumnName];
                    }

                    sb.DataSet.song.AddsongRow(newrow);
                }
            }
        }
        */

        private void obecn�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionsForm.Run(GlobalOpts.Default);
            GlobalOpts.Default.Save();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            global::zp8.Properties.Settings.Default.MainWindowState = WindowState;
            GlobalCfg.Default.Save();
            zp8.Properties.Settings.Default.Save();
        }

        private void konecToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void importP�sn�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportForm.Run(songDatabaseWrapper1.Database);
            songDatabaseWrapper1.DispatchReloadSongs();
            UpdateDbState();
            //try
            //{
            //    //songDatabaseWrapper1.Database = null;
            //}
            //finally
            //{
            //    songDatabaseWrapper1.Database = SelectedDbOrSb;
            //}
        }

        private void vlastnostiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedSongBook != null) songBookFrame1.PropertiesDialog();
        }

        //private void open_Click(object sender, EventArgs e)
        //{
        //    if (openFileDialog1.ShowDialog() == DialogResult.OK)
        //    {
        //        string ext = Path.GetExtension(openFileDialog1.FileName).ToLower();
        //        if (ext == ".zp")
        //        {
        //            SongBook newsb = SongBook.Manager.LoadExisting(openFileDialog1.FileName);
        //            LoadSbList();
        //            SelectedSongBook = newsb;
        //        }
        //    }
        //}

        private void pdfExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            songBookFrame1.ExportAsPDF();
        }

        private void stylyZp�vn�kuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookStylesForm.Run();
        }

        private void zm�nitStylToolStripMenuItem_Click(object sender, EventArgs e)
        {
            songBookFrame1.ChangeBookStyle();
        }

        private void printSong_Click(object sender, EventArgs e)
        {
            SongData song = songFrame1.Song;
            if (song != null && printDialog1.ShowDialog() == DialogResult.OK)
            {
                SongPrinter sp = new SongPrinter(song, printDialog1.PrinterSettings);
                sp.Run();
            }
        }

        private void exportP�sn�DoPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SongData song = songFrame1.Song;
            if (song != null && savePDF.ShowDialog() == DialogResult.OK)
            {
                SongPDFPrinter.Print(song, savePDF.FileName);
            }
        }

        private void vytisknoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            songBookFrame1.PrintSongBook();
        }

        private void songBookFrame1_ChangedPageInfo(object sender, EventArgs e)
        {
            tspages.Text = songBookFrame1.PageInfo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbfilter.Text = "";
            ApplyFilter();
        }

        private void upravitP�se�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (songFrame1.SongID > 0)
            {
                ShowCurrentSong(SongFormMode.Edit);
                //EditSongForm.Run(SelectedDatabase, SelectedDatabase.LoadSong(songView1.SongID));
                //songDatabaseWrapper1.DispatchReloadSongs();
            }
        }

        private void newSong_Click(object sender, EventArgs e)
        {
            if (SelectedDatabase != null)
            {
                //SelectedDatabase.ExecuteNonQuery("insert into song (title) values ('Nova pisen')");
                //EditSongForm.Run(SelectedDatabase, new SongData { Title = "Nova pisen" });
                //songDatabaseWrapper1.DispatchReloadSongs();
                SongForm.Run(songDatabaseWrapper1, SelectedDatabase, new SongData { Title = "Nova pisen" }, SongFormMode.Edit);
            }
        }

        private void p�idatVybranouP�se�DoZp�vn�kuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSelectedSongToDb();
        }

        private void AddSelectedSongToDb()
        {
            if (SelectedSongBook == null) return;
            if (songDatabaseWrapper1.SongID == 0) return;
            SelectedDatabase.ExecuteNonQuery("insert into songlistitem (song_id, songlist_id, transp) values (@song, @list, @transp)",
                "song", songDatabaseWrapper1.SongID, "list", SelectedSongBook.ID, "transp", 0);
            SelectedSongBook.DispatchBookChanged();
        }

        private void p�idatVybranouP�se�DoDatab�zeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSelectedSongToDb();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            songDatabaseWrapper1.SearchText = tbfilter.Text;
            //SongDb.songRow cursong = songDatabaseWrapper1.SelectedSong;
            //if (tbfilter.Text != "")
            //{
            //    songDatabaseWrapper1.SongBindingSource.Filter = String.Format("searchtext LIKE '%{0}%'", Searching.MakeSearchText(tbfilter.Text));
            //}
            //else
            //{
            //    songDatabaseWrapper1.SongBindingSource.Filter = null;
            //}
            //songsByGroupFrame1.Reload();
            //songView1.LoadSong();
            //if (cursong != null) songDatabaseWrapper1.SelectedSong = cursong;
        }

        private void tbfilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ApplyFilter();
            }
            if (e.KeyCode == Keys.Escape)
            {
                tbfilter.Text = "";
                ApplyFilter();
            }
        }

        private void songDatabaseWrapper1_SongChanged(object sender, EventArgs e)
        {
            //UpdateDbState();
        }

        private void exportP�sn�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportForm.Run(songDatabaseWrapper1, songTable1.GetSelectedSongs());
        }

        private void filtryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FiltersForm.Run();
        }

        private void wWWStr�nkaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://zpevnik.net/");
        }

        private void oProgramuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = "";
            text += "Zp�vn�k�tor " + VersionInfo.VERSION + "\r\n";
            text += "(c) JenaSoft 1998-2007\r\n";
            text += "WWW: http://zpevnik.net";
            MessageBox.Show(text, "O programu...");
        }

        private void smazatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var songs = songTable1.GetSelectedSongsOrFocused();
            if (MessageBox.Show(String.Format("Opravdu vymazat {0} p�sn� ?", songs.Count), "Zp�vn�k�tor", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                songDatabaseWrapper1.Database.DeleteSongs(songs);
                songDatabaseWrapper1.DispatchReloadSongs();
            }
        }

        private void obsahToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "zp8.chm"));
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (TabControl1.SelectedTab == tbsongbook)
            {
                if (e.KeyCode == Keys.PageUp) songBookFrame1.ScrollPage(-1);
                if (e.KeyCode == Keys.PageDown) songBookFrame1.ScrollPage(1);
            }
        }

        private void kinoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowCurrentSong(SongFormMode.View);
            //if (songView1.Song != null) ViewSongForm.ShowSong(songView1.Song);
        }

        private void ShowCurrentSong(SongFormMode mode)
        {
            SongForm.Run(songDatabaseWrapper1, SelectedDatabase, SelectedDatabase.LoadSong(songFrame1.SongID), mode);
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl2.SelectedIndex)
            {
                case 0:
                    songTable1.LoadCurrentSong();
                    break;
                case 1:
                    songsByGroupFrame1.LoadCurrentSong();
                    break;
            }
            //if (tabControl2.SelectedIndex == 0)
            //{
            //    //SongDb.songRow song = songsByGroupFrame1.SongDb.SelectedSong;
            //    //songTable1.
            //}
        }

        private void mnuNewDatabase_Click(object sender, EventArgs e)
        {
            string dbname;
            if (NewDbForm.Run(out dbname))
            {
                SongDatabase newdb = DbManager.Manager.CreateDatabase(dbname);
                LoadDbList();
                SelectedDatabase = newdb;
            }
        }

        private void znovuNa��stDatab�ziToolStripMenuItem_Click(object sender, EventArgs e)
        {
            songDatabaseWrapper1.DispatchReloadSongs();
        }

        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dlg = MessageLogForm.Show("Stahuji novinky", false))
            {
                songDatabaseWrapper1.Database.LoadNews(dlg);
                dlg.FinishAndWait();
                songDatabaseWrapper1.DispatchReloadSongs();
            }
        }

        private void songTable1_SongDoubleClick(object sender, EventArgs e)
        {
            ShowCurrentSong(SongFormMode.View);
        }

        private void otev��tDatab�ziToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                var doc = new XmlDocument();
                try { doc.Load(openFileDialog2.FileName); }
                catch { doc = null; }
                int maxpri = 0;
                ISongParser maxtype = null;
                foreach (ISongParser type in SongFilters.EnumFilters<ISongParser>())
                {
                    int pri = type.AcceptFile(openFileDialog2.FileName, doc);
                    if (pri > maxpri && type.CreateDynamicProperties() is MultipleStreamImporterProperties)
                    {
                        maxpri = pri;
                        maxtype = type;
                    }
                }
                if (maxtype != null)
                {
                    string dbname = NewFromImportDbForm.Run(maxtype, openFileDialog2.FileName);
                    if (dbname != null)
                    {
                        SongDatabase newdb = DbManager.Manager.CreateDatabase(dbname);
                        LoadDbList();
                        SelectedDatabase = newdb;

                        var xmldb = new InetSongDb();
                        using (IWaitDialog wait = WaitForm.Show("Import p�sn�", true))
                        {
                            var props = (MultipleStreamImporterProperties)maxtype.CreateDynamicProperties();
                            props.FileName = openFileDialog2.FileName;
                            maxtype.Parse(props, xmldb, wait);
                            SelectedDatabase.ImportNewSongs(xmldb, 0, wait);
                        }
                        songDatabaseWrapper1.DispatchReloadSongs();
                    }
                }
                else
                {
                    StdDialog.ShowError("Nebyl rozpozn�n form�t souboru");
                }
            }
        }
    }
}
