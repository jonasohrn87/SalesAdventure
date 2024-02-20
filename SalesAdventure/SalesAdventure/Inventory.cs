using SalesAdventure.Map;

namespace SalesAdventure
{
    public class Inventory
    {

        public string[,] inventory;
        public int InventorySizeX;
        public int InventorySizeY;
        //public List<string> inventoryList = new List<string> ();

        public Inventory(string[,] inventory, int InventorySizeX, int InventorySizeY)
        {
            this.inventory = inventory;
            this.InventorySizeX = InventorySizeX;
            this.InventorySizeY = InventorySizeY;
            //this.inventoryList = inventoryList;
        }
        public static void DrawInventory(DrawMap drawMap, string[,] map, int mapSizeY, int mapSizeX)
        {
            string[] InventoryText = { "#","#","-","I", "N", "V", "E", "N", "T", "O", "R", "Y", "-","#","#" };

            List<string> inventoryList = new List<string>();


        int inventoryX = 5;
            for (int i = 1; i < 24; i++)
            {
                int invindex = 0;
                for(int x = 40; x < 55; x++)
                {
                    map[0,x] = InventoryText[invindex];
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
                        //Console.Write(new string(' ', inventoryX) + " |" + "InventoryList"[i]);
                        drawMap.map[i, j] = " ";
                    }
                }
            }
            drawMap.Draw();
            //for (int i = 0; i < 24; i++)
            //{
            //    for (int j = 30; j < 32; j++)
            //    {
            //        Console.Write(map[i, j] + " ");
            //    }
            //    Console.WriteLine();
            //}
            //drawMap.map[this.positionY, this.positionX] = this.creatureIcon;
        }
    
    }
}







/*


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











 
public void PlacePlayer(DrawMap drawMap)
{
    drawMap.map[this.positionY, this.positionX] = this.creatureIcon;
}

public void MovePlayer(DrawMap drawMap, int movePosY, int movePosX, int mapSizeY, int mapSizeX)
{
    int newPosY = this.positionY + movePosY;
    int newPosX = this.positionX + movePosX;

    if (newPosY > 0 && newPosY < mapSizeY - 1 && newPosX > 0 && newPosX < mapSizeX - 1)
    {
        drawMap.map[this.positionY, this.positionX] = ".";
        this.positionY = newPosY;
        this.positionX = newPosX;
        PlacePlayer(drawMap);
    }
    drawMap.Draw();
}

*/