using System;
using System.Collections.Generic;
using CheckoutSystem.Models;
using CheckoutSystem.Services;

namespace CheckoutSystem.Repositories
{
    public interface ICheckoutRepository
    {
        ICheckout GetOrAddCheckout(string sessionId);
        void AddCheckout(string sessionId);
    }

    public class CheckoutRepository : ICheckoutRepository
    {
        IDictionary<string, ICheckout> _checkouts;

        public CheckoutRepository()
        {
            _checkouts = new Dictionary<string, ICheckout>();
        }

        public void AddCheckout(string sessionId)
        {
            _checkouts.Add(sessionId, new Checkout(new Scanner()));
        }

        public ICheckout GetOrAddCheckout(string sessionId)
        {
            if (!_checkouts.ContainsKey(sessionId))
            {
                AddCheckout(sessionId);
            }
            return _checkouts[sessionId];
        }
    }
}
