using System;
using System.Collections.Generic;
using System.Text;

namespace LearnSeeSharp.Learn
{
    internal class LearnCast
    {
        public void Run()
        {
            var _float1 = 100.2;
            
            // verliest getallen na de comma
            // 100
            var _int1 = (int)_float1;

            // 100
            var _float2 = (float)_int1;

            var _int2 = 7456546845;

            byte _byte1 = (byte)_int2;
        }
    }
}
