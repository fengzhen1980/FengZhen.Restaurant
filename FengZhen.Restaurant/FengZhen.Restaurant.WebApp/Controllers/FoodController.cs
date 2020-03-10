using FengZhen.Restaurant.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FengZhen.Restaurant.WebApp.Controllers
{
    public class FoodController : Controller
    {
        public IFoodsRepository FoodsRepository { get; set; }

        //// GET: Food
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ViewResult List()
        {
            return View(FoodsRepository.FoodsList);
        }
    }
}