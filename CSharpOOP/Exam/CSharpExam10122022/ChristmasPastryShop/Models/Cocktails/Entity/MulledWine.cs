using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails.Entity
{
    public class MulledWine : Cocktail
    {
        public MulledWine(string cocktailName, string size) : base(cocktailName, size, 13.50)
        {
        }
    }
}
