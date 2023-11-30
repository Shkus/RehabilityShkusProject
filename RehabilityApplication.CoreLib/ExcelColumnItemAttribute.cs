using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehabilityApplication.CoreLib
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ExcelColumnItemAttribute : Attribute
    {
        public ExcelColumnItemAttribute() { }

        public int HeaderColumnIndex { get; set; }  = -1;
        public int HeaderRowIndex { get; set; } = -1;
        public string ChapterName { get; set; } = string.Empty;
        public string ColumnName { get; set; } = string.Empty;

    }
}
