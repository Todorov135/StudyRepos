using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Components
{
    public class Motherboard : Component
    {
        private const double MotherboardOverallPerformance = 1.25;
        public Motherboard(int id, string manufacturer, string model, decimal price, double overallPerformanc, int generation) 
            : base(id, manufacturer, model, price, overallPerformanc, generation)
        {
        }
        public override double OverallPerformance => base.OverallPerformance * MotherboardOverallPerformance;
    }
}
