using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesAdventure.Entities;
using SalesAdventure.Map;

using SalesAdventure;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;

namespace SalesAdventure
{
    public class Item
    {
        private string itemIcon;
        private string name;
        private double hp;
        private int luck;
        private int strength;
        private int charisma;
        private int wackiness;
        private int positionY;
        private int positionX;
        private static List<string> inventory = new List<string>();

        public Item(string itemIcon, string name, double hp, int luck, int strength, int charisma, int wackiness, int positionY, int positionX)
        {
            this.itemIcon = itemIcon;
            this.name = name;
            this.hp = hp;
            this.luck = luck;
            this.strength = strength;
            this.charisma = charisma;
            this.wackiness = wackiness;
            this.positionY = positionY;
            this.positionX = positionX;
        }
        public static List<string> PlayerInventory
        {
            get { return inventory; }
            set { inventory = value; }
        }
        public string ItemIcon
        {
            get { return itemIcon; }
            set { itemIcon = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public double Hp
        {
            get { return hp; }
            set { hp = value; }
        }
        public int Luck
        {
            get { return luck; }
            set { luck = value; }
        }
        public int Strength
        {
            get { return strength; }
            set { strength = value; }
        }
        public int Charisma
        {
            get { return charisma; }
            set { charisma = value; }
        }
        public int Wackiness
        {
            get { return wackiness; }
            set { wackiness = value; }
        }
        public int PositionY
        {
            get { return positionY; }
            set { positionY = value; }
        }
        public int PositionX
        {
            get { return positionX; }
            set { positionX = value; }
        }
        public static void ItemMenuFill(DrawMap drawMap, string[,] map, Player player1, Cyclop cyclop1, Goblin goblin1, Orc orc1, Item pie, Item apple)
        {
            string menuColor = "\u001b[38;5;130m";
            Console.Clear();
            Mechanics.HideItem(map, pie, apple);
            Console.WriteLine($"{menuColor}Use {Game.MenuOptionColor}Arrows{menuColor} or {Game.MenuOptionColor}WASD{menuColor} to Move around, {Game.MenuOptionColor}Q{menuColor} to Quit ------ Use {Game.MenuOptionColor}[number]{menuColor} to comsume an item from Inventory\u001b[38;2;0;0;0m\u001b[48;5;237m");
            drawMap.DrawUp();
            Inventory.ShowInventory(player1);
            drawMap.FillUp();
            drawMap.MapColor();
            player1.PlayerPlacement(drawMap);
            drawMap.PlaceObject(cyclop1, goblin1, orc1, pie, apple);
            Console.WriteLine($"{Game.TextColor}Press {Game.MenuOptionColor}1{Game.TextColor} to Consume or {Game.MenuOptionColor}2{Game.TextColor} to place {apple.Name}{Game.TextColor} in inventory?");
        }
        private static void Pie(DrawMap drawMap, string[,] map, Player player1, Cyclop cyclop1, Goblin goblin1, Orc orc1, Item pie, Item apple)
        {
            if (map[player1.PositionY, player1.PositionX] == map[pie.PositionY, pie.PositionX])
            {
                bool useItems = true;
                while (useItems)
                {
                    ItemMenuFill(drawMap, map, player1, cyclop1, goblin1, orc1, pie, apple);
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.D1:
                            player1.Hp += pie.Hp;
                            Console.WriteLine($"{Game.TextColor}\nConsumed {pie.name}{Game.TextColor}. {Game.MenuOptionColor}Enter{Game.TextColor} to continue");
                            Console.ReadLine();
                            pie.ItemIcon = ".";
                            pie.PositionY = 0;
                            pie.PositionX = 0;
                            pie.ItemIcon = "#";
                            map[8, 8] = ".";
                            Mechanics.ItemCollision = false;
                            useItems = false;
                            break;

                        case ConsoleKey.D2:
                            Item.inventory.Add($"{pie.Name} - {pie.Hp} +HP");
                            Console.WriteLine($"{Game.TextColor}\nAdded {pie.name}{Game.TextColor} to inventory. {Game.MenuOptionColor}Enter{Game.TextColor} to continue.");
                            Console.ReadLine();
                            pie.ItemIcon = ".";
                            pie.PositionY = 0;
                            pie.PositionX = 0;
                            pie.ItemIcon = "#";
                            map[8, 8] = ".";
                            Mechanics.ItemCollision = false;
                            useItems = false;
                            break;

                        default:
                            break;
                    }
                }
            }
        }
        public static void ItemPie(DrawMap drawMap, string[,] map, Player player1, Cyclop cyclop1, Goblin goblin1, Orc orc1, Item pie, Item apple)
        {
            Pie(drawMap, map, player1, cyclop1, goblin1, orc1, pie, apple);
        }

        private static void Apple(DrawMap drawMap, string[,] map, Player player1, Cyclop cyclop1, Goblin goblin1, Orc orc1, Item pie, Item apple)
        {
            if (map[player1.PositionY, player1.PositionX] == map[apple.PositionY, apple.PositionX])
            {
                bool useItems = true;
                while (useItems)
                {
                    ItemMenuFill(drawMap, map, player1, cyclop1, goblin1, orc1, pie, apple);
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.D1:
                            player1.Hp += apple.Hp;
                            Console.WriteLine($"{Game.TextColor}\nConsumed {apple.name}{Game.TextColor}. {Game.MenuOptionColor}Enter{Game.TextColor} to continue");
                            Console.ReadLine();
                            apple.ItemIcon = ".";
                            apple.PositionY = 0;
                            apple.PositionX = 0;
                            apple.ItemIcon = "#";
                            map[10, 10] = ".";
                            Mechanics.ItemCollision = false;
                            useItems = false;
                            break;

                        case ConsoleKey.D2:
                            inventory.Add($"{apple.Name} - {apple.Hp} +HP");
                            Console.WriteLine($"{Game.TextColor}\nAdded {apple.name}{Game.TextColor} to inventory. {Game.MenuOptionColor}Enter{Game.TextColor} to continue.");
                            Console.ReadLine();
                            apple.ItemIcon = ".";
                            apple.PositionY = 0;
                            apple.PositionX = 0;
                            apple.ItemIcon = "#";
                            map[10, 10] = ".";
                            Mechanics.ItemCollision = false;
                            useItems = false;
                            break;

                        default:
                            break;
                    }
                }
            }
        }
        public static void ItemApple(DrawMap drawMap, string[,] map, Player player1, Cyclop cyclop1, Goblin goblin1, Orc orc1, Item pie, Item apple)
        {
            Apple(drawMap, map, player1, cyclop1, goblin1, orc1, pie, apple);
        }
    }
}
