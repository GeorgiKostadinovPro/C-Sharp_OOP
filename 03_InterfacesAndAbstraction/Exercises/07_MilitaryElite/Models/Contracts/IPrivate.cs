using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models.Contracts
{
    public interface IPrivate : ISoldier
    {
        public decimal Salary { get; }
    }
}
