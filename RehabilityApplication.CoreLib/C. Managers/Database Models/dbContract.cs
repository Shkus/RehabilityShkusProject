using System;

namespace RehabilityApplication.CoreLib
{
    public class dbContract : ITree
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; }

        public string ParentId { get; set; } = string.Empty;
    }
}
