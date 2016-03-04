using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Xsl;

namespace zp8
{
    [StaticSongFilter]
    public class InetDbSongFormatter : SingleFileExporter
    {
        public override string Title
        {
            get { return "Internetov� datab�ze"; }
        }

        public override string Description
        {
            get { return "Soubor XML s p�sn�mi ve stejn�m form�tu, jako je ulo�en v internetov� datab�zi"; }
        }

        public override string FileDialogFilter
        {
            get { return "XML soubory (*.xml)|*.xml"; }
        }

        public override void Format(InetSongDb xmldb, Stream fw, IWaitDialog wait, object props)
        {
            xmldb.Save(fw);
        }
    }

    [StaticSongFilter]
    public class Zp6SongParser : MultipleStreamImporter
    {
        public override string Title
        {
            get { return "Datab�ze zp�vn�k�toru 6.0"; }
        }

        public override string FileDialogFilter
        {
            get { return "XML soubory (*.xml)|*.xml|Komprimovan� XML soubory (*.xgz)|*.xgz"; }
        }

        public override string Description
        {
            get { return "Datab�ze zp�vn�k�toru 6.0 ve form�tu XML"; }
        }

        //public void Run(SongDatabase db, string filename, int? serverid)
        public override void Parse(Stream fr, InetSongDb xmldb, IWaitDialog wait)
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(XmlReader.Create(new StringReader(xsls.zp6_to_zp8)));
            XmlDocument result = new XmlDocument();
            StringBuilder sb = new StringBuilder();
            XmlDocument zp6doc = new XmlDocument();
            zp6doc.Load(fr);
            if (zp6doc.DocumentElement.LocalName != "zpevnik_data" && zp6doc.DocumentElement.LocalName != "zpevnik") throw new Exception("�patn� form�t vstupn�ho souboru");
            xslt.Transform(zp6doc, XmlWriter.Create(sb));
            using (StringReader sr = new StringReader(sb.ToString()))
            {
                xmldb.Load(XmlTextReader.Create(sr));
            }
            //db.ImportSongs(sr, serverid);
        }

        public override int AcceptFile(string file, XmlDocument doc)
        {
            if (doc != null && (doc.DocumentElement.LocalName == "zpevnik_data" || doc.DocumentElement.LocalName == "zpevnik")) return 10;
            return 0;
        }
    }

    [StaticSongFilter]
    public class InetDbSongParser : MultipleStreamImporter
    {
        public override string Title
        {
            get { return "Internetov� datab�ze"; }
        }

        public override string Description
        {
            get { return "Soubor XML s p�sn�mi ve stejn�m form�tu, jako je ulo�en v internetov� datab�zi"; }
        }

        public override string FileDialogFilter
        {
            get { return "XML soubory (*.xml)|*.xml"; }
        }

        public override void Parse(Stream fr, InetSongDb xmldb, IWaitDialog wait)
        {
            xmldb.Load(fr);
        }

        public override int AcceptFile(string file, XmlDocument doc)
        {
            if (doc != null
                && doc.DocumentElement.NamespaceURI == "http://zpevnik.net/InetSongDb.xsd"
                && doc.DocumentElement.LocalName == "InetSongDb") return 15;
            return 0;
        }
    }

}
