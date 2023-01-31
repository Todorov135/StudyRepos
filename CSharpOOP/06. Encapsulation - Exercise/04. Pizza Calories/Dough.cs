using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Dough
    {
        private const double MaxGramsinDough = 200.00;
        private Dictionary<string, double> doughtTypes = new Dictionary<string, double>()
        {
            { "white", 1.5 },
            { "wholegrain" , 1.0},
            { "crispy", 0.9},
            { "chewy", 1.1},
            { "homemade", 1.0}
        };

        private string  flourType;
		private string bakingTechnique;
        
		private double grams;
		public Dough(string flourType, string bakingTechnique, double grams)
		{
			this.FlourType = flourType;
			this.BakingTechnique = bakingTechnique;
            this.Grams = grams;
		}
		public string FlourType
		{
			get 
            { 
                return flourType; 
            }
			private set 
            {
                if (!doughtTypes.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                flourType = value; 
            }
		}
        public string BakingTechnique
        {
            get
            {
                return bakingTechnique;
            }
            private set 
            { 

                bakingTechnique = value; 
            }
        }
        public double Grams
        {
            get
            { 
                return grams; 
            }
            private set
            {
                if (value <1 ||value > MaxGramsinDough)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                grams = value; 
            }
        }
        public double Calories => DoughCalories();
        private double DoughCalories()
		{
			double flourTypeValue = doughtTypes[this.FlourType.ToLower()];
			double bakingTechniqueValue = doughtTypes[this.BakingTechnique.ToLower()];
            return 2 * flourTypeValue * bakingTechniqueValue * this.Grams;
            
        }
    }
}
