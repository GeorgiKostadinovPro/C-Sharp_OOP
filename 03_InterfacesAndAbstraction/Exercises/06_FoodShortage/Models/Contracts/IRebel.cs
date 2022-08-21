using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage.Models.Contracts
{
    public interface IRebel
    {
        string Name { get; }

        int Age { get; }

        string Group { get; }
    }
}
