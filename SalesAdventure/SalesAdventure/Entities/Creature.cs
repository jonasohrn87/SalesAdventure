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
        public string creatureIcon;
        public int lvl;
        public string name;
        public double hp;
        public int luck;
        public int strength;
        public int charisma;
        public int wackiness;
        public int positionY;
        public int positionX;
        public Creature()
        {
        }

        //public virtual void CreaturePosition()
        //{
        //}

        public abstract void Attack(Creature target);

        public abstract void ThrowRock(Creature target);

        public abstract void Attacks(Creature target);

        public void CreatureDeafeated(DrawMap drawMap, Player player1, Creature target)
        {
            if (target.hp <= 0)
            {
                this.creatureIcon = ".";
                this.positionY = 0;
                this.positionX = 0;
                this.creatureIcon = "#";
                //this.hp = 0;
                Mechanics.monsterEncounter = false;
                Mechanics.creaturePlayerCollision = false;
                player1.PlacePlayer(drawMap);
                Console.Clear();
                Console.WriteLine("You WON! Press any key to Continue.");
            }
        }
    }
}