using System;
using System.Collections.Generic;

namespace TelefonMarketStorage
{
    public interface ITelephone
    {
        string GetModelDetails();
        decimal GetPrice();
    }

    public abstract class Telephone : ITelephone
    {
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public decimal Price { get; private set; }

        protected Telephone(string brand, string model, decimal price)
        {
            Brand = brand;
            Model = model;
            Price = price;
        }

        public abstract string GetModelDetails();

        public decimal GetPrice()
        {
            return Price;
        }
    }
}
