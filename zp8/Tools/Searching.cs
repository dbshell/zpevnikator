using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;

namespace zp8
{
    public static class Searching
    {
        static Dictionary<char, char> m_remap = new Dictionary<char, char>();
        static Searching()
        {
            string cz = "�������������������";
            string en = "acdeeeillnoorstuuuyz";
            string abc = "abcdefghijklmnopqrstuvwxyz";
            for (int i = 0; i < cz.Length; i++) m_remap[cz[i]] = en[i];
            foreach (char c in abc) m_remap[Char.ToUpper(c)] = c;
            foreach (char c in abc) m_remap[c] = c;
        }

        public static string MakeSearchText(string s)
        {
            StringBuilder res = new StringBuilder();
            foreach (char c in s)
            {
                char newc;
                if (m_remap.TryGetValue(c, out newc)) res.Append(newc);
            }
            return res.ToString();
        }
    }

    //[SQLiteFunction(Arguments = 1, FuncType = FunctionType.Scalar, Name = "makesearchtext")]
    //public class MakeSearchTextFunction : SQLiteFunction
    //{
    //    public MakeSearchTextFunction()
    //    {
    //    }
    //    public override object Invoke(object[] args)
    //    {
    //        return Searching.MakeSearchText(args[0].ToString());
    //    }
    //}
}

