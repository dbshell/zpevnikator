using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Resources;
using System.Windows.Forms;
using System.Data;
using System.Linq;

using System.Data.SQLite;
using System.Net;

namespace zp8
{
    //public abstract partial class SongDatabase
    //{
    //    protected SongDb m_dataset;
    //    protected abstract void WantOpen();
    //    private bool m_disableTriggers;

    //    public event EventHandler SongChanged;

    //    public SongDb DataSet
    //    {
    //        get
    //        {
    //            WantOpen();
    //            return m_dataset;
    //        }
    //    }
    //    protected void UnInstallTriggers()
    //    {
    //        m_dataset.song.RowChanged -= song_RowChanged;
    //    }
    //    protected void InstallTriggers()
    //    {
    //        foreach (SongDb.songRow row in EnumSongs())
    //        {
    //            if (row.IssearchtextNull()) row.searchtext = MakeSearchText(row);
    //        }
    //        m_dataset.song.RowChanged += song_RowChanged;
    //        if (SongChanged != null) SongChanged(this, new EventArgs());
    //    }

    //    private static string MakeSearchText(SongDb.songRow row)
    //    {
    //        string stext = "";
    //        stext += Searching.MakeSearchText(row.Title);
    //        stext += Searching.MakeSearchText(row.Author);
    //        stext += Searching.MakeSearchText(row.GroupName);
    //        stext += Searching.MakeSearchText(SongTool.RemoveChords(row.SongText));
    //        return stext;
    //    }

    //    void song_RowChanged(object sender, DataRowChangeEventArgs e)
    //    {
    //        if (m_disableTriggers) return;
    //        if (SongChanged != null) SongChanged(sender, e);
    //        SongDb.songRow row = (SongDb.songRow)e.Row;
    //        if (row.RowState != DataRowState.Modified && row.RowState != DataRowState.Added) return;
    //        try
    //        {
    //            m_disableTriggers = true;
    //            row.searchtext = MakeSearchText(row);
    //        }
    //        finally
    //        {
    //            m_disableTriggers = false;
    //        }

    //    }
    //    public bool CanEditSong(SongDb.songRow song)
    //    {
    //        if (song.Isserver_idNull()) return true;
    //        int srvid = song.server_id;
    //        try
    //        {
    //            return !m_dataset.server.FindByID(srvid).isreadonly;
    //        }
    //        catch (Exception)
    //        {
    //            return true;
    //        }
    //    }
    //    public SongDb.songRow CreateSong()
    //    {
    //        SongDb.songRow song = DataSet.song.NewsongRow();
    //        song.Title = "Nov� p�se�";
    //        song.GroupName = "";
    //        song.Author = "";
    //        song.SongText = "";
    //        DataSet.song.AddsongRow(song);
    //        return song;
    //    }
    //    public IEnumerable<SongDb.songRow> EnumSongs()
    //    {
    //        foreach (SongDb.songRow row in m_dataset.song.Rows)
    //        {
    //            if (row.RowState != DataRowState.Deleted && row.RowState != DataRowState.Detached) yield return row;
    //        }
    //    }
    //}

    //public class SongDatabase : SongDatabase
    //{
    //    SQLiteConnection m_conn;
    //    SQLiteDataAdapter m_song_adapter;
    //    SQLiteDataAdapter m_server_adapter;
    //    SQLiteDataAdapter m_deletedsong_adapter;
    //    string m_filename;
    //    bool m_opened = false;

    //    public SongDatabase(string filename)
    //    {
    //        m_filename = filename;
    //    }
    //    private void ExecuteSql(string sql)
    //    {
    //        SQLiteCommand cmd = new SQLiteCommand(sql, m_conn);
    //        cmd.ExecuteNonQuery();
    //    }
    //    private static void AddParameter(SQLiteCommand cmd, object value)
    //    {
    //        SQLiteParameter p = new SQLiteParameter();
    //        p.Value = value;
    //        cmd.Parameters.Add(p);
    //    }
    //    public void SetInfo(string name, string value)
    //    {
    //        SQLiteCommand cmd_del = new SQLiteCommand("DELETE FROM info WHERE name=?", m_conn);
    //        AddParameter(cmd_del, name);
    //        cmd_del.ExecuteNonQuery();

    //        SQLiteCommand cmd_ins = new SQLiteCommand("INSERT INTO info (name, value) VALUES (?, ?)", m_conn);
    //        AddParameter(cmd_ins, name);
    //        AddParameter(cmd_ins, value);
    //        cmd_ins.ExecuteNonQuery();
    //    }
    //    public string GetInfo(string name)
    //    {
    //        SQLiteCommand cmd = new SQLiteCommand("SELECT value FROM info WHERE name=?", m_conn);
    //        AddParameter(cmd, name);
    //        object res = cmd.ExecuteScalar();
    //        if (res is DBNull) return null;
    //        if (res == null) return null;
    //        return res.ToString();
    //    }
    //    public int GetDbVersion()
    //    {
    //        try
    //        {
    //            return Int32.Parse(GetInfo("dbversion"));
    //        }
    //        catch (Exception)
    //        {
    //            return 0;
    //        }
    //    }
    //    private void Upgrade(int version)
    //    {
    //        if (version < 1)
    //        {
    //            ExecuteSql("ALTER TABLE song ADD remark VARCHAR");
    //            ExecuteSql("CREATE TABLE info (name VARCHAR PRIMARY KEY, value TEXT)");
    //            SetInfo("dbversion", "1");
    //        }
    //        if (version < 2)
    //        {
    //            ExecuteSql("ALTER TABLE song ADD link_1 VARCHAR");
    //            ExecuteSql("ALTER TABLE song ADD link_2 VARCHAR");
    //            SetInfo("dbversion", "2");
    //        }
    //    }
    //    protected override void WantOpen()
    //    {
    //        if (m_opened) return;
    //        using (IWaitDialog wait = WaitForm.Show("Na��t�m datab�zi " + Path.GetFileName(m_filename), false))
    //        {
    //            if (File.Exists(m_filename))
    //            {
    //                m_conn = new SQLiteConnection(String.Format("Data Source={0};Version=3", m_filename));
    //                m_conn.Open();
    //                int version = GetDbVersion();
    //                Upgrade(version);
    //            }
    //            else
    //            {
    //                m_conn = new SQLiteConnection(String.Format("Data Source={0};New=True;Version=3", m_filename));
    //                m_conn.Open();
    //                ExecuteSql("CREATE TABLE song (ID INTEGER PRIMARY KEY, title VARCHAR, groupname VARCHAR, author VARCHAR, songtext TEXT, lang VARCHAR, server_id INT NULL, netID INT NULL, transp INT, searchtext VARCHAR, published DATETIME, localmodified INT, remark VARCHAR, link_1 VARCHAR, link_2 VARCHAR)");
    //                ExecuteSql("CREATE TABLE server (ID INTEGER PRIMARY KEY, url VARCHAR, servertype VARCHAR, config TEXT, isreadonly INT)");
    //                ExecuteSql("CREATE TABLE deletedsong (ID INTEGER PRIMARY KEY, song_netID INT, server_id INT)");
    //                ExecuteSql("CREATE TABLE info (name VARCHAR PRIMARY KEY, value TEXT)");
    //                SetInfo("dbversion", "2");
    //            }
    //            m_song_adapter = new SQLiteDataAdapter("SELECT * FROM song", m_conn);
    //            m_server_adapter = new SQLiteDataAdapter("SELECT * FROM server", m_conn);
    //            m_deletedsong_adapter = new SQLiteDataAdapter("SELECT * FROM deletedsong", m_conn);
    //            m_dataset = new SongDb();
    //            m_song_adapter.Fill(m_dataset.song);
    //            m_server_adapter.Fill(m_dataset.server);
    //            m_deletedsong_adapter.Fill(m_dataset.deletedsong);

    //            SQLiteCommandBuilder song_cb = new SQLiteCommandBuilder(m_song_adapter);
    //            m_song_adapter.InsertCommand = (SQLiteCommand)song_cb.GetInsertCommand();

    //            SQLiteCommandBuilder server_cb = new SQLiteCommandBuilder(m_server_adapter);
    //            m_server_adapter.InsertCommand = (SQLiteCommand)server_cb.GetInsertCommand();

    //            SQLiteCommandBuilder deletedsong_cb = new SQLiteCommandBuilder(m_deletedsong_adapter);
    //            m_deletedsong_adapter.InsertCommand = (SQLiteCommand)deletedsong_cb.GetInsertCommand();

    //            m_opened = true;
    //            InstallTriggers();
    //        }
    //    }

    //    /*
    //    public void ImportZp8Xml(StringReader fr)
    //    {
    //        m_dataset.song.ReadXml(fr);
    //    }
    //    */

    //    public static string ExtractDbName(string filename) {return Path.GetFileName(filename).ToLower(); }
    //    public string Name { get { return ExtractDbName(m_filename); } }
    //    public void Commit()
    //    {
    //        using (IWaitDialog wait = WaitForm.Show("Ukl�d�m datab�zi " + Path.GetFileName(m_filename), false))
    //        {
    //            WantOpen();
    //            UnInstallTriggers();
    //            SQLiteTransaction t = m_conn.BeginTransaction();
    //            m_song_adapter.Update(m_dataset.song);
    //            m_server_adapter.Update(m_dataset.server);
    //            t.Commit();
    //            InstallTriggers();
    //        }
    //    }
    //    public bool Modified
    //    {
    //        get
    //        {
    //            if (!m_opened) return false;
    //            return m_dataset.HasChanges();
    //        }
    //    }
    //}

    public class SongDatabase
    {
        string m_filename;
        SQLiteConnection m_conn;
        SearchIndex m_searchIndex;

        public SongDatabase(string filename)
        {
            m_filename = filename;
        }

        public SQLiteConnection Connection
        {
            get
            {
                WantOpen();
                return m_conn;
            }
        }
        public static string ExtractDbName(string filename) { return Path.GetFileName(filename).ToLower(); }
        public string Name { get { return ExtractDbName(m_filename); } }

        public void WantOpen()
        {
            if (m_conn != null) return;
            using (IWaitDialog wait = WaitForm.Show("Otv�r�m datab�zi " + Path.GetFileName(m_filename), false))
            {
                if (File.Exists(m_filename))
                {
                    m_conn = new SQLiteConnection(String.Format("Data Source={0};Version=3", m_filename));
                }
                else
                {
                    m_conn = new SQLiteConnection(String.Format("Data Source={0};New=True;Version=3", m_filename));
                }
                m_conn.Open();
                Generated.DbCreator.Run(m_conn);
            }
        }

        private void BindParams(SQLiteCommand cmd, object[] args)
        {
            for (int i = 0; i < args.Length; i += 2)
            {
                SQLiteParameter par = new SQLiteParameter("@" + args[i].ToString());
                par.Value = args[i + 1];
                cmd.Parameters.Add(par);
                //cmd.Parameters.AddWithValue(args[i].ToString(), args[i + 1]);
            }
        }

        public object[] ExecuteOneRow(string sql, params object[] args)
        {
            WantOpen();
            using (SQLiteCommand cmd = m_conn.CreateCommand())
            {
                cmd.CommandText = sql;
                BindParams(cmd, args);
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        object[] res = new object[reader.FieldCount];
                        reader.GetValues(res);
                        return res;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public object ExecuteScalar(string sql, params object[] args)
        {
            WantOpen();
            using (SQLiteCommand cmd = m_conn.CreateCommand())
            {
                cmd.CommandText = sql;
                BindParams(cmd, args);
                return cmd.ExecuteScalar();
            }
        }

        public void ExecuteNonQuery(SQLiteTransaction tran, string sql, params object[] args)
        {
            WantOpen();
            using (SQLiteCommand cmd = m_conn.CreateCommand())
            {
                cmd.Transaction = tran;
                cmd.CommandText = sql;
                BindParams(cmd, args);
                cmd.ExecuteNonQuery();
            }
        }

        public void ExecuteNonQuery(string sql, params object[] args)
        {
            ExecuteNonQuery((SQLiteTransaction)null, sql, args);
        }

        public SQLiteDataReader ExecuteReader(SQLiteTransaction tran, string sql, params object[] args)
        {
            WantOpen();
            using (SQLiteCommand cmd = m_conn.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.Transaction = tran;
                BindParams(cmd, args);
                return cmd.ExecuteReader();
            }
        }

        public SQLiteDataReader ExecuteReader(string sql, params object[] args)
        {
            return ExecuteReader(null, sql, args);
        }

        public int LastInsertId()
        {
            return Int32.Parse(ExecuteScalar("select last_insert_rowid()").ToString());
        }

        public bool CanEditSong(int songid)
        {
            return !(bool)ExecuteScalar("select server.isreadonly from server "
            + "inner join song on song.server_id = server.id where song.id=@id", "id", songid);
        }

        public void ImportNewSongs(InetSongDb db, int? serverid, IWaitDialog dlg)
        {
            WantOpen();
            int imported = 0;
            using (var tran = m_conn.BeginTransaction())
            {
                foreach (var song in db.Songs)
                {
                    var scopy = song.Clone();
                    scopy.NetID = null;
                    InsertSong(tran, scopy, serverid, true);
                    imported++;
                }
                tran.Commit();
            }
            dlg.Message(String.Format("Importov�no {0} p�sn�", imported));
        }

        public void DownloadSongsFromServer(InetSongDb db, int? serverid, IWaitDialog dlg)
        {
            WantOpen();
            int imported = 0;
            ExecuteNonQuery("delete from songdata where song_id = (select song.id from song where song.server_id=@sid and song.localmodified=0)", "sid", serverid);
            ExecuteNonQuery("delete from song where song.server_id=@sid and song.localmodified=0", "sid", serverid);
            List<string> modifiedNetIds = new List<string>();
            using (var reader = ExecuteReader("select netID from song where server_id=@sid and localmodified=1", "sid", serverid))
            {
                while (reader.Read())
                {
                    modifiedNetIds.Add(reader.SafeString(0));
                }
                reader.Close();
            }
            foreach (var song in db.Songs)
            {
                if (modifiedNetIds.Contains(song.NetID))
                {
                    dlg.Message(String.Format("Ignoruji zm�n�nou p�se� {0}, netID={1}", song.Title, song.NetID));
                }
                else
                {
                    InsertSong(song, serverid, false);
                    imported++;
                }
            }
            dlg.Message(String.Format("Importov�no {0} p�sn�", imported));
        }

        public SearchIndex SearchIndex
        {
            get
            {
                if (m_searchIndex == null) m_searchIndex = new SearchIndex(this);
                return m_searchIndex;
            }
        }

        public void SaveSong(SongData song, int ?serverid)
        {
            if (song.LocalID == 0)
            {
                InsertSong(song, serverid, true);
            }
            else
            {
                UpdateSong(song, serverid);
            }
            if (m_searchIndex != null) m_searchIndex.UpdatedSong(song.LocalID);
        }

        private void InsertSongItem(int song, SongDataItem item)
        {
            InsertSongItem(null, song, item);
        }

        private void InsertSongItem(SQLiteTransaction tran, int song, SongDataItem item)
        {
            ExecuteNonQuery(tran, "insert into songdata (song_id, datatype_id, label, textdata) values (@song, @datatype, @label, @data)",
                "song", song, "datatype", item.DataType, "label", item.Label, "data", item.TextData);
        }

        private void UpdateSong(SongData song, int ?serverid)
        {
            ExecuteNonQuery("delete from songdata where song_id=@id", "id", song.LocalID);
            foreach (var item in song.Items)
            {
                InsertSongItem(song.LocalID, item);
            }
            ExecuteNonQuery(@"update song set title=@title, groupname=@groupname, author=@author, lang=@lang, 
                            server_id=@server, netID=@netid, transp=@transp, remark=@remark, published=@published, localmodified=1
                            where id=@id",
                            "title", song.Title, "groupname", song.GroupName, "author", song.Author, "lang", song.Lang,
                            "server", serverid, "netid", song.NetID, "transp", song.Transp, "remark", song.Remark, 
                            "published", song.Published, "id", song.LocalID);
        }

        private void InsertSong(SQLiteTransaction tran, SongData song, int? serverid, bool localmodified)
        {
            ExecuteNonQuery(tran, @"insert into song (title, groupname, author, lang, server_id, netID, transp, remark, published, localmodified)
                             values
                             (@title, @groupname, @author, @lang, @server, @netid, @transp, @remark, @published, @localmodified)",
                            "title", song.Title, "groupname", song.GroupName, "author", song.Author, "lang", song.Lang,
                            "server", serverid, "netid", song.NetID, "transp", song.Transp, "remark", song.Remark,
                            "published", song.Published, "localmodified", localmodified);
            song.LocalID = LastInsertId();
            foreach (var item in song.Items)
            {
                InsertSongItem(tran, song.LocalID, item);
            }
        }

        private void InsertSong(SongData song, int? serverid, bool localmodified)
        {
            InsertSong(null, song, serverid, localmodified);
        }

        //public void SetSongServer(int song, int server)
        //{
        //    ExecuteNonQuery("update song set server_id=@server where id=@song", "song", song, "server", server);
        //}

        public void DeleteSongs(List<int> songs)
        {
            using (SQLiteTransaction tran = m_conn.BeginTransaction())
            {
                string songids = String.Join(",", (from i in songs select i.ToString()).ToArray());
                ExecuteNonQuery(@"insert into deletedsong
                    select NULL, song.netID, song.server_id from song 
                    where song.server_id is not null and song.netID is not null and song.id in (" + songids + ")");
                ExecuteNonQuery(tran, "delete from songdata where song_id in (" + songids + ")");
                ExecuteNonQuery(tran, "delete from song where id in (" + songids + ")");
                tran.Commit();
            }
        }

        public void InsertServer(ISongServer server)
        {
            SongServerType st = SongServer.GetServerName(server);
            ExecuteNonQuery(@"insert into server (url, servertype, config, isreadonly)
                             values (@url, @type, @config, @readonly)",
                            "url", server.ToString(), "type", st.Name, "config", SongServer.Save(server), "readonly", st.ReadOnly);
        }

        public ISongServer LoadServer(int id)
        {
            using (var reader = ExecuteReader("select servertype, config from server where id=@id", "id", id))
            {
                if (reader.Read())
                {
                    ISongServer srv = SongServer.Load(reader.SafeString(0), reader.SafeString(1));
                    return srv;
                }
                return null;
            }
        }

        public void SaveServer(ISongServer srv, int id)
        {
            ExecuteNonQuery("update server set url=@url, config=@config where id=@id",
                "url", srv.ToString(), "config", SongServer.Save(srv), "id", id);
        }

        public void DeleteServer(int id)
        {
            ExecuteNonQuery("delete from server where id=@id", "id", id);
        }

        private void ProcessPublishSong(SQLiteTransaction tran, InetSongDb xmldb, SongData song, IWaitDialog dlg)
        {
            if (song.NetID != null)
            {
                xmldb.UpdateSongByNetID(song);
                ExecuteNonQuery("update song set published=@published, localmodified=0 where id=@id",
                    "published", DateTime.UtcNow, "id", song.LocalID);
            }
            else
            {
                xmldb.AddSongWithNewNetID(song);
                ExecuteNonQuery("update song set published=@published, localmodified=0, netID=@netid where id=@id",
                    "published", DateTime.UtcNow, "id", song.LocalID, "netid", song.NetID);
            }
            dlg.Message(String.Format("Publikuji p�se� {0}, netID={1}", song.Title, song.NetID));
        }

        public void PublishSongsChanges(int serverid, InetSongDb xmldb, IWaitDialog dlg)
        {
            var songs = new List<SongData>(this.LoadSongs(null, null, "song.server_id=" + serverid.ToString() + " and song.localmodified=1"));
            using (SQLiteTransaction tran = m_conn.BeginTransaction())
            {
                foreach (var song in songs)
                {
                    ProcessPublishSong(tran, xmldb, song, dlg);
                }
                using (var reader = ExecuteReader("select ID, song_netID from deletedsong where server_id=@sid", "sid", serverid))
                {
                    while (reader.Read())
                    {
                        int id = reader.SafeInt(0);
                        string netid = reader.SafeString(1);
                        xmldb.DeleteSongByNetID(netid);
                        dlg.Message(String.Format("Ma�u p�se� netID={0}", netid));
                    }
                }
                ExecuteNonQuery("delete from deletedsong where server_id=@sid", "sid", serverid);
                tran.Commit();
            }
        }

        public void PublishAllSongs(int serverid, InetSongDb xmldb, IWaitDialog dlg)
        {
            xmldb.Songs.Clear();
            var songs = new List<SongData>(this.LoadSongs(null, null, "song.server_id=" + serverid.ToString()));
            using (SQLiteTransaction tran = m_conn.BeginTransaction())
            {
                foreach (var song in songs)
                {
                    ProcessPublishSong(tran, xmldb, song, dlg);
                }
                ExecuteNonQuery("delete from deletedsong where server_id=@sid", "sid", serverid);
                tran.Commit();
            }
        }

        public void LoadServers(IWaitDialog dlg)
        {
            using (var reader = ExecuteReader("select id, url from serverlist"))
            {
                while (reader.Read())
                {
                    WebRequest req = WebRequest.Create(reader.SafeString(1));
                    using (var resp = req.GetResponse())
                    {
                        using (var strm = resp.GetResponseStream())
                        {
                            XmlDocument doc = new XmlDocument();
                            doc.Load(strm);
                            foreach (XmlElement elem in doc.SelectNodes("/ServerList/Server/Url"))
                            {
                                string url = elem.InnerText;
                                if ("0" == ExecuteScalar("select count(*) from server where url=@url", "url", url).ToString())
                                {
                                    var ss = new XmlSongServer { URL = url };
                                    InsertServer(ss);
                                    dlg.Message(String.Format("P�id�v�m server {0}", ss));
                                }
                            }
                        }
                    }
                }
            }
        }

        public void LoadNews(MessageLogForm dlg)
        {
            LoadServers(dlg);

            using (var reader = ExecuteReader("select id from server"))
            {
                while (reader.Read())
                {
                    int serverid = reader.SafeInt(0);
                    var srv = LoadServer(serverid);
                    srv.DownloadNew(this, serverid, dlg);
                }
            }
        }
    }
}
