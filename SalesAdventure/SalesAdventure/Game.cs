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
            Player player1 = new Player("P", 1, "Tintin", 100, 5, 8, 6, 1, 10, 1);
            Cyclop cyclop = new Cyclop("C", 5, "Ruben", 150, 4, 3, 2, 0, 0, 0);
            Orc orc = new Orc("O", 2, "Nikos", 100, 5, 8, 6, 0, 0, 0);
            Goblin goblin = new Goblin("G", 4, "Johnny", 85, 5, 8, 6, 0, 0, 0);
            DrawMap drawMap = new DrawMap(map, mapSizeX, mapSizeY);
            Console.WriteLine("Welcome Player!!\nPress Enter to play the SalesAdventures\n");
            Console.ReadLine();

            drawMap.Fill();
            drawMap.SpawnEnemies(cyclop, goblin, orc);
            player1.PlacePlayer(drawMap);
            Mechanics.MovePlayer(drawMap, map, player1, cyclop, goblin, orc, mapSizeY, mapSizeX);
        }
    }
}