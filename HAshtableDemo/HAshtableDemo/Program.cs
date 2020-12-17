using System;

namespace HAshtableDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            MyMapNod<int, string> myMapNod = new MyMapNod<int, string>(15);
            /*myMapNod.Add(0, "To");
            myMapNod.Add(1, "be");
            myMapNod.Add(2, "or");
            myMapNod.Add(3, "not");
            myMapNod.Add(4, "To");
            myMapNod.Add(5, "be");
            int index = Convert.ToInt32(Console.ReadLine());
            string choice1 = myMapNod.Get(index);
            Console.WriteLine("5th index values : " + choice1);*/
            string phrase = "Paranoids are not paranoid because they are paranoid but because they keep putting themselves deliberately into paranoid avoidable situations";
            string[] words = phrase.Split(' ');
            int a = 1;
            foreach (var word in words)
            {
                myMapNod.Add(a, word);
                a++;
            }
            int index = 18;
            string choice = myMapNod.Get(index);
            Console.WriteLine("{0}th index values : is {1}",index,choice);
            int index2 = 15;
            string choice2 = myMapNod.Get(index2);
            Console.WriteLine("{0}th index values : is {1}", index2, choice2);
            myMapNod.Remove(index);


        }
    }
}
