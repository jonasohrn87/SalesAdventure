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
        //public static int mapSizeX = 12;
        //public static int mapSizeY = 12;
        public string[,] map = new string[mapSizeY, mapSizeX];

        //public static Dictionary<int, string> inventoryPlayer = new Dictionary<int, string>();

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

            Player player1 = new Player("P", 1, "Tintin", 200, 10, 8, 6, 1, 22, 1);
            Cyclop cyclop1 = new Cyclop("C", 5, $"{TextColorRed}Ruben{TextColorReset}", 150, 4, 3, 2, 2, 2, 28);
            Orc orc1 = new Orc("O", 2, $"{TextColorGreen}Nikos{TextColorReset}", 100, 5, 8, 6, 1, 14, 12);
            Goblin goblin1 = new Goblin("G", 4, $"{BrigtGreen}Johnny{TextColorReset}", 85, 5, 8, 6, 1, 19, 5);
            DrawMap drawMap = new DrawMap(map, mapSizeX, mapSizeY);
            //Inventory inventory = new Inventory(map, mapSizeX, mapSizeY);
            //Creature[] creature = { cyclop1, orc1, goblin1 };

            Item pie = new Item("?", "Pie", 100, 0, 0, 0, 0, 8, 8);
            Item apple = new Item("?", "Apple", 50, 0, 0, 0, 0, 10, 10);

            Item.inventory.Add(1, $"{pie.name} + {pie.hp}");
            Item.inventory.Add(2, $"apple");

            //foreach (KeyValuePair<int> int inventoryPlayer)
            //{
            //    Console.WriteLine(items);
            //}
            foreach (KeyValuePair<int, string> item in Item.inventory)
            {
                Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
            }
            //Console.WriteLine($"Key: {inventoryPlayer}, Value: {item.Value}");
            Console.WriteLine(Item.inventory);
            //Item.inventory[]();

            Console.WriteLine("Welcome Player!!\nPress Enter to play the SalesAdventures\n");
            Console.ReadLine();

            drawMap.Draw();
            drawMap.Fill();
            //drawMap.SpawnEnemies(cyclop1, goblin1, orc1);
            player1.PlacePlayer(drawMap);
            //drawMap.PlaceEnemies(cyclop1, goblin1, orc1);
            //drawMap.PlaceItems(pie, apple);
            drawMap.PlaceObjects(cyclop1, goblin1, orc1, pie, apple);
            Inventory.DrawInventory(drawMap, map, mapSizeY, mapSizeX);
            Mechanics.MovePlayer(drawMap, map, player1, cyclop1, goblin1, orc1, pie, apple, mapSizeY, mapSizeX);
        }
    }
}