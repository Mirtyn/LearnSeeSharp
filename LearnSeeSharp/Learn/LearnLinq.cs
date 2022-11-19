using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnSeeSharp.Learn
{
    internal class LearnLinq
    {
        class DummyClass
        {
            public int Id;
            public string Name;
        }

        public void Run()
        {
            var c = new List<DummyClass> { new DummyClass { Id = 0, Name = "Steven" }, new DummyClass { Id = 1, Name = "Mirtyn" }, new DummyClass { Id = 4, Name = "Moemoe" } };

            var lowtoHighName = c.OrderBy(o => o.Name);

            var hightolowName = c.OrderByDescending(o => o.Name);

            var r = c.SingleOrDefault(o => o.Id == 3);

            var s = c.Single(o => o.Id == 0);

            var t = c.Max(o => o.Id);

            var u = c.Min(o => o.Id);

            var v = c.Where(o => o.Name.StartsWith("M")).ToList();

            var w = c.First();

            var x = c.Last();

            var d = new List<int> { 1, 2, 4, 8, 3, 22 };

            var e = new List<int> { 17, 32, 74, 98, 13, 222 };

            d.AddRange(e);

            d = d.OrderBy(o => o).ToList();

            d.RemoveAll(o => o == 98);

            var y = c.RemoveAll(o => o.Name.StartsWith("M"));
        }
    }
}
