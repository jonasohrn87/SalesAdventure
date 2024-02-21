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

            //if (itemCollision && map[player1.positionY, player1.positionX] == map[pie.positionY, pie.positionX])
            //{
            //    Item.inventory.Add(1, $"{pie.name} - {pie.hp} HP");
            //    Item.inventory.Add(2, $"{apple.name} - {apple.hp} HP");

            //    int key = 1;
            //    Item.inventory.TryGetValue(key, out string inventoryItem);
            //    Console.WriteLine(inventoryItem ?? "");
            //    Console.ReadLine();
            //    //map[3, 45] = pie.name + pie.hp; // skriv ut item i inventory
            //    //pie.positionY = 3;
            //    //pie.positionX = 45;
            //    //pie.itemIcon = pie.name;
            //}
            //else if (itemCollision && map[player1.positionY, player1.positionX] == map[apple.positionY, apple.positionX])
            //{
            //    //map[5, 45] = 
            //        Console.Write(apple.name + apple.hp); // skriv ut item i inventory
            //    apple.positionY = 5;
            //    apple.positionX = 45;
            //}

            while (creatureCollision)
            {
                Console.Clear();
                Console.WriteLine("You've encountered an Enemy! What will you do?");
                Console.WriteLine("\nA. Attack!!\nF. Flee encounter!\n");

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.A)
                {
                    //Creature.EncounterFight(drawMap, map, player1, orc1);
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
                Console.WriteLine("Use Arrows or WASD to Move around or press Q to Quit\n");
                Console.WriteLine("Press [number] to comsume an item from Inventory\n");

                drawMap.Draw();
                drawMap.Fill();

                player1.PlacePlayer(drawMap);
                //drawMap.PlaceEnemies(player1, cyclop1, goblin1, orc1);
                //drawMap.PlaceItems(pie, apple);
                drawMap.PlaceObjects(cyclop1, goblin1, orc1, pie, apple);
                Mechanics.Encounters(map, drawMap, player1, cyclop1, goblin1, orc1, pie, apple);
                Inventory.DrawInventory(drawMap, map, mapSizeY, mapSizeX);

                ConsoleKeyInfo keyInfo = Console.ReadKey();

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
                        break;

                    case ConsoleKey.D2:
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