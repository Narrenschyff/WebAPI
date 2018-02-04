using System;
using System.Collections.Generic;

namespace CheckoutSystem.Models
{
    public interface IOrder
    {
        void AddToOrder(IItem item);
        IEnumerable<IItem> GetAllItems();
        double GetTotalPrice();
    }

    public class Order : IOrder
    {
        IDictionary<IItem, int> _items;

        public Order()
        {
            _items = new Dictionary<IItem, int>(new Helpers.ItemEqualityComparer());
        }

        public void AddToOrder(IItem item)
        {
            if (_items.ContainsKey(item))
            {
                _items[item]++;
            }
            else 
            {
                _items.Add(item, 0);
            }
        }

        public IEnumerable<IItem> GetAllItems()
        {
            return _items.Keys;
        }

        public double GetTotalPrice(){
            double totalPrice = 0;
            foreach(var itemTuple in _items)
            {
                var item = itemTuple.Key;
                totalPrice += item.CalculatePriceGivenQuantity(itemTuple.Value);
            }
            return totalPrice;
        }
    }
}
