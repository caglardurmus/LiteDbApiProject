using MyProject.Business.Abstract;
using MyProject.DataAccess.Abstract;
using MyProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyProject.Business.Concrete
{
    /// <summary>
    /// Sepete ekleme,silme ve listeme işlemlerini yapan servis.
    /// </summary>
    public class CartService : ICartService
    {
        private ICartDal _cartDal;
        public CartService(ICartDal cartDal)
        {
            _cartDal = cartDal;
        }
        public void AddToCart(Cart cart)
        {
            _cartDal.Insert(cart);
        }

        public List<Cart> GetCart(int cartId)
        {
            var cart = _cartDal.GetAll(x => x.CartNumber == cartId);

            if (cart.Count == 0)
            {
                return null;
            }

            return cart;
        }

        public void UpdateCart(Cart cart)
        {
            _cartDal.Update(cart);
        }
    }
}
