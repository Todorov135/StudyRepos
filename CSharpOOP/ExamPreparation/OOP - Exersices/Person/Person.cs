using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        private string name;
        private int age;
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string  Name
        {
            get
            { 
                return name; 
            }
          private  set
            {
                name = value;
            }
        }
        public  int Age 
        {
            get
            {
                return age;
            }
            private  set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age must be zero or positive!");
                }
                age = value;
            }
        }
        public override string ToString()
        {
            return $"Name: {this.Name}, Age: {this.Age}";
        }
    }
}
