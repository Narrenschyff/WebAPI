using CheckoutSystem.Models;
using CheckoutSystem.Services;
using Moq;
using NUnit.Framework;

namespace CheckoutSystem.Tests
{
    [TestFixture]
    public class CheckoutTests
    {
        private ICheckout _checkout;

        [SetUp]
        public void Setup()
        {
            var scannerMock = new Mock<IScanner>();
            scannerMock.Setup(x => x.GetScannedItem("itemCodeA"))
                .Returns(new FoodItem() { Sku = "A" });
            _checkout = new Checkout(scannerMock.Object);
        }

        [Test]
        public void ScanItemReturnsSku()
        {
            Assert.AreEqual("A", _checkout.ScanItem("itemCodeA"));
        }
    }
}
