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
            this.Charisma = Charisma; //ej implementerad ännu
            this.Wackiness = Wackiness; // påverkar bl a critical hit
            this.PositionY = PositionY;
            this.PositionX = PositionX;
        }

        public override void Attack(Creature target)
        {
            Random random = new Random();
            int orcAttack = random.Next(1, 10) + this.Strength;
            bool isCriticalHit = random.Next(100) < this.Luck;
            if (isCriticalHit)
            {
                orcAttack *= 2;
                Console.WriteLine($"\n{this.Name}{Game.TextColor} lands a critical hit on {target.Name}{Game.TextColor}!");
            }
            Math.Round(target.Hp -= orcAttack);

            Console.WriteLine($"\n{this.Name}{Game.TextColor} attacks {target.Name}{Game.TextColor} for {Game.HpColor}{orcAttack}{Game.TextColor} damage. {target.Name}{Game.TextColor} have now {Game.HpColor}{target.Hp}{Game.TextColor} HP left.");
        }

        public override void ThrowRock(Creature target)
        {
            Random random = new Random();
            double orcRock = (random.Next(1, 15) + this.Strength) * this.Wackiness;
            bool isCriticalHit = random.Next(80) < this.Luck;
            if (isCriticalHit)
            {
                Math.Round(orcRock *= 2);
                Console.WriteLine($"\n{this.Name}{Game.TextColor} lands a critical hit with a rock on {target.Name}{Game.TextColor}!");
            }
            Math.Round(target.Hp -= orcRock);

            Console.WriteLine($"\n{this.Name}{Game.TextColor} throws a rock on {target.Name}{Game.TextColor} for {Game.HpColor}{orcRock}{Game.TextColor} damage. {target.Name}{Game.TextColor} stumbles and have now {Game.HpColor}{target.Hp}{Game.TextColor} HP left.");
        }

        public override void Attacks(Creature target)
        {
            Random random = new Random();
            int attacking = random.Next(1, 3);
            if (this.Hp > 0)
            {
                if (attacking >= 2)
                {
                    Attack(target);
                }
                else
                {
                    ThrowRock(target);
                }
            }
        }

        private void OrcEncounter(DrawMap drawMap, string[,] map, Player player1, Creature target, Item pie, Item apple)
        {
            if (map[player1.PositionY, player1.PositionX] == map[this.PositionY, this.PositionX])
            {
                Mechanics.MonsterEncounter = true;
                while (Mechanics.MonsterEncounter)
                {
                    ShowLucky(player1, target);
                    Console.WriteLine($"\n{player1.Name}{Game.TextColor} lucky roll: {Game.ColorReset}{PlayerLucky}{Game.TextColor} and {this.Name}{Game.TextColor} lucky roll: {Game.ColorReset}{MonsterLucky}");
                    if (PlayerLucky > MonsterLucky)
                    {
                        Console.WriteLine($"{player1.Name}{Game.TextColor} attacks first.");
                        Console.ReadLine();

                        player1.AttackMenu(drawMap, target, player1, pie, apple);
                        CreatureDeath(drawMap, player1, target);
                        Attacks(player1);
                    }
                    else if (PlayerLucky < MonsterLucky)
                    {
                        Console.ReadLine();
                        Console.WriteLine($"{this.Name}{Game.TextColor} attacks first.");
                        Console.ReadLine();
                        Attacks(player1);
                        player1.AttackMenu(drawMap, target, player1, pie, apple);
                        CreatureDeath(drawMap, player1, target);
                    }
                }
            }
        }
        public void OrcEncount(DrawMap drawMap, string[,] map, Player player1, Creature target, Item pie, Item apple)
        {
            OrcEncounter(drawMap, map, player1, target, pie, apple);
        }
    }
}
