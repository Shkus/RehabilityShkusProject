using DevExpress.DataAccess.Native.Excel;
using DevExpress.DocumentServices.ServiceModel.DataContracts;
using DevExpress.Mvvm.Native;
using DevExpress.XtraReports.Wizards.Templates;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraRichEdit.Model;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Documents;
using System.Xml.Linq;
using SearchOptions = DevExpress.XtraRichEdit.API.Native.SearchOptions;
using Table = DevExpress.XtraRichEdit.API.Native.Table;

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

            if(typeof(T) == typeof(VasiliyResumeType))
            {
                GenDoc(document, (document as VasiliyResumeType).TemplateFilename, (document as VasiliyResumeType).Id);
            }
            if(typeof(T) == typeof(IvanTemplateResume))
            {
                GenDoc(document, (document as IvanTemplateResume).TemplateFilename, (document as IvanTemplateResume).Id);
            }
        }

        public static void GenerateWithTables<T, W>(this T document) where T : ITemplatable, IUniqueIdentificator
        {
            string template = document.Template;

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
                        string piType = pi.PropertyType.Name.ToString();
                        string piAutoReplaceParameterName = pi.GetCustomAttribute<AutoReplaceAttribute>().ParameterName.ToString();
                        bool piAutoReplaceIsList = pi.GetCustomAttribute<AutoReplaceAttribute>().IsThisInstanceAsList;

                        if(piType == "Bitmap" && piAutoReplaceParameterName != "")
                        {
                            DocumentRange[] rangesForInsertImage = docServer.Document.FindAll(piAutoReplaceParameterName, SearchOptions.None);

                            foreach(var rangeForInsertImage in rangesForInsertImage)
                            {
                                DocumentPosition position = rangeForInsertImage.Start;
                                Bitmap piValue = (Bitmap)pi.GetValue(document);
                                DocumentImage di = docServer.Document.Images.Insert(position, piValue);
                                di.ScaleX = 1f;
                                //di.ScaleY = (float)1;
                                di.ScaleY = 1f;

                                docServer.Document.Delete(rangeForInsertImage);
                            }
                        }
                        else if(piAutoReplaceParameterName == "" && piAutoReplaceIsList == true)
                        {
                            List<W> workPlaces = (List<W>)pi.GetValue(document);

                            //var tables = docServer.Document.Tables;

                            //DocumentRange[] rangesWorkplace = docServer.Document.FindAll("#WORKPLACE#", SearchOptions.None);

                            //DevExpress.XtraRichEdit.API.Native.TableCell tablesWithWorkplace = docServer.Document.Tables.GetTableCell(rangesWorkplace.First().Start);

                            //var tableIndex = docServer.Document.Tables.IndexOf(tablesWithWorkplace.First());

                            //CoreGlobalCommandManager.StartCommand(null, tableIndex.ToString());

                            int tableIndex = 2;

                            Table table = docServer.Document.Tables[tableIndex];

                            var row = table.Rows.Last();
                            int rowIndex = table.Rows.ToList().IndexOf(row);

                            List<string> cellValues = new List<string>();

                            for(int i = 0; i < row.Cells.Count; i++)
                            {
                                string value = docServer.Document.GetText(table.Rows[rowIndex].Cells[i].ContentRange);
                                cellValues.Add(value);
                                CoreGlobalCommandManager.StartCommand(null, value);
                            }

                            CoreGlobalCommandManager.StartCommand(null, "Так, я здесь!");

                            foreach(var item in workPlaces)
                            {
                                List<PropertyInfo> itemProperties = item.GetType().GetRuntimeProperties().ToList();
                                foreach(PropertyInfo itemProperty in itemProperties)
                                {
                                    string itemPropertyValue = itemProperty.GetValue(item).ToString();
                                    string itemPropertyAutoReplaceParameterName = itemProperty.GetCustomAttribute<AutoReplaceAttribute>().ParameterName.ToString();
                                    docServer.Document.ReplaceAll(itemPropertyAutoReplaceParameterName, itemPropertyValue, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
                                }

                                table.Rows.Append();

                                var lastRow = table.Rows.Last();

                                for(int i = 0; i < lastRow.Cells.Count; i++)
                                {
                                    string valuePaste = cellValues[i];
                                    DocumentRange dr = lastRow.Cells[i].ContentRange;
                                    DocumentPosition dp = dr.Start;
                                    docServer.Document.InsertText(dp, valuePaste);
                                }
                            }

                            table.Rows.RemoveAt(table.Rows.Count - 1);

                        }
                        else
                        {
                            string piValue = pi.GetValue(document).ToString();
                            docServer.Document.ReplaceAll(piAutoReplaceParameterName, piValue, DevExpress.XtraRichEdit.API.Native.SearchOptions.None);
                        }

                    }
                    catch
                    {
                        // Видимо нет такого аттрибута у свойства.
                    }

                }

                string saveName = $@"{targetFolder}\{document.Id}.doc";
                docServer.SaveDocument(saveName, DocumentFormat.Doc);
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
