using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesAdventure;

namespace SalesAdventure.Entities
{
    public class Orc : Creature
    {
        public Orc(string creatureIcon, int lvl, string name, int hp, int luck, int streanght, int charisma, int wackiness)
        {
            this.creatureIcon = creatureIcon;
            this.lvl = lvl;
            this.name = name;
            this.hp = hp;
            this.luck = luck;
            this.strenght = strenght;
            this.charisma = charisma;
            this.wackiness = wackiness;
        }
        public int orcPosY;
        public int orcPosX;
        public void OrcDeafeated()
        {
            this.creatureIcon = ".";
            orcPosY = 0;
            orcPosX = 0;
            this.creatureIcon = "#";
            this.hp = 0;

            Console.Clear();
            Console.WriteLine("You WON! Press any key to Continue.");
        }
    }
}
