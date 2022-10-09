using System;
using System.Collections.Generic;
using System.Text;

namespace LearnSeeSharp.Learn
{
    internal class LearnRandom
    {
        public void Initialize()
        {
            // 'willekeurig' seed, gebasseerd op de tijd
            // zal altijd andere waardes geven
            var r1 = new Random();

            // zal altijd andere waardes geven
            Console.WriteLine("random seed - zal altijd andere waardes geven");
            Console.WriteLine(r1.Next(1000));
            Console.WriteLine(r1.Next(1000));
            Console.WriteLine(r1.Next(1000));
            Console.WriteLine(r1.Next(1000));
            Console.WriteLine(r1.Next(1000));
            Console.WriteLine(r1.Next(1000));

            // vaste seed
            // zal altijd dezelfde waardes geven
            var r2 = new Random(1000);

            // zal altijd dezelfde waardes geven
            Console.WriteLine("");
            Console.WriteLine("fixed seed - zal altijd dezelfde waardes geven");
            Console.WriteLine(r2.Next(1000));
            Console.WriteLine(r2.Next(1000));
            Console.WriteLine(r2.Next(1000));
            Console.WriteLine(r2.Next(1000));
            Console.WriteLine(r2.Next(1000));
            Console.WriteLine(r2.Next(1000));
        }
    }
}
