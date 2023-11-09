using System;
using System.ComponentModel;

namespace RehabilityApplication.CoreLib
{
    public class dbCall
    {
        [DisplayName("Идентификатор")]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [DisplayName("Дата")]
        public string Date { get; set; }
        [DisplayName("Коментарий")]
        public string Comment { get; set; }
        [DisplayName("Телефон")]
        public string Telephone { get; set; }
        [DisplayName("Клиент Id")]
        public string ClientId { get; set; }
        [DisplayName("Выделен?")]
        public bool IsSelected { get; set; }
        public dbCall() { }
    }
}
