using System;
using System.Collections.Generic;

namespace CheckoutSystem.Models
{
    public interface IOrder
    {
        void AddToOrder(IItem item);
        IEnumerable<IItem> GetAllItems();
    }

    public class Order : IOrder
    {
        ICollection<IItem> _items;

        public Order()
        {
            _items = new List<IItem>();
        }

        public void AddToOrder(IItem item) => _items.Add(item);

        public IEnumerable<IItem> GetAllItems()
        {
            return _items;
        }
    }
}
