using FengZhen.Restaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FengZhen.Restaurant.WebApp.Models
{
    public class FoodsListViewModel
    {
        public IEnumerable<Food> Foods { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string currentCategory { get; set; }
    }
}