using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using NToastNotify;
using Programers.Entities.Concrete;
using Programers.Mvc.Areas.Admin.Models;
using Programers.Services.Abstract;
using Programers.Shared.Utilities.Helpers.Abstract;

namespace Programers.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class OptionsController : Controller
    {
        private readonly AboutUsPageInfo _aboutUsPageInfo;
        private readonly IWritableOptions<AboutUsPageInfo> _aboutUsPageInfoWriter;
        private readonly IToastNotification _toastNotification;
        private readonly WebsiteInfo _websiteInfo;
        private readonly IWritableOptions<WebsiteInfo> _websiteInfoWriter;
        private readonly SmtpSettings _smtpSettings;
        private readonly IWritableOptions<SmtpSettings> _smtpSettingsWriter;
        private readonly ProductRightSideBarWidgetOptions _productRightSideBarWidgetOptions;
        private readonly IWritableOptions<ProductRightSideBarWidgetOptions> _productRightSideBarWidgetOptionsWriter;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public OptionsController(IOptionsSnapshot<AboutUsPageInfo> aboutUsPageInfo,
            IWritableOptions<AboutUsPageInfo> aboutUsPageInfoWriter,
            IToastNotification toastNotification, IOptionsSnapshot<WebsiteInfo> websiteInfo,
            IWritableOptions<WebsiteInfo> websiteInfoWriter,
            IOptionsSnapshot<SmtpSettings> smtpSettings, IWritableOptions<SmtpSettings> smtpSettingsWriter, 
            IOptionsSnapshot<ProductRightSideBarWidgetOptions> productRightSideBarWidgetOptions,
            IWritableOptions<ProductRightSideBarWidgetOptions> productRightSideBarWidgetOptionsWriter,
            ICategoryService categoryService, IMapper mapper)
        {
            _aboutUsPageInfoWriter = aboutUsPageInfoWriter;
            _toastNotification = toastNotification;
            _websiteInfoWriter = websiteInfoWriter;
            _smtpSettingsWriter = smtpSettingsWriter;
            _productRightSideBarWidgetOptionsWriter = productRightSideBarWidgetOptionsWriter;
            _categoryService = categoryService;
            _mapper = mapper;
            _productRightSideBarWidgetOptions = productRightSideBarWidgetOptions.Value;
            _smtpSettings = smtpSettings.Value;
            _websiteInfo = websiteInfo.Value;
            _aboutUsPageInfo = aboutUsPageInfo.Value;
        }

        [HttpGet]
        public IActionResult About()
        {
            return View(_aboutUsPageInfo);
        }
        [HttpPost]
        public IActionResult About(AboutUsPageInfo aboutUsPageInfo)
        {
            if (ModelState.IsValid)
            {
                _aboutUsPageInfoWriter.Update(x =>
                {
                    x.Header = aboutUsPageInfo.Header;
                    x.Content = aboutUsPageInfo.Content;
                    x.SeoAuthor = aboutUsPageInfo.SeoAuthor;
                    x.SeoDescription = aboutUsPageInfo.SeoDescription;
                    x.SeoTags = aboutUsPageInfo.SeoTags;
                });
                _toastNotification.AddSuccessToastMessage("Hakkımızda Sayfa İçerikleri başarıyla güncellenmiştir.",new ToastrOptions
                {
                    Title = "Başarılı İşlem!"
                });
                return View(aboutUsPageInfo);

            }
            return View(aboutUsPageInfo);
        }
        [Authorize(Roles = "SuperAdmin,AdminArea.Home.Read")]
        [HttpGet]
        public IActionResult GeneralSettings()
        {
            return View(_websiteInfo);
        }
        [Authorize(Roles = "SuperAdmin,AdminArea.Home.Read")]
        [HttpPost]
        public IActionResult GeneralSettings(WebsiteInfo websiteInfo)
        {
            if (ModelState.IsValid)
            {
                _websiteInfoWriter.Update(x =>
                {
                    x.Title = websiteInfo.Title;
                    x.MenuTitle = websiteInfo.MenuTitle;
                    x.SeoAuthor = websiteInfo.SeoAuthor;
                    x.SeoDescription = websiteInfo.SeoDescription;
                    x.SeoTags = websiteInfo.SeoTags;
                });
                _toastNotification.AddSuccessToastMessage("Sitenizin genel ayarları başarıyla güncellenmiştir.", new ToastrOptions
                {
                    Title = "Başarılı İşlem!"
                });
                return View(websiteInfo);

            }
            return View(websiteInfo);
        }
        [Authorize(Roles = "SuperAdmin,AdminArea.Home.Read")]
        [HttpGet]
        public IActionResult EmailSettings()
        {
            return View(_smtpSettings);
        }
        [Authorize(Roles = "SuperAdmin,AdminArea.Home.Read")]
        [HttpPost]
        public IActionResult EmailSettings(SmtpSettings smtpSettings)
        {
            if (ModelState.IsValid)
            {
                _smtpSettingsWriter.Update(x =>
                {
                    x.Server = smtpSettings.Server;
                    x.Port = smtpSettings.Port;
                    x.SenderName = smtpSettings.SenderName;
                    x.SenderEmail = smtpSettings.SenderEmail;
                    x.Username = smtpSettings.Username;
                    x.Password = smtpSettings.Password;
                });
                _toastNotification.AddSuccessToastMessage("Sitenizin e-posta ayarları başarıyla güncellenmiştir.", new ToastrOptions
                {
                    Title = "Başarılı İşlem!"
                });
                return View(smtpSettings);

            }
            return View(smtpSettings);
        }
        [Authorize(Roles = "SuperAdmin,AdminArea.Home.Read")]
        [HttpGet]
        public async Task<IActionResult> ProductRightSideBarWidgetSettings()
        {
            var categoriesResult = await _categoryService.GetAllByNonDeletedAndActiveAsync();
            var productRightSideBarWidgetOptionsViewModel =
                _mapper.Map<ProductRightSideBarWidgetOptionsViewModel>(_productRightSideBarWidgetOptions);
            productRightSideBarWidgetOptionsViewModel.Categories = categoriesResult.Data.Categories;
            return View(productRightSideBarWidgetOptionsViewModel);
        }
        [Authorize(Roles = "SuperAdmin,AdminArea.Home.Read")]
        [HttpPost]
        public async Task<IActionResult> ProductRightSideBarWidgetSettings(ProductRightSideBarWidgetOptionsViewModel productRightSideBarWidgetOptionsViewModel)
        {
            var categoriesResult = await _categoryService.GetAllByNonDeletedAndActiveAsync();
            productRightSideBarWidgetOptionsViewModel.Categories = categoriesResult.Data.Categories;
            if (ModelState.IsValid)
            {
                _productRightSideBarWidgetOptionsWriter.Update(x =>
                {
                    x.Header = productRightSideBarWidgetOptionsViewModel.Header;
                    x.TakeSize = productRightSideBarWidgetOptionsViewModel.TakeSize;
                    x.CategoryId = productRightSideBarWidgetOptionsViewModel.CategoryId;
                    x.FilterBy = productRightSideBarWidgetOptionsViewModel.FilterBy;
                    x.OrderBy = productRightSideBarWidgetOptionsViewModel.OrderBy;
                    x.IsAscending = productRightSideBarWidgetOptionsViewModel.IsAscending;
                    x.StartAt = productRightSideBarWidgetOptionsViewModel.StartAt;
                    x.EndAt = productRightSideBarWidgetOptionsViewModel.EndAt;
                    x.MaxViewCount = productRightSideBarWidgetOptionsViewModel.MaxViewCount;
                    x.MinViewCount = productRightSideBarWidgetOptionsViewModel.MinViewCount;
                    x.MaxCommentCount = productRightSideBarWidgetOptionsViewModel.MaxCommentCount;
                    x.MinCommentCount = productRightSideBarWidgetOptionsViewModel.MinCommentCount;
                });
                _toastNotification.AddSuccessToastMessage("Ürün sayfalarınızın widget ayarları başarıyla güncellenmiştir.", new ToastrOptions
                {
                    Title = "Başarılı İşlem!"
                });
                return View(productRightSideBarWidgetOptionsViewModel);

            }
            return View(productRightSideBarWidgetOptionsViewModel);
        }
    }
}
