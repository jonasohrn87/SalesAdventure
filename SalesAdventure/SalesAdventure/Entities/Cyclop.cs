using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesAdventure;
using SalesAdventure.Map;

namespace SalesAdventure.Entities
{
    public class Cyclop : Creature
    {
        public Cyclop(string creatureIcon, int lvl, string name, int hp, int luck, int strength, int charisma, int wackiness, int positionY, int positionX)
        {
            this.creatureIcon = creatureIcon;
            this.lvl = lvl;
            this.name = name;
            this.hp = hp;
            this.luck = luck;
            this.strength = strength;
            this.charisma = charisma;
            this.wackiness = wackiness;
            this.positionY = positionY;
            this.positionX = positionX;
        }
         public void CyclopDeafeated()
        {
            this.creatureIcon = ".";
            this.positionY = 0;
            this.positionX = 0;
            this.creatureIcon = "#";
            this.hp = 0;

            Console.Clear();
            Console.WriteLine("You WON! Press any key to Continue.");
        }

        public void CyclopFight(Player player1)
        {

            while (player1.hp != 0 || this.hp != 0)
            {
                if (player1.hp > this.luck)
                {
                    Console.WriteLine($"{player1.name} will do the first attack.");
                }

                else
                {
                    Console.WriteLine($"{this.name} will do the first attack.");
                }

            }
        }
        public bool CyclopPlayerFight(DrawMap drawMap, Cyclop cyclop, Player player1)
        {
            if (drawMap.map[player1.positionY, player1.positionX] == drawMap.map[this.positionY, this.positionX])
            {
                return true;
            }
            return false;
        }
    }
}
