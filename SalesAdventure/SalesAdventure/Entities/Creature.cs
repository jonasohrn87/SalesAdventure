using SalesAdventure.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesAdventure.Entities
{
    public abstract class Creature
    {
        private string icon;
        private int lvl;
        private string creatureName;
        private double hp;
        private int luck;
        private int strength;
        private int charisma;
        private int wackiness;
        private int positionY;
        private int positionX;
        private int playerLucky;
        private int monsterLucky;

        public Creature()
        {
        }
        public string CreatureIcon {
            get { return icon; }
            set { icon = value; }
        }
        public int Lvl
        {
            get { return lvl; }
            set { lvl = value; }
        }
        public string Name
        {
            get { return creatureName; }
            set { creatureName = value; }
        }
        public double Hp
        {
            get { return hp; }
            set { hp = value; }
        }
        public int Luck
        {
            get { return luck; }
            set { luck = value; }
        }
        public int Strength
        {
            get { return strength; }
            set { strength = value; }
        }
        public int Charisma
        {
            get { return charisma; }
            set { charisma = value; }
        }
        public int Wackiness
        {
            get { return wackiness; }
            set { wackiness = value; }
        }
        public int PositionY
        {
            get { return positionY; }
            set { positionY = value; }
        }
        public int PositionX
        {
            get { return positionX; }
            set { positionX = value; }
        }
        public int PlayerLucky
        {
            get { return playerLucky; }
            set { playerLucky = value; }
        }
        public int MonsterLucky
        {
            get { return monsterLucky; }
            set { monsterLucky = value; }
        }

        public abstract void Attack(Creature target);

        public abstract void ThrowRock(Creature target);

        public abstract void Attacks(Creature target);

        private int LuckyStart(Player player1, Creature target)
        {
            Random random = new Random();
            PlayerLucky = random.Next(1, 8) + player1.Luck;
            MonsterLucky = random.Next(1, 8) + target.Luck;

            return PlayerLucky + MonsterLucky;
        }

        public int ShowLucky(Player player1, Creature target)
        {
            return LuckyStart(player1, target);
        }

        private void CreatureDeafeated(DrawMap drawMap, Player player1, Creature target)
        {
            if (target.hp <= 0)
            {
                this.CreatureIcon = ".";
                this.PositionY = 0;
                this.PositionX = 0;
                this.CreatureIcon = "#";
                Mechanics.MonsterEncounter = false;
                Mechanics.CreatureCollision = false;
                player1.PlayerPlacement(drawMap);
                Console.Clear();
                Console.WriteLine("You WON! Press any key to Continue.");
            }
        }
        public void CreatureDeath(DrawMap drawMap, Player player1, Creature target)
        {
            CreatureDeafeated(drawMap, player1, target);
        }
    }
}


        //public virtual void EncounterFight(DrawMap drawMap, string[,] map, Player player1, Creature target)
        //{
        //    if (map[player1.positionY, player1.positionX] == map[this.positionY, this.positionX])
        //    {
        //        Mechanics.monsterEncounter = true;
        //        while (Mechanics.monsterEncounter)
        //        {
        //            if (player1.luck > this.luck)
        //            {
        //                LuckyStart(player1, this);
        //                Console.WriteLine($"{playerLucky} and {monsterLucky}");
        //                Console.WriteLine($"{player1.name} will do the first attack.");
        //                Console.ReadLine();

        //                player1.PlayerAttackMenu(drawMap, this, player1);
        //                CreatureDeafeated(drawMap, player1, this);
        //            }
        //            else if (player1.luck < this.luck)
        //            {
        //                LuckyStart(player1, target);
        //                Console.WriteLine($"{playerLucky} and {monsterLucky}");
        //                Console.ReadLine();
        //                Console.WriteLine($"{this.name} will do the first attack.");
        //                Console.ReadLine();
        //                Attacks(player1);
        //                //Attack(player1);
        //                player1.PlayerAttackMenu(drawMap, this, player1);
        //                CreatureDeafeated(drawMap, player1, this);
        //            }
        //        }
        //    }
        //}