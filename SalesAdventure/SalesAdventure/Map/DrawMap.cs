
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

        //public Creature GetCreatureAtPosition(int positionY, int positionX)
        //{
        //    return Creatures.FirstOrDefault(creatures => creatures.positionY == positionY && creatures.positionX == positionX);
        //}

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
            for (int i = 0; i < 24; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    if (i == 0 || i == 24 - 1 || j == 0 || j == 32 - 1)
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
        //public void Fill()
        //{
        //    for (int i = 0; i < mapSizeY; i++)
        //    {
        //        for (int j = 0; j < mapSizeX; j++)
        //        {
        //            if (i == 0 || i == mapSizeY - 1 || j == 0 || j == mapSizeX - 1)
        //            {
        //                map[i, j] = "#"; // # representerar väggar
        //            }
        //            else
        //            {
        //                map[i, j] = ".";
        //            }
        //        }
        //    }
        //}



        public void PlaceEnemies(Player player1, Cyclop cyclop1, Goblin goblin1, Orc orc1)
        {
            map[cyclop1.positionY, cyclop1.positionX] = cyclop1.creatureIcon;
            map[orc1.positionY, orc1.positionX] = orc1.creatureIcon;
            map[goblin1.positionY, goblin1.positionX] = goblin1.creatureIcon;
        }

        public void SpawnEnemies(Cyclop cyclop1, Goblin goblin1, Orc orc1)
        {
            Random randomMonsterPosition = new Random();

            //cyclop1.positionY = randomMonsterPosition.Next(1, mapSizeY - 1); //Y
            //cyclop1.positionX = randomMonsterPosition.Next(1, mapSizeX - 1); //X

            //orc1.positionY = randomMonsterPosition.Next(1, mapSizeY - 1);
            //orc1.positionX = randomMonsterPosition.Next(1, mapSizeX - 1);

            //goblin1.positionY = randomMonsterPosition.Next(1, mapSizeY - 1);
            //goblin1.positionX = randomMonsterPosition.Next(1, mapSizeX - 1);


            cyclop1.positionY = randomMonsterPosition.Next(1, 24 - 1); //Y
            cyclop1.positionX = randomMonsterPosition.Next(1, 32 - 1); //X

            orc1.positionY = randomMonsterPosition.Next(1, 24 - 1);
            orc1.positionX = randomMonsterPosition.Next(1, 32 - 1);

            goblin1.positionY = randomMonsterPosition.Next(1, 24 - 1);
            goblin1.positionX = randomMonsterPosition.Next(1, 32 - 1);


            map[cyclop1.positionY, cyclop1.positionX] = cyclop1.creatureIcon;
            map[orc1.positionY, orc1.positionX] = orc1.creatureIcon;
            map[goblin1.positionY, goblin1.positionX] = goblin1.creatureIcon;
        }
    }
}