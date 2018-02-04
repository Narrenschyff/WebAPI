using System;
using System.Collections.Generic;
using CheckoutSystem.Models;
using CheckoutSystem.Services;

namespace CheckoutSystem.Repositories
{
    public interface ICheckoutRepository
    {
        ICheckout GetOrAddCheckout(string sessionId, ICheckout checkout);
        void AddCheckout(string sessionId, ICheckout checkout);
    }

    public class CheckoutRepository : ICheckoutRepository // TODO this should be rather IRepository
    {
        IDictionary<string, ICheckout> _checkouts;

        public CheckoutRepository()
        {
            _checkouts = new Dictionary<string, ICheckout>();
        }

        public void AddCheckout(string sessionId, ICheckout checkout)
        {
            _checkouts.Add(sessionId, checkout);
        }

        public ICheckout GetOrAddCheckout(string sessionId, ICheckout checkout)
        {
            if (!_checkouts.ContainsKey(sessionId))
            {
                AddCheckout(sessionId, checkout);
            }
            return _checkouts[sessionId];
        }
    }
}
