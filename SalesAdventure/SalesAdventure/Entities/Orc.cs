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
        public Orc(string CreatureIcon, int Lvl, string Name, double Hp, int Luck, int Strength, int Charisma, int Wackiness, int PositionY, int PositionX)
        {
            this.CreatureIcon = CreatureIcon;
            this.Lvl = Lvl;
            this.Name = Name;
            this.Hp = Hp;
            this.Luck = Luck;
            this.Strength = Strength;
            this.Charisma = Charisma;
            this.Wackiness = Wackiness;
            this.PositionY = PositionY;
            this.PositionX = PositionX;
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
            Random random = new Random();
            int orcAttack = random.Next(1, 10) + this.Strength;
            bool isCriticalHit = random.Next(100) < this.Luck;
            if (isCriticalHit)
            {
                orcAttack *= 2;
                Console.WriteLine($"{this.Name} lands a critical hit on {target.Name}!");
            }
            target.Hp -= orcAttack;

            Console.WriteLine($"{this.Name} attacks {target.Name} for {orcAttack} damage. {target.Name} have now {target.Hp} HP left.");
        }

        public override void ThrowRock(Creature target)
        {
            Random random = new Random();
            double orcRock = (random.Next(1, 15) + this.Strength) * this.Wackiness;
            bool isCriticalHit = random.Next(80) < this.Luck;
            if (isCriticalHit)
            {
                orcRock *= 2;
                Console.WriteLine($"{this.Name} lands a critical hit with a rock on {target.Name}!");
            }
            target.Hp -= orcRock;

            Console.WriteLine($"{this.Name} throws a rock on {target.Name} for {orcRock} damage. {target.Name} stumbles and have now {target.Hp} HP left.");
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

        //public override void EncounterFight(DrawMap drawMap, string[,] map, Player player1, Creature target)
        //{

        //}

        public void OrcEncounter(DrawMap drawMap, string[,] map, Player player1, Creature target)
        {
            if (map[player1.PositionY, player1.PositionX] == map[this.PositionY, this.PositionX])
            {
                Mechanics.monsterEncounter = true;
                while (Mechanics.monsterEncounter)
                {
                    LuckyStart(player1, target);
                    Console.WriteLine($"{player1.Name} lucky roll: {PlayerLucky} and {this.Name} lucky roll: {MonsterLucky}");
                    if (PlayerLucky > MonsterLucky)
                    {
                        Console.WriteLine($"{player1.Name} will do the first attack.");
                        Console.ReadLine();

                        player1.PlayerAttackMenu(drawMap, target, player1);
                        CreatureDeafeated(drawMap, player1, target);
                        Attacks(player1);
                    }
                    else if (PlayerLucky < MonsterLucky)
                    {
                        Console.ReadLine();
                        Console.WriteLine($"{this.Name} will do the first attack.");
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
