﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Seat : ICar
    {
        private string model;
        private string color;

        public Seat(string model, string color)
        {
            this.Model = model;
            this.Color = color;
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
            sb.AppendLine($"{this.Color} Seat {this.Model}");
            sb.AppendLine(Start());
            sb.Append(Stop());
            return sb.ToString();
        }
    }
}
