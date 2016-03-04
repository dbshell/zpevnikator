using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace zp8
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Core.IsGUI = true;
            Core.Initialize();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Directories.CopyDefaultData();
#if (DEBUG)
            Application.Run(new MainForm());
#else
            try
            {
                Application.Run(new MainForm());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
#endif
        }
    }
}