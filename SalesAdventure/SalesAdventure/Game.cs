using System;
using System.Threading.Channels;

class Game
{
    string[,] map = new string[10, 10];
    int playerPosX = 5;
    int playerPosY = 5;
    string player = "P";
    //string playerSymbol = "P";
    ConsoleKeyInfo keyInfo = Console.ReadKey();
    bool runGame = true;


    public Game()
    {
    }

    public void Run()
    {
        DrawMap();
        PlacePlayer();

        Console.WriteLine("Welcome Player!!");

        //while (runGame)
        //{

        FillMap();

        //    readkey

        //    up
        //    MovePlayer();

        //    down
        //    MovePlayer();

        //    left
        //    MovePlayer();

        //    right
        //    MovePlayer();

        //}


    }

    //private void MovePlayer(int playerPosX, int playerPosY, int i, int j)
    //{
    //    if ((keyInfo.Key == ConsoleKey.UpArrow))//Lägga till logik för träffa väggar åt alla hållen
    //    {
    //        playerPosY = j++;
    //    }
    //    else if (keyInfo.Key == ConsoleKey.DownArrow)
    //    {
    //        playerPosY = j--;
    //    }
    //    else if (keyInfo.Key == ConsoleKey.LeftArrow)
    //    {
    //        playerPosY = i--;
    //    }
    //    else if (keyInfo.Key == ConsoleKey.RightArrow)
    //    {
    //        playerPosY = i++;
    //    }
    //    else
    //    {
    //        runGame = false;
    //    }
    //}

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
