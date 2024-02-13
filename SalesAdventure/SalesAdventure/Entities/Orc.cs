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
            this.charisma = charisma;
            this.wackiness = wackiness;
        }
    }
}
