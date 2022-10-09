using System;
using System.Collections.Generic;
using System.Text;

namespace LearnGameSeeSharp001
{
    class Soldier
    {
        public static Random _random = new Random();

        public int Life = 100;

        public int AttackValue = 30;

        public float HitChance = 0.75f;

        public string Name = string.Empty;

        public void Attack(Soldier enemy)
        {
            var chance = (float)_random.NextDouble();

            if(chance >= HitChance)
            {
                return;
            }

            enemy.Life -= AttackValue;
        }
    }
}
