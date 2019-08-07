using AbstractClass.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass
{
    public class WagonR : BaseCar
    {
        public WagonR(string mileage) : base(mileage, false, "4") { }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}
