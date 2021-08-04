using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Programers.Entities.Concrete;
using Programers.Entities.Dtos;

namespace Programers.Mvc.Areas.Admin.Models
{
    public class DashboardViewModel
    {
        public int CategoriesCount { get; set; }
        public int ProductsCount { get; set; }
        public int CommentsCount { get; set; }
        public int UsersCount { get; set; }
        public ProductListDto Products { get; set; }
    }
}
