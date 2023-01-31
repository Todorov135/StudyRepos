namespace Restaurant
{
    public class Cake : Dessert
    {
        private const double DeffCakeGrams = 250;
        private const double DeffCakeCalories = 1000;
        private const decimal DeffCakePrice = 1000;
        public Cake(string name) : base(name, DeffCakePrice, DeffCakeGrams, DeffCakeCalories)
        {
        }
    }
}
