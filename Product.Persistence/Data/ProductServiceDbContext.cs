using Microsoft.EntityFrameworkCore;
using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Persistence.Data
{
    public class ProductServiceDbContext : DbContext
    {
        public ProductServiceDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ProductItem> ProductItems { get; set; }
    }
}
