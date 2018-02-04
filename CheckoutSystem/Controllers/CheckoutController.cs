using System;
using System.Collections.Generic;
using CheckoutSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace CheckoutSystem.Controllers
{
    [Route("api/[controller]")]
    public class CheckoutController : Controller
    {
        [HttpGet("[action]")]
        public IActionResult GetAllItems()
        {
            return Ok(new Item[] {});
        }

        [HttpGet("[action]")]
        public IActionResult GetTotalPrice()
        {
            return Ok(0);
        }

        [HttpGet("[action]")]
        public IActionResult GetTotalDiscount()
        {
            return Ok(0);
        }

        // GET api/checkout/A
        [HttpGet("{id}")]
        public IActionResult GetItem(string sku)
        {
            var item = new FoodItem();
            item.Name = "pineapple";
            item.Sku = "A";
            item.Price = 50;
            return Ok(item);
        }

        // POST api/checkout
        [HttpPost]
        public IActionResult ScanItem([FromBody]string itemCode)
        {
            // add to the checkout
            return CreatedAtAction(nameof(GetItem), new { sku = "A" });
        }

        // DELETE api/checkout/5
        [HttpDelete("{id}")]
        public IActionResult DeleteItem(string sku)
        {
            return Ok();
        }
    }
}
