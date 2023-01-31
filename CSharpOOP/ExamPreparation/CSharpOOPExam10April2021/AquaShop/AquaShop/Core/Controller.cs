using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private ICollection<IAquarium> aquariums;
        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium currAquarium;
            if (aquariumType == "FreshwaterAquarium")
            {
                currAquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                currAquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }
            this.aquariums.Add(currAquarium);
            return String.Format(OutputMessages.SuccessfullyAdded,currAquarium.GetType().Name);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration currDecoration;
            if (decorationType == "Ornament")
            {
                currDecoration = new Ornament();
            }
            else if (decorationType == "Plant")
            {
                currDecoration = new Plant();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }
            this.decorations.Add(currDecoration);
            return String.Format(OutputMessages.SuccessfullyAdded, currDecoration.GetType().Name);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish currFish;

            if (fishType == "FreshwaterFish")
            {
                currFish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == "SaltwaterFish")
            {
                currFish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }
            IAquarium currAquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);
            string currAquariumType = currAquarium.GetType().Name.Substring(0, currFish.GetType().Name.Length - 4);
            string currFishWotherType = fishType.Substring(0,fishType.Length-4);
            if (currAquariumType == currFishWotherType)
            {
                IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);
                aquarium.AddFish(currFish);
                return String.Format(OutputMessages.EntityAddedToAquarium,currFish.GetType().Name,aquariumName);
            }
            else
            {
                return OutputMessages.UnsuitableWater;
            }
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium currAquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);
            decimal fishPrice = currAquarium.Fish.Sum(f=>f.Price);
            decimal decorationPrice = currAquarium.Decorations.Sum(d=>d.Price);
            decimal totalPriceOfAquarium = fishPrice + decorationPrice;
            return String.Format(OutputMessages.AquariumValue, aquariumName, totalPriceOfAquarium);

        }

        public string FeedFish(string aquariumName)
        {
            IAquarium currAquarium = this.aquariums.FirstOrDefault(a=>a.Name == aquariumName);
            if (currAquarium != null)
            {
                foreach (IFish fish in currAquarium.Fish)
                {
                    fish.Eat();
                }
                return string.Format(OutputMessages.FishFed, currAquarium.Fish.Count);
            }
            throw new InvalidOperationException();
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration validatingExistingDecoration = this.decorations.Models.FirstOrDefault(d=>d.GetType().Name == decorationType);
            IAquarium currAquarium = this.aquariums.FirstOrDefault(a=>a.Name == aquariumName);

            if (validatingExistingDecoration == null || currAquarium == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }
            currAquarium.AddDecoration(validatingExistingDecoration);
            this.decorations.Remove(validatingExistingDecoration);
            
            return String.Format(OutputMessages.EntityAddedToAquarium, validatingExistingDecoration.GetType().Name, aquariumName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (IAquarium aquarium in this.aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }
            return sb.ToString().Trim();
        }
    }
}
