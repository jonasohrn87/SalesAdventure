using SalesAdventure.Map;

namespace SalesAdventure
{
    public class Inventory
    {

        //public string[,] inventory;
        //public int InventorySizeX;
        //public int InventorySizeY;

        public Inventory(/*string[,] inventory, int InventorySizeX, int InventorySizeY*/)
        {
            //this.inventory = inventory;
            //this.InventorySizeX = InventorySizeX;
            //this.InventorySizeY = InventorySizeY;
        }
        public static void DrawInventory(DrawMap drawMap, string[,] map, int mapSizeY, int mapSizeX)
        {
            string[] InventoryText = { "#", "#", "-", "I", "N", "V", "E", "N", "T", "O", "R", "Y", "-", "#", "#" };

            

            for (int i = 1; i < 24; i++)
            {
                int invindex = 0;
                for (int x = 40; x < 55; x++)
                {
                    map[0, x] = InventoryText[invindex];

                    //map[3, x] = Game.inventoryPlayer[invindex];
                    invindex++;
                }
                for (int j = 36; j < 60; j++)
                {
                    if (i == 0 || i == 24 - 1 || j == 36 || j == 60 - 1)
                    {
                        drawMap.map[i, j] = "#"; // # representerar väggar
                    }

                    else
                    {
                        drawMap.map[i, j] = " ";
                    }
                }
            }
        }

    }
}