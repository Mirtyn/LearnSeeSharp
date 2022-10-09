using System;
using System.Collections.Generic;
using System.Text;

namespace LearnSeeSharp.Learn
{
    internal class LearnArrays
    {
        class DummyClass
        {
            public int Id;
            public string Name;
        }

        public void Initialize()
        {
            var a = new int[2];

            var b = new string[2];

            var c = new DummyClass[2];

            var d = new[] { 1, 2 };

            // werkt niet omdat 1 een int is
            // var e = new[] { string.Empty, 1 };

            var e = new[] { string.Empty, "1" };

            // arrays van objecten zijn geen goed idee!!!
            var f = new object[] { string.Empty, 1 };

            // dit zal crashen want f[0] is geen int maar en string
            //var t = (int)f[0] * 2;

            var g = new object[2];
            f[0] = 1;
            f[1] = "steven";
        }

        public void Length()
        {
            var a = new int[2];

            var t = a.Length;
        }
    }
}
