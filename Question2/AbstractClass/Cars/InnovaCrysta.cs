using AbstractClass.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass
{
    public class InnovaCrysta : BaseCar
    {
        public InnovaCrysta(string mileage) : base(mileage, false, "6") { }

        public override int GetHashCode()
        {
            return 2;
        }
    }
}
