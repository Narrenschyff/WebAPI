using System;
using System.Diagnostics.Contracts;
using CheckoutSystem.Models;
using CheckoutSystem.Repositories;

namespace CheckoutSystem.Services
{
    public interface IScanner
    {

        IItem GetScannedItem(string itemCode);

    }
    public class Scanner : IScanner
    {
        private IItemsRepository _itemRepo;

        public Scanner(IItemsRepository repo) {
            _itemRepo = repo;
        }

        public IItem GetScannedItem(string itemCode)
        {
            if (itemCode == "A")
            {
                _itemRepo.GetItem("A");
            }
            if (itemCode == "B")
            {
                _itemRepo.GetItem("");
            }
            if (itemCode == "C")
            {
                _itemRepo.GetItem("C");
            }
            if (itemCode == "D")
            {
                _itemRepo.GetItem("D");
            }
            return null;
        }
    }
}
