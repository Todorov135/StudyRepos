using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Peripherals
{
    public class Headset : Peripheral
    {
        public Headset(int id, string manufacturer, string model, decimal price, double overallPerformanc, string connectionType) 
            : base(id, manufacturer, model, price, overallPerformanc, connectionType)
        {
        }
    }
}
