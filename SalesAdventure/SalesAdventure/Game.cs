using System;
using System.Security.Cryptography;
using System.Threading.Channels;
using SalesAdventure.Entities;
using SalesAdventure.Map;

namespace SalesAdventure
{
    public class Game
    {

        Player player1 = new Player("P", 1, "Tintin", 100, 5, 8, 6, 0);
        Cyclop cyclop = new Cyclop("C", 5, "Ruben", 150, 4, 3, 2, 0);
        Goblin goblin = new Goblin("G", 4, "Johnny", 100, 5, 8, 6, 0);
        Orc orc = new Orc("O", 2, "Nikos", 100, 5, 8, 6, 0);

        static int mapSizeX = 12;
        static int mapSizeY = 12;
        static string[,] map = new string[mapSizeY, mapSizeX];

        int playerPosX = 1;
        int playerPosY = 10;

        int monsterPosX = 3;
        int monsterPosY = 3;
        int orcPosY = 4;
        int orcPosX = 4;
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
            SpawnEnemies();
            PlacePlayer();


            while (runGame)
            {
                Console.Clear();
                Console.WriteLine("Use Arrows or WASD to Move around or press Q to Quit\n");

                drawMap.Draw();
                drawMap.Fill();

                PlacePlayer();
                PlaceEnemies();                
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
            // if (monsterPosY == playerPosY && monsterPosX == playerPosX && monster == "M" || orc.creatureIcon == "O")
            // if (orcPosY == playerPosY && orcPosX == playerPosX)
            if (map[playerPosY, playerPosX] == map[orcPosY, orcPosX] || map[playerPosY, playerPosX] == map[monsterPosY, monsterPosX])
            {
                Console.Clear();
                Console.WriteLine("You've encountered an Ogre Giant, what will you do?");
                Console.WriteLine(" A. Attack!!\n F. Flee encounter!");

                // orcPosX = 0;
                // orcPosY = 0;
                // orc.creatureIcon = "#";

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

        private void PlaceEnemies()
        {
            map[monsterPosY, monsterPosX] = monster;
            map[orcPosY, orcPosX] = orc.creatureIcon;
        }
        
        private void SpawnEnemies()
        {
            Random randomMonsterPosition = new Random();
            monsterPosY = randomMonsterPosition.Next(1, mapSizeY - 1);
            monsterPosX = randomMonsterPosition.Next(1, mapSizeX - 1);
            
            orcPosY = randomMonsterPosition.Next(1, mapSizeY - 1);
            orcPosX = randomMonsterPosition.Next(1, mapSizeX - 1);
            
            map[orcPosY, orcPosX] = orc.creatureIcon;
            map[monsterPosY, monsterPosX] = monster;
            
        }
        public void MovePlayer(int movePosY, int movePosX)
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
            map[playerPosY, playerPosX] = player1.creatureIcon;
        }
    }
}