using SalesAdventure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesAdventure;
using SalesAdventure.Map;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;

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

        private void InventoryConsumables(Player player1, Item pie, Item apple)
        {
            bool useItems = true;
            while (useItems)
            {
                Console.Clear();
                Inventory.ShowInventory(player1);
                //Console.WriteLine($"{this.Name}{Game.TextColor} Health: {Game.HpColor}{this.Hp}");
                Console.WriteLine($"{Game.TextColor}Press {Game.MenuOptionColor}[Number]{Game.TextColor} to use an item or {Game.MenuOptionColor}I{Game.TextColor} to close inventory");
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        if (Item.PlayerInventory.Count > 1)
                        {
                            if (Item.PlayerInventory[1] != null)
                            {
                                if (Item.PlayerInventory[1] == ($"{pie.Name} - {pie.Hp} +HP"))
                                {
                                    player1.Hp += pie.Hp;
                                }
                                else if ((Item.PlayerInventory[1] == $"{apple.Name} - {apple.Hp} +HP"))
                                {
                                    player1.Hp += apple.Hp;
                                }
                                Item.PlayerInventory.RemoveAt(1);
                            }
                        }
                        break;

                    case ConsoleKey.D2:

                        if (Item.PlayerInventory.Count > 2)
                        {
                            if (Item.PlayerInventory[2] != null)
                            {
                                if (Item.PlayerInventory[2] == ($"{pie.Name} - {pie.Hp} +HP"))
                                {
                                    player1.Hp += pie.Hp;
                                }
                                else if ((Item.PlayerInventory[2] == $"{apple.Name} - {apple.Hp} +HP"))
                                {
                                    player1.Hp += apple.Hp;
                                }
                                Item.PlayerInventory.RemoveAt(2);
                            }
                        }
                        break;

                    case ConsoleKey.I:
                        Console.WriteLine($"\n{Game.TextColor}Closing inventory");
                        useItems = false;
                        break;

                    default:
                        break;
                }
            }
        }
        public void Consumable(Player player1, Item pie, Item apple)
        {
            InventoryConsumables(player1, pie, apple);
        }

        public override void Attack(Creature target)
        {
            Random random = new Random();
            int playerAttack = random.Next(1, 10) + this.Strength;
            bool isCriticalHit = random.Next(100) < this.Luck;
            if (isCriticalHit)
            {
                playerAttack *= 2;
                Console.WriteLine($"\n{this.Name}{Game.TextColor} lands a critical hit on {target.Name}{Game.TextColor}!");
            }
            Math.Round(target.Hp -= playerAttack);

            Console.WriteLine($"\n{this.Name}{Game.TextColor} attacks {target.Name}{Game.TextColor} for {Game.HpColor}{playerAttack}{Game.TextColor} damage. {target.Name}{Game.TextColor} have now {Game.HpColor}{target.Hp}{Game.TextColor} HP left.");
        }

        public override void ThrowRock(Creature target)
        {
            Random random = new Random();
            double playerRock = (random.Next(1, 15) + this.Strength) * this.Wackiness;
            bool isCriticalHit = random.Next(80) < this.Luck;
            if (isCriticalHit)
            {
                Math.Round(playerRock *= 1.8);
                Console.WriteLine($"\n{this.Name}{Game.TextColor} lands a critical hit with a rock on {target.Name}{Game.TextColor}!");
            }
            Math.Round(target.Hp -= playerRock);

            Console.WriteLine($"\n{this.Name}{Game.TextColor} throws a rock on {target.Name}{Game.TextColor} for {Game.HpColor}{playerRock}{Game.TextColor} damage. {target.Name}{Game.TextColor} stumbles and have now {Game.HpColor}{target.Hp}{Game.TextColor} HP left.");
        }

        public override void Attacks(Creature target)
        {
        }

        private void PlayerAttackMenu(DrawMap drawMap, Creature target, Player player1, Item pie, Item apple)
        {
            string menuColor = "\u001b[38;5;180m";
            Console.Clear();
            Inventory.ShowInventory(player1);
            Console.WriteLine($"{this.Name}{menuColor} Health: {Game.HpColor}{this.Hp}  {target.Name} {menuColor}Health: {Game.HpColor}{target.Hp}");
            Console.WriteLine($"{Game.MenuOptionColor} 1{menuColor}. Attack\n {Game.MenuOptionColor}2{menuColor}. Throw Rock\n {Game.MenuOptionColor}I{menuColor}. Access Inventory\n {Game.MenuOptionColor}F{menuColor}. Flee\n");
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            switch (keyInfo.Key)
            {
                case ConsoleKey.D1:
                    this.Attack(target);
                    break;

                case ConsoleKey.D2:
                    this.ThrowRock(target);
                    break;

                case ConsoleKey.I:
                    Consumable(player1, pie, apple);
                    Console.ReadLine();
                    break;

                case ConsoleKey.F:
                    player1.PositionX--;
                    Mechanics.MonsterEncounter = false;
                    Mechanics.CreatureCollision = false;
                    player1.PlacePlayer(drawMap);
                    break;

                default:
                    break;
            }
        }
        public void AttackMenu(DrawMap drawMap, Creature target, Player player1, Item pie, Item apple)
        {
            PlayerAttackMenu(drawMap, target, player1, pie, apple);
        }

        private void PlacePlayer(DrawMap drawMap)
        {
            drawMap.Map[this.PositionY, this.PositionX] = this.CreatureIcon;
        }
        public void PlayerPlacement(DrawMap drawMap)
        {
            PlacePlayer(drawMap);
        }

        private void MovePlayer(DrawMap drawMap, int movePosY, int movePosX, int mapSizeY, int mapSizeX)
        {
            int newPosY = this.PositionY + movePosY;
            int newPosX = this.PositionX + movePosX;

            if (newPosY > 0 && newPosY < mapSizeY - 1 && newPosX > 0 && newPosX < mapSizeX - 1)
            {
                drawMap.Map[this.PositionY, this.PositionX] = ".";
                this.PositionY = newPosY;
                this.PositionX = newPosX;
                PlacePlayer(drawMap);
            }
        }
        public void MovingPlayer(DrawMap drawMap, int movePosY, int movePosX, int mapSizeY, int mapSizeX)
        {
            MovePlayer(drawMap, movePosY, movePosX, mapSizeY, mapSizeX);
        }
    }
}
