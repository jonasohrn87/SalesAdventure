using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesAdventure;

namespace SalesAdventure
{
    internal class GameWorld
    {
       public string[,] worldMap { get; } = new string[40, 40];


        public GameWorld()
        {

            for (int i = 0; i < 40; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    worldMap[i, j] = "| ";
                }
            }
        }
    }
}
