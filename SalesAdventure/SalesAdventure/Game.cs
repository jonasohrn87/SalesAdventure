using System;
using System.Threading.Channels;

class Game
{
    string[,] map = new string[10, 10];
    int playerPosX = 5;
    int playerPosY = 5;
    string player = "P";
    bool runGame = true;

    public Game()
    {
    }
    public void Run()
    {
        DrawMap();
        PlacePlayer();

        Console.WriteLine("Welcome Player!!\nPress Enter to play the SalesAdventures\n");

        Console.WriteLine("hej pull");
        Console.ReadLine();

        while (runGame)
        {
            Console.Clear();
            Console.WriteLine("Use Arrows or WASD to Move around or press Q to Quit\n");
            FillMap();
            PlacePlayer();

            ConsoleKeyInfo keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    map[playerPosX, playerPosY] = ".";
                    playerPosX--;
                    PlacePlayer();
                    break;

                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    map[playerPosX, playerPosY] = ".";
                    playerPosX++;
                    PlacePlayer();
                    break;

                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    map[playerPosX, playerPosY] = ".";
                    playerPosY--;
                    PlacePlayer();
                    break;

                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    map[playerPosX, playerPosY] = ".";
                    playerPosY++;
                    PlacePlayer();
                    break;

                case ConsoleKey.Q:
                    runGame = false;
                    break;

                default:
                    break;
            }
        }
    }
    public void PlacePlayer()
    {
        map[playerPosX, playerPosY] = player;
    }
    public void DrawMap()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                map[i, j] = ".";
            }
        }
    }
    public void FillMap()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Console.Write(map[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}