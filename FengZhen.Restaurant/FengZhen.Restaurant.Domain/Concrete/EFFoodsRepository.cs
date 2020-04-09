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

        public void SaveFood(Food food)
        {
            if (food.FoodId == 0)
            {
                context.Foods.Add(food);
            }
            else
            {
                Food dbEntity = context.Foods.Find(food.FoodId);
                if (dbEntity != null)
                {
                    dbEntity.Name = food.Name;
                    dbEntity.Description = food.Description;
                    dbEntity.Category = food.Category;
                    dbEntity.Price = food.Price;
                }
            }
            context.SaveChanges();
        }

        public Food DeleteFood(int foodId)
        {
            Food food = context.Foods.Find(foodId);
            if (food != null)
            {
                context.Foods.Remove(food);
                context.SaveChanges();
            }
            return food;
        }
    }
}
