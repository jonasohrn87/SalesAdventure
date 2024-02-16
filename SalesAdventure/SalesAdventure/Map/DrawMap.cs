
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesAdventure;
using SalesAdventure.Entities;

namespace SalesAdventure.Map
{
    public class DrawMap
    {
        public string[,] map;
        public int mapSizeX;
        public int mapSizeY;

        public DrawMap(string[,] map, int mapSizeX, int mapSizeY)
        {
            this.map = map;
            this.mapSizeX = mapSizeX;
            this.mapSizeY = mapSizeY;
        }

        public void Draw()
        {
            for (int i = 0; i < mapSizeY; i++)
            {
                for (int j = 0; j < mapSizeX; j++)
                {
                    Console.Write(map[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public void Fill()
        {
            for (int i = 0; i < mapSizeY; i++)
            {
                for (int j = 0; j < mapSizeX; j++)
                {
                    if (i == 0 || i == mapSizeY - 1 || j == 0 || j == mapSizeX - 1)
                    {
                        map[i, j] = "#"; // # representerar väggar
                    }
                    else
                    {
                        map[i, j] = ".";
                    }
                }
            }
        }
        public void PlaceEnemies(Player player1, Cyclop cyclop, Goblin goblin, Orc orc)
        {
            map[cyclop.positionY, cyclop.positionX] = cyclop.creatureIcon;
            map[orc.positionY, orc.positionX] = orc.creatureIcon;
            map[goblin.positionY, goblin.positionX] = goblin.creatureIcon;
        }
        public void SpawnEnemies(Cyclop cyclop, Goblin goblin, Orc orc)
        {
            Random randomMonsterPosition = new Random();

            cyclop.positionY = randomMonsterPosition.Next(1, mapSizeY - 1);
            cyclop.positionX = randomMonsterPosition.Next(1, mapSizeX - 1);

            orc.positionY = randomMonsterPosition.Next(1, mapSizeY - 1);
            orc.positionX = randomMonsterPosition.Next(1, mapSizeX - 1);

            goblin.positionY = randomMonsterPosition.Next(1, mapSizeY - 1);
            goblin.positionX = randomMonsterPosition.Next(1, mapSizeX - 1);


            map[cyclop.positionY, cyclop.positionX] = cyclop.creatureIcon;
            map[orc.positionY, orc.positionX] = orc.creatureIcon;
            map[goblin.positionY, goblin.positionX] = goblin.creatureIcon;
        }
    }
}
