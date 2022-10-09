using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearnGameSeeSharp001
{
    enum ArmyType
    {
        Red,
        Blue,
        Yellow,
        Green,
        Black,
        White,
    }

    class ArmyCard
    {
        public int MinSoldiers = 100;
        public int MaxSoldiers = 100;

        public float SoldiersMultiplier = 1f;

        public int MinSoldierLife = 100;
        public int MaxSoldierLife = 100;

        public float SoldierLifeMultiplier = 1f;

        public int MinSoldierAttackValue = 30;
        public int MaxSoldierAttackValue = 30;

        public float SoldierAttackValueMultiplier = 1f;

        public float MinSoldierHitChance = 0.75f;
        public float MaxSoldierHitChance = 0.75f;

        public float SoldierHitChanceMultiplier = 1f;
    }

    class Army
    {
        private static Random _random = new Random();

        public ArmyType ArmyType = ArmyType.Red;

        public ArmyCard ArmyCard;

        public List<Soldier> Soldiers = new List<Soldier>();

        internal void Revive()
        {
            foreach(var soldier in Soldiers)
            {
                soldier.Life = (int)(_random.Next(ArmyCard.MinSoldierLife, ArmyCard.MaxSoldierLife) * ArmyCard.SoldierLifeMultiplier);
            }
        }

        internal int AmountOfLivingSoldiers()
        {
            return Soldiers.Count(o => o.Life > 0);
        }
    }
}
