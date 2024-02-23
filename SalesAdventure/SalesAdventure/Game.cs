using System;
using System.Security.Cryptography;
using System.Threading.Channels;
using SalesAdventure.Entities;
using SalesAdventure.Map;
using SalesAdventure;
using System.Collections.Generic;

namespace SalesAdventure
{
    public class Game
    {
        public static int mapSizeX = 50;
        public static int mapSizeY = 18;
        public string[,] map = new string[mapSizeY, mapSizeX];
        public Game()
        {
        }
        public void Run()
        {
            Console.CursorVisible = false;
            string TextColorRed = "\u001b[31m";
            string TextColorGreen = "\u001b[32m";
            string BrigtGreen = "\u001b[92m";

            string TextColorReset = "\u001b[0m";

            //$"{TextColorRed}C{TextColorReset}"

            Player player1 = new Player("P", 1, "Tintin", 200, 10, 8, 6, 1, 16, 1);
            Cyclop cyclop1 = new Cyclop("C", 5, $"{TextColorRed}Ruben{TextColorReset}", 150, 4, 3, 2, 2, 2, 45);
            Orc orc1 = new Orc("O", 2, $"{TextColorGreen}Nikos{TextColorReset}", 100, 5, 8, 6, 1, 14, 12);
            Goblin goblin1 = new Goblin("G", 4, $"{BrigtGreen}Johnny{TextColorReset}", 85, 5, 8, 6, 1, 16, 5);
            DrawMap drawMap = new DrawMap(map, mapSizeX, mapSizeY);
            //Creature[] creature = { cyclop1, orc1, goblin1 };

            Item pie = new Item("Q", "Pie", 100, 0, 0, 0, 0, 8, 8);
            Item apple = new Item("A", "Apple", 50, 0, 0, 0, 0, 10, 10);
            Item.inventory.Add($" ");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Welcome Player!!\nPress Enter to play the SalesAdventures\n");
            Console.ReadLine();

            drawMap.Draw();
            Inventory.DrawInventory();
            drawMap.Fill();
            player1.PlacePlayer(drawMap);
            drawMap.PlaceObjects(cyclop1, goblin1, orc1, pie, apple);
            Mechanics.MovePlayer(drawMap, map, player1, cyclop1, goblin1, orc1, pie, apple, mapSizeY, mapSizeX);
        }
    }
}