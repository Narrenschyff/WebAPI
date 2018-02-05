using CheckoutSystem.Models;
using NUnit.Framework;

namespace CheckoutSystem.Tests
{
    [TestFixture]
    public class ItemTests
    {
        [Test]
        public void CalculatePriceGivenQuantityWhenNoPromotion()
        {
            var item = new FoodItem();
            item.Price = 50;
            Assert.AreEqual(2 * 50, item.CalculatePriceGivenQuantity(2));
        }

        [Test]
        public void CalculatePriceGivenQuantityWhenPromotionNotApplied()
        {
            var item = new FoodItem();
            item.Price = 50;
            item.Promotion = (3, 90);
            Assert.AreEqual(2 * 50, item.CalculatePriceGivenQuantity(2));
        }

        [Test]
        public void CalculatePriceGivenQuantityWhenPromotionAppliedEvenNums()
        {
            var item = new FoodItem();
            item.Price = 50;
            item.Promotion = (2, 50);
            Assert.AreEqual(100, item.CalculatePriceGivenQuantity(4));
        }

        [Test]
        public void CalculatePriceGivenQuantityWhenPromotionAppliedOddNums()
        {
            var item = new FoodItem();
            item.Price = 50;
            item.Promotion = (2, 50);
            Assert.AreEqual(150, item.CalculatePriceGivenQuantity(5));
        }
    }
}
