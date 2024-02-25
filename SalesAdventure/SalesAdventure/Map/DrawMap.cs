
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesAdventure;
using SalesAdventure.Entities;

namespace SalesAdventure.Map
{
    public class DrawMap
    {
        private string[,] map;
        private int mapSizeX;
        private int mapSizeY;

        public string[,] Map
        {
            get { return map; }
            set { map = value; }
        }
        public int MapSizeX
        {
            get { return mapSizeX; }
            set { mapSizeX = value; }
        }
        public int MapSizeY
        {
            get { return mapSizeY; }
            set { mapSizeY = value; }
        }
        public DrawMap(string[,] map, int mapSizeX, int mapSizeY)
        {
            this.map = map;
            this.mapSizeX = mapSizeX;
            this.mapSizeY = mapSizeY;
        }

        private void Draw()
        {
            for (int i = 0; i < MapSizeY; i++)
            {
                for (int j = 0; j < MapSizeX; j++)
                {
                    Console.Write(Map[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public void DrawUp()
        {
            Draw();
        }

        private void Fill()
        {
            for (int i = 0; i < MapSizeY; i++)
            {
                for (int j = 0; j < MapSizeX; j++)
                {
                    if (i == 0 || i == MapSizeY - 1 || j == 0 || j == MapSizeX - 1)
                    {
                        Map[i, j] = "#"; // # representerar väggar
                    }
                    else
                    {
                        Map[i, j] = ".";
                    }
                }
            }
        }
        public void FillUp()
        {
            Fill();
        }

        private void ColorTiles()
        {
            string wallColor = "\u001b[38;2;0;0;0m\u001b[48;5;237m";
            string wallColorReset = "\u001b[0m";
            string innerColor = "\u001b[38;2;170;85;0m";
            int startBottom = 0;
            int endBottom = 49;

            string w = $"{wallColor}#{wallColorReset}";

            Map[17, startBottom] = $"{wallColor}#";
            for (int i = startBottom + 1; i < endBottom; i++)
            {
                Map[17, i] = "#";
            }
            Map[17, endBottom] = $"#{wallColorReset}";

            (Map[1, 0], Map[2, 0], Map[3, 0], Map[4, 0], Map[5, 0], Map[6, 0], Map[7, 0], Map[8, 0], Map[9, 0], Map[10, 0], Map[11, 0], Map[12, 0], Map[13, 0], Map[14, 0], Map[15, 0], Map[16, 0]) = (w, w, w, w, w, w, w, w, w, w, w, w, w, w, w, w);
            (Map[0, 49], Map[1, 49], Map[2, 49], Map[3, 49], Map[4, 49], Map[5, 49], Map[6, 49], Map[7, 49], Map[8, 49], Map[9, 49], Map[10, 49], Map[11, 49], Map[12, 49], Map[13, 49], Map[14, 49], Map[15, 49], Map[16, 49], Map[17, 49]) = (w, w, w, w, w, w, w, w, w, w, w, w, w, w, w, w, w, w);

            for (int y = 1; y < MapSizeY - 1; y++)
            {
                for (int x = 1; x < MapSizeX -1; x++) 
                {
                    Map[y, x] = $"{innerColor}.";
                }
            }
            Map[16, 48] += wallColorReset;

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public void MapColor()
        {
            ColorTiles();
        }
        private void PlaceObjects(Cyclop cyclop1, Goblin goblin1, Orc orc1, Item pie, Item apple)
        {
            Map[cyclop1.PositionY, cyclop1.PositionX] = cyclop1.CreatureIcon;
            Map[orc1.PositionY, orc1.PositionX] = orc1.CreatureIcon;
            Map[goblin1.PositionY, goblin1.PositionX] = goblin1.CreatureIcon;
            Map[pie.PositionY, pie.PositionX] = pie.ItemIcon;
            Map[apple.PositionY, apple.PositionX] = apple.ItemIcon;
        }
        public void PlaceObject(Cyclop cyclop1, Goblin goblin1, Orc orc1, Item pie, Item apple)
        {
            PlaceObjects(cyclop1, goblin1, orc1, pie, apple);
        }

        //public void PlaceItems(Item pie, Item apple)
        //{
        //    map[pie.positionY, pie.positionX] = pie.itemIcon;
        //    map[apple.positionY, apple.positionX] = apple.itemIcon;
        //}


        //public void SpawnEnemies(Cyclop cyclop1, Goblin goblin1, Orc orc1)
        //{
        //    Random randomMonsterPosition = new Random();

        //    //cyclop1.positionY = randomMonsterPosition.Next(1, mapSizeY - 1); //Y
        //    //cyclop1.positionX = randomMonsterPosition.Next(1, mapSizeX - 1); //X

        //    //orc1.positionY = randomMonsterPosition.Next(1, mapSizeY - 1);
        //    //orc1.positionX = randomMonsterPosition.Next(1, mapSizeX - 1);

        //    //goblin1.positionY = randomMonsterPosition.Next(1, mapSizeY - 1);
        //    //goblin1.positionX = randomMonsterPosition.Next(1, mapSizeX - 1);


        //    cyclop1.positionY = randomMonsterPosition.Next(1, 24 - 1); //Y
        //    cyclop1.positionX = randomMonsterPosition.Next(1, 32 - 1); //X

        //    orc1.positionY = randomMonsterPosition.Next(1, 24 - 1);
        //    orc1.positionX = randomMonsterPosition.Next(1, 32 - 1);

        //    goblin1.positionY = randomMonsterPosition.Next(1, 24 - 1);
        //    goblin1.positionX = randomMonsterPosition.Next(1, 32 - 1);


        //    map[cyclop1.positionY, cyclop1.positionX] = cyclop1.creatureIcon;
        //    map[orc1.positionY, orc1.positionX] = orc1.creatureIcon;
        //    map[goblin1.positionY, goblin1.positionX] = goblin1.creatureIcon;
        //}
    }
}