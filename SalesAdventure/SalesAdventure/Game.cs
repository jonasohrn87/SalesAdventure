using System;
using System.Security.Cryptography;
using System.Threading.Channels;
using SalesAdventure.Entities;
using SalesAdventure.Map;
using SalesAdventure;

namespace SalesAdventure
{
    public class Game
    {

        Player player1 = new Player("P", 1, "Tintin", 100, 5, 8, 6, 1, 10, 1);
        Cyclop cyclop = new Cyclop("C", 5, "Ruben", 150, 4, 3, 2, 0, 0, 0);
        Orc orc = new Orc("O", 2, "Nikos", 100, 5, 8, 6, 0, 0, 0);
        Goblin goblin = new Goblin("G", 4, "Johnny", 85, 5, 8, 6, 0, 0, 0);
        public static int mapSizeX = 12;
        public static int mapSizeY = 12;
        public  string[,] map = new string[mapSizeY, mapSizeX];
        private DrawMap drawMap;
        bool runGame = true;

        public Game()
        {
            drawMap = new DrawMap(map, mapSizeX, mapSizeY);
        }
        public void Run()
        {
            Console.WriteLine("Welcome Player!!\nPress Enter to play the SalesAdventures\n");
            Console.ReadLine();

            drawMap.Fill();
            SpawnEnemies();
            player1.PlacePlayer(drawMap);

            while (runGame)
            {
                Console.Clear();
                Console.WriteLine("Use Arrows or WASD to Move around or press Q to Quit\n");

                drawMap.Draw();
                drawMap.Fill();

                player1.PlacePlayer(drawMap);
                PlaceEnemies();
                MonsterEncounter();

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
        private void MonsterEncounter()
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
                            Console.WriteLine($"{player1.name}'s Health: {player1.hp} MonsterHealth: {MonesterHp()}");
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
        public int MonesterHp()
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
        public void PlaceEnemies()
        {
            map[cyclop.positionY, cyclop.positionX] = cyclop.creatureIcon;
            map[orc.positionY, orc.positionX] = orc.creatureIcon;
            map[goblin.positionY, goblin.positionX] = goblin.creatureIcon;
        }
        private void SpawnEnemies()
        {
            Random randomMonsterPosition = new Random();

            cyclop.positionY = randomMonsterPosition.Next(1, mapSizeY - 1);
            cyclop.positionX = randomMonsterPosition.Next(1, mapSizeX - 1);

            orc.positionY = randomMonsterPosition.Next(1, mapSizeY - 1);
            orc.positionX = randomMonsterPosition.Next(1, mapSizeX - 1);

            goblin.positionY = randomMonsterPosition.Next(1, mapSizeY - 1);
            goblin.positionX = randomMonsterPosition.Next(1, mapSizeX - 1);


            map[cyclop.positionY, cyclop.positionX] = cyclop.creatureIcon;
            map[orc.positionY, orc.positionX] = orc.creatureIcon;
            map[goblin.positionY, goblin.positionX] = goblin.creatureIcon;
        }
        
    }
}