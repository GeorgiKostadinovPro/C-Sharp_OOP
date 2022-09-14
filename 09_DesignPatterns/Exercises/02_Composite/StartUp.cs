using System;

namespace Composite
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            BaseGift phone = new SingleGift("Samsung Galaxy S22", 1290);
            phone.CalculateTotalPrice();
            Console.WriteLine();

            CompositeGift rootBox = new CompositeGift("RootBox", 0);
            BaseGift truckToy = new SingleGift("TruckToy", 289);
            BaseGift planeToy = new SingleGift("PlaneToy", 587);
            rootBox.Add(truckToy);
            rootBox.Add(planeToy);

            CompositeGift childBox = new CompositeGift("ChildBox", 0);
            BaseGift soldierToy = new SingleGift("SoldierToy", 200);
            childBox.Add(soldierToy);
            rootBox.Add(childBox);

            decimal totalPrice = rootBox.CalculateTotalPrice();

            Console.WriteLine($"Total price of this composite present is: {totalPrice:f2}");
        }
    }
}
