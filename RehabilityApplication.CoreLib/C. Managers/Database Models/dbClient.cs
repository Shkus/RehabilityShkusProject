using System;

namespace RehabilityApplication.CoreLib
{
    public class dbClient
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public bool IsSelected { get; set; }
        public string Snils { get; set; }
        public dbClient() { }
    }
}
