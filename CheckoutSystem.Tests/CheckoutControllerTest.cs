using System.Collections.Generic;
using System.Net.Http;
using CheckoutSystem.Controllers;
using CheckoutSystem.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class CheckoutControllerTests
    {
        private CheckoutController _controller;

        [SetUp]
        public void Setup()
        {
            _controller = new CheckoutController();
        }

        [Test]
        public void GetItemReturnsItem()
        {
            string sku = "A";
            var result = _controller.GetItem(sku);

            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var item = okResult.Value.Should().BeAssignableTo<IItem>().Subject;

            Assert.AreEqual("A", item.Sku);
            Assert.AreEqual("pineapple", item.Name);
            Assert.AreEqual(50, item.Price);
        }

        [Test]
        public void GetTotalPriceReturnsDouble()
        {
            var result = _controller.GetTotalPrice();
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            Assert.AreEqual(0, okResult.Value);           
        }

        [Test]
        public void GetTotalDiscountReturnsDouble()
        {
            var result = _controller.GetTotalDiscount();
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            Assert.AreEqual(0, okResult.Value);
        }

        [Test]
        public void GetAllItemsReturnsItems()
        {
            var result = _controller.GetAllItems();
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var items = okResult.Value.Should().BeAssignableTo<IList<IItem>>().Subject;
            Assert.AreEqual(0, items.Count);
        }

        [Test]
        public void ScanItemReturnsCreatedItem()
        {
            var result = _controller.ScanItem("barcode");
            var okResult = result.Should().BeOfType<CreatedAtActionResult>().Subject;
            var item = okResult.Value.Should().BeAssignableTo<object>().Subject;
            item.ShouldBeEquivalentTo(new {sku="A"});
        }

        [Test]
        public void DeleteItemDeletesItem()
        {
            string sku = "A";
            var result = _controller.DeleteItem(sku);
            var okResult = result.Should().BeOfType<OkResult>().Subject;
        }

    }
}