using FengZhen.Restaurant.Domain.Concrete;
using FengZhen.Restaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengZhen.Restaurant.DebugConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new EFDbContext())
            {
                for (int i = 0; i < 10; i++)
                {
                    var food = new Food()
                    {
                        Name = $"name-{i.ToString("000")}",
                        Price = 10.49M,
                        Description = $"des{i.ToString("00")}",
                        Category = "C1"
                    };
                    ctx.Foods.Add(food);
                }
               
                ctx.SaveChanges();
            }

            Console.WriteLine("Done.");
            Console.ReadLine();
        }
    }
}
