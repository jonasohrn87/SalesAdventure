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

            
            //Console.Clear();
            drawMap.Fill();
            PlacePlayer();
            SpawnEnemies();
             

            //Console.ReadLine();

            while (runGame)
            {
                Console.Clear();
                Console.WriteLine("Use Arrows or WASD to Move around or press Q to Quit\n");
                drawMap.Draw();
                drawMap.Fill();
                PlacePlayer();
                SpawnEnemies();


                ConsoleKeyInfo keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        MovePlayer("W");
                        break;

                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        MovePlayer("S");
                        break;

                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A:
                        MovePlayer("A");
                        break;

                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D:
                        MovePlayer("D");
                        break;

                    case ConsoleKey.Q:
                        runGame = false;
                        break;

                    default:
                        break;
                }
            }
        }

        private void SpawnEnemies()
        {
            map[monsterPosY, monsterPosX] = monster;
        }

        private void MovePlayer(string direction)
        {

            if (direction == "W")
            {
                {
                    map[playerPosY, playerPosX] = ".";
                    playerPosY--;
                    PlacePlayer();
                }
            }
            else if (direction == "S")
            {
                {
                    map[playerPosY, playerPosX] = ".";
                    playerPosY++;
                    PlacePlayer();
                }
            }
            else if (direction == "A")
            {
                {
                    map[playerPosY, playerPosX] = ".";
                    playerPosX--;
                    PlacePlayer();
                }
            }
            else if (direction == "D")
            {
                {
                    map[playerPosY, playerPosX] = ".";
                    playerPosX++;
                    PlacePlayer();
                }
            }
        }

        public void PlacePlayer()
        {
            if (playerPosY <= 0)
            {
                playerPosY++;
            }
            else if (playerPosY >= 11)
            {
                playerPosY--;
            }
            else if (playerPosX <= 0)
            {
                playerPosX++;
            }
            else if (playerPosX >= 11)
            {
                playerPosX--;
            }
            map[playerPosY, playerPosX] = player;
        }       
    }
}