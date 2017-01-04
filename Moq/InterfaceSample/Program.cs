using System;
using System.Collections.Generic;

namespace InterfaceSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Human man = new Human();
            IEat foodie = man as IEat;
            foodie.Eat();

            IRun runner = man as IRun;
            runner.Run();

            Console.WriteLine("--------------------------------");

            List<IEat> foodies = new List<IEat>
            {
                new Human(),
                new PaperShredder()
            };
            foodies.ForEach(f => f.Eat());

            List<IRun> runners = new List<IRun>
            {
                new Human(),
                new Car()
            };
            runners.ForEach(r => r.Run());
        }
    }
}
