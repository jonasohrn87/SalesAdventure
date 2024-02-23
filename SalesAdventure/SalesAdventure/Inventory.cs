using SalesAdventure.Entities;
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

        

        public static void DrawInventory()
        {
            int count1 = 1;
            Console.WriteLine("##### I N V E N T O R Y #####");
           

            for (var i = 0; i < Item.inventory.Count; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine("        "   + Item.inventory[i]);
                }
                else
                {

                    {
                        Console.WriteLine("       " + count1 + ":" + Item.inventory[i]);
                        count1++;
                        Console.WriteLine("");
                    }
                }
            }
            Console.WriteLine("##############################");
        }

    }
}