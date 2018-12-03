using System;

namespace Flight
{
    class Program
    {
        static void Main(string[] args)
        {
            var plain1 = new Flight("Typolev", "Typolev.txt");
            var plain2 = new Flight("Boeing", "Boeing.txt");
            var plain3 = new Flight("Airbus", "Airbus.txt");
            plain1.Start();
            plain2.Start();
            plain3.Start();
            Console.ReadLine();
        }
    }
}
