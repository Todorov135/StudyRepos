using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ComputerArchitecture
{
    public class Computer
    {
		private List<CPU> multiprocessor;
        private string model;
        private int capacity;

		private Computer() 
		{
            this.Multiprocessor = new List<CPU>();
        }
		public Computer(string model, int capacity) : this()
		{
			this.Model = model;
			this.Capacity = capacity;
		}
        public List<CPU> Multiprocessor
        {
			get { return multiprocessor; }
			set { multiprocessor = value; }
		}
		public string  Model
		{
			get { return model; }
			set { model = value; }
		}
		public int Capacity
        {
			get { return capacity; }
			set { capacity = value; }
		}
		public int Count => this.Multiprocessor.Count;

		public void Add(CPU cpu)
		{
			if (this.Multiprocessor.Count < this.Capacity)
			{
				this.Multiprocessor.Add(cpu);
			}
		}
		public bool Remove(string brand)
		{
			CPU cpuToRemove = this.Multiprocessor.FirstOrDefault(c => c.Brand == brand);
			if (cpuToRemove != null)
			{
				return this.Multiprocessor.Remove(cpuToRemove);
            }
			return false;
		}
		public CPU MostPowerful()
		{
			List<CPU> sortedListOfCPUs = this.Multiprocessor.OrderByDescending(c => c.Frequency).ToList();
			
			return sortedListOfCPUs[0];

        }
		public CPU GetCPU(string brand)
		{
			CPU cpuByBrand = this.Multiprocessor.FirstOrDefault(c => c.Brand == brand);
			if (cpuByBrand != null)
			{
				return cpuByBrand;
            }
			return null;
		}
		public string Report()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"CPUs in the Computer {this.Model}:");
			foreach (CPU cpu in this.Multiprocessor)
			{
				sb.AppendLine(cpu.ToString());
			}
			return sb.ToString().Trim();

        }


    }
}
