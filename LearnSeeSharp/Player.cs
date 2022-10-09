using System;
using System.Threading;

namespace LearnSeeSharp
{
    
    public class Player
    {
        public float BaseDamage = 2;
        public Weapon MainHand = new Weapon();
        public Weapon OffHand = null;

        public void Attack(Zombie enemy)
        {
            float damage = 0;

            if(MainHand != null)
            {
                if(MainHand.Type == Weapon.Melee)
                {
                    if (OffHand == null)
                    {
                        damage += BaseDamage;
                    }
                    else
                    {
                        // OffHand != null
                        if(OffHand.Type != Weapon.Ranged)
                        {
                            damage += BaseDamage;
                        }

                    }
                }
                //else
                //{
                //    // MainHand.Type == Weapon.Ranged
                //}
            }
            else
            {
                // MainHand == null

                if (OffHand != null)
                {
                    if (OffHand.Type != Weapon.Ranged)
                    {
                        damage += BaseDamage;
                    }
                }
                else
                {
                    // OffHand == null
                    damage += BaseDamage;
                }
            }




            if (MainHand != null)
            {
                damage += MainHand.Damage;
            }

            if (OffHand != null)
            {
                damage += OffHand.Damage;
            }




            enemy.take_damage(damage);
        
        }
    }
}
