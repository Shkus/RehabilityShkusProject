using DevExpress.XtraRichEdit;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Documents;
using System.Xml.Linq;

namespace RehabilityApplication.CoreLib
{
    public static class DocumentManager
    {

        public static void GenerateDocument<T>(this T document)
        {
            if(typeof(T) == typeof(DocumentType1))
            {
                GenDoc(document, (document as DocumentType1).TemplateFilename, (document as DocumentType1).Id);
            }
            if(typeof(T) == typeof(DocumentType2))
            {
                GenDoc(document, (document as DocumentType2).TemplateFilename, (document as DocumentType2).Id);
            }
            if(typeof(T) == typeof(DocumentType3))
            {
                GenDoc(document, (document as DocumentType3).TemplateFilename, (document as DocumentType3).Id);
            }

            if (typeof(T) == typeof(VasiliyResumeType))
            { 
                GenDoc(document, (document as VasiliyResumeType).TemplateFilename, (document as VasiliyResumeType).Id);
            }
            if (typeof(T) == typeof(IvanTemplateResume)) 
            {
                GenDoc(document, (document as IvanTemplateResume).TemplateFilename, (document as IvanTemplateResume).Id);
            }
        }

        public static void GenDoc<T>(T document, string TemplateName, string Id)
        {
            string template = TemplateName;

            string saveFolder = System.IO.Path.GetDirectoryName(template);
            string targetFolder = $@"{saveFolder}\Documents";
            System.IO.Directory.CreateDirectory(targetFolder);
            Process.Start(new ProcessStartInfo("explorer.exe", targetFolder));

            using(var docServer = new RichEditDocumentServer())
            {
                docServer.LoadDocument(template);

                List<PropertyInfo> properties = document.GetType().GetRuntimeProperties().ToList();

                foreach(PropertyInfo pi in properties)
                {
                    try
                    {
                        string piValue = pi.GetValue(document).ToString();
                        string piAutoReplaceParameterName = pi.GetCustomAttribute<AutoReplaceAttribute>().ParameterName.ToString();
                        docServer.Document.ReplaceAll(piAutoReplaceParameterName, piValue, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
                    }
                    catch
                    {
                        // Видимо нет такого аттрибута у свойства.
                    }
                }


                string saveName = $@"{targetFolder}\{Id}.doc";
                docServer.SaveDocument(saveName, DocumentFormat.Doc);
            }
        }

        //public static void GenerateDocument(this DocumentType1 documentType1)
        //{
        //    string template = documentType1.TemplateFilename;

        //    string saveFolder = System.IO.Path.GetDirectoryName(template);
        //    string targetFolder = $@"{saveFolder}\Documents";
        //    System.IO.Directory.CreateDirectory(targetFolder);
        //    Process.Start(new ProcessStartInfo("explorer.exe", targetFolder));

        //    using(var docServer = new RichEditDocumentServer())
        //    {
        //        docServer.LoadDocument(template);

        //        docServer.Document.ReplaceAll("%name%", documentType1.Name, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%description%", documentType1.Description, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%description%", documentType1.Description, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%description%", documentType1.Description, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%description%", documentType1.Description, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%description%", documentType1.Description, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%description%", documentType1.Description, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%description%", documentType1.Description, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%description%", documentType1.Description, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%description%", documentType1.Description, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%description%", documentType1.Description, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%description%", documentType1.Description, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%description%", documentType1.Description, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%description%", documentType1.Description, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%description%", documentType1.Description, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%description%", documentType1.Description, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%description%", documentType1.Description, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%description%", documentType1.Description, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%description%", documentType1.Description, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%description%", documentType1.Description, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%description%", documentType1.Description, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%description%", documentType1.Description, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);

        //        string saveName = $@"{targetFolder}\{documentType1.Id}.doc";
        //        docServer.SaveDocument(saveName, DocumentFormat.Doc);
        //    }
        //}

        //public static void GenerateDocument(this DocumentType2 documentType2)
        //{
        //    string template = documentType2.TemplateFilename;

        //    string saveFolder = System.IO.Path.GetDirectoryName(template);
        //    string targetFolder = $@"{saveFolder}\Documents";
        //    System.IO.Directory.CreateDirectory(targetFolder);
        //    Process.Start(new ProcessStartInfo("explorer.exe", targetFolder));

        //    using(var docServer = new RichEditDocumentServer())
        //    {
        //        docServer.LoadDocument(template);

        //        docServer.Document.ReplaceAll("%company%", documentType2.Company, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%address%", documentType2.Address, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%City%", documentType2.City, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%RecepientName%", documentType2.RecepientName, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%RecepientName%", documentType2.RecepientName, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%RecepientName%", documentType2.RecepientName, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%RecepientName%", documentType2.RecepientName, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%RecepientName%", documentType2.RecepientName, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%RecepientName%", documentType2.RecepientName, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%RecepientName%", documentType2.RecepientName, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%RecepientName%", documentType2.RecepientName, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%RecepientName%", documentType2.RecepientName, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%RecepientName%", documentType2.RecepientName, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%RecepientName%", documentType2.RecepientName, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%RecepientName%", documentType2.RecepientName, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%RecepientName%", documentType2.RecepientName, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%RecepientName%", documentType2.RecepientName, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%RecepientName%", documentType2.RecepientName, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%RecepientName%", documentType2.RecepientName, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%RecepientName%", documentType2.RecepientName, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%RecepientName%", documentType2.RecepientName, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%RecepientName%", documentType2.RecepientName, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%RecepientName%", documentType2.RecepientName, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%RecepientName%", documentType2.RecepientName, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%RecepientName%", documentType2.RecepientName, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%RecepientName%", documentType2.RecepientName, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%RecepientName%", documentType2.RecepientName, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%RecepientName%", documentType2.RecepientName, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%RecepientName%", documentType2.RecepientName, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%RecepientName%", documentType2.RecepientName, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%RecepientName%", documentType2.RecepientName, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%RecepientName%", documentType2.RecepientName, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%RecepientName%", documentType2.RecepientName, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%TITLE%", documentType2.Title, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%NAME%", documentType2.Name, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);

        //        string saveName = $@"{targetFolder}\{documentType2.Id}.doc";
        //        docServer.SaveDocument(saveName, DocumentFormat.Doc);
        //    }
        //}

        //public static void GenerateDocument(this DocumentType3 documentType3)
        //{
        //    string template = documentType3.TemplateFilename;

        //    string saveFolder = System.IO.Path.GetDirectoryName(template);
        //    string targetFolder = $@"{saveFolder}\Documents";
        //    System.IO.Directory.CreateDirectory(targetFolder);
        //    Process.Start(new ProcessStartInfo("explorer.exe", targetFolder));

        //    using(var docServer = new RichEditDocumentServer())
        //    {
        //        docServer.LoadDocument(template);

        //        docServer.Document.ReplaceAll("%NAME%", documentType3.Name, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%SURNAME%", documentType3.Surname, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%SURNAME%", documentType3.Surname, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%SURNAME%", documentType3.Surname, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%SURNAME%", documentType3.Surname, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%SURNAME%", documentType3.Surname, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%SURNAME%", documentType3.Surname, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%SURNAME%", documentType3.Surname, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%SURNAME%", documentType3.Surname, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%SURNAME%", documentType3.Surname, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%SURNAME%", documentType3.Surname, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%SURNAME%", documentType3.Surname, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%SURNAME%", documentType3.Surname, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%SURNAME%", documentType3.Surname, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%SURNAME%", documentType3.Surname, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%SURNAME%", documentType3.Surname, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%SURNAME%", documentType3.Surname, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%SURNAME%", documentType3.Surname, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%SURNAME%", documentType3.Surname, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
        //        docServer.Document.ReplaceAll("%SURNAME%", documentType3.Surname, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);

        //        string saveName = $@"{targetFolder}\{documentType3.Id}.doc";
        //        docServer.SaveDocument(saveName, DocumentFormat.Doc);
        //    }
        //}
    }
}
