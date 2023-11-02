using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehabilityApplication.CoreLib
{
    public class dbClientInReestr: ITree
    {
        public string Name { get; set; }

        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string ParentId { get; set; } = string.Empty;
    }
}
