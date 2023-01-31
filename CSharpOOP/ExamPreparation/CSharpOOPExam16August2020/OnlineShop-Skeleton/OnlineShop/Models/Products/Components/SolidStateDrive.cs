using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Components
{
    public class SolidStateDrive : Component
    {
        private const double SolidStateDriveOverallPerformance = 1.20;
        public SolidStateDrive(int id, string manufacturer, string model, decimal price, double overallPerformanc, int generation) : base(id, manufacturer, model, price, overallPerformanc, generation)
        {
        }
        public override double OverallPerformance => base.OverallPerformance * SolidStateDriveOverallPerformance;
    }
}
