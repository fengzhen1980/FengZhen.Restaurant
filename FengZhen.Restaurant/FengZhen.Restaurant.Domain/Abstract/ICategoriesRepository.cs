using FengZhen.Restaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengZhen.Restaurant.Domain.Abstract
{
    public interface ICategoriesRepository
    {
        IEnumerable<Category> CategoriesList { get; }
    }
}
