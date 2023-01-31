﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Child : Person
    {
        private int age;
        public Child(string name, int age) : base(name, age)
        {

        }

        public int Age 
        {
            get => age;
            set
            {
                if (value <= 15)
                {
                    age = value;
                }
            }
        }
    }
}
