﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRPG.Game.Engine.Models
{
    public class Weapon : GameItem
    {
        public Weapon(int itemTypeID, string name, int price, int minimumDamage, int maximumDamage)
            : base(itemTypeID, name, price)
        {
            MinimumDamage = minimumDamage;
            MaximumDamage = maximumDamage;
        }

        public int MinimumDamage { get; set; }
        public int MaximumDamage { get; set; }

        public override GameItem Clone() => 
            new Weapon(ItemTypeID, Name, Price, MinimumDamage, MaximumDamage);

    }
}