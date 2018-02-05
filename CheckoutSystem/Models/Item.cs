using System;
namespace CheckoutSystem.Models
{
    public interface IItem
    {
        string Sku
        {
            get;
            set;
        }
        string Name
        {
            get;
            set;
        }
        double Price
        {
            get;
            set;
        }

        (int quantity, double price) Promotion
        {
            get;
            set;
        }

        double CalculatePriceGivenQuantity(int numberOfItems);
    }

    public abstract class Item : IItem
    {
        public string Sku
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public double Price
        {
            get;
            set;
        }

        public (int quantity, double price) Promotion
        {
            get;
            set;
        }

        public double CalculatePriceGivenQuantity(int numberOfItems) {
            if (Promotion.quantity == 0 || numberOfItems < Promotion.quantity) {
                return numberOfItems * Price;
            } 
            return (numberOfItems / Promotion.quantity) * Promotion.price 
                   + (numberOfItems % Promotion.quantity)  * Price;                                                   
        } 
    }
}
