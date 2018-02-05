using CheckoutSystem.Models;
using NUnit.Framework;

namespace CheckoutSystem.Tests
{
    [TestFixture]
    public class OrderTests
    {
        [SetUp]
        public void Setup()
        {
        }

        public void GetTotalPriceReturnsPriceSummedUpForIdenticalItems(){
            var order = new Order();
            order.AddToOrder(new FoodItem{Sku = "A", Price = 50});
            order.AddToOrder(new FoodItem {Sku="A", Price = 50 });
            Assert.AreEqual(100, order.GetTotalPrice());
        }

        public void GetTotalPriceReturnsPriceSummedUpForDifferentItems()
        {
            var order = new Order();
            order.AddToOrder(new FoodItem { Sku = "A", Price = 50 });
            order.AddToOrder(new FoodItem { Sku = "B", Price = 50 });
            Assert.AreEqual(100, order.GetTotalPrice());
        }

        public void GetTotalPriceReturnsPriceSummedUpForDifferentItemsWithPromotion()
        {
            var order = new Order();
            order.AddToOrder(new FoodItem { Sku = "A", Price = 50, Promotion = (2, 90)});
            order.AddToOrder(new FoodItem { Sku = "B", Price = 50 });
            order.AddToOrder(new FoodItem { Sku = "A", Price = 50, Promotion = (2, 90) });
            Assert.AreEqual(140, order.GetTotalPrice());
        }

        // TOdo we can do tests assuming data can be corrupted, in which case, 
        // the program will break, but since no idea what the requirements are,
        // will leave it for now

    }
}
