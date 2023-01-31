using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Formula1.Models.Entity
{
    public class Race : IRace
    {
        private string raceName;
        private int numberOfLaps;

        public Race(string raceName, int numberOfLaps)
        {
            this.Pilots = new List<IPilot>();

            this.RaceName = raceName;
            this.NumberOfLaps = numberOfLaps;
        }
        public string RaceName
        {
            get
            {
                return this.raceName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Invalid race name: {value}.");
                }
                this.raceName = value;
            }
        }
        public int NumberOfLaps
        {
            get
            {
                return this.numberOfLaps;
            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException($"Invalid lap numbers: {value}.");
                }
                this.numberOfLaps = value;
            }
        }

        public bool TookPlace { get; set; }


        public ICollection<IPilot> Pilots { get; }

        public void AddPilot(IPilot pilot)
        {
            this.Pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The {this.RaceName} race has:");
            sb.AppendLine($"Participants: {this.Pilots.Count}");
            sb.AppendLine($"Number of laps: {this.NumberOfLaps}");
            string printTookPlace = this.TookPlace ? "Yes" : "No";
            sb.AppendLine($"Took place: {printTookPlace}");

            return sb.ToString().TrimEnd();
        }
    }
}
