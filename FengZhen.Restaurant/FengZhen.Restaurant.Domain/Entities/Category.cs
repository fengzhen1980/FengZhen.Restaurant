using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengZhen.Restaurant.Domain.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }

    }
}
