using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public class ProfessionalRacer : Racer
    {
        //ProfessionalRacer always starts with 30 driving experience and always have "strict" racing behavior.
        private const string ProfessionalRacerRacingBehavior = "strict";
        private const int ProfessionalRacerDrivingExperience = 30;
        public ProfessionalRacer(string username,  ICar car) : base(username, ProfessionalRacerRacingBehavior, ProfessionalRacerDrivingExperience, car)
        {
        }
        public override void Race()
        {
            base.Race();
            this.DrivingExperience += 10;
        }
    }
}
