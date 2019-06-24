using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyProject.Business.Abstract;
using MyProject.Entities;

namespace MyProject.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        private IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<object> Get()
        {
            try
            {
                var list = _productService.GetAll();
                if (list == null)
                {
                    return this.ReturnResult("Lütfen default ürün listesini ekleyiniz.", false);
                }

                return list;
            }
            catch (Exception)
            {
                return this.ReturnFailed();
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
            catch (Exception)
            {
                return this.ReturnFailed();
            }

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
