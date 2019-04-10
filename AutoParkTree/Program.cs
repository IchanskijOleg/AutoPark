using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParkTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree park = new Tree();
            park.Insert(new Bus(1, "Vasya", 114));
            park.Insert(new Bus(2, "Tasya", 112));
            park.Insert(new Bus(3, "Masya", 115));
            park.Insert(new Bus(4, "Dasya", 117));
            park.Insert(new Bus(5, "Gasya", 111));
            park.Insert(new Bus(6, "Gasya", 113));
            park.Insert(new Bus(7, "Zasya", 116));

            Node found = park.Find(112);
            if (found != null)
            {
                Console.WriteLine("Маршрут знайдений");
            }
            else
            {
                Console.WriteLine("Маршрут не знайдений");
            }
            park.Print();

            Console.ReadKey();
        }
    }
}
