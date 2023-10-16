using DevExpress.Skins;
using DevExpress.UserSkins;
using RehabilityApplication.CoreLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
//using RehabilityApplication.CoreLib;

namespace RehabilityApp.GUI
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа в приложение.
        /// </summary>
        [STAThread]
        static void Main()
        {
            GlobalDatabaseManager.Init();
            TelegramBotManager.Init();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
