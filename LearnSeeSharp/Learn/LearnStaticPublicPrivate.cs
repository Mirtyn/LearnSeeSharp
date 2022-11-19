using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace LearnSeeSharp.Learn
{
    [StructLayout(LayoutKind.Sequential)]
    public class OrcNonStatic
    {
        public string Name;

        public int Life;

        public int MinLife = 10;

        public int MaxLife = 20;

        public OrcNonStatic()
        {
            var random = new Random();

            Name = "Unknown";

            Life = random.Next(MinLife, MaxLife);
        }

        public override string ToString()
        {
            return Life.ToString();
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public class OrcStatic
    {
        public string Name;

        protected static string DefaultName = "Unknown";

        public int Life;

        protected static int MinLife = 10;

        protected static int MaxLife = 20;

        public OrcStatic()
        {
            var random = new Random();

            Name = OrcStatic.DefaultName;

            Life = random.Next(OrcStatic.MinLife, OrcStatic.MaxLife);
        }

        public override string ToString()
        {
            return Life.ToString();
        }
    }

    public class OrcBoss : OrcStatic
    {

        //private static string DefaultName = "Unknown";

        public OrcBoss()
        {
            var random = new Random();

            Name = OrcStatic.DefaultName;

            Life = random.Next(OrcStatic.MinLife, OrcStatic.MaxLife);
        }
    }

    public class Orcus
    {
        public class EntryPublic
        {
            public int Id;
        }

        private class EntryPrivate
        {
            public int Id;
        }

        public Orcus()
        {
            var entryPrivate = new EntryPrivate();
        }
    }

    public class ScreenResolution
    {
        public int Width;
        public int Height;

        public static ScreenResolution DefaultScreenResolution = new ScreenResolution { Width = 1024, Height = 800 };
    }

    public class LearnStaticPublicPrivate
    {
        public ScreenResolution DefaultScreenResolution = new ScreenResolution { Width = 1024, Height = 800 };

        public void Run()
        {
            var orc1 = new OrcNonStatic();
            var orc2 = new OrcNonStatic();
            var orc3 = new OrcNonStatic();
            var orc4 = new OrcNonStatic();

            var min = orc4.MinLife;

            var sizeOrc1 = Marshal.SizeOf(orc1.GetType());
            var sizeOrc2 = Marshal.SizeOf(orc2.GetType());
            var sizeOrc3 = Marshal.SizeOf(orc3.GetType());
            var sizeOrc4 = Marshal.SizeOf(orc4.GetType());

            var orcStatic1 = new OrcStatic();
            var orcStatic2 = new OrcStatic();
            var orcStatic3 = new OrcStatic();
            var orcStatic4 = new OrcStatic();

            //var minStatic = OrcStatic.MinLife;

            var sizeOrcStatic1 = Marshal.SizeOf(orcStatic1.GetType());
            var sizeOrcStatic2 = Marshal.SizeOf(orcStatic2.GetType());
            var sizeOrcStatic3 = Marshal.SizeOf(orcStatic3.GetType());
            var sizeOrcStatic4 = Marshal.SizeOf(orcStatic4.GetType());

            var entryPublic = new Orcus.EntryPublic();

            //var entryPrivate = new Orcus.EntryPrivate();

            var screenResolution1 = new ScreenResolution { Width = 2048, Height = 1600 };
            var screenResolution2 = new ScreenResolution { Width = 1024, Height = 800 };

            SetScreenResolution1(screenResolution1);

            SetScreenResolution1(null);
        }

        public void SetScreenResolution1(ScreenResolution resolution)
        {
            if (resolution == null)
            {
                resolution = new ScreenResolution { Width = 800, Height = 600 };
            }
        }

        public void SetScreenResolution2(ScreenResolution resolution)
        {
            if (resolution == null)
            {
                resolution = new ScreenResolution { Width = 800, Height = 600 };
            }
        }

        public void SetScreenResolution3(ScreenResolution resolution)
        {
            if (resolution == null)
            {
                resolution = new ScreenResolution { Width = 800, Height = 600 };
            }
        }

        public void SetScreenResolution4(ScreenResolution resolution)
        {
            if (resolution == null)
            {
                resolution = new ScreenResolution { Width = 800, Height = 600 };
            }
        }

        public void SetScreenResolution5(ScreenResolution resolution)
        {
            if (resolution == null)
            {
                resolution = new ScreenResolution { Width = 800, Height = 600 };
            }
        }

        public void SetScreenResolution6(ScreenResolution resolution)
        {
            if (resolution == null)
            {
                resolution = ScreenResolution.DefaultScreenResolution;
            }
        }

        public void SetScreenResolution7(ScreenResolution resolution)
        {
            if (resolution == null)
            {
                resolution = ScreenResolution.DefaultScreenResolution;
            }
        }

        public void SetScreenResolution8(ScreenResolution resolution)
        {
            if (resolution == null)
            {
                resolution = ScreenResolution.DefaultScreenResolution;
            }
        }

        public void SetScreenResolution9(ScreenResolution resolution)
        {
            if (resolution == null)
            {
                resolution = ScreenResolution.DefaultScreenResolution;
            }
        }

        public void SetScreenResolution10(ScreenResolution resolution)
        {
            if (resolution == null)
            {
                resolution = this.DefaultScreenResolution;
            }
        }
    }

    public class zezataztaztaz
    {
        public void func()
        {
            var t = new LearnStaticPublicPrivate();

            var tt = t.DefaultScreenResolution;
        }
        public void func2()
        {
            var tt = ScreenResolution.DefaultScreenResolution;
        }
    }
}
