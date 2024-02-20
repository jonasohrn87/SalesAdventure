using SalesAdventure.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesAdventure.Entities
{
    public abstract class Creature
    {
        public string creatureIcon;
        public int lvl;
        public string name;
        public double hp;
        public int luck;
        public int strength;
        public int charisma;
        public int wackiness;
        public int positionY;
        public int positionX;
        public int playerLucky;
        public int monsterLucky;
        public Creature()
        {
        }

        //public virtual void CreaturePosition()
        //{
        //}




        public abstract void Blocking(Creature target);

        public abstract void Attack(Creature target);

        public abstract void ThrowRock(Creature target);

        public abstract void Attacks(Creature target);


        public int LuckyStart(Player player1, Creature target)
        {
            Random random = new Random();
            playerLucky = random.Next(1, 8) + player1.luck;
            monsterLucky = random.Next(1, 8) + target.luck;

            return playerLucky + monsterLucky;
        }

        public void CreatureDeafeated(DrawMap drawMap, Player player1, Creature target)
        {
            if (target.hp <= 0)
            {
                this.creatureIcon = ".";
                this.positionY = 0;
                this.positionX = 0;
                this.creatureIcon = "#";
                //this.hp = 0;
                Mechanics.monsterEncounter = false;
                Mechanics.creaturePlayerCollision = false;
                player1.PlacePlayer(drawMap);
                Console.Clear();
                Console.WriteLine("You WON! Press any key to Continue.");
            }
        }
        //public virtual void EncounterFight(DrawMap drawMap, string[,] map, Player player1, Creature target)
        //{
        //    if (map[player1.positionY, player1.positionX] == map[this.positionY, this.positionX])
        //    {
        //        Mechanics.monsterEncounter = true;
        //        while (Mechanics.monsterEncounter)
        //        {
        //            if (player1.luck > this.luck)
        //            {
        //                LuckyStart(player1, this);
        //                Console.WriteLine($"{playerLucky} and {monsterLucky}");
        //                Console.WriteLine($"{player1.name} will do the first attack.");
        //                Console.ReadLine();

        //                player1.PlayerAttackMenu(drawMap, this, player1);
        //                CreatureDeafeated(drawMap, player1, this);
        //            }
        //            else if (player1.luck < this.luck)
        //            {
        //                LuckyStart(player1, target);
        //                Console.WriteLine($"{playerLucky} and {monsterLucky}");
        //                Console.ReadLine();
        //                Console.WriteLine($"{this.name} will do the first attack.");
        //                Console.ReadLine();
        //                Attacks(player1);
        //                //Attack(player1);
        //                player1.PlayerAttackMenu(drawMap, this, player1);
        //                CreatureDeafeated(drawMap, player1, this);
        //            }
        //        }
        //    }
        //}
    }
}