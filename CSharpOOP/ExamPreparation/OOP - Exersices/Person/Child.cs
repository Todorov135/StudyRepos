using System;
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
        //public  int Age
        //{
        //    get
        //    {
        //        return age;
        //    }
        //     set
        //    {
        //        if (value > 15)
        //        {
        //            throw new ArgumentException("The person is not child!");
        //        }
        //        age = value;
        //    }
        //}
        public override string ToString()
        {
            return $"Name: {base.Name}, Age: {this.Age}";
        }
    }
}
