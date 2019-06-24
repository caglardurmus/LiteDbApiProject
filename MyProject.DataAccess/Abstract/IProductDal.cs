using Core.DataAccess;
using MyProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.DataAccess.Abstract
{
    public interface IProductDal : IGenericRepository<Product>
    {
        void AddDefaultProducts();
    }
}
