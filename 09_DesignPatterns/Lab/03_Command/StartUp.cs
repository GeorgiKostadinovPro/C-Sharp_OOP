using System;

namespace Command
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ModifyPrice modifyPrice = new ModifyPrice();
            Product product = new Product("Samsung Galaxy S22", 1290);

            Execute(modifyPrice, new ProductCommand(product, PriceAction.Increase, 100));
            Execute(modifyPrice, new ProductCommand(product, PriceAction.Increase, 50));
            Execute(modifyPrice, new ProductCommand(product, PriceAction.Decrease, 25));

            Console.WriteLine(product.ToString());
        }

        private static void Execute(ModifyPrice modifyPrice, ICommand productCommand)
        {
            modifyPrice.SetCommand(productCommand);
            modifyPrice.Invoke();
        }
    }
}
