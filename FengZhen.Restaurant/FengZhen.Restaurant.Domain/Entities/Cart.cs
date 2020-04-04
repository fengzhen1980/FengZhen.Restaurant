using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengZhen.Restaurant.Domain.Entities
{
    public class Cart
    {
        private List<ItemInCart> ItemCollection = new List<ItemInCart>();

        public void AddItem(Food food, int quantity)
        {
            ItemInCart item = ItemCollection.Where(p => p.Food.FoodId == food.FoodId).FirstOrDefault();

            if (item == null)
            {
                ItemCollection.Add(new ItemInCart
                {
                    Food = food,
                    Quantity = quantity
                }); 
            }
            else
            {
                item.Quantity += quantity;
            }
        }

        public void RemoveLine(Food food)
        {
            ItemCollection.RemoveAll(p => p.Food.FoodId == food.FoodId);
        }


        public decimal ComputeTotalValue()
        {
            return ItemCollection.Sum(e => e.Food.Price * e.Quantity);
        }

        public void Clear()
        {
            ItemCollection.Clear();
        }

        public IEnumerable<ItemInCart> ItemsInCart
        {
            get { return ItemCollection; }
        }
    }
}
