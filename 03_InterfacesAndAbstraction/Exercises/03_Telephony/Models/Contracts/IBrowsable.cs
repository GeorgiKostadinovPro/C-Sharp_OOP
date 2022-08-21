using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony.Models.Contracts
{
    public interface IBrowsable
    {
        string Browse(string url);
    }
}
