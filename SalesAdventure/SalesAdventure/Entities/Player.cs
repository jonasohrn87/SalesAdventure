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
        public Player(string creatureIcon, int lvl, string name, double hp, int luck, int strength, int charisma, int wackiness, int positionY, int positionX)
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
            Random random = new Random();
            int playerAttack = random.Next(1, 10) + this.strength;
            bool isCriticalHit = random.Next(100) < this.luck;
            if (isCriticalHit)
            {
                playerAttack *= 2;
                Console.WriteLine($"{this.name} lands a critical hit on {target.name}!");
            }
            target.hp -= playerAttack;

            Console.WriteLine($"{this.name} attacks {target.name} for {playerAttack} damage. {target.name} have now {target.hp} HP left.");
        }

        public override void ThrowRock(Creature target)
        {
            Random random = new Random();
            double playerRock = (random.Next(1, 15) + this.strength) * this.wackiness;
            bool isCriticalHit = random.Next(80) < this.luck;
            if (isCriticalHit)
            {
                playerRock *= 1.8;
                Console.WriteLine($"{this.name} lands a critical hit with a rock on {target.name}!");
            }
            target.hp -= playerRock;

            Console.WriteLine($"{this.name} throws a rock on {target.name} for {playerRock} damage. {target.name} stumbles and have now {target.hp} HP left.");
        }

        public override void Attacks(Creature target)
        {
        }

        public void PlayerAttackMenu(DrawMap drawMap, Creature target, Player player1)
        {
            Console.Clear();
            Console.WriteLine($"{this.name}'s Health: {this.hp}  {target.name} : {target.hp}");
            Console.WriteLine(" 1. Attack\n 2. Throw Rock\n 3. Block\n 4. Flee");
            Mechanics.keyInfo = Console.ReadKey();
            switch (Mechanics.keyInfo.Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("Attacking monster");
                    this.Attack(target);
                    //if (target.hp > 0)
                    //{
                    //    target.Attacks(this);
                    //}
                    break;

                case ConsoleKey.D2:
                    Console.WriteLine("Throwing rock on monster");
                    this.ThrowRock(target);
                    //if (target.hp > 0)
                    //{
                    //    target.Attacks(this);
                    //}
                    break;

                case ConsoleKey.D3:
                    Console.WriteLine("Getting hit or blocking");
                    Console.ReadLine();
                    break;

                case ConsoleKey.D4:
                    player1.positionX--;
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
            drawMap.map[this.positionY, this.positionX] = this.creatureIcon;
        }

        public void MovePlayer(DrawMap drawMap, int movePosY, int movePosX, int mapSizeY, int mapSizeX)
        {
            int newPosY = this.positionY + movePosY;
            int newPosX = this.positionX + movePosX;

            if (newPosY > 0 && newPosY < mapSizeY - 1 && newPosX > 0 && newPosX < 32 - 1)
            {
                drawMap.map[this.positionY, this.positionX] = ".";
                this.positionY = newPosY;
                this.positionX = newPosX;
                PlacePlayer(drawMap);
            }
            //drawMap.Draw();
        }
    }
}
