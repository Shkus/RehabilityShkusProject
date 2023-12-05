using System;
using System.Collections.Generic;
using System.Drawing;

namespace RehabilityApplication.CoreLib
{
    public class ResumeItem: ITemplatable, IUniqueIdentificator
    {
        public string Id { get; set; } = Guid.NewGuid().ToString(); 
        [AutoReplace("#FIO#")]
        public string FIO { get; set; }
        [AutoReplace("#POST#")]
        public string Post { get; set; }   
        [AutoReplace("#BIRTHDAY#")]
        public string Birthday { get; set; }
        [AutoReplace(ParameterName: "#IMG#")]
        public Bitmap Avatar { get; set; }
        [AutoReplace(isThisInstanceAsList: true, ParameterName: "")]
        public List<WorkPlaceItem> WorkPlaces { get; set; } = new List<WorkPlaceItem>();
        public string Template { get; set; } = $@"D:\!!! Базовые элементы\Рабочий стол\Шаблоны\Resume.docx";
    }

    public class WorkPlaceItem
    {
        [AutoReplace("#WORKPLACE#")]
        public string Workplace { get; set; }
        [AutoReplace("#POSTBEFORE#")]
        public string Postbefore { get; set; }
        [AutoReplace("#DUTY#")]
        public string Duty { get; set; }
        [AutoReplace("#STARTDATE#")]
        public string StartDate { get; set; }
        [AutoReplace("#ENDDATE#")]
        public string EndDate { get; set; }
    }

    public interface ITemplatable
    {
        public string Template { get; set; }
    }
    public interface IUniqueIdentificator
    {
        public string Id { get; set; }
    }




    public class ActItem : ITemplatable, IUniqueIdentificator
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [AutoReplace("#FIO#")]
        public string FIO { get; set; }
        [AutoReplace("#SNILS#")]
        public string Snils { get; set; }
        [AutoReplace("#BIRTHDAY#")]
        public string Birthday { get; set; }
        [AutoReplace(ParameterName: "#CODE#")]
        public Bitmap Code { get; set; }
        [AutoReplace(isThisInstanceAsList: true, ParameterName: "")]
        public List<AddressItem> Addresses { get; set; } = new List<AddressItem>();
        public string Template { get; set; } = $@"D:\!!! Базовые элементы\Рабочий стол\Шаблоны\Doc2.docx";
    }

    public class AddressItem
    {
        [AutoReplace("#CITY#")]
        public string City { get; set; }
        [AutoReplace("#STREET#")]
        public string Street { get; set; }
        [AutoReplace("#HOUSE#")]
        public string House { get; set; }
        [AutoReplace("#APARTAMENT#")]
        public string Apartment { get; set; }
        [AutoReplace("#COUNT#")]
        public string Count { get; set; }
    }




}
