using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonMarketStorage
{
    public class Smartphone : Telephone
    {
        public string OperatingSystem { get; private set; }

        public Smartphone(string brand, string model, decimal price, string operatingSystem)
            : base(brand, model, price)
        {
            OperatingSystem = operatingSystem;
        }

        public override string GetModelDetails()
        {
            return $"Brand: {Brand}, Model: {Model}, OS: {OperatingSystem}, Price: {Price:C}";
        }
    }
}
