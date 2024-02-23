using SalesAdventure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesAdventure;
using SalesAdventure.Map;
using static System.Net.Mime.MediaTypeNames;

namespace SalesAdventure.Entities
{
    public class Player : Creature
    {
        public Player(string CreatureIcon, int Lvl, string Name, double Hp, int Luck, int Strength, int Charisma, int Wackiness, int PositionY, int PositionX)
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
              
        public override void Blocking(Creature target)
        {

        }

        public override void Attack(Creature target)
        {
            Random random = new Random();
            int playerAttack = random.Next(1, 10) + this.Strength;
            bool isCriticalHit = random.Next(100) < this.Luck;
            if (isCriticalHit)
            {
                playerAttack *= 2;
                Console.WriteLine($"{this.Name} lands a critical hit on {target.Name}!");
            }
            target.Hp -= playerAttack;

            Console.WriteLine($"{this.Name} attacks {target.Name} for {playerAttack} damage. {target.Name} have now {target.Hp} HP left.");
        }

        public override void ThrowRock(Creature target)
        {
            Random random = new Random();
            double playerRock = (random.Next(1, 15) + this.Strength) * this.Wackiness;
            bool isCriticalHit = random.Next(80) < this.Luck;
            if (isCriticalHit)
            {
                playerRock *= 1.8;
                Console.WriteLine($"{this.Name} lands a critical hit with a rock on {target.Name}!");
            }
            target.Hp -= playerRock;

            Console.WriteLine($"{this.Name} throws a rock on {target.Name} for {playerRock} damage. {target.Name} stumbles and have now {target.Hp} HP left.");
        }

        public override void Attacks(Creature target)
        {
        }

        public void PlayerAttackMenu(DrawMap drawMap, Creature target, Player player1)
        {
            Console.Clear();
            Console.WriteLine($"{this.Name}'s Health: {this.Hp}  {target.Name} : {target.Hp}");
            Console.WriteLine(" 1. Attack\n 2. Throw Rock\n 3. Block\n 4. Flee");
            Mechanics.keyInfo = Console.ReadKey();
            switch (Mechanics.keyInfo.Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("Attacking monster");
                    this.Attack(target);
                    break;

                case ConsoleKey.D2:
                    Console.WriteLine("Throwing rock on monster");
                    this.ThrowRock(target);
                    break;

                case ConsoleKey.D3:
                    Console.WriteLine("Getting hit or blocking");
                    Console.ReadLine();
                    break;

                case ConsoleKey.D4:
                    player1.PositionX--;
                    Mechanics.monsterEncounter = false;
                    Mechanics.creatureCollision = false;
                    player1.PlacePlayer(drawMap);
                    break;

                default:
                    break;
            }
        }

        public void PlacePlayer(DrawMap drawMap)
        {
            drawMap.map[this.PositionY, this.PositionX] = this.CreatureIcon;
        }

        public void MovePlayer(DrawMap drawMap, int movePosY, int movePosX, int mapSizeY, int mapSizeX)
        {
            int newPosY = this.PositionY + movePosY;
            int newPosX = this.PositionX + movePosX;

            if (newPosY > 0 && newPosY < mapSizeY - 1 && newPosX > 0 && newPosX < mapSizeX - 1)
            {
                drawMap.map[this.PositionY, this.PositionX] = ".";
                this.PositionY = newPosY;
                this.PositionX = newPosX;
                PlacePlayer(drawMap);
            }
        }
    }
}
