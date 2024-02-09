using System;
using System.Threading.Channels;

class Game
{
    static int mapSizeX = 12;
    static int mapSizeY = 12;
    static string[,] map = new string[mapSizeY, mapSizeX];
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
                    
                    MovePlayer("W");
                    
                    break;

                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    MovePlayer("S");
                    break;

                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:                    
                    MovePlayer("A");
                    break;

                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    MovePlayer("D");
                    break;

                case ConsoleKey.Q:
                    runGame = false;
                    break;

                default:
                    break;
            }
        }
    }

    private void MovePlayer(string direction)
    {

        //if (playerPosY <= 0 || playerPosY >= 11 || playerPosX <= 0 || playerPosX >= 11)
        //{
        //    PlacePlayer();
        //}
        if (direction =="W") { 
        {
            map[playerPosY, playerPosX] = ".";
            playerPosY--;
            PlacePlayer();
            }
        }
        else if (direction == "S")
        {
            {
                map[playerPosY, playerPosX] = ".";
                playerPosY++;
                PlacePlayer();
            }
        }
        else if (direction == "A")
        {
            {
                map[playerPosY, playerPosX] = ".";
                playerPosX--;
                PlacePlayer();
            }
        }
        else if (direction == "D")
        {
            {
                map[playerPosY, playerPosX] = ".";
                playerPosX++;
                PlacePlayer();
            }
        }
    }

    public void PlacePlayer()
    {
        if (playerPosY <= 0)
        {
            playerPosY++;
        }
        else if (playerPosY >= 11)
        {
            playerPosY--;
        }
        else if (playerPosX <= 0)
        {
            playerPosX++;
        }
        else if (playerPosX >= 11)
        {
            playerPosX--;
        }
        map[playerPosY, playerPosX] = player;
    }
    public void DrawMap()
    {
        for (int i = 0; i < mapSizeY; i++)
        {
            for (int j = 0; j < mapSizeX; j++)
            {
                map[i, j] = ".";
            }
        }
    }
    public void FillMap()
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
}