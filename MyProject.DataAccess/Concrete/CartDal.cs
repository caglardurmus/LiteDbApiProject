using Core.LiteDb;
using MyProject.DataAccess.Abstract;
using MyProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.DataAccess.Concrete
{
    public class CartDal : LiteDbRepository<Cart>, ICartDal
    {
    }
}
