using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Tires
    {
        private double presure;
        private int age;

       
        public double Presure 
        {
            get { return presure; }
            set { presure = value; } 
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
    }
}
