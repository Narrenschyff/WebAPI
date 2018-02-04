using System;
using System.Diagnostics.Contracts;
using CheckoutSystem.Models;

namespace CheckoutSystem.Services
{
    public interface IScanner
    {

        IItem GetScannedItem(string itemCode);

    }
    public class Scanner : IScanner
    {
        public IItem GetScannedItem(string itemCode)
        {
            if (itemCode == "ACode")
            {
                return new FoodItem()
                {
                    Sku = "A",
                    Name = "Pineapple",
                    Price = 50.0
                };
            }
            return null;
        }
    }
}
