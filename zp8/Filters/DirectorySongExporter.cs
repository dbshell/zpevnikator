using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows.Forms.Design;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace zp8
{
    public class DirectorySongExporterProperties : DatAdmin.PropertyPageBase
    {
        string m_folderName;

        [DisplayName("V�stupn� slo�ka")]
        [Editor(typeof(FolderNameEditor), typeof(UITypeEditor))]
        public string FolderName
        {
            get { return m_folderName; }
            set { m_folderName = value; }
        }
    }

    public class GroupOfSongs
    {
        public List<SongData> Songs = new List<SongData>();
        public int Index;
        public string Name;
    }

    public class DirectorySongHolder
    {
        public DirectorySongHolder(IEnumerable songs)
        {
            int songindex = 0;
            foreach (SongData song in songs)
            {
                if (!Groups.ContainsKey(song.GroupName))
                {
                    Groups[song.GroupName] = new GroupOfSongs();
                    Groups[song.GroupName].Index = Groups.Count;
                    Groups[song.GroupName].Name = song.GroupName;
                }
                Groups[song.GroupName].Songs.Add(song);
                Songs.Add(song);
                SongIndexes[song] = ++songindex;
                SongGroups[song] = Groups[song.GroupName];
            }
            foreach (GroupOfSongs grp in Groups.Values) grp.Songs.Sort(Sorting.GetComparison(SongOrder.GroupTitle));
            Songs.Sort(Sorting.GetComparison(SongOrder.GroupTitle));
            SortedGroups.AddRange(Groups.Values);
            SortedGroups.Sort(delegate(GroupOfSongs a, GroupOfSongs b) { return String.Compare(a.Name, b.Name); });
        }

        public Dictionary<string, GroupOfSongs> Groups = new Dictionary<string,GroupOfSongs>();
        public List<SongData> Songs = new List<SongData>();
        public Dictionary<SongData, int> SongIndexes = new Dictionary<SongData, int>();
        public Dictionary<SongData, GroupOfSongs> SongGroups = new Dictionary<SongData, GroupOfSongs>();
        public List<GroupOfSongs> SortedGroups = new List<GroupOfSongs>();
    }

    [ConfigurableSongFilter(Name = "V�stup do slo�ky")]
    public class DirectorySongExporter : DatAdmin.PropertyPageBase, ISongFormatter, ICustomSongFilter
    {
        string m_name;
        [Browsable(false)]
        [XmlIgnore]
        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        Encoding m_encoding = System.Text.Encoding.UTF8;
        [DisplayName("K�dov�n�")]
        public string Encoding
        {
            get { return m_encoding.WebName; }
            set { m_encoding = System.Text.Encoding.GetEncoding(value); }
        }

        bool m_writeIndex;
        [Category("Index")]
        [DisplayName("Zapisovat index")]
        public bool WriteIndex
        {
            get { return m_writeIndex; }
            set { m_writeIndex = value; }
        }

        string m_indexFileName = "";
        [Category("Index")]
        [DisplayName("Jm�no souboru")]
        public string IndexFileName
        {
            get { return m_indexFileName; }
            set { m_indexFileName = value; }
        }

        string m_indexHeader = "";
        [Category("Index")]
        [DisplayName("Hlavi�ka souboru")]
        [Editor(typeof(TemplateTextEditor), typeof(UITypeEditor))]
        public string IndexHeader
        {
            get { return m_indexHeader; }
            set { m_indexHeader = value; }
        }

        string m_indexGroupRepeat = "";
        [Category("Index")]
        [DisplayName("�ablona pro skupinu")]
        [Description("Opakuje se pro ka�dou skupinu, m��e obsahovat makro $[GROUPINDEX] pro ��slo skupiny")]
        [Editor(typeof(TemplateTextEditor), typeof(UITypeEditor))]
        public string IndexGroupRepeat
        {
            get { return m_indexGroupRepeat; }
            set { m_indexGroupRepeat = value; }
        }

        string m_indexBetweenGroupsAndSongs = "";
        [Category("Index")]
        [DisplayName("Skupiny-p�sn�")]
        [Description("Text mezi seznamem skupin a seznamem p�sn�")]
        [Editor(typeof(TemplateTextEditor), typeof(UITypeEditor))]
        public string IndexBetweenGroupsAndSongs
        {
            get { return m_indexBetweenGroupsAndSongs; }
            set { m_indexBetweenGroupsAndSongs = value; }
        }

        string m_indexSongRepeat = "";
        [Category("Index")]
        [DisplayName("�ablona pro p�se�")]
        [Description("Opakuje se pro ka�dou p�se�, m��e obsahovat makro $[SONGINDEX] pro ��slo p�sn�")]
        [Editor(typeof(TemplateTextEditor), typeof(UITypeEditor))]
        public string IndexSongRepeat
        {
            get { return m_indexSongRepeat; }
            set { m_indexSongRepeat = value; }
        }

        string m_indexFooter = "";
        [Category("Index")]
        [DisplayName("Pati�ka souboru")]
        [Editor(typeof(TemplateTextEditor), typeof(UITypeEditor))]
        public string IndexFooter
        {
            get { return m_indexFooter; }
            set { m_indexFooter = value; }
        }

        bool m_writeGroups;
        [Category("Skupiny")]
        [DisplayName("Zapisovat skupiny")]
        public bool WriteGroups
        {
            get { return m_writeGroups; }
            set { m_writeGroups = value; }
        }

        string m_groupFileMask = "";
        [Category("Skupiny")]
        [DisplayName("Maska souboru")]
        [Description("Maska souboru pro skupinu, m��e obsahovat $[GROUPINDEX] pro ��slo skupiny")]
        public string GroupFileMask
        {
            get { return m_groupFileMask; }
            set { m_groupFileMask = value; }
        }

        string m_groupHeader = "";
        [Category("Skupiny")]
        [DisplayName("Hlavi�ka souboru")]
        [Editor(typeof(TemplateTextEditor), typeof(UITypeEditor))]
        public string GroupHeader
        {
            get { return m_groupHeader; }
            set { m_groupHeader = value; }
        }

        string m_groupSongRepeat = "";
        [Category("Skupiny")]
        [DisplayName("�ablona pro p�se�")]
        [Description("Opakuje se pro ka�dou p�se�, m��e obsahovat makro $[SONGINDEX] pro ��slo p�sn�")]
        [Editor(typeof(TemplateTextEditor), typeof(UITypeEditor))]
        public string GroupSongRepeat
        {
            get { return m_groupSongRepeat; }
            set { m_groupSongRepeat = value; }
        }

        string m_groupFooter = "";
        [Category("Skupiny")]
        [DisplayName("Pati�ka souboru")]
        [Editor(typeof(TemplateTextEditor), typeof(UITypeEditor))]
        public string GroupFooter
        {
            get { return m_groupFooter; }
            set { m_groupFooter = value; }
        }

        bool m_writeSeparateSongs;
        [Category("P�sn�")]
        [DisplayName("Zapisovat jednotliv�")]
        [Description("Zda zapisovat p�sn� po jedn� do jednoho souboru")]
        public bool WriteSeparateSongs
        {
            get { return m_writeSeparateSongs; }
            set { m_writeSeparateSongs = value; }
        }

        bool m_writeGroupedSongs;
        [Category("P�sn�")]
        [DisplayName("Zapisovat seskupen�")]
        [Description("Zda zapisovat p�sn� po skupin�ch do jednoho souboru")]
        public bool WriteGroupedSongs
        {
            get { return m_writeGroupedSongs; }
            set { m_writeGroupedSongs = value; }
        }

        string m_groupedSongsFileMask = "";
        [Category("P�sn�")]
        [DisplayName("Maska souboru seskupen�")]
        [Description("Maska souboru pro z�pis seskupen�ch p�sn� do souboru, m��e obsahovat $[GROUINDEX]")]
        public string GroupedSongsFileMask
        {
            get { return m_groupedSongsFileMask; }
            set { m_groupedSongsFileMask = value; }
        }

        string m_songFileMask = "";
        [Category("P�sn�")]
        [DisplayName("Maska souboru jednotliv�")]
        [Description("Maska souboru pro z�pis jednotliv�ch p�sn� do souboru, m��e obsahovat $[SONGINDEX] a $[GROUINDEX]")]
        public string SongFileMask
        {
            get { return m_songFileMask; }
            set { m_songFileMask = value; }
        }

        string m_streamFormatter;
        [Category("P�sn�")]
        [DisplayName("Styl form�tov�n� p�sn�")]
        [Editor(typeof(DependedFilterEditor<IStreamSongFormatter>), typeof(UITypeEditor))]
        public string StreamFormatter
        {
            get { return m_streamFormatter; }
            set { m_streamFormatter = value; }
        }

        private IStreamSongFormatter GetStreamFormatter()
        {
            return (IStreamSongFormatter)SongFilters.FilterByName(m_streamFormatter);
        }

        private string MakeTemplate(string tpl, GroupOfSongs grp)
        {
            tpl = tpl.Replace("$[GROUPINDEX]", grp.Index.ToString());
            tpl = tpl.Replace("$[GROUP]", grp.Name);
            return tpl;
        }

        private string MakeTemplate(string tpl, SongData song, DirectorySongHolder dsh)
        {
            tpl = tpl.Replace("$[SONGINDEX]", dsh.SongIndexes[song].ToString());
            tpl = Templates.MakeTemplate(tpl, song);
            tpl = MakeTemplate(tpl, dsh.SongGroups[song]);
            return tpl;
        }

        private void WriteIndexFile(TextWriter fw, DirectorySongHolder dsh)
        {
            fw.Write(m_indexHeader);
            foreach (GroupOfSongs grp in dsh.SortedGroups)
            {
                fw.Write(MakeTemplate(m_indexGroupRepeat, grp));
            }
            fw.Write(m_indexBetweenGroupsAndSongs);
            foreach (SongData song in dsh.Songs)
            {
                fw.Write(MakeTemplate(m_indexSongRepeat, song, dsh));
            }
            fw.Write(m_indexFooter);
        }

        private void WriteGroupFile(StreamWriter fw, GroupOfSongs grp, DirectorySongHolder dsh)
        {
            fw.Write(MakeTemplate(m_groupHeader, grp));
            foreach (SongData song in grp.Songs)
            {
                fw.Write(MakeTemplate(m_groupSongRepeat, song, dsh));
            }
            fw.Write(MakeTemplate(m_groupFooter, grp));
        }

        #region ISongFormatter Members

        public void Format(InetSongDb db, object props, IWaitDialog wait)
        {
            DirectorySongExporterProperties p = (DirectorySongExporterProperties)props;
            IStreamSongFormatter songfmt = GetStreamFormatter();
            string directory = p.FolderName;
            DirectorySongHolder dsh = new DirectorySongHolder(db.Songs);
            // nejdrive zapiseme index
            wait.Message("Zapisuji " + m_indexFileName);
            if (m_writeIndex)
            {
                using (FileStream fsw = new FileStream(Path.Combine(directory, m_indexFileName), FileMode.Create))
                {
                    using (StreamWriter fw = new StreamWriter(fsw, m_encoding))
                    {
                        WriteIndexFile(fw, dsh);
                    }
                }
            }

            // pak skupinove soubory
            if (m_writeGroups)
            {
                foreach (GroupOfSongs grp in dsh.Groups.Values)
                {
                    string path = Path.Combine(directory, MakeTemplate(m_groupFileMask, grp));
                    try { Directory.CreateDirectory(Path.GetDirectoryName(path)); }
                    catch (Exception) { }

                    wait.Message("Zapisuji " + path);
                    if (wait.Canceled) return;

                    using (FileStream fsw = new FileStream(path, FileMode.Create))
                    {
                        using (StreamWriter fw = new StreamWriter(fsw, m_encoding))
                        {
                            WriteGroupFile(fw, grp, dsh);
                        }
                    }
                }
            }

            // pisne - nejdrive zgrupovane
            if (m_writeGroupedSongs)
            {
                foreach (GroupOfSongs grp in dsh.Groups.Values)
                {
                    string path = Path.Combine(directory, MakeTemplate(m_groupedSongsFileMask, grp));
                    try { Directory.CreateDirectory(Path.GetDirectoryName(path)); }
                    catch (Exception) { }

                    wait.Message("Zapisuji " + path);
                    if (wait.Canceled) return;

                    InetSongDb tmp = new InetSongDb();
                    foreach (SongData song in grp.Songs)
                    {
                        DbTools.AddSongRow(song, tmp);
                    }
                    using (FileStream fw = new FileStream(path, FileMode.Create))
                    {
                        songfmt.Format(tmp, fw, wait, props);
                    }
                }
            }

            // pisne - po jedne
            if (m_writeSeparateSongs)
            {
                foreach (SongData song in db.Songs)
                {
                    string path = Path.Combine(directory, MakeTemplate(m_songFileMask, song, dsh));
                    try { Directory.CreateDirectory(Path.GetDirectoryName(path)); }
                    catch (Exception) { }

                    wait.Message("Zapisuji " + path);
                    if (wait.Canceled) return;

                    InetSongDb tmp = new InetSongDb();
                    DbTools.AddSongRow(song, tmp);
                    using (FileStream fw = new FileStream(path, FileMode.Create))
                    {
                        songfmt.Format(tmp, fw, wait, props);
                    }
                }
            }
        }

        #endregion

        #region ISongFilter Members

        public string Title
        {
            get { return m_name; }
        }

        public string Description
        {
            get { return "V�stup do adres��e"; }
        }

        public object CreateDynamicProperties()
        {
            return new DirectorySongExporterProperties();
        }

        #endregion

    }
}
