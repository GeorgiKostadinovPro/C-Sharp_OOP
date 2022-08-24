using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.IO.Contracts
{
    public interface IWriter
    {
        void Write(string value);

        void WriteLine(string value);
    }
}
