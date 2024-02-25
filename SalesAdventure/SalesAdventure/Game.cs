using System;
using System.Security.Cryptography;
using System.Threading.Channels;
using SalesAdventure.Entities;
using SalesAdventure.Map;
using SalesAdventure;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SalesAdventure
{
    public class Game
    {
        private static int mapSizeX = 50;
        private static int mapSizeY = 18;
        private string[,] map = new string[MapSizeY, MapSizeX];
        private static string textColor = "\u001b[38;5;222m";
        private static string colorReset = "\u001b[0m";
        private static string hpColor = "\u001b[38;5;124m";
        private static string menuOptionColor = "\u001b[38;5;220m";

        public static int MapSizeX
        {
            get { return mapSizeX; }
            set { mapSizeX = value; }
        }
        public static int MapSizeY
        {
            get { return mapSizeY; }
            set { mapSizeY = value; }
        }
        public string[,] Map
        {
            get { return map; }
            set { map = value; }
        }
        public static string ColorReset
        {
            get { return colorReset; }
            set { colorReset = value; }
        }
        public static string TextColor
        {
            get { return textColor; }
            set { textColor = value; }
        }
        public static string HpColor
        {
            get { return hpColor; }
            set { hpColor = value; }
        }
        public static string MenuOptionColor
        {
            get { return menuOptionColor; }
            set { menuOptionColor = value; }
        }

        public Game()
        {
        }
        private void Run()
        {
            Console.CursorVisible = false;
            string playerColor = "\u001b[38;5;223m";
            string cyclopColor = "\u001b[31m";
            string orcColor = "\u001b[32m";
            string goblinColor = "\u001b[92m";

            Player player1 = new Player($"{playerColor}P", 1, $"{playerColor}Tintin", 200, 10, 8, 6, 1, 16, 1);
            Cyclop cyclop1 = new Cyclop($"{cyclopColor}C", 5, $"{cyclopColor}Ruben", 150, 4, 3, 2, 2, 2, 45);
            Orc orc1 = new Orc($"{orcColor}O", 2, $"{orcColor}Nikos", 100, 5, 8, 6, 1, 14, 12);
            Goblin goblin1 = new Goblin($"{goblinColor}G", 4, $"{goblinColor}Johnny", 85, 5, 8, 6, 1, 16, 5);
            DrawMap drawMap = new DrawMap(Map, MapSizeX, MapSizeY);
            //Creature[] creature = { cyclop1, orc1, goblin1 };

            Item pie = new Item("Q", "Pie", 100, 0, 0, 0, 0, 8, 8);
            Item apple = new Item("A", "Apple", 50, 0, 0, 0, 0, 10, 10);

            Item.PlayerInventory.Add($" \u001b[6m");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\u001b[6mWelcome Player!!\nPress Enter to play the SalesAdventures\u001b[0m\n");
            Console.ReadLine();

            drawMap.DrawUp();
            Inventory.ShowInventory(player1);
            drawMap.FillUp();
            drawMap.MapColor();
            player1.PlayerPlacement(drawMap);
            drawMap.PlaceObject(cyclop1, goblin1, orc1, pie, apple);
            Mechanics.HideItem(map, pie, apple);
            Mechanics.MoveingPlayer(drawMap, Map, player1, cyclop1, goblin1, orc1, pie, apple, MapSizeY, MapSizeX);
        }
        public void PlayGame()
        {
            Run();
        }
    }
}