using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Spreadsheet;

namespace RehabilityApplication.CoreLib
{
    public static class ExcelFileManager
    {
        private static string excelFileName;
        public static List<ExcelRowItem> Data = new List<ExcelRowItem>();

        public static void OpenExcelFile()
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Excel-файл|*.xlsx;*.xls"
            };

            DialogResult dr = ofd.ShowDialog();

            if(dr == DialogResult.OK)
            {
                CustomFlyoutDialog.ShowForm(null, null, new ucOkDialog("Файл открыт!"));
                excelFileName = ofd.FileName;

                Task.Run(() =>
                {
                    GetDataFromExcelFile(excelFileName);
                });
            }
        }

        public static void GetDataFromExcelFile(string excelFilePath)
        {
            Data.Clear();

            Workbook wb = new Workbook();
            wb.LoadDocument(excelFilePath);
            Worksheet ws = wb.Worksheets[0];
            string searchTextPattern = "СНИЛС";

            int startRowIndex = 0;
            bool IsStartRowIndexFounded = false;

            // A-Z = 28
            for(int i = 0; i < 100; i++)
            {
                if(IsStartRowIndexFounded)
                {
                    break;
                }

                for(int j = 0; j < 28; j++)
                {
                    CoreGlobalCommandManager.StartCommand(CommandType.Text, $"Ячейка [{i};{j}] = {ws.Cells[i, j].Value}");

                    if(ws.Cells[i, j].Value.ToString().Trim().ToUpper() == searchTextPattern.ToUpper())
                    {
                        startRowIndex = j;
                        IsStartRowIndexFounded = true;
                        break;
                    }
                }
            }

            CellRange range = ws.GetUsedRange();

            int lastRowIndex = range.BottomRowIndex;

            for(int k = startRowIndex + 1; k <= lastRowIndex; k++)
            {
                Data.Add(new ExcelRowItem()
                {
                    Date = ws.Cells[k, 1].Value.ToString(),
                    Snils = ws.Cells[k, 3].Value.ToString(),
                    Address = ws.Cells[k, 15].Value.ToString(),
                    ContractNumber = ws.Cells[k, 7].Value.ToString(),
                    ContractStartDate = ws.Cells[k, 6].Value.ToString(),
                    DirectionDate = ws.Cells[k, 12].Value.ToString(),
                    DirectionNumber = ws.Cells[k, 13].Value.ToString(),
                    FIO = ws.Cells[k, 4].Value.ToString(),
                    IsPaliative = ws.Cells[k, 5].Value.ToString(),
                });

            }

            // Read values

            // List<ExcelItem>
        }

    }


    public class ExcelRowItem
    {
        [Description("Дата")]
        public string Date { get; set; }
        [Description("СНИЛС")]
        public string Snils { get; set; }
        [Description("ФИО")]
        public string FIO { get; set; }
        [Description("Паллиатив")]
        public string IsPaliative { get; set; }
        [Description("Дата ГК")]
        public string ContractStartDate { get; set; }
        [Description("Номер ГК")]
        public string ContractNumber { get; set; }
        [Description("Направление|Дата")]
        public string DirectionDate { get; set; }
        [Description("Направление|Номер")]
        public string DirectionNumber { get; set; }
        [Description("Адрес")]
        public string Address { get; set; }
    }
}
