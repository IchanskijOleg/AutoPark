using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPark
{
    class Program
    {
        static void Main(string[] args)
        {
            AutoLinkedList park = new AutoLinkedList();
            park.AddFirst(new Bus(1, "Vasya", 111));
            park.AddLast(new Bus(2, "Tasya", 112));
            park.AddFirst(new Bus(3, "Masya", 113));
            park.AddFirst(new Bus(4, "Dasya", 114));
            park.AddLast(new Bus(5, "Gasya", 115));
            park.AddFirst(new Bus(6, "Zasya", 116));

            AutoLinkedList routes = new AutoLinkedList();
            routes.AddFirst(park.RemoveDataByRoute(113));
            routes.AddFirst(park.RemoveDataByRoute(116));
            routes.AddLast(park.RemoveDataByRoute(111));

            park.Print();
            Console.WriteLine("\n**************");
            routes.Print();
            //foreach (var item in park)
            //{
            //    Console.WriteLine(item);
            //}
            //IEnumerator iter = park.GetEnumerator();
            //while (iter.MoveNext()) {
            //    Console.WriteLine(iter.Current);
            //}

            Console.WriteLine("\n**************");

            LinkedList<Bus> list = new LinkedList<Bus>();
            list.AddFirst(new Bus(1, "Vasya", 111));
            list.AddLast(new Bus(2, "Tasya", 112));
            list.AddFirst(new Bus(3, "Masya", 113));
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            // List < AutoLinkedList > = List < AutoLinkedList> { new Bus(1, "Vasya", 111) };
            //Array ar;
            Console.ReadKey();
        }
    }
}
