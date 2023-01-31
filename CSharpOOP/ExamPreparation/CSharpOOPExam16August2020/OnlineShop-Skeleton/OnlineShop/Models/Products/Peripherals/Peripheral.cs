using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Peripherals
{
    public abstract class Peripheral : Product, IPeripheral
    {
        protected Peripheral(int id, string manufacturer, string model, decimal price, double overallPerformanc, string connectionType) 
            : base(id, manufacturer, model, price, overallPerformanc)
        {
            this.ConnectionType = connectionType;
        }

        public string ConnectionType { get; private set; }
        public override string ToString()
        {
            return base.ToString() + $" Connection Type: ${this.ConnectionType}";
        }
    }
}
