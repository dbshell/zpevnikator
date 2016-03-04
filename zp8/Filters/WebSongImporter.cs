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
using System.Net;
using System.Text.RegularExpressions;
using System.Xml;

namespace zp8
{
    public class WebSongImporterProperties : DatAdmin.PropertyPageBase
    {
        string m_URL;

        [DisplayName("Internetov� adresa")]
        public string URL
        {
            get { return m_URL; }
            set { m_URL = value; }
        }

        public WebSongImporterProperties(string url)
        {
            m_URL = url;
        }
    }

    public struct HtmlLink
    {
        public string Name;
        public string Link;
    }

    [ConfigurableSongFilter(Name = "Import webu")]
    public class WebSongImporter : DatAdmin.PropertyPageBase, ISongParser, ICustomSongFilter
    {
        Encoding m_encoding = System.Text.Encoding.UTF8;
        [DisplayName("K�dov�n�")]
        public string Encoding
        {
            get { return m_encoding.WebName; }
            set { m_encoding = System.Text.Encoding.GetEncoding(value); }
        }

        string m_name;
        [Browsable(false)]
        [XmlIgnore]
        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        string m_indexURL = "";
        [Category("Index")]
        [DisplayName("URL hlavn�ho souboru")]
        public string IndexURL
        {
            get { return m_indexURL; }
            set { m_indexURL = value; }
        }

        string m_indexGroupPattern = "";
        [Category("Index - skupiny")]
        [DisplayName("Regul�rn� v�raz")]
        public string IndexGroupPattern
        {
            get { return m_indexGroupPattern; }
            set { m_indexGroupPattern = value; }
        }

        string m_indexGroupRLink = "";
        [Category("Index - skupiny")]
        [DisplayName("Odkaz")]
        public string IndexGroupRLink
        {
            get { return m_indexGroupRLink; }
            set { m_indexGroupRLink = value; }
        }

        string m_indexGroupRName = "";
        [Category("Index - skupiny")]
        [DisplayName("N�zev")]
        public string IndexGroupRName
        {
            get { return m_indexGroupRName; }
            set { m_indexGroupRName = value; }
        }

        string m_indexSongPattern = "";
        [Category("Index - p�sn�")]
        [DisplayName("Regul�rn� v�raz")]
        public string IndexSongPattern
        {
            get { return m_indexSongPattern; }
            set { m_indexSongPattern = value; }
        }

        string m_indexSongRLink = "";
        [Category("Index - p�sn�")]
        [DisplayName("Odkaz")]
        public string IndexSongRLink
        {
            get { return m_indexSongRLink; }
            set { m_indexSongRLink = value; }
        }

        string m_indexSongRName = "";
        [Category("Index - p�sn�")]
        [DisplayName("N�zev")]
        public string IndexSongRName
        {
            get { return m_indexSongRName; }
            set { m_indexSongRName = value; }
        }

        string m_groupSongPattern = "";
        [Category("Skupiny - p�sn�")]
        [DisplayName("Regul�rn� v�raz")]
        public string GroupSongPattern
        {
            get { return m_groupSongPattern; }
            set { m_groupSongPattern = value; }
        }

        string m_groupSongRLink = "";
        [Category("Skupiny - p�sn�")]
        [DisplayName("Odkaz")]
        public string GroupSongRLink
        {
            get { return m_groupSongRLink; }
            set { m_groupSongRLink = value; }
        }

        string m_groupSongRName = "";
        [Category("Skupiny - p�sn�")]
        [DisplayName("N�zev")]
        public string GroupSongRName
        {
            get { return m_groupSongRName; }
            set { m_groupSongRName = value; }
        }


        string m_streamParser = "";
        [Category("P�sn�")]
        [DisplayName("Styl form�tov�n� p�sn�")]
        [Editor(typeof(DependedFilterEditor<IStreamSongParser>), typeof(UITypeEditor))]
        public string StreamParser
        {
            get { return m_streamParser; }
            set { m_streamParser = value; }
        }

        private IStreamSongParser GetStreamParser()
        {
            return (IStreamSongParser)SongFilters.FilterByName(m_streamParser);
        }

        #region ISongFilter Members

        public string Title
        {
            get { return m_name; }
        }

        public string Description
        {
            get { return "Import webov� str�nky"; }
        }

        public object CreateDynamicProperties()
        {
            return new WebSongImporterProperties(m_indexURL);
        }

        #endregion

        private IEnumerable<HtmlLink> EnumLinks(string url, string pattern, string name, string link)
        {
            if (pattern == "") yield break;
            WebRequest req = WebRequest.Create(url);
            WebResponse resp = req.GetResponse();
            using (Stream fr = resp.GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(fr, m_encoding))
                {
                    string data = sr.ReadToEnd();
                    foreach (Match m in Regex.Matches(data, pattern))
                    {
                        HtmlLink value;
                        value.Link = m.Result(link);
                        value.Name = m.Result(name);
                        yield return value;
                    }
                }
            }
            resp.Close();
        }

        private static void ParseSongStream(InetSongDb db, IStreamSongParser parser, string link, string defsongname, string defgroupname, IWaitDialog wait)
        {
            InetSongDb tmp = new InetSongDb();
            WebRequest req = WebRequest.Create(link);
            WebResponse resp = req.GetResponse();
            using (Stream fr = resp.GetResponseStream())
            {
                parser.Parse(fr, tmp, wait);
            }
            resp.Close();
            foreach (SongData row in tmp.Songs)
            {
                if (defsongname != null && row.Title == "") row.Title = defsongname;
                if (defgroupname != null && row.GroupName == "") row.GroupName = defgroupname;
                DbTools.AddSongRow(row, db);
            }
        }

        private string MakeAbsoluteUri(string indexfile, string link)
        {
            Uri idxu = new Uri(indexfile);
            Uri res;
            if (Uri.TryCreate(idxu,link, out res)) return res.ToString();
            return null;
        }

        #region ISongParser Members

        public void Parse(object props, InetSongDb db, IWaitDialog wait)
        {
            IStreamSongParser parser = GetStreamParser();
            WebSongImporterProperties p = (WebSongImporterProperties)props;
            foreach (HtmlLink grp in EnumLinks(p.URL, IndexGroupPattern, IndexGroupRName, IndexGroupRLink))
            {
                wait.Message("Importuji skupinu " + grp.Name);
                string grplink = MakeAbsoluteUri(p.URL, grp.Link);
                foreach (HtmlLink song in EnumLinks(grplink, GroupSongPattern, GroupSongRName, GroupSongRLink))
                {
                    wait.Message("Importuji p�se� " + song.Name);
                    if (wait.Canceled) return;
                    ParseSongStream(db, parser, MakeAbsoluteUri(grplink, song.Link), song.Name, grp.Name, wait);
                }
                if (wait.Canceled) return;
            }
            foreach (HtmlLink song in EnumLinks(p.URL, IndexSongPattern, IndexSongRName, IndexSongRLink))
            {
                wait.Message("Importuji p�se� " + song.Name);
                if (wait.Canceled) return;
                ParseSongStream(db, parser, MakeAbsoluteUri(p.URL, song.Link), song.Name, null, wait);
            }
        }

        #endregion

        #region ISongParser Members

        public virtual int AcceptFile(string file, XmlDocument doc)
        {
            return 0;
        }

        #endregion
    }
}
