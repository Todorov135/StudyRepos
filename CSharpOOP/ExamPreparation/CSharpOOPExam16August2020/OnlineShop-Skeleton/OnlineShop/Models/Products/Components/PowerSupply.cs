using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Components
{
    public class PowerSupply : Component
    {
        private const double PowerSupplyOverallPerformance = 1.05;
        public PowerSupply(int id, string manufacturer, string model, decimal price, double overallPerformanc, int generation) : base(id, manufacturer, model, price, overallPerformanc, generation)
        {
        }
        public override double OverallPerformance => base.OverallPerformance * PowerSupplyOverallPerformance;
    }
}
