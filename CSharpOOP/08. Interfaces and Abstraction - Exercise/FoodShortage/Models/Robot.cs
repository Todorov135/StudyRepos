﻿using BorderControl.Models.Interfaces;
using System.Xml.Linq;

namespace BorderControl.Models
{
    public class Robot : IEnterable
    {
        private string model;
        private string id;
        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
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

        public string Id
        {
            get
            {
                return id;
            }
            private set
            {
                id = value;
            }
        }
    }
}
