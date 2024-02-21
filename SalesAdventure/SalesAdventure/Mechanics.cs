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

        public static bool CollisionPosition(string[,] map, DrawMap drawMap, Player player1, Cyclop cyclop1, Goblin goblin1, Orc orc1, Item pie, Item apple)
        {
            if (map[player1.positionY, player1.positionX] == map[cyclop1.positionY, cyclop1.positionX] || map[player1.positionY, player1.positionX] == map[goblin1.positionY, goblin1.positionX] || map[player1.positionY, player1.positionX] == map[orc1.positionY, orc1.positionX])
            {
                return creatureCollision = true;
            }
            else if (map[player1.positionY, player1.positionX] == map[pie.positionY, pie.positionX] || map[player1.positionY, player1.positionX] == map[apple.positionY, apple.positionX])
            {
                return itemCollision = true;
            }
            else
            return (creatureCollision = false) & (itemCollision = false);
        }

        public static void Encounters(string[,] map, DrawMap drawMap, Player player1, Cyclop cyclop1, Goblin goblin1, Orc orc1, Item pie, Item apple)
        {
            CollisionPosition(map, drawMap, player1, cyclop1, goblin1, orc1, pie, apple);


            if (!itemCollision && map[player1.positionY, player1.positionX] == map[pie.positionY, pie.positionX])
            {
                map[3, 45] = pie.name + pie.hp; // skriv ut item i inventory
            }
            //else if (!itemCollision && map[player1.positionY, player1.positionX] == map[apple.positionY, apple.positionX])
            //{

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
                    player1.positionX--;
                    player1.PlacePlayer(drawMap);
                }
                else
                {
                    Console.WriteLine("\nA. Attack!!\nF. Flee encounter!\n");
                    keyInfo = Console.ReadKey();
                }
            }
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
