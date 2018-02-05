using System;
using System.Collections.Generic;
using CheckoutSystem.Models;

namespace CheckoutSystem.Repositories
{
    public interface IItemsRepository
    {
        IItem GetItem(string sku);
    }

    public class ItemsRepository : IItemsRepository // TODO this should be rather IRepository
    {
        IDictionary<string, IItem> _items;

        public ItemsRepository()
        {
            _items = ConstructProvisionaryItems();
        }

        private IDictionary<string, IItem> ConstructProvisionaryItems(){
            var items = new Dictionary<string, IItem>();
            items.Add("A", new FoodItem(){Sku = "A", Name = "A", Price = 50});
            items.Add("B", new FoodItem() { Sku = "B", Name = "B", Price = 30 });
            items.Add("C", new FoodItem() { Sku = "C", Name = "C", Price = 20 });
            items.Add("D", new FoodItem() { Sku = "D", Name = "D", Price = 15 });
            return items;
        }

        public IItem GetItem(string sku) {
            return _items[sku];
        }

    }
}
