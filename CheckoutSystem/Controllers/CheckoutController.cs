using System;
using System.Collections.Generic;
using CheckoutSystem.Models;
using CheckoutSystem.Repositories;
using CheckoutSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CheckoutSystem.Controllers
{
    [Route("api/[controller]")]
    public class CheckoutController : Controller
    {
        ICheckoutRepository _checkoutRepo;
        IItemsRepository _itemsRepo;
        IScanner _scanner;

        public CheckoutController(ICheckoutRepository checkoutRepo, IItemsRepository itemsRepo){
            _checkoutRepo = checkoutRepo;
            _itemsRepo = itemsRepo;
            _scanner = new Scanner(itemsRepo);
        }

        [HttpGet("[action]")]
        public IActionResult GetAllItems()
        {
            var sessionId = (HttpContext == null)
                ? new Guid().ToString()
                : HttpContext.Session.Id;

            var checkout = _checkoutRepo.GetOrAddCheckout(sessionId, new Checkout(_scanner));
            return Ok(checkout.GetAllItems());
        }

        [HttpGet("[action]")]
        public IActionResult GetTotalPrice()
        {
            var sessionId = (HttpContext == null)
                ? new Guid().ToString()
                : HttpContext.Session.Id;

            var checkout = _checkoutRepo.GetOrAddCheckout(sessionId, new Checkout(_scanner));
            return Ok(checkout.GetTotalPrice());
        }

        // GET api/checkout/A
        [HttpGet("{id}")]
        public IActionResult GetItem(string sku)
        {
            return Ok(_itemsRepo.GetItem(sku));
        }

        // POST api/checkout
        [HttpPost]
        public IActionResult ScanItem([FromBody]string itemCode)
        {
            var sessionId = (HttpContext == null) 
                ? new Guid().ToString() 
                : HttpContext.Session.Id;
            
            var checkout = _checkoutRepo.GetOrAddCheckout(sessionId, new Checkout(_scanner));
            var scannedItem  = checkout.ScanItem(itemCode);
            return CreatedAtAction(nameof(GetItem), new { sku = scannedItem });
        }

        // DELETE api/checkout/5
        [HttpDelete("{id}")]
        public IActionResult DeleteItem(string sku)
        {
            return Ok(); //TODO
        }
    }
}
