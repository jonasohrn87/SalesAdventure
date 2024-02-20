using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SalesAdventure;
using SalesAdventure.Map;

namespace SalesAdventure.Entities
{
    public class Orc : Creature
    {
        public Orc(string creatureIcon, int lvl, string name, double hp, int luck, int strength, int charisma, int wackiness, int positionY, int positionX)
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

        public override void Attack(Creature target)
        {
            Random random = new Random();
            int orcAttack = random.Next(1, 10) + this.strength;
            bool isCriticalHit = random.Next(100) < this.luck;
            if (isCriticalHit)
            {
                orcAttack *= 2;
                Console.WriteLine($"{this.name} lands a critical hit on {target.name}!");
            }
            target.hp -= orcAttack;

            Console.WriteLine($"{this.name} attacks {target.name} for {orcAttack} damage. {target.name} have now {target.hp} HP left.");
        }

        public override void ThrowRock(Creature target)
        {
            Random random = new Random(); 
            double orcRock = (random.Next(1, 15) + this.strength) * this.wackiness;
            bool isCriticalHit = random.Next(80) < this.luck;
            if (isCriticalHit) 
            {
                orcRock *= 2;
                Console.WriteLine($"{this.name} lands a critical hit with a rock on {target.name}!");
            }
            target.hp -= orcRock;

            Console.WriteLine($"{this.name} throws a rock on {target.name} for {orcRock} damage. {target.name} stumbles and have now {target.hp} HP left.");
        }

        public override void Attacks (Creature target)
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

        public void OrcEncounter(DrawMap drawMap, string[,] map, Player player1, Orc orc1)
        {
            if(map[player1.positionY, player1.positionX] == map[this.positionY, this.positionX])
            {
                Mechanics.monsterEncounter = true;
                while (Mechanics.monsterEncounter)
                {
                    if (player1.luck > this.luck)
                    {
                        Console.WriteLine($"{player1.name} will do the first attack.");
                        Console.ReadLine();

                        player1.PlayerAttackMenu(drawMap, orc1, player1);
                        CreatureDeafeated(drawMap, player1, orc1);
                    }
                    else if (player1.luck < this.luck)
                    {
                        Console.WriteLine($"{this.name} will do the first attack.");
                        Console.ReadLine();
                        Attacks(player1);
                        //Attack(player1);
                        player1.PlayerAttackMenu(drawMap, orc1, player1);
                        CreatureDeafeated(drawMap, player1, orc1);
                    }
                }
            }
        }
    }
}
