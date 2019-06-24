using MyProject.Business.Abstract;
using MyProject.DataAccess.Abstract;
using MyProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Business.Concrete
{
    public class ProductService : IProductService
    {
        private IProductDal _productDal;
        public ProductService(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void AddDefaultProducts()
        {
            _productDal.AddDefaultProducts();
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }
        public Product GetById(int id)
        {
            return _productDal.GetEntityById(id);
        }
    }
}
