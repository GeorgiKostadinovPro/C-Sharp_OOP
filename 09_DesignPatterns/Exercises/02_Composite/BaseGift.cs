namespace Composite
{
    public abstract class BaseGift
    {
        private string name;
        private decimal price;

        public BaseGift(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name
        {
            get 
            { 
                return this.name; 
            }
            private set 
            { 
                this.name = value; 
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                this.price = value;
            }
        }

        public abstract decimal CalculateTotalPrice(); 
    }
}
