using System.Xml.Schema;
using Telephony.IO.Interfaces;
using Telephony.Models;

namespace Telephony.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly StationaryPhone stationaryPhone;
        private readonly Smartphone smartophone;
        private Engine()
        {
            this.stationaryPhone = new StationaryPhone();
            this.smartophone = new Smartphone();
        }
        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string[] phoneNumbers = this.reader.ReadLine().Split(" ", System.StringSplitOptions.RemoveEmptyEntries);
            string[] urls = this.reader.ReadLine().Split(" ", System.StringSplitOptions.RemoveEmptyEntries);
            foreach (var number in phoneNumbers)
            {
                if (!this.ValidateNumber(number))
                {
                    this.writer.WriteLine("Invalid number!");
                }
                else if (number.Length == 10)
                {
                    this.writer.WriteLine(smartophone.Call(number));
                }
                else if (number.Length == 7)
                {
                    this.writer.WriteLine(this.stationaryPhone.Call(number));
                }
            }
            foreach (var url in urls)
            {
                if (!ValidateURL(url))
                {
                    this.writer.WriteLine("Invalid URL!");
                }
                else
                {
                    this.writer.WriteLine(this.smartophone.BrowseURL(url));
                }
            }
            
        }
        private bool ValidateNumber(string number)
        {
            foreach (var digit in number)
            {
                if (!char.IsDigit(digit))
                {
                    return false;
                }
            }
            return true;
        }
        private bool ValidateURL(string url)
        {
            foreach (var ch in url)
            {
                if (char.IsDigit(ch))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
