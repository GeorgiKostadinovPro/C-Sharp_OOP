﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products
{
    public abstract class Product : IProduct
    {
        protected Product(int id, string manufacturer, string model, decimal price, double overallPerformance)
        {

        }

        public int Id => throw new NotImplementedException();

        public string Manufacturer => throw new NotImplementedException();

        public string Model => throw new NotImplementedException();

        public virtual decimal Price => throw new NotImplementedException();

        public virtual double OverallPerformance => throw new NotImplementedException();

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
