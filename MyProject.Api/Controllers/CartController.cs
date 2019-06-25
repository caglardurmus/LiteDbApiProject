using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyProject.Business.Abstract;
using MyProject.Entities;

namespace MyProject.Api.Controllers
{
    public class CartController : BaseController
    {
        private ICartService _cartService;
        private IProductService _productService;
        public CartController(
            ICartService cartService,
            IProductService productService)
        {
            _cartService = cartService;
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<Result> Get(int cartNumber)
        {
            try
            {
                var cart = _cartService.GetCart(cartNumber);

                if (cart == null)
                {
                    return this.ReturnResult(description: "Sepet Bulunamadı!", successful: false);
                }

                return this.ReturnResult("Sepetiniz:", cart);
            }
            catch (Exception ex)
            {
                return this.ReturnFailed(ex.Message);
            }

        }

        [HttpPost]
        public ActionResult<Result> AddToCart(int productId, int quantity, int? cartNumber)
        {
            try
            {
                var product = _productService.GetById(productId);
                if (product == null)
                {
                    return this.ReturnResult(description: "Ürün Bulunamadı!", successful: false);
                }

                if (cartNumber.HasValue)
                {
                    var cart = _cartService.GetCart(cartNumber.Value);

                    if (cart == null)
                    {
                        return this.ReturnResult(description: "Sepet Bulunamadı!", successful: false);
                    }

                    var productInCart = cart.FirstOrDefault(x => x.ProductId == productId);
                    if (productInCart == null)
                    {
                        if (quantity > product.Stock)
                        {
                            return this.ReturnResult(description: "Ürün Stoğu yetersiz!", successful: false);
                        }

                        var productWillBeAdd = new Cart()
                        {
                            CartNumber = cartNumber.Value,
                            ProductId = productId,
                            Quantity = quantity
                        };
                        _cartService.AddToCart(productWillBeAdd);
                    }
                    else
                    {
                        if (quantity + productInCart.Quantity > product.Stock)
                        {
                            return this.ReturnResult(description: "Ürün Stoğu yetersiz!", successful: false);
                        }

                        productInCart.Quantity += quantity;
                        _cartService.UpdateCart(productInCart);
                    }

                    return this.ReturnResult("Ürün Sepete Eklendi.", cart);
                }
                else
                {
                    if (quantity > product.Stock)
                    {
                        return this.ReturnResult(description: "Ürün Stoğu yetersiz!", successful: false);
                    }

                    var productWillBeAdd = new Cart()
                    {
                        ProductId = productId,
                        Quantity = quantity
                    };

                    _cartService.AddToCart(productWillBeAdd);
                    productWillBeAdd.CartNumber = productWillBeAdd.Id;
                    _cartService.UpdateCart(productWillBeAdd);

                    return this.ReturnResult("Ürün Sepete Eklendi.", productWillBeAdd);
                }

            }
            catch (Exception ex)
            {
                return this.ReturnFailed(ex.Message);
            }
        }
    }
}