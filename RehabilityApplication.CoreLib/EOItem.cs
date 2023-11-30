using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehabilityApplication.CoreLib
{
    public class EOItem
    {
        [ExcelColumnItem(ChapterName = "Заявка", ColumnName = "Номер заявки")]
        [DisplayName("Номер заявки")]
        public string numberApplication { get; set; }

        [ExcelColumnItem(ChapterName = "Завка", ColumnName = "СНИЛС")]
        [DisplayName("СНИЛС")]
        public string snils { get; set; }

        [ExcelColumnItem(ChapterName = "Заявка", ColumnName ="ФИО")]
        [DisplayName("ФИО")]
        public string FIO { get; set; }

        
        ///
        [ExcelColumnItem(ChapterName = "Реестр направлений", ColumnName = "Дата реестра")]
        [DisplayName("Дата реестра")]
        public string DateReestr { get; set; }
        [ExcelColumnItem(ChapterName = "Реестр направлений", ColumnName = "Номер реестра")]
        [DisplayName("Номер реестра")]
        public string NumberReestr { get; set; }
        [ExcelColumnItem(ChapterName = "Направление", ColumnName = "ID")]
        [DisplayName("ID")]
        public string ID { get; set; }

        public EOItem() { }

    }

    public class EOHeader : EOItem { }  
}
