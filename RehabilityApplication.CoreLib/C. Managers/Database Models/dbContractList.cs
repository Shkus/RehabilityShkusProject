using System;

namespace RehabilityApplication.CoreLib
{
    public class dbContractList : ITree
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string ParentId { get; set; }

        public string Name { get; set; }  
    }
}
