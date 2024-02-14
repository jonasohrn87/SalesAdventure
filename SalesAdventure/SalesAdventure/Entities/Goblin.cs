using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesAdventure.Entities
{
    public class Goblin : Creature
    {
        public Goblin(string creatureIcon, int lvl, string name, int hp, int luck, int streanght, int charisma, int wackiness)
        {
            this.creatureIcon = creatureIcon;
            this.lvl = lvl;
            this.name = name;
            this.hp = hp;
            this.luck = luck;
            this.charisma = charisma;
            this.wackiness = wackiness;
        }
        public int goblinPosY;
        public int goblinPosX;
        public void goblinDeafeated()
        {
            this.creatureIcon = ".";
            goblinPosY = 0;
            goblinPosX = 0;
            this.creatureIcon = "#";
            this.hp = 0;

            Console.Clear();
            Console.WriteLine("You WON! Press any key to Continue.");
        }
    }
}
