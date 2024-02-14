using SalesAdventure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesAdventure;
using SalesAdventure.Map;

namespace SalesAdventure.Entities
{
    public class Player : Creature
    {
        public Player(string creatureIcon, int lvl,string name, int hp, int luck,int streanght,int charisma,int wackiness) 
        {
            this.creatureIcon = creatureIcon;
            this.lvl = lvl;            
            this.name = name;
            this.hp = hp;
            this.luck = luck;
            this.charisma = charisma;
            this.wackiness = wackiness;
        }
        public int playerPosY = 10;
        public int playerPosX = 1;
        //public void PlacePlayer()
        //{
        //    map[this.playerPosY, this.playerPosX] = this.creatureIcon;
        //}
    }
}
