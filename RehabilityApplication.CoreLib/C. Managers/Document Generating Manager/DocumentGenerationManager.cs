using DevExpress.XtraPrinting;
using DevExpress.XtraRichEdit;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RehabilityApplication.CoreLib
{
    public static class DocumentGenerationManager
    {
        public static void GenerateDocuments()
        {
            string templatePath = @"template.docx";
            string saveFolder = System.IO.Path.GetDirectoryName(templatePath);
            string targetFolder = $@"{saveFolder}\documents";
            System.IO.Directory.CreateDirectory(targetFolder);
            Process.Start(new ProcessStartInfo("explorer.exe", targetFolder));

            long docCount = GlobalDatabaseManager.clients.Count;
            long currentIndex = 0;

            foreach (var client in GlobalDatabaseManager.clients)
            {
                using (var docServer = new RichEditDocumentServer())
                {
                    docServer.LoadDocument(templatePath);
                    docServer.Document.ReplaceAll(new Regex("%ID%"), client.Id);
                    docServer.Document.ReplaceAll(new Regex("%ISSELECTED%"), client.IsSelected.ToString());
                    docServer.Document.ReplaceAll(new Regex("%SNILS%"), client.Snils);
                    docServer.SaveDocument($@"{targetFolder}\{client.Id}.doc", DocumentFormat.Doc);
                    currentIndex++;
                    SplashScreenManager.Default.SetWaitFormDescription($"Документ {currentIndex} из {docCount} сохранён!");
                }
            }
        }

        public static string GenerateDocuments(string snils)
        {
            string templatePath = @"template.docx";
            string saveFolder = System.IO.Path.GetDirectoryName(templatePath);
            string targetFolder = $@"{saveFolder}\documents";
            System.IO.Directory.CreateDirectory(targetFolder);
            Process.Start(new ProcessStartInfo("explorer.exe", targetFolder));

            var client = GlobalDatabaseManager.clients.Where(t => t.Snils == snils).FirstOrDefault();

            if (client == null)
            {
                return string.Empty;
            }

            using (var docServer = new RichEditDocumentServer())
            {
                docServer.LoadDocument(templatePath);
                docServer.Document.ReplaceAll(new Regex("%ID%"), client.Id);
                docServer.Document.ReplaceAll(new Regex("%ISSELECTED%"), client.IsSelected.ToString());
                docServer.Document.ReplaceAll(new Regex("%SNILS%"), client.Snils);
                string savedFilePath = $@"{targetFolder}\{client.Id}.doc";
                docServer.SaveDocument(savedFilePath, DocumentFormat.Doc);

                return savedFilePath;
            }
        }

        /// <summary>
        /// Метод, генерирующий документ и преобразующий его в PDF, если convertToPdf = true
        /// </summary>
        /// <param name="snils">СНИЛС.</param>
        /// <param name="converToPdf">Конвертировать в PDF или нет?</param>
        /// <returns></returns>
        public static string GenerateDocuments(string snils, bool converToPdf)
        {
            string templatePath = @"template.docx";
            string saveFolder = System.IO.Path.GetDirectoryName(templatePath);
            string targetFolder = $@"{saveFolder}\documents";
            System.IO.Directory.CreateDirectory(targetFolder);
            Process.Start(new ProcessStartInfo("explorer.exe", targetFolder));

            var client = GlobalDatabaseManager.clients.Where(t => t.Snils == snils).FirstOrDefault();

            if (client == null)
            {
                return string.Empty;
            }

            using (var docServer = new RichEditDocumentServer())
            {
                docServer.LoadDocument(templatePath);
                docServer.Document.ReplaceAll(new Regex("%ID%"), client.Id);
                docServer.Document.ReplaceAll(new Regex("%ISSELECTED%"), client.IsSelected.ToString());
                docServer.Document.ReplaceAll(new Regex("%SNILS%"), client.Snils);

                if (converToPdf == true)
                {
                    PdfExportOptions exportOptions = new PdfExportOptions();
                    exportOptions.DocumentOptions.Author = "Rehability Application";
                    exportOptions.ImageQuality = PdfJpegImageQuality.Highest;
                    string savedFilePath = $@"{targetFolder}\{client.Id}.pdf";

                    using (FileStream pdfFileStream = new FileStream(savedFilePath, FileMode.Create))
                    {
                        docServer.ExportToPdf(pdfFileStream, exportOptions);
                    }
                    return savedFilePath;
                }
                else
                {
                    string savedFilePath = $@"{targetFolder}\{client.Id}.doc";
                    docServer.SaveDocument(savedFilePath, DocumentFormat.Doc);
                    return savedFilePath;
                }
            }
        }
    }
}
