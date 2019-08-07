using AbstractClass.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass
{
    class Program
    {
        public static int ToInt(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                s = "0";
            }

            int result;
            if (int.TryParse(s, out result))
            {
                return result;
            }
            return 0;
        }

        static void Main(string[] args)
        {
            var index = Console.ReadLine();
            var mileage = Console.ReadLine();
            var idx = ToInt(index);
            var car = CarFactory.Create(idx, mileage);
            if (car == null)
            {
                Console.WriteLine("Car not found! You must use 0,1,2 to the first line!");
            }
            else
            {
                Console.WriteLine(car.ToString());
            }

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Press Enter to Finish");
            Console.ReadLine();
        }
    }
}
