﻿using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System.Linq;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
			while ((bunny.Dyes.Count > 0) && bunny.Energy > 0 && (!egg.IsDone()))
			{
				IDye currentDye = bunny.Dyes.First();

				egg.GetColored();
				bunny.Work();
				currentDye.Use();

				if (currentDye.IsFinished())
				{
					bunny.Dyes.Remove(currentDye);
				}
			}
		}
    }
}
