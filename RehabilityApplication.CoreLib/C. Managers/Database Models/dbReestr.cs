using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehabilityApplication.CoreLib
{
    public class dbReestr : ITree
    {
        public string Id { get; set; } = Guid.NewGuid().ToString(); 
        public string ParentId { get; set; }
        public string Name { get; set; }

    }
}
