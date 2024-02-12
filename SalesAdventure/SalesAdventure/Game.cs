using System;
using System.Threading.Channels;
using SalesAdventure.Map;

namespace SalesAdventure
{
    internal class Game
    {
        static int mapSizeX = 12;
        static int mapSizeY = 12;
        static string[,] map = new string[mapSizeY, mapSizeX];

        int playerPosX = 1;
        int playerPosY = 10;
        string player = "P";

        int monsterPosX = 3;
        int monsterPosY = 3;
        string monster = "M";

        bool runGame = true;

        public Game()
        {
        }
        public void Run()
        {
            Map.DrawMap drawMap = new Map.DrawMap(map, mapSizeX, mapSizeY);

            Console.WriteLine("Welcome Player!!\nPress Enter to play the SalesAdventures\n");
            Console.ReadLine();

            drawMap.Fill();
            PlacePlayer();
            SpawnEnemies();

            while (runGame)
            {
                Console.Clear();
                Console.WriteLine("Use Arrows or WASD to Move around or press Q to Quit\n");

                drawMap.Draw();
                drawMap.Fill();
                PlacePlayer();
                SpawnEnemies();
                MonsterEncounter();

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        MovePlayer(-1, 0);
                        break;

                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        MovePlayer(1, 0);
                        break;

                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A:
                        MovePlayer(0, -1);
                        break;

                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D:
                        MovePlayer(0, 1);
                        break;

                    case ConsoleKey.Q:
                        runGame = false;
                        break;

                    default:
                        break;
                }
            }
        }

        private void MonsterEncounter()
        {
            if (monsterPosY == playerPosY && monsterPosX == playerPosX && monster == "M")
            {
                Console.Clear();
                Console.WriteLine("You've encountered an Orge Giant, what will you do?");
                Console.WriteLine(" A. Attack!!\n F. Flee encounter!");

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.A)
                {
                    bool monsterFight = true;

                    while (monsterFight)
                    {
                        Console.Clear();
                        Console.WriteLine("PlayerHealth: \"100\" MonsterHealth: \"80\"");
                        Console.WriteLine(" 1. Attack\n 2. Block\n 3. Flee");
                        keyInfo = Console.ReadKey();
                        switch (keyInfo.Key)
                        {
                            case ConsoleKey.D1:
                                Console.WriteLine("Hitting monster");
                                monster = ".";
                                break;

                            case ConsoleKey.D2:
                                Console.WriteLine("Getting hit");
                                break;

                            case ConsoleKey.D3:
                                monsterFight = false;
                                playerPosX--;
                                PlacePlayer();
                                break;

                            default:
                                break;
                        }
                        if (monster == ".")
                        {
                            Console.Clear();
                            Console.WriteLine("You WON! Press any key to Continue.");
                            monsterFight = false;
                            PlacePlayer();
                        }
                    }
                }
                else if (keyInfo.Key == ConsoleKey.F)
                {
                    playerPosX--;
                    PlacePlayer();
                }
            }
        }

        private void SpawnEnemies()
        {
            map[monsterPosY, monsterPosX] = monster;
        }
        private void MovePlayer(int movePosY, int movePosX)
        {
            int newPosY = playerPosY + movePosY;
            int newPosX = playerPosX + movePosX;

            if (newPosY > 0 && newPosY < mapSizeY - 1 && newPosX > 0 && newPosX < mapSizeX - 1)
            {
                map[playerPosY, playerPosX] = ".";
                playerPosY = newPosY;
                playerPosX = newPosX;
                PlacePlayer();
            }
        }

            public void PlacePlayer()
        {
            map[playerPosY, playerPosX] = player;
        }
    }
}