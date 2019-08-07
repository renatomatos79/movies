using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BugFix
{
    public class Person
    {
        public Person(string name)
        {
            this.Name = name;
        }
        public Person(string name, DateTime birthdate) : this(name)
        {
            this.CalcAge(birthdate);
        }

        public string Name { get; set; }
        public int? Age { get; set; }
        public void CalcAge(DateTime birthdate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthdate.Year;
            if (birthdate.Date > today.AddYears(-age))
            {
                age--;
            }
            this.Age = age;
        }
    }

    public static class PersonManager
    {
        private static readonly List<Person> DB = new List<Person>();

        public static void AddPerson(string name, DateTime birthDate)
        {
            DB.Add(new Person(name, birthDate));
        }
        public static void DeletePerson(int id)
        {
            if (DB.Count >= id)
            {
                DB.RemoveAt(id);
            }
        }
        public static List<Person> People { get { return DB; } }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Adding people...");
            PersonManager.AddPerson("Renato", new DateTime(1979, 6, 23));
            PersonManager.AddPerson("Vanessa", new DateTime(1978, 5, 5));
            PersonManager.People.ToList().ForEach(p =>
            {
                Console.WriteLine($"{p.Name}, Age {p.Age}");
            });

            Console.WriteLine("Removing person at index 0...");
            PersonManager.DeletePerson(0);
            PersonManager.People.ToList().ForEach(p =>
            {
                Console.WriteLine($"{p.Name}, Age {p.Age}");
            });

            Console.ReadLine();
        }
    }
}
