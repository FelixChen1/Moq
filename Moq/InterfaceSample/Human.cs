using System;

namespace InterfaceSample
{
    class Human : IEat, IRun
    {
        public void Eat()
        {
            Console.WriteLine("Human is running...");
        }

        public void Run()
        {
            Console.WriteLine("Human is eating...");
        }
    }
}
