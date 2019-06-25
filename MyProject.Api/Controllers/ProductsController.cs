using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyProject.Business.Abstract;
using MyProject.Entities;

namespace MyProject.Api.Controllers
{
    public class ProductsController : BaseController
    {
        private IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        
        [HttpGet]
        public ActionResult<Result> GetAllProducts()
        {
            try
            {
                var list = _productService.GetAll();
                if (list == null)
                {
                    return this.ReturnResult("Lütfen default ürün listesini ekleyiniz.", false);
                }

                return this.ReturnResult("Ürün Listesi", list);
            }
            catch (Exception ex)
            {
                return this.ReturnFailed(ex.Message);
            }

        }

        [HttpGet]
        public ActionResult<Result> AddDefaultProducts()
        {
            try
            {
                _productService.AddDefaultProducts();

                return this.ReturnResult("Default ürünler başarıyla oluşturuldu!");
            }
            catch (Exception ex)
            {
                return this.ReturnFailed(ex.Message);
            }

        }
    }
}
