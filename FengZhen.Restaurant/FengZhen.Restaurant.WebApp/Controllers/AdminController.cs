using FengZhen.Restaurant.Domain.Abstract;
using FengZhen.Restaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FengZhen.Restaurant.WebApp.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IFoodsRepository repository;

        public AdminController(IFoodsRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.FoodsList);
        }

        public ViewResult Edit(int foodId)
        {
            Food food = repository.FoodsList
            .FirstOrDefault(p => p.FoodId == foodId);
            return View(food);
        }

        [HttpPost]
        public ActionResult Edit(Food food)
        {
            if (ModelState.IsValid)
            {
                repository.SaveFood(food);
                TempData["message"] = string.Format("{0} has been saved.", food.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(food);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Food());
        }

        [HttpPost]
        public ActionResult Delete(int foodId)
        {
            Food food = repository.DeleteFood(foodId);
            if(food !=null)
            {
                TempData["message"] = string.Format("{0} has been deleted.", food.Name);
            }
            return RedirectToAction("Index");
        }

    }
}