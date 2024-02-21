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

        //public Dictionary<int, string> GetDictionary()
        //{
        //    return inventory;
        //}

        //public void SetDictionary(Dictionary<int, string>Inventorys)
        //{
        //    inventory = Inventorys;
        //}
    }
}
