using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass.Factory
{
    public static class CarFactory
    {
        public static Car Create(int index, string mileage)
        {
            switch (index)
            {
                case 0: return new WagonR(mileage);
                case 1: return new HondaCity(mileage);
                case 2: return new InnovaCrysta(mileage);
                default: return null;
            }
        }
    }
}
