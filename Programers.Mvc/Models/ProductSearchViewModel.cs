using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Programers.Entities.Dtos;

namespace Programers.Mvc.Models
{
    public class ProductSearchViewModel
    {
        public ProductListDto ProductListDto { get; set; }
        public string Keyword { get; set; }
    }
}
