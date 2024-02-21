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
        public string itemIcon;
        public string name;
        public double hp;
        public int luck;
        public int strength;
        public int charisma;
        public int wackiness;
        public int positionY;
        public int positionX;
        public static Dictionary<int, string> inventory = new Dictionary<int, string>();

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
    }
}
