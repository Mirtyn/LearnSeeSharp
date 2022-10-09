using System;
using System.Threading;

namespace LearnSeeSharp
{
  
    public class Weapon
    {
        public static int Melee = 2;
        public static int Ranged = 1;
        public static float DefaultDamage = 5;

        public int Type = Weapon.Melee;
        public float Damage = Weapon.DefaultDamage;

        public Weapon()
        {
            Type = Weapon.Melee;
            Damage = Weapon.DefaultDamage;
        }

        public Weapon(int type, float damage)
        {
            Type = type;
            Damage = damage;
        }
    }

}
