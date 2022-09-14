using System;

namespace Template
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Sourdough sourdoughBread = new Sourdough();
            sourdoughBread.Make();

            TwelveGrain twelveGrainBread = new TwelveGrain();
            twelveGrainBread.Make();

            WholeWheat wholeWheatBread = new WholeWheat();
            wholeWheatBread.Make();
        }
    }
}
