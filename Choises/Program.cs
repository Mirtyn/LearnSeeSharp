using System;
using System.Collections.Generic;

namespace Choices
{
    class Program
    {
        static void Main(string[] args)
        {
            World world = new World();

            var house1 = new House();
            house1.description = "Steven's krot, there lived an ugly person there.";
            var room1 = new Room();
            var room2 = new Room();
            var room3 = new Room();
            var monster1 = new NPC();
            var monster2 = new NPC();

            house1.Rooms.Add(room1);
            house1.Rooms.Add(room2);
            house1.Rooms.Add(room3);

            room1.NPCs.Add(monster1);
            room3.NPCs.Add(monster2);

            world.Houses.Add(house1);

            world.Run();
        }
    }

    public class World
    {
        public List<House> Houses = new List<House>();
        public Player Player = new Player();

        internal void Run()
        {
            Console.WriteLine("Press 'q' to quit.");
            
            Console.WriteLine("Welcome to choices.");
            Console.WriteLine("You are the player and you can walk around this world.");
            Console.WriteLine("Whats your name?");
            Player.Name = Console.ReadLine();

            Console.WriteLine($"There are {Houses.Count} houses in the world.");
            for (var i = 0; i < Houses.Count; i++)
            {
                Console.WriteLine(Houses[i].description + (i + 1));
            }
            Console.WriteLine($"Which house do you want to enter? Press the number of a house.");
            int houseindex = int.Parse(Console.ReadLine());
            houseindex--;

            var selectedHouse = Houses[houseindex];

            Console.WriteLine($"There are {selectedHouse.Rooms.Count} rooms in the house.");
            //Console.WriteLine($"There are {Houses[houseindex].Rooms.Count} rooms in the house.");

            for (var i = 0; i < selectedHouse.Rooms.Count; i++)
            {
                Console.WriteLine("Room " + (i + 1));
            }
            Console.WriteLine($"Which room do you want to enter? Press the number of a room.");

            var code = Console.ReadLine();
            if (code == "q")
            {
                Environment.Exit(0);
            }
        }

        //public House CreateHouse(int roomcount,int npccount,int weaponcount)
        //{

        //}
    }

    public class House
    {
        public string description = null;
        public List<Room> Rooms = new List<Room>();
    }

    public class Room
    {
        public List<NPC> NPCs = new List<NPC>();
        //public Item[] Items = new Item[3];
        //public Weapon[] Weapons = new Weapon[1];
    }

    public class Player
    {
        public string Name;
    }

    public class NPC
    {

    }

    public class Weapon
    {

    }

    public class Item
    {

    }
}
