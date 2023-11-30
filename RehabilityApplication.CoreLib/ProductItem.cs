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
}
