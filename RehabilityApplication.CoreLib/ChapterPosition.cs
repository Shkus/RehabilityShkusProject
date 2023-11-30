using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehabilityApplication.CoreLib
{
    public class ChapterPosition
    {
        public int LeftColumnIndex { get; set; } = -1;
        public int RightColumnIndex { get; set; } = -1;
        public int RowIndex { get; set; } = -1;
        public bool IsFounded { get; set; } = false;
    }

    public class ColumnPosition
    {
        public int ColumnIndex { get; set; } = -1;
        public int RowIndex { get; set; } = -1;
        public bool IsFounded { get; set; } = false;
    }
}
