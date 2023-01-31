using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public Map()
        {

        }
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return "Race cannot be completed because both racers are not available!";
            }
            if (!racerOne.IsAvailable())
            {
                return $"{racerTwo.Username} wins the race! {racerOne.Username} was not available to race!";
            }
            if (!racerTwo.IsAvailable())
            {
                return $"{racerOne.Username} wins the race! {racerTwo.Username} was not available to race!";
            }

            IRacer winner;
            
            racerOne.Race();
            racerTwo.Race();
            //chanceOfWinning = horsePower * drivingExperience * racingBehaviorMultiplier

            double winningRateRacerOne = racerOne.Car.HorsePower * racerOne.DrivingExperience;
            if (racerOne.RacingBehavior == "strict")
            {
                winningRateRacerOne *= 1.2;
            }
            else if (racerTwo.RacingBehavior == "aggressive")
            {
                winningRateRacerOne *= 1.1;
            }

            double winningRateRacerTwo = racerTwo.Car.HorsePower * racerTwo.DrivingExperience;
            if (racerTwo.RacingBehavior == "strict")
            {
                winningRateRacerTwo *= 1.2;
            }
            else if (racerTwo.RacingBehavior == "aggressive")
           
            {
                winningRateRacerTwo *= 1.1;
            }
           
            if (winningRateRacerOne> winningRateRacerTwo)
            {
                winner = racerOne;
                return $"{racerOne.Username} has just raced against {racerTwo.Username}! {winner.Username} is the winner!";
            }
            else
            {
                winner = racerTwo;
                return $"{racerOne.Username} has just raced against {racerTwo.Username}! {winner.Username} is the winner!";
            }
        }
    }
}
        
