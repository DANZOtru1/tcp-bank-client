using System;
using System.Windows.Forms;

namespace ClientProj
{
    internal static class Program
    {
        #region Static fields

        public static Main MainForm;

        #endregion

        #region Private methods

        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm = new Main();
            Application.Run(MainForm);
        }

        #endregion
    }
}