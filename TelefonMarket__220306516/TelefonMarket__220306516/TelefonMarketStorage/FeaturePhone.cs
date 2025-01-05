using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonMarketStorage
{
    public class FeaturePhone : Telephone
    {
        public bool HasCamera { get; private set; }

        public FeaturePhone(string brand, string model, decimal price, bool hasCamera)
            : base(brand, model, price)
        {
            HasCamera = hasCamera;
        }

        public override string GetModelDetails()
        {
            return $"Brand: {Brand}, Model: {Model}, Camera: {(HasCamera ? "Yes" : "No")}, Price: {Price:C}";
        }
    }
}
