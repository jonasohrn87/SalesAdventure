using SalesAdventure.Entities;
using SalesAdventure.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesAdventure
{
    internal class Mechanics
    {
        public static void MonsterEncounter(string[,] map, DrawMap drawMap, Player player1, Cyclop cyclop, Goblin goblin, Orc orc)
        {
            if (map[player1.positionY, player1.positionX] == map[cyclop.positionY, cyclop.positionX] || map[player1.positionY, player1.positionX] == map[goblin.positionY, goblin.positionX] || map[player1.positionY, player1.positionX] == map[orc.positionY, orc.positionX])
            {
                bool monsterEncounter = true;

                while (monsterEncounter)
                {
                    Console.Clear();
                    Console.WriteLine("You've encountered an Enemy! What will you do?");
                    Console.WriteLine(" A. Attack!!\n F. Flee encounter!");

                    ConsoleKeyInfo keyInfo = Console.ReadKey();

                    if (keyInfo.Key == ConsoleKey.A)
                    {
                        bool monsterFight = true;

                        while (monsterFight)
                        {
                            Console.Clear();
                            Console.WriteLine($"{player1.name}'s Health: {player1.hp} MonsterHealth: {MonesterHp(map, player1, cyclop, goblin, orc)}");
                            Console.WriteLine(" 1. Attack\n 2. Block\n 3. Flee");
                            keyInfo = Console.ReadKey();
                            switch (keyInfo.Key)
                            {
                                case ConsoleKey.D1:
                                    Console.WriteLine("Hitting monster");
                                    if (map[player1.positionY, player1.positionX] == map[cyclop.positionY, cyclop.positionX])
                                    {
                                        //cyclop.CyclopFight(player1);
                                        cyclop.CyclopDeafeated();

                                        if (cyclop.hp == 0)
                                        {
                                            player1.PlacePlayer(drawMap);
                                            monsterFight = false;
                                            monsterEncounter = false;
                                        }
                                    }
                                    else if (map[player1.positionY, player1.positionX] == map[orc.positionY, orc.positionX])
                                    {
                                        orc.OrcDeafeated();

                                        if (orc.hp == 0)
                                        {
                                            player1.PlacePlayer(drawMap);
                                            monsterFight = false;
                                            monsterEncounter = false;
                                        }
                                    }
                                    else if (map[player1.positionY, player1.positionX] == map[goblin.positionY, goblin.positionX])
                                    {
                                        goblin.GoblinDeafeated();

                                        if (goblin.hp == 0)
                                        {
                                            player1.PlacePlayer(drawMap);
                                            monsterFight = false;
                                            monsterEncounter = false;
                                        }
                                    }
                                    break;

                                case ConsoleKey.D2:
                                    Console.WriteLine("Getting hit");
                                    break;

                                case ConsoleKey.D3:
                                    monsterFight = false;//lägg till förgående position istället, hamnar i väggen om de är på vänster sida
                                    player1.positionX--;
                                    monsterEncounter = false;
                                    player1.PlacePlayer(drawMap);
                                    break;

                                default:
                                    break;
                            }
                        }
                    }
                    else if (keyInfo.Key == ConsoleKey.F)
                    {
                        monsterEncounter = false;
                        player1.positionX--;
                        player1.PlacePlayer(drawMap);
                    }
                    else
                    {
                        Console.WriteLine(" A. Attack!!\n F. Flee encounter!");
                        keyInfo = Console.ReadKey();
                    }
                }
            }
        }
        public static int MonesterHp(string[,] map, Player player1, Cyclop cyclop, Goblin goblin, Orc orc)
        {
            if (map[player1.positionY, player1.positionX] == map[goblin.positionY, goblin.positionX])
            {
                return goblin.hp;
            }
            else if (map[player1.positionY, player1.positionX] == map[orc.positionY, orc.positionX])
            {
                return orc.hp;
            }
            else if (map[player1.positionY, player1.positionX] == map[cyclop.positionY, cyclop.positionX])
            {
                return cyclop.hp;
            }
            return 0;
        }
        public static void MovePlayer(DrawMap drawMap, string[,] map, Player player1, Cyclop cyclop, Goblin goblin, Orc orc, int mapSizeY, int mapSizeX)
        {
            bool runGame = true;
            while (runGame)
            {
                Console.Clear();
                Console.WriteLine("Use Arrows or WASD to Move around or press Q to Quit\n");

                drawMap.Draw();
                drawMap.Fill();

                player1.PlacePlayer(drawMap);
                drawMap.PlaceEnemies(player1, cyclop, goblin, orc);
                Mechanics.MonsterEncounter(map, drawMap, player1, cyclop, goblin, orc);

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
