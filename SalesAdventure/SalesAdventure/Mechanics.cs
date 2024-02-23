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
        public static bool creatureCollision = false;
        public static bool monsterEncounter = false;
        public static bool itemCollision = false;
        public static ConsoleKeyInfo keyInfo = Console.ReadKey();

        public static void PlayerDeath()
        {

        }

        public static bool CollisionPosition(string[,] map, DrawMap drawMap, Player player1, Cyclop cyclop1, Goblin goblin1, Orc orc1, Item pie, Item apple)
        {
            if (map[player1.PositionY, player1.PositionX] == map[cyclop1.PositionY, cyclop1.PositionX] || map[player1.PositionY, player1.PositionX] == map[goblin1.PositionY, goblin1.PositionX] || map[player1.PositionY, player1.PositionX] == map[orc1.PositionY, orc1.PositionX])
            {
                return creatureCollision = true;
            }
            else if (map[player1.PositionY, player1.PositionX] == map[pie.PositionY, pie.PositionX] || map[player1.PositionY, player1.PositionX] == map[apple.PositionY, apple.PositionX])
            {
                return itemCollision = true;
            }
            else
                return (creatureCollision = false) & (itemCollision = false);
        }



        public static void Encounters(string[,] map, DrawMap drawMap, Player player1, Cyclop cyclop1, Goblin goblin1, Orc orc1, Item pie, Item apple)
        {
            CollisionPosition(map, drawMap, player1, cyclop1, goblin1, orc1, pie, apple);

            Console.ForegroundColor = ConsoleColor.DarkYellow;

            while (itemCollision)
            {
                Item.Pie(map, player1, pie);
                Item.Apple(map, player1, apple);
            }

            while (creatureCollision)
            {
                Console.Clear();
                Console.WriteLine("You've encountered an Enemy! What will you do?");
                Console.WriteLine("\nA. Attack!!\nF. Flee encounter!\n");

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.A)
                {
                    orc1.OrcEncounter(drawMap, map, player1, orc1);
                    cyclop1.CyclopEncounter(drawMap, map, player1, cyclop1);
                    goblin1.GoblinEncounter(drawMap, map, player1, goblin1);
                }
                else if (keyInfo.Key == ConsoleKey.F)
                {
                    creatureCollision = false;
                    player1.PositionX--;
                    player1.PlacePlayer(drawMap);
                }
                else
                {
                    Console.WriteLine("\nA. Attack!!\nF. Flee encounter!\n");
                    keyInfo = Console.ReadKey();
                    Console.Clear();
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
        }

        public static void MovePlayer(DrawMap drawMap, string[,] map, Player player1, Cyclop cyclop1, Goblin goblin1, Orc orc1, Item pie, Item apple, int mapSizeY, int mapSizeX)
        {
            bool runGame = true;
            while (runGame)
            {
                Console.Clear();
                Console.WriteLine("Use Arrows or WASD to Move around or press Q to Quit ------------------- Press [number] to comsume an item from Inventory");

                drawMap.Draw();
                drawMap.Fill();
                Inventory.DrawInventory();
                player1.PlacePlayer(drawMap);

                drawMap.PlaceObjects(cyclop1, goblin1, orc1, pie, apple);
                Mechanics.Encounters(map, drawMap, player1, cyclop1, goblin1, orc1, pie, apple);

                keyInfo = Console.ReadKey();


                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        player1.MovePlayer(drawMap, -1, 0, mapSizeY, mapSizeX);
                        break;

                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        player1.MovePlayer(drawMap, 1, 0, mapSizeY, mapSizeX);
                        break;

                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A:
                        player1.MovePlayer(drawMap, 0, -1, mapSizeY, mapSizeX);
                        break;

                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D:
                        player1.MovePlayer(drawMap, 0, 1, mapSizeY, mapSizeX);
                        break;

                    case ConsoleKey.D1:

                        if (Item.inventory[1] != null)
                        {
                            if (Item.inventory[1] == ($"{pie.Name} - {pie.Hp} +HP"))
                            {
                                player1.Hp += pie.Hp;
                            }
                            else if ((Item.inventory[1] == $"{apple.Name} - {apple.Hp} +HP"))
                            {
                                player1.Hp += apple.Hp;
                            }
                            Item.inventory.RemoveAt(1);
                        }
                        //else 
                        //{ 
                        //    Console.WriteLine("No such item exist in inventory"); 
                        //}
                        break;


                    case ConsoleKey.D2:

                        if (Item.inventory[2] != null)
                        {
                            if (Item.inventory[2] == ($"{pie.Name} - {pie.Hp} +HP"))
                            {
                                player1.Hp += pie.Hp;
                            }
                            else if ((Item.inventory[2] == $"{apple.Name} - {apple.Hp} +HP"))
                            {
                                player1.Hp += apple.Hp;
                            }
                            Item.inventory.RemoveAt(2);
                        }
                        //else
                        //{
                        //    Console.WriteLine("No such item exist in inventory");
                        //}
                        break;

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
    }
}