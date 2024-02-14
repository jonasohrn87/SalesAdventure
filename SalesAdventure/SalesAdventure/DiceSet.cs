using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SalesAdventure.Entities;

namespace SalesAdventure
{
    class DiceSet
    {
        //public List<int> d2 { get; private set; }
        //public List<int> d4 { get; private set; }
        //public List<int> d6 { get; private set; }
        //public List<int> d8 { get; private set; }
        //public List<int> d10 { get; private set; }
        //public List<int> d12 { get; private set; }
        //public List<int> d20 { get; private set; }
        //public DiceSet()
        //{
        //    this.d2 = d2;
        //    this.d4 = d4;
        //    this.d6 = d6;
        //    this.d8 = d8;
        //    this.d10 = d10;
        //    this.d12 = d12;
        //    this.d20 = d20;
        //}
        public DiceSet() 
        {            
        }
        public void Dices ()
        {
            Random diceThrow = new Random();            
            diceThrow.Next(1, 11);
            //Entities.Orc(hp)
        }
        //public void RandomAtkDmg()
        //{
        //    int orcAttack =  Dices + Entities.Orc.strenght;
        //}
    }
}
