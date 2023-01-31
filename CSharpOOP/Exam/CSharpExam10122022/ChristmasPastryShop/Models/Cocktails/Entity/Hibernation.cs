using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails.Entity
{
    public class Hibernation : Cocktail
    {
        public Hibernation(string cocktailName, string size) : base(cocktailName, size, 10.50)
        {
        }
    }
}
