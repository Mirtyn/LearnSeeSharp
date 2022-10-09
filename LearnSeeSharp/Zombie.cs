using System;
using System.Collections.Generic;
using System.Text;

namespace LearnSeeSharp
{
    public class Zombie
    {
        private string _type = "Undead";
        public float Health = 20f;
        public float Damage = 3.5f;
        public float MaxHealth = 20f;
        public HealthPotion Healthpotion;
        private static Random random = new Random();


        public void Attack(Zombie enemy)
        {
            if(this.Health > 0)
            {
                enemy.take_damage(Damage);
            }

        }

        public void take_damage(float damage)
        {
            update_health(-damage);
        }

        public void Drink(HealthPotion healthPotion)
        {
            update_health(healthPotion.Life);
        }


        public string status()
        {
            if (Health <= 0.0f)
            {
                return "Is dead";
            }
            else
            {
                return "Is alive, he has " + Health + " health";
            }
        }
        private void update_health(float v)
        {
            if (Health == 0f)
            {
                return;
            }

            Health += v;

            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }
            else if (Health < 0)
            {
                Health = 0;
            }
        }

        public void AttackOrDrink(Zombie enemy)
        {
            var r = random.Next(2);
            if (this.Healthpotion != null && this.Health <= 5 && r == 1)
            {
                Drink(this.Healthpotion);
                this.Healthpotion = null;
            }
            else
            {
                this.Attack(enemy);
            }

        }

    }

}
