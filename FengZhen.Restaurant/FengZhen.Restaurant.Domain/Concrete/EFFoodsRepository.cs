using FengZhen.Restaurant.Domain.Abstract;
using FengZhen.Restaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengZhen.Restaurant.Domain.Concrete
{
    public class EFFoodsRepository : IFoodsRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Food> FoodsList
        {
            get { return context.Foods; }
        }
    }
}
