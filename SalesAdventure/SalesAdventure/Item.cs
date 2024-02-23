using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesAdventure.Entities;
using SalesAdventure.Map;

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
        public static List<string> inventory = new List<string>();

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

        public static void Pie(string[,] map, Player player1, Item pie)
        {
            if (map[player1.PositionY, player1.PositionX] == map[pie.PositionY, pie.PositionX])
            {
                Console.WriteLine($"Press 1 to Consume or 2 to place {pie.Name} in inventory?");
                Mechanics.keyInfo = Console.ReadKey();
                switch (Mechanics.keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        player1.Hp += pie.Hp;
                        Console.WriteLine("Consumed Pie");
                        pie.ItemIcon = ".";
                        pie.PositionY = 0;
                        pie.PositionX = 0;
                        pie.ItemIcon = "#";
                        Mechanics.itemCollision = false;
                        break;

                    case ConsoleKey.D2:
                        Item.inventory.Add($"{pie.Name} - {pie.Hp} +HP");
                        Console.WriteLine("Added Pie to inventory");
                        pie.ItemIcon = ".";
                        pie.PositionY = 0;
                        pie.PositionX = 0;
                        pie.ItemIcon = "#";
                        Mechanics.itemCollision = false;
                        break;

                    default:
                        break;
                }
            }
        }
        public static void Apple(string[,] map, Player player1, Item apple)
        {
            if (map[player1.PositionY, player1.PositionX] == map[apple.PositionY, apple.PositionX])
            {
                Console.WriteLine($"Press 1 to Consume or 2 to place {apple.Name} in inventory?");
                Mechanics.keyInfo = Console.ReadKey();
                switch (Mechanics.keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        player1.Hp += apple.Hp;
                        Console.WriteLine($"Consumed Apple");
                        apple.ItemIcon = ".";
                        apple.PositionY = 0;
                        apple.PositionX = 0;
                        apple.ItemIcon = "#";
                        Mechanics.itemCollision = false;
                        break;

                    case ConsoleKey.D2:
                        Item.inventory.Add($"{apple.Name} - {apple.Hp} +HP");
                        Console.WriteLine("Added Apple to inventory");
                        apple.ItemIcon = ".";
                        apple.PositionY = 0;
                        apple.PositionX = 0;
                        apple.ItemIcon = "#";
                        Mechanics.itemCollision = false;
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
