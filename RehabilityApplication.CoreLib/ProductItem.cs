using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehabilityApplication.CoreLib
{
    public class ProductItem
    {
        [ExcelColumnItem(ChapterName = "", ColumnName = "Город")]
        [DisplayName("Город")]
        public string City { get; set; }
        [ExcelColumnItem(ChapterName = "Молочные продукты", ColumnName = "Молоко")]
        [DisplayName("Молоко")]
        public string Milk { get; set; }
        [ExcelColumnItem(ChapterName = "Молочные продукты", ColumnName = "Масло")]
        [DisplayName("Масло")]
        public string Butter { get; set; }
        [ExcelColumnItem(ChapterName = "Хлебобулочные изделия", ColumnName = "Батон")]
        [DisplayName("Батон")]
        public string Loaf { get; set; }
        [ExcelColumnItem(ChapterName = "Сладкое", ColumnName = "Сахар")]
        [DisplayName("Сахар")]
        public string Sugar { get; set; }
        [ExcelColumnItem(ChapterName = "Фрукты", ColumnName = "Бананы")]
        [DisplayName("Бананы")]
        public string Banana { get; set; }

        public ProductItem() { }
    }

    public class ProductHeader : ProductItem { }


    public class EoFillItem
    {
        [ExcelColumnItem(ChapterName = "Направление", ColumnName = "Дата")]
        public string DirectName { get; set; }
        [ExcelColumnItem(ChapterName = "Направление", ColumnName = "Номер")]
        public string DirectNumber { get; set; }
        [ExcelColumnItem(ChapterName = "Заявка", ColumnName = "СНИЛС")]
        public string Snils { get; set; }
        [ExcelColumnItem(ChapterName = "Заявка", ColumnName = "ФИО")]
        public string Fio { get; set; }
        [ExcelColumnItem(ChapterName = "Акт приема-передачи", ColumnName = "Кол-во по акту")]
        public string Count { get; set; }
        [ExcelColumnItem(ChapterName = "Акт приема-передачи", ColumnName = "Цена за ед., руб.")]
        public string Cost { get; set; }
    }

    public class EoFillItemHeader : EoFillItem { }
}
