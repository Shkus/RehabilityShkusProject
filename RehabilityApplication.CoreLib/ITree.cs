using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehabilityApplication.CoreLib
{
    public interface ITree
    {
        string Id { get; set; }
        string Name { get; set; }
        string ParentId { get; set; }
    }
}
