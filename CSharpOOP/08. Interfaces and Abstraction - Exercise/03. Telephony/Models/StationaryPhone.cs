namespace Telephony.Models
{
    using Interface;
    using System.Runtime.CompilerServices;

    public class StationaryPhone : ICallable
    {
        public string Call(string number)
        {
            return $"Dialing... {number}";
        }
       
    }
}
