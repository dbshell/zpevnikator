using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using DatAdmin;

namespace zp8
{
    public partial class SongBookFrame : UserControl
    {
        SongBook m_book;
        FormattedBook m_fbook;
        PrinterSettings m_settings;

        public SongBookFrame()
        {
            InitializeComponent();
        }
        public SongBook SongBook
        {
            get { return m_book; }
            set
            {
                if (m_book != null) m_book.BookChanged -= m_book_Changed;
                m_book = value;
                if (m_book != null) m_book.BookChanged += m_book_Changed;
                m_book_Changed(null, null);
            }
        }

        void m_book_Changed(object sender, EventArgs e)
        {
            Format();
            lbsequence.Items.Clear();
            if (m_book != null)
            {
                foreach (SongData row in m_book.GetSongs(SongOrder.Database))
                {
                    lbsequence.Items.Add(row);
                }
            }
        }

        private void Format()
        {
            if (m_book == null)
            {
                m_fbook = null;
            }
            else
            {
                m_fbook = m_book.Book;
            }
            if (m_fbook != null)
            {
                previewFrame1.mmky = m_book.PrintTarget.mmky;
                previewFrame1.Source = m_fbook.GetPreview();
                previewFrame2.mmky = m_book.PrintTarget.mmky;
                previewFrame2.Source = m_fbook.GetLogicalPreview();
            }
            else
            {
                previewFrame1.Source = null;
                previewFrame2.Source = null;
            }
            if (ChangedPageInfo != null) ChangedPageInfo(this, new EventArgs());
        }


        public void PropertiesDialog()
        {
            if (m_book != null)
            {
                OptionsForm.Run(m_book);
                m_book.ClearCaches();
                m_book.Modified();
                Format();
            }
        }

        public void ExportAsPDF()
        {
            if (m_book != null && savepdf.ShowDialog() == DialogResult.OK)
            {
                m_book.ExportAsPDF(savepdf.FileName);
            }
        }

        public void ChangeBookStyle()
        {
            if (m_book == null) return;
            string newstyle = ChangeBookStyleForm.Run();
            if (newstyle != null)
            {
                m_book.SetBookStyle(newstyle);
                m_book.ClearCaches();
                m_book.Modified();
                Format();
            }
        }

        public string PageInfo
        {
            get
            {
                if (m_fbook == null) return "n/a";
                return String.Format("A4:{0}, prázdné:{1}", m_fbook.A4SheetCount * 2, m_fbook.FreePageCount);
            }
        }

        public event EventHandler ChangedPageInfo;

        private void SongBookFrame_Load(object sender, EventArgs e)
        {
            cbprinter.Items.Add("(PDF soubor)");
            foreach (string name in PrinterSettings.InstalledPrinters)
            {
                cbprinter.Items.Add(name);
            }
            cbprinter.SelectedIndex = 0;
            PrintDocument doc = new PrintDocument();
            m_settings = doc.PrinterSettings;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbprinter.SelectedIndex > 0)
            {
                printDialog1.PrinterSettings = m_settings;
                if (printDialog1.ShowDialog() == DialogResult.OK)
                {
                    m_settings = printDialog1.PrinterSettings;
                    cbprinter.SelectedIndex = cbprinter.Items.IndexOf(m_settings.PrinterName);
                    ChangedPrintTarget();
                }
            }
        }

        private void cbprinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbprinter.SelectedIndex > 0) m_settings.PrinterName = (string)cbprinter.Items[cbprinter.SelectedIndex];
            ChangedPrintTarget();
        }

        private void ChangedPrintTarget()
        {
            if (m_book != null)
            {
                if (cbprinter.SelectedIndex == 0) m_book.PrintTarget = new PdfPrintTarget();
                else m_book.PrintTarget = new PrinterPrintTarget(m_settings);
            }
        }

        public void PrintSongBook()
        {
            if (m_book != null)
            {
                if (cbprinter.SelectedIndex > 0) printDialog1.PrinterSettings = m_settings;
                if (printDialog1.ShowDialog() == DialogResult.OK)
                {
                    SongBookPrinter sp = new SongBookPrinter(m_book, printDialog1.PrinterSettings);
                    sp.Run();
                }
            }
        }

        public void ScrollPage(int dpage)
        {
            ((PreviewFrame)tabControl1.SelectedTab.Controls[0]).ScrollPage(dpage);
        }

        private void btnRemoveSong_Click(object sender, EventArgs e)
        {
            var song = lbsequence.SelectedItem as SongData;
            if (song == null) return;
            m_book.Database.ExecuteNonQuery("delete from songlistitem where song_id=@song and songlist_id=@list",
                "song", song.LocalID, "list", m_book.ID);
            m_book.DispatchBookChanged();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            lbsequence.MoveSelectedDown();
            SavePositions();
            m_book.DispatchBookChanged();
        }

        private void SavePositions()
        {
            int pos = 1;
            foreach (SongData song in lbsequence.Items)
            {
                m_book.Database.ExecuteNonQuery("update songlistitem set position=@pos where song_id=@song and songlist_id=@list",
                    "song", song.LocalID, "list", m_book.ID, "pos", pos);
                pos++;
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            lbsequence.MoveSelectedUp();
            SavePositions();
            m_book.DispatchBookChanged();
        }
    }
}
