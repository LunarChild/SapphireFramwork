using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sapphire.Core.Model.Cms;
using Sapphire.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sapphire.Web.Pages.SapphireAdmin.Cms
{
    public class ProductModifyModel : PageModel
    {
        private readonly ICmsProductService _productService;
        public ProductModifyModel(ICmsProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public CmsProduct Product { get; set; }


        public void OnGet(int id = 0, int column = 0)
        {
            Product = _productService.GetModelAsync(m => m.Id == id).Result.data;
            if (Product.Id == 0 && column != 0)
            {
                Product.ParentId = column;
            }

        }
    }
}
