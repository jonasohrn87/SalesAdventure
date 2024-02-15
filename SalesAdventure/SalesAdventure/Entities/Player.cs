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
        public Player(string creatureIcon, int lvl, string name, int hp, int luck, int strength, int charisma, int wackiness, int positionY, int positionX)
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
        public void PlacePlayer(DrawMap drawMap)
        {
            drawMap.map[this.positionY, this.positionX] = this.creatureIcon;
        }

        public void MovePlayer(DrawMap drawMap,int movePosY, int movePosX,int mapSizeY,int mapSizeX)
        {
            int newPosY = this.positionY + movePosY;
            int newPosX = this.positionX + movePosX;

            if (newPosY > 0 && newPosY < mapSizeY - 1 && newPosX > 0 && newPosX < mapSizeX - 1)
            {
                drawMap.map[this.positionY, this.positionX] = ".";
                this.positionY = newPosY;
                this.positionX = newPosX;
                PlacePlayer(drawMap);
            }
        }
    }
}
