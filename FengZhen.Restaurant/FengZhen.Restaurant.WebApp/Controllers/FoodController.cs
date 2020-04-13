using FengZhen.Restaurant.Domain.Abstract;
using FengZhen.Restaurant.Domain.Entities;
using FengZhen.Restaurant.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FengZhen.Restaurant.WebApp.Controllers
{
    public class FoodController : Controller
    {
        public const int PageSize = 5;

        public IFoodsRepository FoodsRepository { get; set; }

        //// GET: Food
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ViewResult List(string category, int page = 1)
        {
            FoodsListViewModel model = new FoodsListViewModel
            {
                currentCategory = category,

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = FoodsRepository.FoodsList.Where(f => category == null || f.Category == category).Count()
                },

                Foods = FoodsRepository.FoodsList
                .Where(f => category == null || f.Category == category)
                .OrderBy(f => f.FoodId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
            };

            return View(model);
        }

        public FileContentResult GetImage(int foodId)
        {
            Food foodItem = FoodsRepository.FoodsList.FirstOrDefault(x => x.FoodId == foodId);

            if (foodItem != null)
            {
                return File(foodItem.ImageData, foodItem.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}