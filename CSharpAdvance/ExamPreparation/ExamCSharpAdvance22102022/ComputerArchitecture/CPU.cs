﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerArchitecture
{
    public class CPU
    {
		private string brand;
        private int cores;
        private double frequency;

		public CPU(string brand, int cores, double frequency)
		{
			this.Brand = brand;
			this.Cores = cores;
			this.Frequency = frequency;
		}
        public string Brand
		{
			get { return brand; }
			set { brand = value; }
		}
		public int Cores
		{
			get { return cores; }
			set { cores = value; }
		}
		public double Frequency
        {
			get { return frequency; }
			set { frequency = value; }
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendLine($"{this.Brand} CPU:");
			sb.AppendLine($"Cores: {this.Cores}");
			sb.AppendLine($"Frequency: {this.Frequency:F1} GHz");

			return sb.ToString().Trim();
		}


	}
}
