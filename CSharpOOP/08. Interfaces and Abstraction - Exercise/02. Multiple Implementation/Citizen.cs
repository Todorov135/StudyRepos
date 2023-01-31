using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace PersonInfo
{
    public class Citizen : IPerson, IIdentifiable, IBirthable
    {
        private string name;
        private int age;
        private string id;
        private string birthdate;
        public Citizen(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public Citizen(string name, int age, string id, string birthdate):this(name, age)
        {
            this.Id = id;
            this.Birthdate = birthdate;
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

        public string Birthdate
        {
            get
            {
                return birthdate;
            }
            private set
            {
                birthdate = value;
            }
        }
    }
}
