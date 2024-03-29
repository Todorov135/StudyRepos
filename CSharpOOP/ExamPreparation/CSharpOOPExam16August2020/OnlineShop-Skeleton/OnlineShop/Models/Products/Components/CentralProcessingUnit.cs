﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Components
{
    public class CentralProcessingUnit : Component
    {
        private const double CentralProcessingUnitOverallPerformance = 1.25;
        public CentralProcessingUnit(int id, string manufacturer, string model, decimal price, double overallPerformanc, int generation) 
            : base(id, manufacturer, model, price, overallPerformanc, generation)
        {
        }
        public override double OverallPerformance => base.OverallPerformance * CentralProcessingUnitOverallPerformance;
    }
}
