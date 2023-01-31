using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Athletes.Entity
{
    public class Boxer : Athlete
    {
        public Boxer(string fullName, string motivation, int numberOfMedals) : base(fullName, motivation, numberOfMedals, 60)
        {
        }

        public override void Exercise()
        {
            int valueOfIncreasingBoxerStamina = 15;
            int maximumBoxerStamina = 100;
            if (base.Stamina + valueOfIncreasingBoxerStamina > maximumBoxerStamina)
            {
                base.Stamina = maximumBoxerStamina;
                throw new ArgumentException("Stamina cannot exceed 100 points.");
            }
            else 
            {
                base.Stamina += valueOfIncreasingBoxerStamina;
            }
        }
    }
}
