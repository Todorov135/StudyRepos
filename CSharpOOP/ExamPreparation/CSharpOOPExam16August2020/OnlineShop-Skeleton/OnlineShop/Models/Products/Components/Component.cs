using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OnlineShop.Models.Products.Components
{
    public abstract class Component : Product, IComponent
    {
        protected Component(int id, string manufacturer, string model, decimal price, double overallPerformanc, int generation)
            : base(id, manufacturer, model, price, overallPerformanc)
        {
            this.Generation = generation;
        }

        public int Generation { get; private set; }
        public override string ToString()
        {
            return base.ToString() + $" Generation: {this.Generation}";
        }
    }
}
