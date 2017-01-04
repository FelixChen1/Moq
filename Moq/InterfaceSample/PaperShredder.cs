using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceSample
{
    class PaperShredder : IEat
    {
        public void Eat()
        {
            Console.WriteLine("Paper shredder is eating paper...");
        }
    }
}
