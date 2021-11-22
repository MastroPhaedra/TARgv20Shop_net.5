using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Targv20Shop.Core.ServiceInterface;
using Targv20Shop.Data;
using Targv20Shop.Models.Product;

namespace Targv20Shop.Controllers
{
    public class ProductController : Controller
    {
        private readonly Targv20ShopDbContext _context;
        private readonly IProductService _productService;

        public ProductController
            (
                Targv20ShopDbContext context,
                IProductService productService
            )
        {
            _context = context;
            _productService = productService;
        }


        public IActionResult Index()
        {
            var result = _context.Product
                .Select(x => new ProductListViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Ammount = x.Ammount,
                    Description = x.Description
                });

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var product = await _productService.Delete(id);



            return RedirectToAction(nameof(Index), null);
        }

    }
}
