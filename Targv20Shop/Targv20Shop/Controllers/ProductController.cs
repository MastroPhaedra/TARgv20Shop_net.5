using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Targv20Shop.Core.Dtos;
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
            if (product == null)
            {
                RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), product);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ProductViewModel model = new ProductViewModel();

            return View("Edit", model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductViewModel model)
        {
            var dto = new ProductDto()
            {
                Id = model.Id,
                Description = model.Description,
                Name = model.Name,
                Amount = model.Amount,
                Price = model.Price,
                ModifiedAt = model.ModifiedAt,
                CreatedAt = model.CreatedAt
            };

            var result = await _productService.Add(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Index");
        }

    }
}
