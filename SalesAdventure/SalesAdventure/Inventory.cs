using SalesAdventure.Entities;
using SalesAdventure.Map;
using SalesAdventure;

namespace SalesAdventure
{
    public class Inventory
    {
        public Inventory()
        {
        }

        // Målar upp inventory och dess innehåll under kartan.
        private static void DrawInventory(Player player1)
        {
            string inventoryColor = "\u001b[0m\u001b[38;5;130m\u001b[1m";
            int count1 = 1;
            Console.WriteLine($"{inventoryColor}##### I N V E N T O R Y #####       {player1.Name}{inventoryColor} HP: {Game.HpColor}{player1.Hp}{inventoryColor} " +
                $"Luck: {Game.HpColor}{player1.Luck}{inventoryColor} Strength: {Game.HpColor}{player1.Strength}{inventoryColor} Charisma: {Game.HpColor}{player1.Charisma}{inventoryColor} Wackiness: {Game.HpColor}{player1.Wackiness}{Game.ColorReset}");

            Console.ForegroundColor = ConsoleColor.DarkYellow;

            for (var i = 0; i < Item.PlayerInventory.Count; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine("        "   + Item.PlayerInventory[i]);
                }
                else
                {
                    {
                        Console.Write("       " + count1 + ":" + Item.PlayerInventory[i]);
                        count1++;
                        Console.WriteLine("");
                    }
                }
            }
            Console.WriteLine($"{inventoryColor}\n#############################\u001b[0m");
        }
        public static void ShowInventory(Player player1)
        {
            DrawInventory(player1);
        }
        //private void InventoryPlaceOne()
        //{

        //}
    }
}