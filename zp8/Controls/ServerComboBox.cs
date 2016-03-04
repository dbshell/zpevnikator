using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace zp8
{
    public class ServerComboBox : ComboBox
    {
        SongDatabase m_db;

        public ServerComboBox()
        {
            DropDownStyle = ComboBoxStyle.DropDownList;
            ReloadItems();
        }

        public SongDatabase Database
        {
            get { return m_db; }
            set
            {
                m_db = value;
                ReloadItems();
                ServerID = null;
            }
        }

        private void ReloadItems()
        {
            if (m_db == null) return;
            Items.Clear();
            Items.Add(new Item { id = 0, url = "(Není zadán)" });
            Enabled = false;
            using (var reader = m_db.ExecuteReader("select id, url from server"))
            {
                while (reader.Read())
                {
                    Items.Add(new Item { id = reader.SafeInt(0), url = reader.SafeString(1) });
                }
            }
            Enabled = true;
        }

        public int? ServerID
        {
            get
            {
                if (SelectedIndex <= 0) return null;
                return ((Item)Items[SelectedIndex]).id;
            }
            set
            {
                if (m_db == null) return;
                int index = 0;
                foreach (Item item in Items)
                {
                    if (item.id == value)
                    {
                        SelectedIndex = index;
                        return;
                    }
                    index++;;
                }
                SelectedIndex = 0;
            }
        }

        public class Item
        {
            internal int id;
            internal string url;
            public override string ToString()
            {
                return url;
            }
        }
    }
}
