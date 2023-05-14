using EStorage;
using EStorage.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EStorage
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DataHelper.InitializeLogs();
            DataHelper.InitializeDB();

            DataHelper.UpdateDB();

            Application.Run(new title());
        }
    }
}
