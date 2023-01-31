using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace PersonInfo
{
    internal class Citizen : IPerson
    {
        private string name;
        private int age;
        public Citizen(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                name = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            private set
            {
                age = value;
            }
        }
    }
}
