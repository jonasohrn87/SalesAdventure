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
        public static int mapSizeX = 60;
        public static int mapSizeY = 24;
        public string[,] map = new string[mapSizeY, mapSizeX];

        public Game()
        {
        }
        public void Run()
        {
            string TextColorRed = "\u001b[31m";
            string TextColorGreen = "\u001b[32m";
            string BrigtGreen = "\u001b[92m";

            string TextColorReset = "\u001b[0m";

            //$"{TextColorRed}C{TextColorReset}"

            Player player1 = new Player("P", 1, "Tintin", 200, 10, 8, 6, 1, 10, 1);
            Cyclop cyclop1 = new Cyclop("C", 5, $"{TextColorRed}Ruben{TextColorReset}", 150, 4, 3, 2, 2, 0, 0);
            Orc orc1 = new Orc("O", 2, $"{TextColorGreen}Nikos{TextColorReset}", 100, 5, 8, 6, 1, 0, 0);
            Goblin goblin1 = new Goblin("G", 4, $"{BrigtGreen}Johnny{TextColorReset}", 85, 5, 8, 6, 1, 0, 0);
            DrawMap drawMap = new DrawMap(map, mapSizeX, mapSizeY);
            Inventory inventory = new Inventory(map, mapSizeX, mapSizeY);
            //Creature[] creature = { cyclop1, orc1, goblin1 };

            Console.WriteLine("Welcome Player!!\nPress Enter to play the SalesAdventures\n");
            Console.ReadLine();

            drawMap.Draw();
            Inventory.DrawInventory(drawMap, map, mapSizeY, mapSizeX);
            drawMap.Fill();
            drawMap.SpawnEnemies(cyclop1, goblin1, orc1);
            player1.PlacePlayer(drawMap);
            Mechanics.MovePlayer(drawMap, map, player1, cyclop1, goblin1, orc1, mapSizeY, mapSizeX);
        }
    }
}