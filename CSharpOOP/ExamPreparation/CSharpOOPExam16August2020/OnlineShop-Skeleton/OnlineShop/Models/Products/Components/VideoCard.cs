using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Components
{
    public class VideoCard : Component
    {
        private const double VideoCardOverallPerformance = 1.25;
        public VideoCard(int id, string manufacturer, string model, decimal price, double overallPerformanc, int generation) 
            : base(id, manufacturer, model, price, overallPerformanc, generation)
        {
        }
        public override double OverallPerformance => base.OverallPerformance * VideoCardOverallPerformance;
    }
}
