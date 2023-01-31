using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Text;

namespace Cars
{
    public class Tesla : ICar, IElectricCar
    {
        private string model;
        private string color;
        private int battery;
        public Tesla(string model, string color, int battery)
        {
            this.Model = model;
            this.Color = color;
            this.Battery = battery;
        }
        public string Model
        {
            get
            {
                return model;
            }
            private set
            {
                model = value;
            }
        }
        public string Color
        {
            get
            {
                return color;
            }
            private set
            {
                color = value;
            }
        }
        
        public int Battery
        {
            get
            {
                return battery;
            }
            private set
            {
                battery = value;
            }
        }
        string Start()
        {
            return "Engine start";
        }
        string Stop()
        {
            return "Breaaak!";
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Color} Tesla {this.Model} whit {this.Battery} Batteries");
            sb.AppendLine(Start());
            sb.Append(Stop());
            return sb.ToString();
            
        }

        
    }
}
