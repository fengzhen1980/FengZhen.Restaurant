using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengZhen.Restaurant.Domain.Entities
{
    public class ItemInCart
    {
        public Food Food { set; get; }
        public int Quantity { set; get; }
    }
}
