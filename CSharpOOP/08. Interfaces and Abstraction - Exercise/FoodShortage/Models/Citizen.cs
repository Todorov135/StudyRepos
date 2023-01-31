using BorderControl.Models.Interfaces;
using FoodShortage.Models.Interfaces;

namespace BorderControl.Models
{
    public class Citizen : IEnterable, IBirthdate,IBuyer
    {
        private string name;
        private int age;
        private string id;
        private string birthdate;
        private int food;
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
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

        public int Food
        {
            get
            {
                return food;
            }
            private set
            {
                food = value;
            }
        }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
