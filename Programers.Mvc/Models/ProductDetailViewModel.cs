using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Programers.Entities.Dtos;

namespace Programers.Mvc.Models
{
    public class ProductDetailViewModel
    {
        public ProductDto ProductDto { get; set; }
        public ProductDetailRightSideBarViewModel ProductDetailRightSideBarViewModel { get; set; }
    }
}
