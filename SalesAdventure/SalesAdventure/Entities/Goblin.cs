using SalesAdventure.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesAdventure.Entities
{
    public class Goblin : Creature
    {
        public Goblin(string creatureIcon, int lvl, string name, double hp, int luck, int strength, int charisma, int wackiness, int positionY, int positionX)
        {
            this.creatureIcon = creatureIcon;
            this.lvl = lvl;
            this.name = name;
            this.hp = hp;
            this.luck = luck;
            this.strength = strength;
            this.charisma = charisma;
            this.wackiness = wackiness;
            this.positionY = positionY;
            this.positionX = positionX;
        }

        //public override void CreaturePosition()
        //{
        //    int[] creaturePosYx = { this.positionY, this.positionX };
        //    //map[this.positionY, this.positionX] = this.creatureIcon;
        //}

        public override void Blocking(Creature target)
        {

        }

        public override void Attack(Creature target)
        {
            Random randrom = new Random();
            int goblinAttack = randrom.Next(1, 10) + this.strength;
            bool isCriticalHit = randrom.Next(100) < this.luck;
            if (isCriticalHit)
            {
                goblinAttack *= 2;
                Console.WriteLine($"{this.name} lands a critical hit on {target.name}!");
            }
            target.hp -= goblinAttack;

            Console.WriteLine($"{this.name} attacks {target.name} for {goblinAttack} damage. {target.name} have now {target.hp} HP left.");
        }

        public override void ThrowRock(Creature target)
        {
            Random random = new Random();
            double goblinRock = (random.Next(1, 15) + this.strength) * this.wackiness;
            bool isCriticalHit = random.Next(80) < this.luck;
            if (isCriticalHit)
            {
                goblinRock *= 1.2;
                Console.WriteLine($"{this.name} lands a critical hit with a rock on {target.name}!");
            }
            target.hp -= goblinRock;

            Console.WriteLine($"{this.name} throws a rock on {target.name} for {goblinRock} damage. {target.name} stumbles and have now {target.hp} HP left.");
        }

        public override void Attacks(Creature target)
        {
            Random random = new Random();
            int attacking = random.Next(1, 3);
            if (attacking >= 2)
            {
                Attack(target);
                Console.ReadLine();
            }
            else
            {
                ThrowRock(target);
                Console.ReadLine();
            }
        }

        public void GoblinEncounter(DrawMap drawMap, string[,] map, Player player1, Creature target)
        {
            //if (map[player1.positionY, player1.positionX] == map[this.positionY, this.positionX])
            //{
            //    Mechanics.monsterEncounter = true;
            //    while (Mechanics.monsterEncounter)
            //    {
            //        if (player1.luck > this.luck)
            //        {
            //            Console.WriteLine($"{player1.name} will do the first attack.");
            //            Console.ReadLine();

            //            player1.PlayerAttackMenu(drawMap, goblin1, player1);
            //            CreatureDeafeated(drawMap, player1, goblin1);
            //        }
            //        else if (player1.luck < this.luck)
            //        {
            //            Console.WriteLine($"{this.name} will do the first attack.");
            //            Console.ReadLine();
            //            //Attack(goblin1);
            //            Attacks(player1);
            //            player1.PlayerAttackMenu(drawMap, goblin1, player1);
            //            CreatureDeafeated(drawMap, player1, goblin1);
            //        }
            //    }
            //}
            if (map[player1.positionY, player1.positionX] == map[this.positionY, this.positionX])
            {
                Mechanics.monsterEncounter = true;
                while (Mechanics.monsterEncounter)
                {
                    LuckyStart(player1, target);
                    Console.WriteLine($"{player1.name} lucky roll: {playerLucky} and {this.name} lucky roll: {monsterLucky}");
                    if (playerLucky > monsterLucky)
                    {
                        Console.WriteLine($"{player1.name} will do the first attack.");
                        Console.ReadLine();

                        player1.PlayerAttackMenu(drawMap, target, player1);
                        CreatureDeafeated(drawMap, player1, target);
                        Attacks(player1);
                    }
                    else if (playerLucky < monsterLucky)
                    {
                        Console.ReadLine();
                        Console.WriteLine($"{this.name} will do the first attack.");
                        Console.ReadLine();
                        Attacks(player1);
                        player1.PlayerAttackMenu(drawMap, target, player1);
                        CreatureDeafeated(drawMap, player1, target);
                    }
                }
            }
        }
    }
}
