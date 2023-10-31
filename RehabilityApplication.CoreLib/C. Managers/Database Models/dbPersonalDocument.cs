using System;

namespace RehabilityApplication.CoreLib
{
    public class dbPersonalDocument
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string ClientId { get; set; }
        public string DepartmentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Daddyname { get; set; }
        public string Serial { get; set; }
        public string Number { get; set; }
        public string Department { get; set; }
        public string Date { get; set; }
        public string RegistrationAddress { get; set; }
        public string Gender { get; set; }
        public string PlaceFrom { get; set; }
    }
}
