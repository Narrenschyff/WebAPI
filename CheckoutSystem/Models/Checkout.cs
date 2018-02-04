using System;
using CheckoutSystem.Models;

namespace CheckoutSystem.Services
{
    public interface ICheckout
    {
        
        string ScanItem(string itemCode);
    }

    public class Checkout : ICheckout
    {
        private IScanner _scanner;
        private IOrder _order;

        public Checkout(IScanner scanner)
        {
            _order = new Order();
            _scanner = scanner;
        }

        public string ScanItem(string itemCode)
        {
            var item = _scanner.GetScannedItem(itemCode);
            _order.AddToOrder(item);
            return item.Sku;
        }
    }
}
