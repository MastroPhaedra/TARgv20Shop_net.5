using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Targv20Shop.Data
{
    public class Targv20ShopDbContext : DbContext
    {
        public Targv20ShopDbContext(DbContextOptions<Targv20ShopDbContext> options)
            : base(options) { }

    }
}
