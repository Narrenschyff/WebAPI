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
    }
}
