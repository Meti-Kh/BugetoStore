using Microsoft.EntityFrameworkCore;
using MyStore.Application.Interfaces.Context;
using MyStore.Common.Dto;
using MyStore.Domain.Entities.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
namespace MyStore.Application.Services.Cart
{
    public interface ICartService
    {
        ResultDto AddToCart(long ProductID, Guid BrowserID);
        ResultDto RemoveFromCart(long ProductID, Guid BrowserID);
        ResultDto<CartDto> GetMyCart(long? UserID, Guid BrowserID);

        ResultDto Add(long ProductID);
        ResultDto LowOff(long ProductID);
    }


    public class CartService : ICartService
    {
        IDatabaseContext _context;
        public CartService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDto Add(long ProductID)
        {
            var product = _context.CartItams.Find(ProductID);
            product.Count++;
            _context.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true
            };
        }

        public ResultDto AddToCart(long ProductId, Guid BrowserId)
        {
            var cart = _context.Carts.Where(p => p.BrowserID == BrowserId && p.Finished == false).FirstOrDefault();
            if (cart == null)
            {
                MyStore.Domain.Entities.Cart.Cart newCart = new Domain.Entities.Cart.Cart()
                {
                    Finished = false,
                    BrowserID = BrowserId,
                };
                _context.Carts.Add(newCart);
                _context.SaveChanges();
                cart = newCart;
            }


            var product = _context.Products.Find(ProductId);

            var cartItem = _context.CartItams.Where(p => p.ProductID == ProductId && p.CartID == cart.ID).FirstOrDefault();
            if (cartItem != null)
            {
                cartItem.Count++;
            }
            else
            {
                CartItams newCartItem = new CartItams()
                {
                    Cart = cart,
                    Count = 1,
                    Price = product.Price,
                    Product = product,

                };
                _context.CartItams.Add(newCartItem);
                _context.SaveChanges();
            }

            return new ResultDto()
            {
                IsSuccess = true,
                Message = $"محصول  {product.Name} با موفقیت به سبد خرید شما اضافه شد ",
            };
        }

        public ResultDto<CartDto> GetMyCart(long? UserID, Guid BrowserID)
        {
            try
            {
                var cart = _context.Carts
                    .Include(p => p.CartItams)
                    .ThenInclude(p => p.Product)
                    .ThenInclude(p => p.ProductImages)
                    .Where(p => p.BrowserID == BrowserID && p.Finished == false)
                    .OrderByDescending(p => p.ID)
                    .FirstOrDefault();

                if (cart == null)
                {
                    return new ResultDto<CartDto>()
                    {
                        Data = new CartDto()
                        {
                            CartItems = new List<CartItemDto>()
                        },
                        IsSuccess = false,
                    };
                }

                if (UserID != null)
                {
                    var user = _context.Users.Find(UserID);
                    cart.User = user;
                    _context.SaveChanges();
                }



                return new ResultDto<CartDto>()
                {
                    Data = new CartDto()
                    {
                        ProductCount = cart.CartItams.Count(),
                        SumAmount = cart.CartItams.Sum(p => p.Price * p.Count),
                        CartID=cart.ID,
                        CartItems = cart.CartItams.Select(p => new CartItemDto
                        {
                            Count = p.Count,
                            Price = p.Price,
                            ProductName = p.Product.Name,
                            ID = p.ID,
                            Image = p.Product?.ProductImages?.FirstOrDefault()?.Src ?? "",
                        }).ToList(),
                    },
                    IsSuccess = true,
                };
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public ResultDto LowOff(long ProductID)
        {
            var product = _context.CartItams.Find(ProductID);
            product.Count--;
            _context.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true
            };
        }

        public ResultDto RemoveFromCart(long ProductID, Guid BrowserID)
        {
            var cartItem = _context.CartItams.Where(x => x.Cart.BrowserID == BrowserID).FirstOrDefault();
            if (cartItem != null)
            {
                cartItem.IsRemoved = true;
                cartItem.RemovedTime = DateTime.Now;
                _context.SaveChanges();
                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "محصول با موفقیت حذف شد"
                };

            }
            else
            {
                return new ResultDto { IsSuccess = false, Message = "محصول یافت نشد" };
            }

        }
    }



    public class CartDto
    {
        public long CartID { get; set; }
        public int ProductCount { get; set; }
        public double SumAmount { get; set; }
        public List<CartItemDto> CartItems { get; set; }
    }

    public class CartItemDto
    {
        public long ID { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public int Count { get; set; }
        public string ProductName { get; set; }

    }
}

