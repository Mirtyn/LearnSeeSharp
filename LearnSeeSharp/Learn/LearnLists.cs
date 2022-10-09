using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnSeeSharp.Learn
{
    internal class LearnLists
    {
        class DummyClass
        {
            public int Id;
            public string Name;
        }

        public void Initialize()
        {
            var a = new List<int>();

            var b = new List<string>();

            var c = new List<DummyClass>();

            var d = new List<int> { 1, 2 };

            var e = new List<object> { string.Empty, "1" };

            // list van objecten zijn geen goed idee!!!
            var f = new List<object> { string.Empty, 1 };

            // dit zal crashen want f[0] is geen int maar en string
            // var t = (int)f[0] * 2;

            for (var i = 0; i < 999; i++)
            {
                a.Add(i);
            }

            var array = new[] { 1, 2, 3, 4 };
            var g = new List<int>(array);
        }

        public void Add()
        {
            var list = new List<int>();

            list.Add(5);
            list.Add(1);
            list.Add(3);
            list.Add(4);
            list.Add(2);

            list[0] = 10;

            // zal crashen, element 1000 bestaat niet
            // list[1000] = 10;
        }

        public void RemoveClear()
        {
            var list = new List<int>();

            list.Remove(5);
            list.RemoveAt(1);
            list.Clear();

            // zal crashen, element 1000 bestaat niet
            // list[1000] = 10;
        }

        public void Count()
        {
            var list = new List<int>();

            var t = list.Count;

            list.Add(5);
            list.Add(1);
            list.Add(3);
            list.Add(4);
            list.Add(2);

            t = list.Count;
        }

        public void TraitsPicker()
        {
            var list = new List<string> { 
                "trait 1", 
                "trait 2", 
                "trait 3", 

                "trait 4", 
                "trait 5", 
                "trait 6", 

                "trait 7", 
                "trait 8", 
                "trait 9",

                "trait 10",
                "trait 11",
                "trait 12",

                "trait 13",
                "trait 14",
                "trait 15",
                "trait 16",

                "trait 17",
                "trait 18",
                "trait 19"
            };

            list.Add("Mijn Trait - i'm the best");
            list.Add("Mirtyn is NE WORst");

            //var t1 = PickTraitsNonUnique(list, 7);

            //ConsoleWrite(t1);

            //var t2 = PickTraitsNonUnique(list, 48);

            //ConsoleWrite(t2);

            //var t3 = PickTraitsNonUnique(list, -2);

            //ConsoleWrite(t3);

            //var t1 = PickTraitsUnique(list, 7);

            //ConsoleWrite(t1);

            //var t2 = PickTraitsUnique(list, 128);

            //ConsoleWrite(t2);

            //var t3 = PickTraitsUnique(list, -2);

            //ConsoleWrite(t3);

            var t1 = PickTraitsUniqueFaster(list, 7);

            ConsoleWrite(t1);

            var t2 = PickTraitsUniqueFaster(list, 128);

            ConsoleWrite(t2);

            var t3 = PickTraitsUniqueFaster(list, -2);

            ConsoleWrite(t3);


            t1 = PickTraitsUniqueBucketList(list, 20);

            ConsoleWrite(t1);

            t1 = PickTraitsUniqueBucketList(list, 20);

            ConsoleWrite(t1);

            t1 = PickTraitsUniqueBucketList(list, 20);

            ConsoleWrite(t1);

            t2 = PickTraitsUniqueBucketList(list, 70);

            ConsoleWrite(t2);

            t3 = PickTraitsUniqueBucketList(list, -2);

            ConsoleWrite(t3);
        }

        private List<string> PickTraitsNonUnique(List<string> traits, int count)
        {
            var random = new Random();

            var list = new List<string>();

            for(var i = 0; i< count; i++)
            {
                var index = random.Next(traits.Count);

                list.Add(traits[index]);
            }

            return list;
        }

        private List<string> PickTraitsUnique(List<string> traits, int count)
        {
            if(count > traits.Count)
            {
                count = traits.Count;
            }

            var random = new Random();

            var list = new List<string>();

            for (var i = 0; list.Count < count; i++)
            {
                Console.WriteLine("- " + i);

                var index = random.Next(traits.Count);

                var trait = traits[index];

                //var find = list.Find(o => o == trait);

                var exists = list.Exists(o => o == trait);

                // zal crashen als item niet bestaat
                //var single1 = list.Single(o => o == trait);

                //var single2 = list.SingleOrDefault(o => o == trait);

                //var any = list.Any(o => o == trait);

                //var c = list.Count(o => o == trait);

                if(!exists)
                {
                    list.Add(trait);
                }
            }

            return list;
        }


        private static List<string> TraitsBucketList = new List<string>();

        private List<string> PickTraitsUniqueFaster(List<string> traits, int count)
        {
            if (count > traits.Count)
            {
                count = traits.Count;
            }

            var random = new Random();

            var list = new List<string>();

            Console.WriteLine("Create list");

            var traitscopy = new List<string>(traits);

            for (var i = 0; list.Count < count; i++)
            {
                Console.WriteLine("- " + i);

                var index = random.Next(traitscopy.Count);

                var trait = traitscopy[index];

                //var find = list.Find(o => o == trait);

                var exists = list.Exists(o => o == trait);

                // zal crashen als item niet bestaat
                //var single1 = list.Single(o => o == trait);

                //var single2 = list.SingleOrDefault(o => o == trait);

                //var any = list.Any(o => o == trait);

                //var c = list.Count(o => o == trait);

                if (!exists)
                {
                    list.Add(trait);

                    traitscopy.Remove(trait);
                }
            }

            return list;
        }

        private List<string> PickTraitsUniqueBucketList(List<string> traits, int count)
        {
            if (count > traits.Count)
            {
                count = traits.Count;
            }

            var random = new Random();

            var list = new List<string>();

            for (var i = 0; list.Count < count; i++)
            {
                Console.WriteLine("- " + i);

                if(TraitsBucketList.Count == 0)
                {
                    Console.WriteLine("Create bucklist");

                    TraitsBucketList = CreateBucketList(traits);
                }

                var index = random.Next(TraitsBucketList.Count);

                var trait = TraitsBucketList[index];

                //var find = list.Find(o => o == trait);

                var exists = list.Exists(o => o == trait);

                // zal crashen als item niet bestaat
                //var single1 = list.Single(o => o == trait);

                //var single2 = list.SingleOrDefault(o => o == trait);

                //var any = list.Any(o => o == trait);

                //var c = list.Count(o => o == trait);

                if (!exists)
                {
                    list.Add(trait);

                    TraitsBucketList.Remove(trait);
                }
            }

            return list;
        }

        private List<string> CreateBucketList(List<string> traits)
        {
            var traitscopy = new List<string>(traits);

            return traitscopy;
        }

        private void ConsoleWrite(List<string> traits)
        {
            foreach(var t in traits)
            {
                Console.WriteLine(t);
            }

            Console.WriteLine("");
            Console.WriteLine("--------");
            Console.WriteLine("");
        }
    }
}
