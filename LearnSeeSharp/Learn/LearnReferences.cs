using System;
using System.Collections.Generic;
using System.Text;

namespace LearnSeeSharp.Learn
{
    internal class LearnReferences
    {
        public class DummyClass
        {
            public int Id;
            public string Name;

            public void Change()
            {
                Id *= 2;
                Name += Name;

                Console.WriteLine($"class changed: {Id}");
                Console.WriteLine($"class changed: {Name}");
            }
        }

        public void Run()
        {
            int a = 2;

            Change(a);

            Console.WriteLine($"int original: {a}");

            float b = 2.0f;

            Change(b);

            Console.WriteLine($"float original: {b}");

            string c = "2.0f";

            Change(c);

            Console.WriteLine($"string original: {c}");

            DummyClass d = new DummyClass { Id = 4, Name = "Naam" };
            //DummyClass d = new DummyClass();
            //d.Id = 4;
            //d.Name = "Naam";

            Change(d);

            Console.WriteLine($"class original: {d.Id}");
            Console.WriteLine($"class original: {d.Name}");

            d.Change();

            Console.WriteLine($"class original: {d.Id}");
            Console.WriteLine($"class original: {d.Name}");

            DummyClass e = new DummyClass { Id = 8, Name = "Naam" };
            DummyClass f = e;
            DummyClass g = f;

            g.Change();
            f.Change();
            e.Change();

            Console.WriteLine($"class original: {g.Id}");
            Console.WriteLine($"class original: {g.Name}");

            int h = 2;
            int i = h;
            int j = i;

            Change(h);

            Console.WriteLine($"int original: {h}");
            Console.WriteLine($"int original: {i}");
            Console.WriteLine($"int original: {j}");
        }

        public void Change(int a)
        {
            a *= 2;

            Console.WriteLine($"int changed: {a}");
        }

        public void Change(float a)
        {
            a *= 2;

            Console.WriteLine($"float changed: {a}");
        }

        public void Change(string a)
        {
            a += a;

            Console.WriteLine($"string changed: {a}");
        }

        public void Change(DummyClass a)
        {
            a.Id *= 2;
            a.Name += a.Name;

            Console.WriteLine($"class changed: {a.Id}");
            Console.WriteLine($"class changed: {a.Name}");
        }
    }
}
