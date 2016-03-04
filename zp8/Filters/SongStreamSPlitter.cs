using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.IO;

namespace zp8
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class SongStreamSplitProperties : DatAdmin.PropertyPageBase
    {
        bool m_performSplit = true;
        [Category("Rozsek�n� na p�sn�")]
        [DisplayName("Prov�d�t rozsek�n�")]
        public bool PerformSplit
        {
            get { return m_performSplit; }
            set { m_performSplit = value; }
        }

        int m_emptyLineCount = 2;
        [Category("Rozsek�n� na p�sn�")]
        [DisplayName("Po�et pr�zdn�ch ��dek")]
        [Description("Minim�ln� po�et pr�zdn�ch ��dek mezi dv�ma p�sn�mi, pokud je 0, rozsek�n� podle pr�zdn�ch ��dek se ned�l�; pokud je v�t�� ne� 0, nepou�ije se Odd�lova� p�sn�")]
        public int EmptyLineCount
        {
            get { return m_emptyLineCount; }
            set { m_emptyLineCount = value; }
        }

        string m_songSeparator = "";
        [Category("Rozsek�n� na p�sn�")]
        [DisplayName("Odd�lova� p�sn�")]
        [Description("Kus textu (t�eba HTML tag), kter� slou�� k odd�len� p�sn�")]
        public string SongSeparator
        {
            get { return m_songSeparator; }
            set { m_songSeparator = value; }
        }

        bool m_conditionalSplit = true;
        [Category("Rozsek�n� na p�sn�")]
        [DisplayName("Podm�n�n� rozsek�n�")]
        [Description("Pokud je True, rozsek�n� podle po�tu pr�zdn�ch ��dek se provede jen pokud dal�� ��dka vypad� jako n�zev p�sn�")]
        public bool ConditionalSplit
        {
            get { return m_conditionalSplit; }
            set { m_conditionalSplit = value; }
        }

        public override string ToString()
        {
            if (!m_performSplit) return "Neprov�d� se";
            if (m_emptyLineCount > 0) return "Pr�zdn� ��dky:" + m_emptyLineCount.ToString();
            if (m_songSeparator != "") return "Odd�lova�:" + m_songSeparator;
            return "Neprov�d� se";
        }
    }

    public static class SongStreamSplitter
    {
        private static IEnumerable<string> SplitSongsBySpaces(StreamReader fr, SongStreamSplitProperties props)
        {
            List<string> lines = new List<string>();
            while (!fr.EndOfStream) lines.Add(fr.ReadLine().TrimEnd());
            int i = 0;
            // odstranit prazdne radky na konci
            while (lines.Count > 0 && lines[lines.Count - 1] == "") lines.RemoveAt(lines.Count - 1);

            while (i < lines.Count)
            {
                List<string> songlines = new List<string>();
                while (i < lines.Count && lines[i] == "") i++; // preskoc prazdne
                for (; ; ) // cyklus pres radky jedne pisne
                {
                    bool issep = true;
                    for (int j = 0; i + j < lines.Count && j < props.EmptyLineCount; j++)
                    {
                        if (lines[i + j] != "")
                        {
                            issep = false;
                            break;
                        }
                    }

                    if (issep && props.ConditionalSplit) // jeste kontrola prvni radky
                    {
                        while (i < lines.Count && lines[i] == "") i++; // preskoc prazdne
                        if (i < lines.Count && SongDataAnalyser.LooksLikeTextLine(lines[i]))
                        {
                            issep = false;
                        }
                        else if (i < lines.Count) songlines.Add(""); // aby sme nezapomneli prazdnou radku
                    }

                    if (issep)
                    {
                        break;
                    }

                    if (i >= lines.Count) break;
                    songlines.Add(lines[i]);
                    i++;
                }
                if (songlines.Count > 0)
                {
                    yield return String.Join("\n", songlines.ToArray());
                }
            }
        }

        public static IEnumerable<string> SplitSongs(StreamReader fr, SongStreamSplitProperties props)
        {
            if (props.PerformSplit)
            {
                if (props.EmptyLineCount > 0) // rozdeleni rizene poctem prazdnych radek
                {
                    return SplitSongsBySpaces(fr, props);
                }
                else if (props.SongSeparator != "")
                {
                    return SplitSongsBySeparator(fr, props);
                }
            }
            return new string[] { fr.ReadToEnd() };
        }

        private static IEnumerable<string> SplitSongsBySeparator(TextReader fr, SongStreamSplitProperties props)
        {
            string data = fr.ReadToEnd();
            int lastindex = 0;
            for (; ; )
            {
                int index = data.IndexOf(props.SongSeparator, lastindex);
                if (index < 0) break;
                yield return data.Substring(lastindex, index - lastindex);
                lastindex = index + props.SongSeparator.Length;
            }
            if (lastindex < data.Length) yield return data.Substring(lastindex);
        }
    }
}
