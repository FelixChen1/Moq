using System;

namespace InterfaceSample
{
    class Car : IRun
    {
        public void Run()
        {
            Console.WriteLine("Car is running...");
        }
    }
}
