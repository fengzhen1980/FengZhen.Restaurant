using FengZhen.Restaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengZhen.Restaurant.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Food> Foods { get; set; }
    }
}
