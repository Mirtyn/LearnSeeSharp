using System;
using System.Collections.Generic;
using System.Text;

namespace LearnSeeSharp.Learn
{
    internal class LearnEnums
    {
        public enum DoorStatus : int
        {
            Open,
            Closed,
            Broken = 888,
            Stupid = 1024,
            BrokenAndStupid = 1912,
        };

        public class DoorBool
        {
            // true == open
            // false == closed
            public bool Open;
            public bool Broken;
        }

        public class DoorInt
        {
            public static int DoorStatusOpen = 0;
            public static int DoorStatusClosed = 1;
            public static int DoorStatusBroken = 2;
            public static int DoorStatusStupid = 3;

            // 0 == closed
            // 0 != open
            public int Open;
        }

        public class DoorString
        {
            // 0 == closed
            // 0 != open
            public int Open;
        }

        public class DoorEnum
        {
            public DoorStatus Status;
        }

        public void Run()
        {
            var doorInt = new DoorInt();

            doorInt.Open = DoorInt.DoorStatusBroken;
            doorInt.Open = 7987897;
            doorInt.Open = 1000;
            doorInt.Open = -80;

            var doorBool = new DoorBool();

            doorBool.Open = true;
            doorBool.Open = false;

            var doorEnum = new DoorEnum();

            doorEnum.Status = DoorStatus.Open;
            doorEnum.Status = DoorStatus.Closed;
            doorEnum.Status = DoorStatus.Broken;
            doorEnum.Status = DoorStatus.Stupid;

            DoorStatus status = (DoorStatus)((int)DoorStatus.Broken + (int)DoorStatus.Stupid);

            if(status == DoorStatus.Open)
            {

            }
            else if (status == DoorStatus.Closed)
            {

            }
            else if (status == DoorStatus.Broken)
            {

            }
            else if (status == DoorStatus.Stupid)
            {

            }

            switch(status)
            {
                case DoorStatus.Open:
                    // do actie
                    break;
                case DoorStatus.Closed:
                case DoorStatus.Broken:
                    // do actie
                    break;
                default:
                    // throw new Exception("onbekende doorstatus");
                    Console.WriteLine("onbekende doorstatus gevonden; Please fIX me!!!!!!");
                    break;

            }
        }
    }
}
