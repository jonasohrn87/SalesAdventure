//using System;
//using SalesAdventure;
////using Game;


using SalesAdventure;
using System.Threading.Channels;

internal class Game
{
    public Game()
    {
    }
        //const int width = 10;
        //const int height = 10;
        //public string[,] worldMap { get; } = new string[width, height];

    public void Run()
    {
        //Game gameWorld = new Game();
        string[,] worldMap = new string[10, 10];
        worldMap[2, 3] = "2";

        Console.WriteLine(" h e j");
        for (int i = 0; i < worldMap.GetLength(0); i++)
        {
            for (int j = 0; j < worldMap.GetLength(1); j++)
            {
                Console.Write(worldMap[i, j] + " - ");
            }
            Console.WriteLine();
        }


        Console.ReadLine();
    }
}