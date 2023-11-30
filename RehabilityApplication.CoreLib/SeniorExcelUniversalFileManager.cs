using DevExpress.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RehabilityApplication.CoreLib
{
    public static class SeniorExcelUniversalFileManager<R, H> where R : new()
    {
        public static string ExcelFileName = string.Empty;

        public static List<R> Data = new List<R>();

        public static void OpenExcelFile(H header)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Excel-файлы|*.xlsx;*.xls",
                InitialDirectory = "D:\\!!! Базовые элементы\\Рабочий стол"
            };

            DialogResult dr = ofd.ShowDialog();

            if(dr == DialogResult.OK)
            {
                ExcelFileName = ofd.FileName;
                GetDataFromExcel(header);
                // GetDataFromExcel
            }
        }

        public static void GetDataFromExcel(H header)
        {
            // 1. Данные для header
            GetHeaderData(header);


            // 2. Чтение данных
            GetTableData(header);

            CoreGlobalCommandManager.StartReceiveDataCommand(ExcelReadDataCommandType.GetDataComplete, Data);
        }

        private static void GetTableData(H header)
        {
            Data.Clear();

            Workbook wb = new Workbook();
            wb.LoadDocument(ExcelFileName);
            Worksheet ws = wb.Worksheets[0];

            CellRange range = ws.GetUsedRange();

            int lastRowIndex = range.BottomRowIndex;


            var properties = header.GetType().GetRuntimeProperties().ToList();

            var firstHeaderProperty = properties.First();
            var firstHeaderPropertyValue = firstHeaderProperty.GetValue(header).ToString();

            var splitedHeaderValue = firstHeaderPropertyValue.Split('|', StringSplitOptions.TrimEntries);
            var startRowIndexStr = splitedHeaderValue[0];

            int startRowIndex = -1;
            int.TryParse(startRowIndexStr, out startRowIndex);

            startRowIndex = startRowIndex + 1;
            //startRowIndex ++;
            //startRowIndex +=1;

            for(int i = startRowIndex; i <= lastRowIndex; i++)
            {
                R item = new R();

                var itemProperties = item.GetType().GetRuntimeProperties().ToList();

                foreach(var property in itemProperties)
                {
                    int propertyIndex = itemProperties.IndexOf(property);
                    var headerCurrentProperty = properties[propertyIndex];

                    var headerCurrentPropertyValue = headerCurrentProperty.GetValue(header).ToString();
                    //var splitedValue = headerCurrentPropertyValue.Split('|', StringSplitOptions.TrimEntries).Last();
                    var splitedValue = headerCurrentPropertyValue.Split('|', StringSplitOptions.TrimEntries);

                    var ColumnIndexStr = splitedValue[1]; // splitedHeaderValue.Last();

                    int columnIndex = -1;
                    int.TryParse(ColumnIndexStr, out columnIndex);

                    property.SetValue(item, ws.Cells[i, columnIndex].Value.ToString());
                }

                Data.Add(item);
            }

        }

        private static void GetHeaderData(H header)
        {
            Workbook wb = new Workbook();
            wb.LoadDocument(ExcelFileName);
            Worksheet ws = wb.Worksheets[0];

            var properties = header.GetType().GetRuntimeProperties().ToList();

            foreach(var property in properties)
            {
                string propertyName = property.Name;

                var propAttribute = (ExcelColumnItemAttribute)property.GetCustomAttributes().FirstOrDefault(t => t is ExcelColumnItemAttribute);

                var searchChapterName = propAttribute.ChapterName;
                var searchColumnName = propAttribute.ColumnName;

                var chapterPosition = new ChapterPosition();
                var columnPosition = new ColumnPosition();

                if(searchChapterName != string.Empty)
                {
                    // Поиск диапазона колонок для раздела
                    chapterPosition = FindChapterRange(ws, searchChapterName);
                }

                if(chapterPosition.IsFounded)
                {
                    // Ищем колонку в найденном диапазоне
                    columnPosition = FindColumnPosition(ws, searchColumnName, chapterPosition);
                }
                else
                {
                    // Бежим по всей таблице и ищем любой первый ColumnName
                    columnPosition = FindColumnPosition(ws, searchColumnName);
                }

                property.SetValue(header, $@"{columnPosition.RowIndex.ToString()}|{columnPosition.ColumnIndex.ToString()}");
            }
        }

        private static ColumnPosition FindColumnPosition(Worksheet ws, string pattern)
        {
            ColumnPosition columnPosition = new ColumnPosition();

            // Бробегаем по индексам строк
            for(int i = 0; i < 1000; i++)
            {
                if(columnPosition.IsFounded)
                {
                    break;
                }

                for(int j = 0; j < 1000; j++)
                {
                    if(ws.Cells[i, j].Value.ToString().Trim().ToUpper() == pattern.ToUpper())
                    {
                        if(ws.Cells[i, j].IsMerged)
                        {
                            var cellRanges = ws.Cells[i, j].GetMergedRanges();
                            var mergedRange = cellRanges[0];
                            var bottomRowIndex = mergedRange.BottomRowIndex;
                            columnPosition = new ColumnPosition() { RowIndex = bottomRowIndex, ColumnIndex = j, IsFounded = true };
                        }
                        else
                        {
                            columnPosition = new ColumnPosition() { RowIndex = i, ColumnIndex = j, IsFounded = true };
                        }

                        //var mergedRange = ws.Cells[i,j].GetMergedRanges().First();

                        break;
                    }
                }
            }

            return columnPosition;
        }

        private static ColumnPosition FindColumnPosition(Worksheet ws, string pattern, ChapterPosition chapterRegion)
        {
            ColumnPosition columnPosition = new ColumnPosition();

            int rowIndex = chapterRegion.RowIndex + 1;

            for(int i = chapterRegion.LeftColumnIndex; i <= chapterRegion.RightColumnIndex; i++)
            {
                if(ws.Cells[rowIndex, i].Value.ToString().Trim().ToUpper() == pattern.ToUpper())
                {
                    columnPosition = new ColumnPosition() { RowIndex = rowIndex, ColumnIndex = i };
                    break;
                }
            }

            return columnPosition;
        }



        private static ChapterPosition FindChapterRange(Worksheet ws, string pattern)
        {
            ChapterPosition range = new ChapterPosition();

            // Бробегаем по индексам строк
            for(int i = 0; i < 1000; i++)
            {
                if(range.IsFounded)
                {
                    break;
                }

                for(int j = 0; j < 1000; j++)
                {
                    if(ws.Cells[i, j].Value.ToString().Trim().ToUpper() == pattern.ToUpper())
                    {
                        var mergedRange = ws.Cells[i, j].GetMergedRanges()[0];
                        //var mergedRange = ws.Cells[i,j].GetMergedRanges().First();
                        var leftColumnIndex = mergedRange.LeftColumnIndex;
                        var rightColumnIndex = mergedRange.RightColumnIndex;
                        var bottomRowIndex = mergedRange.BottomRowIndex;
                        range = new ChapterPosition() { RowIndex = bottomRowIndex, LeftColumnIndex = leftColumnIndex, RightColumnIndex = rightColumnIndex, IsFounded = true };

                        break;

                    }
                }
            }

            return range;
        }
    }
}
