using System;
using System.Collections.Generic;
using System.Text;

namespace LearnSeeSharp.Learn
{
    internal class LearnClasses
    {

        public class Entity
        {
            public int Id;
            public string Name;

            public void WriteName()
            {
                Console.WriteLine($"{Name} ({Id})");
            }
        }

        public class Orc : Entity
        {
            public int IQ = 3;

            public new void WriteName()
            {
                Console.WriteLine($"{Name} ({Id} - {IQ})");
            }
        }

        public class Captain : Orc
        {
            public Captain()
            {
                IQ += 2;
            }
        }

        public class Warchief : Orc
        {
            public Warchief()
            {
                IQ += 12;
            }
        }

        public class Pet : Entity
        {
            // field
            public int AantalPoten = 4;

            // property
            public int AantalKloten { get; set; } = 2;

            public int AantalKlotenGet { get; }

            public int AantalKlotenGetLikeFunction 
            { 
                get { return AantalKloten + 4; }
            }

            public int AantalKlotenGetFunction()
            {
                return AantalKloten + 4;
            }
        }



        public void Run()
        {
            var p1 = new Pet();

            p1.Name = "Pet1";
            p1.AantalKloten = 3;
            var t1 = p1.AantalKlotenGet;
            var t2 = p1.AantalKlotenGetLikeFunction;
            var t3 = p1.AantalKlotenGetFunction();

            p1.WriteName();

            var o1 = new Orc() { Name = "Orc1" };

            o1.WriteName();

            var c1 = new Captain { Name = "Captain1" };

            c1.WriteName();

            var w1 = new Warchief { Name = "Warchief1" };

            w1.WriteName();
        }
    }
}
