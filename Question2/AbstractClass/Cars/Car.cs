using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass
{
    public abstract class Car
    {
        private bool _isSedan;
        private string _seats;
        public Car(bool isSedan, string seats)
        {
            _isSedan = isSedan;
            _seats = seats;
        }
        public bool getIsSedan()
        {
            return _isSedan;
        }
        public string getSeats()
        {
            return _seats;
        }
        public abstract string getMileage();
    }
}
