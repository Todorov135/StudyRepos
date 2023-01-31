﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public class SaltwaterFish : Fish
    {
        private const int SaltwaterFishSize = 5;
        private const int SaltwaterFishIncreaseSizeValue = 2;
        public SaltwaterFish(string name, string species, decimal price) : base(name, species, price)
        {
            this.Size = SaltwaterFishSize;
        }

        public override void Eat()
        {
            base.Size += SaltwaterFishIncreaseSizeValue;
        }
    }
}
