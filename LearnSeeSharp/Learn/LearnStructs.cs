using System;
using System.Collections.Generic;
using System.Text;

namespace LearnSeeSharp.Learn
{
    internal class LearnStructs
    {
        public struct PlayerStruct
        {
            public int Id;
            public string Name;
        }

        public class PlayerClass
        {
            public int Id;
            public string Name;

            public void Attack(EnemyStruct enemy)
            {
            }
        }

        public struct EnemyStruct
        {
            public int Id;
            public string Name;
        }



        public void Run()
        {
            // structs
            var playerStruct = new PlayerStruct();

            var enemyStruct = new EnemyStruct();

            PlayerAttacksEnemy(playerStruct, enemyStruct);




            // classes
            var playerClass = new PlayerClass();

            playerClass.Attack(enemyStruct);
        }


        public void PlayerAttacksEnemy(PlayerStruct player, EnemyStruct enemy)
        {

        }
    }
}
