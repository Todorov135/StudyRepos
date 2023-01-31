using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
		private List<Ski> data;
		private string  name;
		private int capacity;

        public SkiRental(string name, int capacity)
        {
            this.Data = new List<Ski>();
            this.Name = name;
            this.Capacity = capacity;
        }

		public List<Ski> Data
        {
			get { return data; }
			set { data = value; }
		}
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
        public void Add(Ski ski)
        {
            if (this.Capacity>data.Count)
            {
                this.Data.Add(ski);
            }
        }
        public int Count { get => this.Data.Count;  }
        public bool Remove(string manufacturer, string model)
        {
            Ski currSki = this.Data.FirstOrDefault(m => m.Manufacturer == manufacturer && m.Model == model);
            if (currSki != null)
            {
                this.Data.Remove(currSki);
                return true;
            }
            return false;
        }
        public Ski GetNewestSki()
        {
            if (!this.Data.Any())
            {
                return null;
            }
            Ski newestSki = this.Data.OrderByDescending(i => i.Year).First();
            return newestSki;
        }
        public Ski GetSki(string manufacturer, string model)
        {
            Ski currSki = this.Data.FirstOrDefault(m => m.Manufacturer == manufacturer && m.Model == model);
            if (currSki == null)
            {
                return null;
            }
            return currSki;
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {this.Name}:");
            foreach (Ski ski in this.Data)
            {
                sb.AppendLine(ski.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
