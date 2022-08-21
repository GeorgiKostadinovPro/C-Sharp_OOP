using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony.Models.Contracts
{
    public interface ICallable
    {
        string Call(string phoneNumber);
    }
}
