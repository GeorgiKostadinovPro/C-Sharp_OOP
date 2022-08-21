using System;
using Telephony.Core;
using Telephony.Core.Contracts;

namespace Telephony
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
