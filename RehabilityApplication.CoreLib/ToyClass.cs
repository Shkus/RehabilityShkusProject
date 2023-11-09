using System;
using System.Collections.Generic;
using System.Linq;

namespace RehabilityApplication.CoreLib
{
    public class ToyClass
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public virtual void Sold(List<Product> products)
        {
            Console.WriteLine("Покупка");

            if(this is DollClass)
            {
                (this as DollClass).Smile();
            }

            if(this is CarClass)
            {
                (this as CarClass).Parking();
            }
        }

        public ToyClass() { }
        public ToyClass(CarClass car) 
        {
            this.Id = car.Id;
        }
        public ToyClass(string Name) { }
        public ToyClass(string Name, string Id) { }

    }

    public class DollClass : ToyClass
    {
        public string Dress { get; set; }

        public void Plakat()
        {
            Console.WriteLine("Плачь");
        }

        public override void Sold(List<Product> products)
        {
            var shkafs = products.Where(t => t is Shkaf);

            foreach(var item in shkafs)
            {
                item.Prodat(10000);
            }

            Console.WriteLine( "");
        }

        internal void Smile()
        {

        }

        public DollClass()
        {
        }
    }

    public class CarClass : ToyClass
    {
        public string Engine { get; set; }

        public void Ehat()
        {
            Console.WriteLine("Едем!");

        }

        internal void Parking()
        {

        }

        public override void Sold(List<Product> products)
        {
            var doors = products.Where(t => t is Door);

            foreach(var item in doors)
            {
                item.Prodat(7000);
            }

            Console.WriteLine( "");
        }

        public CarClass()
        {

        }
        public CarClass(CarClass car1):base(car1)
        {
        }
    }


    public class Product
    {
        public void Prodat(int Cost)
        {

        }
    }

    public class Shkaf: Product
    {

    }

    public class  Door: Product
    {
        
    }
}
