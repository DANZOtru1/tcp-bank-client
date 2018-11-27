using System;
using System.Windows.Forms;

namespace Client_tcp
{
    static class Program
    {
        public static Main MainForm;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm = new Main();
            Application.Run(MainForm);
        }
    }
}
