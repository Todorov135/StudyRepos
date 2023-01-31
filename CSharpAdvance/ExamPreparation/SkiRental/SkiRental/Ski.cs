namespace SkiRental
{
    public class Ski
    {
        // • Manufacturer: string
        // • Model: string
        // • Year: int
        private string manufacturer;
        private string model;
        private int year;
        public Ski(string manufacturer, string model, int year)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Year = year;
        }

        public string Manufacturer
        {
            get { return manufacturer; ; }
            set { manufacturer = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        public override string ToString()
        {
            return $"{this.Manufacturer} - {this.Model} - {this.Year}";
        }
    }
}
