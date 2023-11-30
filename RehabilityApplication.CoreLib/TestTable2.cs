using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehabilityApplication.CoreLib
{
    public class TableItem2
    {
        [ExcelColumnItem(ChapterName = "Получатель", ColumnName = "ФИО")]
        [DisplayName("ФИО")]
        public string FIO { get; set; }
        [ExcelColumnItem(ChapterName = "Получатель", ColumnName = "СНИЛС")]
        [DisplayName("СНИЛС")]
        public string Snils { get; set; }
        [ExcelColumnItem(ChapterName = "Товар", ColumnName = "Тип")]
        [DisplayName("Тип")]
        public string ProductType { get; set; }
        [ExcelColumnItem(ChapterName = "Товар", ColumnName = "Модель")]
        [DisplayName("Модель")]
        public string ProductModel { get; set; }
        [ExcelColumnItem(ChapterName = "Адрес", ColumnName = "Почтовый индекс")]
        [DisplayName("Почтовый индекс")]
        public string PostalIndex { get; set; }
    }

    public class TableItem2Header : TableItem2 { }
}
