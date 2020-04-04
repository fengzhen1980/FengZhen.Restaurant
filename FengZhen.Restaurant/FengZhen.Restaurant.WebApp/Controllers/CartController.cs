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
    public class CartController : Controller
    {
        private IFoodsRepository repository;
        private IOrderProcessor orderProcessor;

        public CartController(IFoodsRepository repo, IOrderProcessor proc)
        {
            repository = repo;
            orderProcessor = proc;
        }

        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                ReturnUrl = returnUrl,
                Cart = cart
            });
        }

        public RedirectToRouteResult AddToCart(Cart cart, int FoodId, string returnUrl)
        {
            Food food = repository.FoodsList.FirstOrDefault(p => p.FoodId == FoodId);
            if (food != null)
            {
                cart.AddItem(food, 1);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int foodId, string returnUrl)
        {
            Food food = repository.FoodsList.FirstOrDefault(p => p.FoodId == foodId);
            if (food != null)
            {
                cart.RemoveLine(food);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.ItemsInCart.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }
    }
}