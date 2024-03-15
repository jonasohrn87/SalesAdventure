using SalesAdventure.Entities;
using SalesAdventure.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesAdventure
{
    public class Mechanics
    {
        public Mechanics()
        {
        }
        private static bool creatureCollision = false;
        private static bool monsterEncounter = false;
        private static bool itemCollision = false;

        public static bool CreatureCollision
        {
            get { return creatureCollision; }
            set { creatureCollision = value; }
        }
        public static bool MonsterEncounter
        {
            get { return monsterEncounter; }
            set { monsterEncounter = value; }
        }
        public static bool ItemCollision
        {
            get { return itemCollision; }
            set { itemCollision = value; }
        }
        private static void PlayerDeath()
        {
            // Kommande feature där spelaren faktiskt kan dö...
        }
        public static void Death()
        {
            PlayerDeath();
        }

        //Metod som kollar om kollision mellan spelare och ett objekt sker.
        private static bool CollisionPosition(string[,] map, DrawMap drawMap, Player player1, Cyclop cyclop1, Goblin goblin1, Orc orc1, Item pie, Item apple)
        {
            if (map[player1.PositionY, player1.PositionX] == map[cyclop1.PositionY, cyclop1.PositionX] || map[player1.PositionY, player1.PositionX] == map[goblin1.PositionY, goblin1.PositionX] || map[player1.PositionY, player1.PositionX] == map[orc1.PositionY, orc1.PositionX])
            {
                return CreatureCollision = true;
            }
            else if (map[player1.PositionY, player1.PositionX] == map[pie.PositionY, pie.PositionX] || map[player1.PositionY, player1.PositionX] == map[apple.PositionY, apple.PositionX])
            {
                return ItemCollision = true;
            }
            else
                return (CreatureCollision = false) & (ItemCollision = false);
        }

        public static bool Collision(string[,] map, DrawMap drawMap, Player player1, Cyclop cyclop1, Goblin goblin1, Orc orc1, Item pie, Item apple)
        {
            return CollisionPosition(map, drawMap, player1, cyclop1, goblin1, orc1, pie, apple);
        }

        // När kollision mellan spelare och monster/item inträffar öppnas menyval.
        private static void Encounters(string[,] map, DrawMap drawMap, Player player1, Cyclop cyclop1, Goblin goblin1, Orc orc1, Item pie, Item apple)
        {
            string menuColor = "\u001b[38;5;196m";
            Collision(map, drawMap, player1, cyclop1, goblin1, orc1, pie, apple);

            Console.ForegroundColor = ConsoleColor.DarkYellow;

            while (ItemCollision)
            {
                Item.ItemPie(drawMap, map, player1, cyclop1, goblin1, orc1, pie, apple);
                Item.ItemApple(drawMap, map, player1, cyclop1, goblin1, orc1, pie, apple);
            }

            while (CreatureCollision)
            {
                Console.Clear();
                Console.WriteLine($"{menuColor}You've encountered an Enemy! What will you do?");
                Console.WriteLine($"\n{Game.MenuOptionColor}A{menuColor}. Attack!!\n{Game.MenuOptionColor}F{menuColor}. Flee encounter!\n");

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.A)
                {
                    orc1.OrcEncount(drawMap, map, player1, orc1, pie, apple);
                    cyclop1.CyclopEncount(drawMap, map, player1, cyclop1, pie, apple);
                    goblin1.GoblinEncount(drawMap, map, player1, goblin1, pie, apple);
                }
                else if (keyInfo.Key == ConsoleKey.F)
                {
                    CreatureCollision = false;
                    player1.PositionX--;
                    player1.PlayerPlacement(drawMap);
                }
                else
                {
                    Console.WriteLine("\nA. Attack!!\nF. Flee encounter!\n");
                    Console.Clear();
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
        }

        public static void Encounter(string[,] map, DrawMap drawMap, Player player1, Cyclop cyclop1, Goblin goblin1, Orc orc1, Item pie, Item apple)
        {
            Encounters(map, drawMap, player1, cyclop1, goblin1, orc1, pie, apple);
        }


        // Ändrar items-iconer på kartan till frågetecken
        public static void HideItem(string[,] map, Item pie, Item apple)
        {
            string itemColor = "\u001b[38;5;192m";
            if (map[pie.PositionY, pie.PositionX] == map[8, 8])
            {
                map[8, 8] = $"{itemColor}?";
            }
            else
            {
                map[8, 8] = ".";
            }
            if (map[apple.PositionY, apple.PositionX] == map[10, 10])
            {
                map[10, 10] = $"{itemColor}?";
            }
            else
            {
                map[10, 10] = ".";
            }
        }

        private static void MovePlayer(DrawMap drawMap, string[,] map, Player player1, Cyclop cyclop1, Goblin goblin1, Orc orc1, Item pie, Item apple, int mapSizeY, int mapSizeX)
        {
            string menuColor = "\u001b[38;5;130m";
            bool runGame = true;
            while (runGame)
            {
                Console.Clear();
                Console.WriteLine($"{menuColor}Use {Game.MenuOptionColor}Arrows{menuColor} or {Game.MenuOptionColor}WASD{menuColor} to Move around, {Game.MenuOptionColor}Q{menuColor} to Quit ------ Use {Game.MenuOptionColor}[number]{menuColor} to comsume an item from Inventory\u001b[38;2;0;0;0m\u001b[48;5;237m");
                drawMap.DrawUp();
                Inventory.ShowInventory(player1);
                drawMap.FillUp();
                drawMap.MapColor();
                player1.PlayerPlacement(drawMap);
                drawMap.PlaceObject(cyclop1, goblin1, orc1, pie, apple);
                Encounter(map, drawMap, player1, cyclop1, goblin1, orc1, pie, apple);
                HideItem(map, pie, apple);

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        player1.MovingPlayer(drawMap, -1, 0, mapSizeY, mapSizeX);
                        break;

                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        player1.MovingPlayer(drawMap, 1, 0, mapSizeY, mapSizeX);
                        break;

                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A:
                        player1.MovingPlayer(drawMap, 0, -1, mapSizeY, mapSizeX);
                        break;

                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D:
                        player1.MovingPlayer(drawMap, 0, 1, mapSizeY, mapSizeX);
                        break;

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

                        // Kommande menyval...
                    case ConsoleKey.D3:
                        break;

                    case ConsoleKey.D4:
                        break;

                    case ConsoleKey.D5:
                        break;

                    case ConsoleKey.D6:
                        break;

                    case ConsoleKey.D7:
                        break;

                    case ConsoleKey.D8:
                        break;

                    case ConsoleKey.D9:
                        break;

                    case ConsoleKey.Q:
                        runGame = false;
                        break;

                    default:
                        break;
                }
            }
        }
        public static void MoveingPlayer(DrawMap drawMap, string[,] map, Player player1, Cyclop cyclop1, Goblin goblin1, Orc orc1, Item pie, Item apple, int mapSizeY, int mapSizeX)
        {
            MovePlayer(drawMap, map, player1, cyclop1, goblin1, orc1, pie, apple, mapSizeY, mapSizeX);
        }
    }
}