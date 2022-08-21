using System;
using Telephony.Models.Contracts;

namespace Telephony.Models
{
    public class Smartphone : ICallable, IBrowsable
    {  
        
        public string Call(string phoneNumber)
        {
            return $"Calling... {phoneNumber}";
        }

        public string Browse(string url)
        {
            return $"Browsing: {url}!";
        }
    }
}
