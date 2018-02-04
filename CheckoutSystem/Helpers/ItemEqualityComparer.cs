using System;
using System.Collections.Generic;
using CheckoutSystem.Models;

namespace CheckoutSystem.Helpers
{
    public class ItemEqualityComparer : IEqualityComparer<IItem>
    {
        public bool Equals(IItem a, IItem b)
        {
            return a.Sku == b.Sku;
        }

        public int GetHashCode(IItem a)
        {
            return a.Sku.GetHashCode();
        }
    }
}
