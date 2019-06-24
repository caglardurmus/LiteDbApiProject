using MyProject.Business.Abstract;
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
        public void AddToCart(Cart cart, Product product, int count)
        {
            CartLine cartLine = cart.CartLines.FirstOrDefault(c => c.Product.Id == product.Id);
            if (cartLine != null)
            {
                cartLine.Quantity += count;
                return;
            }
            cart.CartLines.Add(new CartLine { Product = product, Quantity = count });
        }

        public List<CartLine> List(Cart cart)
        {
            return cart.CartLines;
        }

        public void RemoveFromCart(Cart cart, int productId)
        {
            cart.CartLines.Remove(cart.CartLines.FirstOrDefault(c => c.Product.Id == productId));
        }
    }
}
