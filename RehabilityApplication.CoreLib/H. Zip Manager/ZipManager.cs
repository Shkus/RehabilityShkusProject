using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.Dialogs;
using DevExpress.Compression;
using System.Windows;
using DevExpress.XtraSplashScreen;

namespace RehabilityApplication.CoreLib
{
    public static class ZipManager
    {
        public static void ZipFolder()
        {
            CommonOpenFileDialog cfod = new CommonOpenFileDialog()
            {
                IsFolderPicker = true
            };

            if(cfod.ShowDialog() == CommonFileDialogResult.Ok)
            {
                Task.Run(() =>
                {
                    StartZip(cfod.FileName);
                    SplashScreenManager.CloseForm();
                });
            }

        }

        public static void StartZip(string FolderPath)
        {
            string folder = FolderPath;
            string zipFileName = $"{folder}.zip";

            CoreGlobalCommandManager.StartCommand(null, $"Начата архивация папки: {folder}");

            List<string> messages = new List<string>();

            double currentProgress = 0;
            double receivedProgress = 0;


            using(DevExpress.Compression.ZipArchive zip = new DevExpress.Compression.ZipArchive())
            {
                zip.Password = "12345";
                zip.Progress += (s, e) =>
                {
                    currentProgress = Math.Round(e.Progress * 100, 0) % 2;
                    if(currentProgress == 0 && receivedProgress < Math.Round(e.Progress * 100, 0))
                    {
                        receivedProgress = Math.Round(e.Progress * 100, 0);
                        //SplashScreenManager.ShowSkinSplashScreen("");
                        //SplashScreenManager.Default.SetWaitFormDescription($"Выполнено [архивация]: {receivedProgress}%");
                        //CoreGlobalCommandManager.StartCommand(null, $"Выполнено [архивация]: {receivedProgress}%");
                        
                    }
                };

                //zip.ItemAdding += (s, e) =>
                //{
                //    CoreGlobalCommandManager.StartCommand(null, $"Выполнено добавление элемента: {e.Item.Name}");
                //};

                zip.OptionsBehavior.AllowFileOverwrite = AllowFileOverwriteMode.Forbidden;

                //string[] docFiles = System.IO.Directory.GetFiles(folder, "*.docx");

                //foreach(string docFile in docFiles)
                //{
                //    zip.AddFile(docFile, @"\");
                //}

                //docFiles = System.IO.Directory.GetFiles(folder, "*.pdf");

                //foreach(string docFile in docFiles)
                //{
                //    zip.AddFile(docFile, @"\");
                //}



                zip.AddDirectory(folder, @"\");
                zip.Save(zipFileName);
            }

            //foreach(var item in messages)
            //{
            //    CoreGlobalCommandManager.StartCommand(DatabaseCommandType.FocusedClientWasChangedPleaseShowProductsInClients, item);
            //}
        }

        public static void ZipFiles()
        {
            string zipFileName = $@"D:\!!! Базовые элементы\Рабочий стол\Шаблоны\DB.zip";

            using(DevExpress.Compression.ZipArchive zip = new DevExpress.Compression.ZipArchive())
            {
                zip.OptionsBehavior.AllowFileOverwrite = AllowFileOverwriteMode.Allow;

                zip.AddFile(@"D:\!!! Базовые элементы\Рабочий стол\Шаблоны\DB\Clients.xml", @"\");
                zip.AddFile(@"D:\!!! Базовые элементы\Рабочий стол\Шаблоны\DB\Contracts.xml", @"\");
                zip.AddFile(@"D:\!!! Базовые элементы\Рабочий стол\Шаблоны\DB\ProductsInStore_Old.xml", @"\");
                zip.AddDirectory(@"D:\!!! Базовые элементы\Рабочий стол\Шаблоны\DB\ProductsInStore_Old.xml", @"\");

                zip.EncryptionType = EncryptionType.Aes128;
                zip.Password = "12345";

                zip.Save(zipFileName);
            }
        }

        public static void UnzipFile()
        {

            string zipFileName = $@"D:\!!! Базовые элементы\Рабочий стол\Шаблоны\DB.zip";
            string targetFolder = $@"D:\!!! Базовые элементы\Рабочий стол\Шаблоны";

            using(DevExpress.Compression.ZipArchive zip = DevExpress.Compression.ZipArchive.Read(zipFileName))
            {
                //zip.EncryptionType = EncryptionType.Aes128;
                zip.Password = "12345";

                foreach(var file in zip)
                {
                    file.Extract(targetFolder);
                }
            }
        }

    }
}
