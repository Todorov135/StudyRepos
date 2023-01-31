using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Delicacies.Entity
{
    public class Gingerbread : Delicacy
    {
        public Gingerbread(string delicacyName) : base(delicacyName, 4.00)
        {
        }
    }
}
