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
        private int charisma; //ej implementerad ännu
        private int wackiness; // påverkar bl a critical hit
        private int positionY;
        private int positionX;
        private int playerLucky; // startchans av varje fight för player
        private int monsterLucky; // startchans av varje fight för monster

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

        // Samling attacker
        public abstract void Attacks(Creature target);

        //Metod för att räkna ut med random vem som får första attacken i varje attacksekvens.
        private int LuckyStart(Player player1, Creature target)
        {
            Random random = new Random();
            PlayerLucky = random.Next(1, 8) + player1.Luck;
            MonsterLucky = random.Next(1, 8) + target.Luck;

            return PlayerLucky + MonsterLucky;
        }

        // Visar tärningskast för start i fight för player och monster.
        public int ShowLucky(Player player1, Creature target)
        {
            return LuckyStart(player1, target);
        }
        private void CreatureDeafeated(DrawMap drawMap, Player player1, Creature target)
        {

            // Om monster dör, ändra icon och flytta ut monster ur kartan och dölj sedan monster i vägg.
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