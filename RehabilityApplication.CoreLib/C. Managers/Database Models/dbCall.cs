using System;

namespace RehabilityApplication.CoreLib
{
    public class dbCall
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Date { get; set; }
        public string Comment { get; set; }
        public string Telephone { get; set; }
        public string ClientId { get; set; }
        public dbCall() { }
    }
}
