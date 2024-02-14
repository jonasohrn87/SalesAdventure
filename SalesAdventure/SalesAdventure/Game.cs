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
            if (map[player1.playerPosY, player1.playerPosX] == map[cyclop.cyclopPosY, cyclop.cyclopPosX] || map[player1.playerPosY, player1.playerPosX] == map[goblin.goblinPosY, goblin.goblinPosX] || map[player1.playerPosY, player1.playerPosX] == map[orc.orcPosY, orc.orcPosX])
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
                            Console.WriteLine($"PlayerHealth: {player1.hp} MonsterHealth: {MonesterHp()}");
                            Console.WriteLine(" 1. Attack\n 2. Block\n 3. Flee");
                            keyInfo = Console.ReadKey();
                            switch (keyInfo.Key)
                            {
                                case ConsoleKey.D1:
                                    Console.WriteLine("Hitting monster");
                                    if (map[player1.playerPosY, player1.playerPosX] == map[cyclop.cyclopPosY, cyclop.cyclopPosX])
                                    {
                                        //DiceSet.Dices();
                                        cyclop.cyclopDefeated();

                                        if (cyclop.hp == 0)
                                        {
                                            PlacePlayer();
                                            monsterFight = false;
                                            monsterEncounter = false;
                                        }
                                    }
                                    else if (map[player1.playerPosY, player1.playerPosX] == map[goblin.goblinPosY, goblin.goblinPosX])
                                    {
                                        goblin.goblinDeafeated();
                                        
                                        if (goblin.hp == 0)
                                        {
                                            PlacePlayer();
                                            monsterFight = false;
                                            monsterEncounter = false;
                                        }
                                    }
                                    else if (map[player1.playerPosY, player1.playerPosX] == map[orc.orcPosY, orc.orcPosX])
                                    {
                                        orc.OrcDeafeated();

                                        if (orc.hp == 0)
                                        {
                                            PlacePlayer();
                                            monsterFight = false;
                                            monsterEncounter = false;
                                        }
                                    }
                                    break;

                                case ConsoleKey.D2:
                                    Console.WriteLine("Getting hit");
                                    break;

                                case ConsoleKey.D3:
                                    monsterFight = false;
                                    player1.playerPosX--;
                                    monsterEncounter = false;
                                    PlacePlayer();
                                    break;

                                default:
                                    break;
                            }
                        }
                    }
                    else if (keyInfo.Key == ConsoleKey.F)
                    {
                        monsterEncounter = false;
                        player1.playerPosX--;
                        PlacePlayer();
                    }
                    else
                    {
                        Console.WriteLine(" A. Attack!!\n F. Flee encounter!");
                        keyInfo = Console.ReadKey();
                    }
                }
            }
        }
        public int MonesterHp ()
        {
            if (map[player1.playerPosY, player1.playerPosX] == map[goblin.goblinPosY, goblin.goblinPosX])
            {
                //return Console.WriteLine(goblin.hp);
                return goblin.hp;
            }
            else if (map[player1.playerPosY, player1.playerPosX] == map[orc.orcPosY, orc.orcPosX])
            {
                //Console.WriteLine(orc.hp);
                return orc.hp;
            }
            else if (map[player1.playerPosY, player1.playerPosX] == map[cyclop.cyclopPosY, cyclop.cyclopPosX])
            {
                return cyclop.hp;
            }
            return 0;
        }
        //public GoblinAndPlayerPos()
        //{
        //    if (map[player1.playerPosY, player1.playerPosX] == map[goblin.goblinPosY, goblin.goblinPosX])
        //    {

        //    }
        //        return goblin.hp;
        //}
        //public void OrcAndPlayerPos()
        //{
        //    map[player1.playerPosY, player1.playerPosX] == map[orc.orcPosY, orc.orcPosX]
        //}
        //public void CyclopAndPlayerPos()
        //{
        //    map[player1.playerPosY, player1.playerPosX] == map[cyclop.cyclopPosY, cyclop.cyclopPosX]
        //}
        public void PlaceEnemies()
        {
            map[cyclop.cyclopPosY, cyclop.cyclopPosX] = cyclop.creatureIcon;
            map[goblin.goblinPosY, goblin.goblinPosX] = goblin.creatureIcon;
            map[orc.orcPosY, orc.orcPosX] = orc.creatureIcon;
        }
        private void SpawnEnemies()
        {
            Random randomMonsterPosition = new Random();

            cyclop.cyclopPosY = randomMonsterPosition.Next(1, mapSizeY - 1);
            cyclop.cyclopPosX = randomMonsterPosition.Next(1, mapSizeX - 1);

            goblin.goblinPosY = randomMonsterPosition.Next(1, mapSizeY - 1);
            goblin.goblinPosX = randomMonsterPosition.Next(1, mapSizeX - 1);

            orc.orcPosY = randomMonsterPosition.Next(1, mapSizeY - 1);
            orc.orcPosX = randomMonsterPosition.Next(1, mapSizeX - 1);

            map[cyclop.cyclopPosY, cyclop.cyclopPosX] = cyclop.creatureIcon;
            map[goblin.goblinPosY, goblin.goblinPosX] = goblin.creatureIcon;
            map[orc.orcPosY, orc.orcPosX] = orc.creatureIcon;
        }
        public void MovePlayer(int movePosY, int movePosX)
        {
            int newPosY = player1.playerPosY + movePosY;
            int newPosX = player1.playerPosX + movePosX;

            if (newPosY > 0 && newPosY < mapSizeY - 1 && newPosX > 0 && newPosX < mapSizeX - 1)
            {
                map[player1.playerPosY, player1.playerPosX] = ".";
                player1.playerPosY = newPosY;
                player1.playerPosX = newPosX;
                PlacePlayer();
            }
        }        
        public void PlacePlayer() => map[player1.playerPosY, player1.playerPosX] = player1.creatureIcon;
    }
}