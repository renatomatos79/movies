using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass.Cars
{
    public class BaseCar : Car
    {
        private string _mileage;

        public BaseCar(string mileage, bool isSedan, string seats) : base(isSedan, seats)
        {
            _mileage = mileage;
        }

        public override string getMileage()
        {
            return $"{_mileage} kmpl";
        }

        public override string ToString()
        {
            var name = this.GetType().Name;
            var prefixSedan = this.getIsSedan() ? "is" : "is not";

            return $"A {name} {prefixSedan} Sedan, is {getSeats()} - seater, and has a mileage of around {getMileage()}";
        }
    }
}
