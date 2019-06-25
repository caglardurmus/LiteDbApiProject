
using MyProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Business.Abstract
{
    public interface ICartService
    {
        List<Cart> GetCart(int cartId);
        void UpdateCart(Cart cart);
        void AddToCart(Cart cart);
    }
}
