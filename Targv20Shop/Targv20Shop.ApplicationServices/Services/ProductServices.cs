using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Targv20Shop.Core.Domain;
using Targv20Shop.Core.ServiceInterface;
using Targv20Shop.Data;

namespace Targv20Shop.ApplicationServices.Services
{
    public class ProductServices : IProductService
    {
        private readonly Targv20ShopDbContext _context;

        public ProductServices
            (
                Targv20ShopDbContext context
            )
        {
            _context = context;
        }

        public async Task<Product> Delete(Guid id)
        {
            var productId = await _context.Product
                .FirstOrDefaultAsync(x => x.Id == id);

            _context.Product.Remove(productId);
            await _context.SaveChangesAsync();

            return productId;
        }

    }
}
