﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data.Common;

namespace zp8
{
    public static class SongAccessor
    {
        public static string[] SONG_DATA_COLUMNS = new string[] { 
            "title", "groupname", "author", "lang", "netID", 
            "transp", "remark" };

        public static string[] SONG_DATA_TITLES = new string[] {
            "Název", "Skupina", "Autor", "Jazyk", "NetID", 
            null, "Poznámka"
        };

        public static IEnumerable<SongData> LoadSongs(this SongDatabase db, string[] extracols, string joins, string conds)
        {
            if (extracols == null) extracols = new string[] { };
            if (conds == null) conds = "1=1";
            if (joins == null) joins = "";
            var res = new Dictionary<int, SongData>();
            string query = "select song.id,";
            foreach (string ec in extracols) query += ec + ",";
            using (var reader = db.ExecuteReader(query + String.Join(",", (from s in SONG_DATA_COLUMNS select "song." + s).ToArray()) + " from song "
                + joins.Replace("#SONGID#", "song.id") + " where " + conds.Replace("#SONGID#", "song.id")))
            {
                while (reader.Read())
                {
                    SongData song = new SongData();
                    LoadSongDataColumns(song, reader, 1 + extracols.Length);
                    for (int i = 0; i < extracols.Length; i++)
                    {
                        if (extracols[i].Contains("transp"))
                        {
                            if (!reader.IsDBNull(1 + i)) song.Transp = reader.SafeInt(1 + i);
                        }
                        if (extracols[i].Contains("position"))
                        {
                            if (!reader.IsDBNull(1 + i)) song.Position = reader.SafeInt(1 + i);
                        }
                    }
                    song.LocalID = reader.SafeInt(0);
                    res[song.LocalID] = song;
                }
            }
            using (var reader = db.ExecuteReader("select songdata.song_id,songdata.datatype_id,songdata.label,songdata.textdata from songdata "
                + " inner join song on song.id = songdata.song_id "
                + joins.Replace("#SONGID#", "songdata.song_id") + " where " + conds.Replace("#SONGID#", "songdata.song_id")))
            {
                while (reader.Read())
                {
                    SongData song = res[reader.SafeInt(0)];
                    song.Items.Add(new SongDataItem
                    {
                        DataType = (SongDataType)reader.SafeInt(1),
                        Label = reader.SafeString(2),
                        TextData = reader.SafeString(3)
                    });
                }
            }
            return res.Values;

        }

        public static IEnumerable<SongData> LoadSongList(this SongDatabase db, int id)
        {
            return LoadSongs(
                db,
                new string[] { "songlistitem.transp", "songlistitem.position" },
                "inner join songlistitem on songlistitem.song_id = #SONGID# ",
                String.Format("songlistitem.songlist_id = {0}", id.ToString())
                );
                
            //var res = new Dictionary<int, SongData>();
            //using (var reader = db.ExecuteReader("select song.id,songlistitem.transp," + String.Join(",", (from s in SONG_DATA_COLUMNS select "song." + s).ToArray()) + " from song "
            //    + "inner join songlistitem on songlistitem.song_id = song.id "
            //    + "where songlistitem.songlist_id = @id", "id", id))
            //{
            //    while (reader.Read())
            //    {
            //        SongData song = new SongData();
            //        LoadSongDataColumns(song, reader, 2);
            //        if (!reader.IsDBNull(1)) song.Transp = reader.SafeInt(1);
            //        song.LocalID = reader.SafeInt(0);
            //        res[song.LocalID] = song;
            //    }
            //}
            //using (var reader = db.ExecuteReader("select songdata.song_id,datatype_id,label,textdata from songdata "
            //    + "inner join songlistitem on songdata.song_id = songlistitem.song_id "
            //    + "where songlistitem.songlist_id = @id", "id", id))
            //{
            //    while (reader.Read())
            //    {
            //        SongData song = res[reader.SafeInt(0)];
            //        song.Items.Add(new SongDataItem
            //        {
            //            DataType = (SongDataType)reader.SafeInt(1),
            //            Label = reader.SafeString(2),
            //            TextData = reader.SafeString(3)
            //        });
            //    }
            //}
            //return res.Values;
        }

        private static void LoadSongDataColumns(SongData song, DbDataReader reader, int ofs)
        {
            song.Title = reader.SafeString(ofs + 0);
            song.GroupName = reader.SafeString(ofs + 1);
            song.Author = reader.SafeString(ofs + 2);
            song.Lang = reader.SafeString(ofs + 3);
            song.NetID = reader.SafeString(ofs + 4);
            song.Transp = reader.SafeInt(ofs + 5);
            song.Remark = reader.SafeString(ofs + 6);
        }

        public static IEnumerable<SongData> LoadSongs(this SongDatabase db, List<int> rows)
        {
            string cond = "#SONGID# IN (";
            cond += String.Join(", ", (from r in rows select r.ToString()).ToArray());
            cond += ")";
            return LoadSongs(db, new string[] { "song.transp" }, "", cond);
        }

        public static SongData LoadSong(this SongDatabase db, int id)
        {
            var res = new List<SongData>(db.LoadSongs(new string[] { "song.transp" }, "", "#SONGID#=" + id.ToString()));
            if (res.Count > 0) return res[0];
            return null;
            //var res = new SongData();
            //using (var reader = db.ExecuteReader("select id," + String.Join(",", SONG_DATA_COLUMNS) + " from song "
            //    + "where ID = @id", "id", id))
            //{
            //    if (reader.Read())
            //    {
            //        LoadSongDataColumns(res, reader, 1);
            //        res.LocalID = reader.SafeInt(0);
            //    }
            //    else
            //    {
            //        return null;
            //    }
            //}
            //using (var reader = db.ExecuteReader("select song_id,datatype_id,label,textdata from songdata "
            //    + "where songdata.song_id = @id", "id", id))
            //{
            //    while (reader.Read())
            //    {
            //        res.Items.Add(new SongDataItem
            //        {
            //            DataType = (SongDataType)reader.SafeInt(1),
            //            Label = reader.SafeString(2),
            //            TextData = reader.SafeString(3)
            //        });
            //    }
            //}
            //return res;
        }

        public static string GetSongFields(bool wantid)
        {
            var res = new List<string>();
            if (wantid) res.Add("ID");
            for (int i = 0; i < SONG_DATA_COLUMNS.Length; i++)
            {
                if (SONG_DATA_TITLES[i] == null) continue;
                res.Add(String.Format("{0} AS \"{1}\"", SONG_DATA_COLUMNS[i], SONG_DATA_TITLES[i]));
            }
            return String.Join(",", res.ToArray());
        }
    }
}
