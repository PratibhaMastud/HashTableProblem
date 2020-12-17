using System;

namespace HAshtableDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            MyMapNod<int, string> myMapNod = new MyMapNod<int, string>(15);
            myMapNod.Add(0,"To");
            myMapNod.Add(1, "be");
            myMapNod.Add(2, "or");
            myMapNod.Add(3, "not");
            myMapNod.Add(4, "To");
            myMapNod.Add(5, "be");
            int index = Convert.ToInt32(Console.ReadLine());
            string choice1 = myMapNod.Get(index);
            Console.WriteLine("5th index values : "+ choice1);
           
            
        }
    }
}
