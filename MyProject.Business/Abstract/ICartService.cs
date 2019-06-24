
using MyProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Business.Abstract
{
    public interface ICartService
    {
        void AddToCart(Cart cart, Product product,int count);
        void RemoveFromCart(Cart cart, int productId);
        List<CartLine> List(Cart cart);
    }
}
