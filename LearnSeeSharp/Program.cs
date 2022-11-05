using System;
using System.Threading;
using LearnSeeSharp.Learn;

namespace LearnSeeSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //NotMain001(args);
            //NotMain002(args);
            //NotMain003(0);
            //PlayerAttacksZombie(args);
            //PlayerAttacksZombieWithOffHand(args);
            //RandomValues();
            //RandomBiomes();


            //AnArrayOfZombies(100);


            new LearnClasses().Run();

            Console.ReadKey();

            //Thread.Sleep(5000);
        }



        static void AnArrayOfZombies(int numberzombies)
        {
            var sexyZombies = MakeArrayOfZombies(numberzombies, 20, 5);
            var uglyZombies = MakeArrayOfZombies(numberzombies, 20, 5);

            Fight(sexyZombies, uglyZombies);

            int sexyZombiesAlive = CountZombiesAlive(sexyZombies);
            int uglyZombiesAlive = CountZombiesAlive(uglyZombies);

            if (uglyZombiesAlive == 0)
            {
                Console.WriteLine("UglyZombies are dead for real");
            }
            else
            {
                Console.WriteLine($"UglyZombies have won!\nThere are {uglyZombiesAlive}");
            }

            if (sexyZombiesAlive == 0)
            {
                Console.WriteLine("SexyZombies are dead for real");
            }
            else
            {
                Console.WriteLine($"SexyZombies have won!\nThere are {sexyZombiesAlive}");
            }
        }

        private static Random randomFight = new Random();

        static void Fight(Zombie[] sexyZombies, Zombie[] uglyZombies)
        {
            var sexyZombie = PickAliveZombie(sexyZombies);
            var uglyZombie = PickAliveZombie(uglyZombies);

            if (sexyZombie != null && uglyZombie != null)
            {
                var r = randomFight.Next(0, 2);

                if(r == 0)
                {
                    sexyZombie.AttackOrDrink(uglyZombie);
                }
                else
                {
                    uglyZombie.AttackOrDrink(sexyZombie);
                }

                Fight(sexyZombies, uglyZombies);
            }
        }

        static Zombie PickAliveZombie(Zombie[] zombies)
        {
            for (int teller = 0; teller < zombies.Length; teller++)
            {
                if(zombies[teller].Health > 0)
                {
                    return zombies[teller];
                }
            }

            return null;
        }

        //static bool IsAnyZombieAlive(Zombie[] zombieArmy)
        //{
            
        //    for (int teller = 0; teller < zombieArmy.Length; teller++)
        //    {
        //        if (zombieArmy[teller].Health > 0)
        //        {
        //            return true;
        //        }

        //    }

        //    return false;
        //}

        static int CountZombiesAlive(Zombie[] zombieArmy)
        {
            int zombiecount = 0;

            for (int teller = 0; teller < zombieArmy.Length; teller++)
            {
                if (zombieArmy[teller].Health > 0)
                {
                    zombiecount++;
                }

            }

            return zombiecount;
        }

        static Zombie[] MakeArrayOfZombies(int numberzombies, float health, float damage)
        {
            Zombie zombie = new Zombie();

            // default class == null
            // een array van classes is gevuld met null's
            Zombie[] zombies = new Zombie[numberzombies];

            int integer = 0;

            // default int == 0
            // een array van int's is gevuld met 0
            int[] integers = new int[100];

            //zombies[0] = new Zombie();
            //zombies[1] = new Zombie();

            for(int teller = 0;              // de teller, wordt 1 maal geinitialiseerd op 0
                teller < numberzombies;      // de controle, zolang teller kleiner is dan numberzombies
                teller++)                    // tel de teller op
            {
                zombies[teller] = new Zombie();
                zombies[teller].Health = health;
                zombies[teller].Damage = damage;
            }


            HealthPotion[] healthpotions = new HealthPotion[numberzombies];

            for (int teller = 0; teller < numberzombies; teller++)
            {
                healthpotions[teller] = new HealthPotion();
                zombies[teller].Healthpotion = healthpotions[teller];
            }
            return zombies;

        }

        //static void randombiomes()
        //{
        //    random random1 = new random(1000);

        //    for (var i = 0; i < 20; i++)
        //    {
        //        var b = new biome(random1.next(0, 4));

        //        console.writeline(b);
        //    }

        //    console.readkey();
        //}

        //static void randomvalues()
        //{
        //    random random1 = new random(1000);

        //    //// min = 20, max = 100
        //    //var i = 20f + (float)random1.next(0, 81);

        //    //// min = 0, max = 0.9999999999;
        //    //var d = 20 + random1.nextdouble();

        //    for (var i = 0; i < 5; i++)
        //    {
        //        for (var j = 0; j < 5; j++)
        //        {
        //            console.writeline(random1.next(0, 100));
        //        }
        //        console.writeline("");
        //    }
        //}

        static void PlayerAttacksZombie(string[] args)
        {
            var zombie = new Zombie();

            var player = new Player();

            player.Attack(zombie);

            Console.WriteLine(zombie.status());
        }

        static void PlayerAttacksZombieWithOffHand(string[] args)
        {
            var zombie = new Zombie();
            var player = new Player();

            //player.MainHand = new Weapon(Weapon.Melee, 4f);
            player.OffHand = new Weapon(Weapon.Ranged, 4f);

            player.Attack(zombie);
            Console.WriteLine(zombie.status());
            player.Attack(zombie);
            Console.WriteLine(zombie.status());
            zombie.Drink(new HealthPotion() { Life = 22 });
            Console.WriteLine(zombie.status());
            player.Attack(zombie);
            Console.WriteLine(zombie.status());
            player.Attack(zombie);
            Console.WriteLine(zombie.status());
            player.Attack(zombie);
            Console.WriteLine(zombie.status());
            player.Attack(zombie);
            Console.WriteLine(zombie.status());
        }

        static void NotMain004(string[] args)
        {
            var zombie_1 = new Zombie();
            //Zombie zombie_2 = new Zombie();

            ////zombie_1.type = "qfjoijf";
            //zombie_1.Health = 2f;
            //zombie_1.take_damage(5f);
            //Console.WriteLine(zombie_1.status());

            //zombie_2.take_damage(5f);
            //Console.WriteLine(zombie_2.status());

            var knife = new Weapon(Weapon.Melee, 5);
            //knife.Type = "Melee";
            //knife.Damage= 5;
            var sword = new Weapon(Weapon.Melee, 8);
            var bow = new Weapon(Weapon.Ranged, 4);

            var small_health_potion = new HealthPotion();
            var medium_health_potion = new HealthPotion();
            var large_health_potion = new HealthPotion();

            small_health_potion.Life = 3;
            large_health_potion.Life = 8;


            zombie_1.Health = 20;

            // 20
            zombie_1.Drink(small_health_potion);
            Console.WriteLine(zombie_1.status());

            // 15
            zombie_1.take_damage(5f);
            Console.WriteLine(zombie_1.status());

            // 20
            zombie_1.Drink(medium_health_potion);
            Console.WriteLine(zombie_1.status());

            // 15
            zombie_1.take_damage(5f);
            Console.WriteLine(zombie_1.status());

            // 20
            zombie_1.Drink(large_health_potion);
            Console.WriteLine(zombie_1.status());


            zombie_1.Health = 1;
            zombie_1.Drink(large_health_potion);
            Console.WriteLine(zombie_1.status());

            zombie_1.take_damage(10f);
            Console.WriteLine(zombie_1.status());
        }

        static void NotMain002(string[] args)
        {
            Console.WriteLine(@"Vul een getal in, of ""q"" om te stoppen.");

            var waarde1 = Console.ReadLine();

            if (waarde1 == "q" || waarde1 == "Q")
            {
                return;
            }

            Console.WriteLine("Vul nog een getal in.");

            var waarde2 = Console.ReadLine();

            if (int.TryParse(waarde1, out int getal1) == true && int.TryParse(waarde2, out int getal2) == true)
            {
                int som = getal1 + getal2;

                Console.WriteLine($"De som van {waarde1} en {waarde2} is {som}");
            }
            else if (float.TryParse(waarde1.Replace('.', ','), out float floatgetal1) == true && float.TryParse(waarde2.Replace('.', ','), out float floatgetal2) == true)
            {
                float som = floatgetal1 + floatgetal2;

                Console.WriteLine($"De som van {waarde1} en {waarde2} is {som}");
            }
            else
            {
                Console.WriteLine(@"Jij dikke vette domme achterlijke aap kan je niet lezen er staat ""vul een GETAL in"".");
                Console.WriteLine($"{waarde1} en {waarde2} kan je niet optellen.");
            }

            NotMain002(args);
        }

        static void NotMain003(int gg)
        {
            gg = gg + 1;

            gg++;

            gg += 1;

            if(gg>= 1000)
            {
                return;
            }

            Console.WriteLine(gg);

            NotMain003(gg);
        }

        static void NotMain001(string[] args)
        {
            string steven = "steven is dik";

            string mirtyn = "mirtyn is slim";

            //int mirtynLeeftijd = 16;

            //int stevenKG = 10000000;

            //bool overgewichtSteven = true;

            //Console.WriteLine(steven + " " + stevenKG + "KG" + "overgewicht is " + overgewichtSteven);

            //Console.WriteLine(mirtyn + " " + mirtynLeeftijd + " " + "jaar");


            //Console.WriteLine("Hello World!");

            //foreach (var arg in args)
            //{
            //    Console.WriteLine(arg);
            //}


            //string message = "geef uw gewicht in. en druk dan op 'enter'.";

            //Console.WriteLine(message);

            //message = "geef uw gewicht in. en druk dan op 'enter'. nieuwe string";

            //Console.WriteLine(message);

            //Console.WriteLine("Geef uw gewicht in. En druk dan op 'Enter'.");

            //string gewichtstring = console.readline();

            //int gewicht = int.parse(gewichtstring);

            //Console.WriteLine(gewichtString);

            //if (gewicht >= 90) 
            //{
            //    Console.WriteLine("Dikke pattate zak");
            //}

            //if (gewicht <= 40)
            //{
            //    Console.WriteLine("Fijne pite wiet");
            //}

            //if (gewicht > 40 && gewicht < 90)
            //{
            //    Console.WriteLine("sexy mother fucker!!!");
            //}


            //if (gewicht >= 90)
            //{
            //    Console.WriteLine("Dikke pattate zak");
            //}
            //else if (gewicht <= 40)
            //{
            //    Console.WriteLine("Fijne pite wiet");
            //}
            //else
            //{
            //    Console.WriteLine("sexy mother fucker!!!");
            //}

            //Console.WriteLine("Geef een getal in.");

            //string stringgetal1 = Console.ReadLine();

            //Console.WriteLine("Geef nog een ander getal in.");

            //string stringgetal2 = Console.ReadLine();

            //Console.WriteLine("De som van de getallen zijn " + stringgetal1 + " " + stringgetal2);

            //int getal1 = int.Parse(stringgetal1);

            //int getal2 = int.Parse(stringgetal2);

            //int som = getal1 + getal2;

            //Console.WriteLine("De som van de getallen zijn " + getal1 + getal2);

            //Console.WriteLine("De som van de getallen zijn " + som);

            Console.WriteLine("De min/max waarde van int is " + int.MinValue + "/" + int.MaxValue);

            Console.WriteLine("De min/max waarde van uint is " + uint.MinValue + "/" + uint.MaxValue);


            Console.WriteLine("De max waarde van float is " + float.MaxValue);

            Console.WriteLine("De max waarde van long is " + long.MaxValue);

            Console.WriteLine("De max waarde van byte is " + byte.MaxValue);

            Console.WriteLine("De max waarde van short is " + short.MaxValue);

            Console.WriteLine("De max waarde van char is " + (int)char.MaxValue);

            Int16 int16 = Int16.MaxValue;
            Int32 int32 = Int32.MaxValue;
            Int64 int64 = Int64.MaxValue;

            Console.WriteLine("Druk een toets in om het venster af te sluiten.");

            Console.ReadKey();
        }
    }

    
}
