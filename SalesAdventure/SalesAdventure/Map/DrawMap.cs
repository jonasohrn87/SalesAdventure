
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesAdventure;
using SalesAdventure.Entities;

namespace SalesAdventure.Map
{
    internal class DrawMap
    {
        private string[,] map;
        private int mapSizeX;
        private int mapSizeY;

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
    }
}
