using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Programers.Entities.Concrete;
using Programers.Entities.Dtos;
using Programers.Mvc.Areas.Admin.Models;

namespace Programers.Mvc.AutoMapper.Profiles
{
    public class ViewModelsProfile:Profile
    {
        public ViewModelsProfile()
        {
            CreateMap<ProductAddViewModel, ProductAddDto>();
            CreateMap<ProductUpdateDto, ProductUpdateViewModel>().ReverseMap();
            CreateMap<ProductRightSideBarWidgetOptions, ProductRightSideBarWidgetOptionsViewModel>();
        }
    }
}
