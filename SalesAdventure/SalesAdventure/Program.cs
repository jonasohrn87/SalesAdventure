using System;
using SalesAdventure;

namespace SalesAdventure
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            GameWorld gameWorld = new GameWorld();

            
            for (int i = 0; i < 40; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    Console.Write(gameWorld.worldMap[i, j]);
                }
                Console.WriteLine();
            }

          
            Console.ReadLine();
        }
    }
}
