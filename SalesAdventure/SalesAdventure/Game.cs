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
        public static int mapSizeX = 12;
        public static int mapSizeY = 12;
        public string[,] map = new string[mapSizeY, mapSizeX];

        public Game()
        {
        }
        public void Run()
        {
            Player player1 = new Player("P", 1, "Tintin", 200, 2, 8, 6, 1, 10, 1);
            Cyclop cyclop1 = new Cyclop("C", 5, "Ruben", 150, 4, 3, 2, 2, 0, 0);
            Orc orc1 = new Orc("O", 2, "Nikos", 100, 5, 8, 6, 1, 0, 0);
            Goblin goblin1 = new Goblin("G", 4, "Johnny", 85, 5, 8, 6, 1, 0, 0);
            DrawMap drawMap = new DrawMap(map, mapSizeX, mapSizeY);
            //Creature[] creature = { cyclop1, orc1, goblin1 };

            Console.WriteLine("Welcome Player!!\nPress Enter to play the SalesAdventures\n");
            Console.ReadLine();

            drawMap.Draw();
            drawMap.Fill();
            drawMap.SpawnEnemies(cyclop1, goblin1, orc1);
            player1.PlacePlayer(drawMap);
            Mechanics.MovePlayer(drawMap, map, player1, cyclop1, goblin1, orc1, mapSizeY, mapSizeX);
        }
    }
}