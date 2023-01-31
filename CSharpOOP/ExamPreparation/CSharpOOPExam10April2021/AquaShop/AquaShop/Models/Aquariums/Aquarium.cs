using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int capacity;
       
        private Aquarium()
        {
            this.Decorations = new List<IDecoration>();
            this.Fish = new List<IFish>();
        }
        public Aquarium(string name, int capacity) : this()
        {
            this.Name = name;
            this.Capacity = capacity;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }
                this.name = value;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                this.capacity = value;
            }
        }


        public int Comfort => this.Decorations.Sum(d=>d.Comfort);

        public ICollection<IDecoration> Decorations { get; private set; }
        

        public ICollection<IFish> Fish { get; private set; }
       

        public void AddFish(IFish fish)
        {
            if (this.Capacity< this.Decorations.Count+1)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
            this.Fish.Add(fish);
        }
        public bool RemoveFish(IFish fish) => this.Fish.Remove(fish);

        public void AddDecoration(IDecoration decoration) => this.Decorations.Add(decoration);

        public void Feed()
        {
            foreach (IFish fish in this.Fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();
            string fishes = this.Fish.Count == 0 ? "none" : string.Join(", ", this.Fish.Select(f=>f.Name));

              sb.AppendLine($"{this.Name} ({this.GetType().Name}):")
                .AppendLine($"Fish: {fishes}")
                .AppendLine($"Decorations: {this.Decorations.Count}")
                .Append($"Comfort: {this.Comfort}");
            return sb.ToString().Trim();
            
        }
    }

}
