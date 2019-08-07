using AbstractClass.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass
{
    public class HondaCity : BaseCar
    {
        public HondaCity(string mileage) : base(mileage, true, "4") { }
        
        public override int GetHashCode()
        {
            return 1;
        }
    }
}
