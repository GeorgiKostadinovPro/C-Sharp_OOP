namespace Composite
{
    public abstract class GiftBase
    {
        private string name;
        private decimal price;

        public GiftBase(string name, decimal price)
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
