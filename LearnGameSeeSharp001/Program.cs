using System;
using System.Collections.Generic;
using System.Linq;

namespace LearnGameSeeSharp001
{
    class Program
    {
        static List<Army> armies = new List<Army>();
        static List<ArmyCard> armyCards = new List<ArmyCard>();

        static void Main(string[] args)
        {
            var keyChar = 'r';

            var amountOfArmies = 0;
            var amountOfSoldiers = 0;

            while (keyChar != 'q' && keyChar != 'Q')
            {
                Console.Clear();

                var reset = keyChar == 'r' || keyChar == 'R';

                if (reset)
                {
                    Console.WriteLine("Press a number from 2 to 6 for the amount of armies...");

                    amountOfArmies = int.Parse(Console.ReadLine());

                    if (amountOfArmies > 6)
                    {
                        amountOfArmies = 6;
                    }
                    else if (amountOfArmies < 2)
                    {
                        amountOfArmies = 2;
                    }

                    Console.WriteLine("Press a number from 20 to 2000 for the amount of soldiers...");

                    amountOfSoldiers = int.Parse(Console.ReadLine());

                    if (amountOfSoldiers > 2000)
                    {
                        amountOfSoldiers = 2000;
                    }
                    else if (amountOfSoldiers < 20)
                    {
                        amountOfSoldiers = 20;
                    }
                }

                ArmiesFight(amountOfArmies, amountOfSoldiers, reset);

                Console.WriteLine("Press q to quit, r to reset or another key to attack...");

                keyChar = Console.ReadKey().KeyChar;
            }
        }

        static void CreateArmyCards(int amountOfSoldiers, bool reset)
        {
            if(!reset)
            {
                return;
            }

            var cardStandard = new ArmyCard
            {
                MinSoldiers = amountOfSoldiers,
                MaxSoldiers = amountOfSoldiers,
                SoldiersMultiplier = 1f,

                SoldierLifeMultiplier = 1f,

                SoldierAttackValueMultiplier = 1f,

                SoldierHitChanceMultiplier = 1f,
            };

            armyCards.Add(cardStandard);

            var cardDoubleAttack = new ArmyCard
            {
                MinSoldiers = amountOfSoldiers,
                MaxSoldiers = amountOfSoldiers,
                SoldiersMultiplier = 0.25f,

                SoldierLifeMultiplier = 2f,

                SoldierAttackValueMultiplier = 2f,

                SoldierHitChanceMultiplier = 1f,
            };

            armyCards.Add(cardDoubleAttack);

            //var cardDoubleLife = new ArmyCard
            //{
            //    MinSoldiers = amountOfSoldiers,
            //    MaxSoldiers = amountOfSoldiers,
            //    SoldiersMultiplier = 0.5f,

            //    SoldierLifeMultiplier = 2f,

            //    SoldierAttackValueMultiplier = 1f,

            //    SoldierHitChanceMultiplier = 1f,
            //};

            //armyCards.Add(cardDoubleLife);

            //var cardQuarterHitChance = new ArmyCard
            //{
            //    MinSoldiers = amountOfSoldiers,
            //    MaxSoldiers = amountOfSoldiers,
            //    SoldiersMultiplier = 0.75f,

            //    SoldierLifeMultiplier = 1f,

            //    SoldierAttackValueMultiplier = 1f,

            //    SoldierHitChanceMultiplier = 2f,
            //};

            //armyCards.Add(cardQuarterHitChance);
        }

        static void ArmiesFight(int amountOfArmies, int amountOfSoldiers, bool reset)
        {
            CreateArmyCards(amountOfSoldiers, reset);

            CreateArmies(amountOfArmies, amountOfSoldiers, reset);

            while (SolidiersFight())
            {

            }
        }

        static bool SolidiersFight()
        {
            var attackingArmy = PickAttackingArmy();

            var defendingArmy = PickDefendingArmy(attackingArmy);

            if (defendingArmy == null)
            {
                Console.WriteLine(attackingArmy.ArmyType + " has won!!!! (winning army " + attackingArmy.AmountOfLivingSoldiers() + ") ");

                return false;
            }

            var attackingSoldier = PickRandomSoldier(attackingArmy);

            var defendingSoldier = PickRandomSoldier(defendingArmy);

            attackingSoldier.Attack(defendingSoldier);

            //Console.WriteLine(attackingSoldier.Name + " attacks " + defendingSoldier.Name + " (" + defendingSoldier.Life + ")");

            if (defendingArmy.AmountOfLivingSoldiers() == 0)
            {
                Console.WriteLine(defendingArmy.ArmyType + " has lost!!!!");
            }

            return true;
        }

        static Random _random = new Random();

        static Army PickAttackingArmy()
        {
            var armiesWithSoldier = armies.Where(o => o.AmountOfLivingSoldiers() > 0).ToArray();

            var index = _random.Next(0, armiesWithSoldier.Length);

            return armiesWithSoldier[index];
        }

        static Army PickDefendingArmy(Army attackingArmy)
        {
            var armiesWithSoldier = armies.Where(o => o.AmountOfLivingSoldiers() > 0 && o.ArmyType != attackingArmy.ArmyType).ToArray();

            if(armiesWithSoldier.Length == 0)
            {
                return null;
            }

            var index = _random.Next(0, armiesWithSoldier.Length);

            return armiesWithSoldier[index];
        }

        static Soldier PickRandomSoldier(Army army)
        {
            return army.Soldiers.FirstOrDefault(o => o.Life > 0);
        }

        static void CreateArmies(int amountOfArmies, int amountOfSoldiers, bool reset)
        {
            if(reset || armies.Count == 0)
            {
                CreateArmies(amountOfArmies, amountOfSoldiers);
            }

            ReviveArmies();

            ConsoleWriteLineArmies();
        }

        static void CreateArmies(int amountOfArmies, int amountOfSoldiers)
        {
            armies.Clear();

            for (var i = 0; i < amountOfArmies; i++)
            {
                var army = new Army();

                armies.Add(army);

                army.ArmyType = PickArmyType();
                army.ArmyCard = PickArmyCard();

                var amount = (int)(_random.Next(amountOfSoldiers, amountOfSoldiers) * army.ArmyCard.SoldiersMultiplier);

                for (var count = 0; count < amount; count++)
                {
                    army.Soldiers.Add(new Soldier
                    {
                        AttackValue = (int)(_random.Next(army.ArmyCard.MinSoldierAttackValue, army.ArmyCard.MaxSoldierAttackValue) * army.ArmyCard.SoldierAttackValueMultiplier),
                        HitChance = (float)army.ArmyCard.MinSoldierHitChance * army.ArmyCard.SoldierHitChanceMultiplier,
                        Name = army.ArmyType + "  " + count,
                    });
                }
            }

        }

        static void ReviveArmies()
        {
            foreach (var army in armies)
            {
                army.Revive();
            }
        }

        static void ConsoleWriteLineArmies()
        {
            foreach(var army in armies)
            {
                Console.WriteLine("Army " + army.ArmyType);
                Console.WriteLine("Soldiers " + army.AmountOfLivingSoldiers());
                Console.WriteLine("Soldier Amount Multiplier " + army.ArmyCard.SoldiersMultiplier);
                Console.WriteLine("Soldier Life Multiplier " + army.ArmyCard.SoldierLifeMultiplier);
                Console.WriteLine("Soldier Attack Value Multiplier " + army.ArmyCard.SoldierAttackValueMultiplier);
                Console.WriteLine("Soldier Hit Chance Multiplier " + army.ArmyCard.SoldierHitChanceMultiplier);
            }
        }

        static ArmyCard PickArmyCard()
        {
            var index = _random.Next(0, armyCards.Count);

            return armyCards[index];
        }

        static ArmyType PickArmyType()
        {
            var armyTypes = ((ArmyType[])Enum.GetValues(typeof(ArmyType))).ToList();

            return armyTypes.FirstOrDefault(o => !armies.Any(p => p.ArmyType == o));
        }
    }
}
