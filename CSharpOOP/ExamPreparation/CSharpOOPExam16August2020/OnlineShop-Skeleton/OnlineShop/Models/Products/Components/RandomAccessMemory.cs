using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Components
{
    public class RandomAccessMemory : Component
    {
        private const double RandomAccessMemoryOverallPerformance = 1.20;
        public RandomAccessMemory(int id, string manufacturer, string model, decimal price, double overallPerformanc, int generation) : base(id, manufacturer, model, price, overallPerformanc, generation)
        {
        }
        public override double OverallPerformance => base.OverallPerformance * RandomAccessMemoryOverallPerformance; 
    }
}
