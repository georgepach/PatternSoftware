using PSDLab_Project.Models; // *** HANYA INI UNTUK MODELS ***
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PSDLab_Project.Repositories
{
    public class CartRepository
    {
        public static List<Cart> GetCartItemsByUserId(int userId)
        {
            using (var db = new JawelsDBEntities1())
            {
                return db.Carts
                         .Include(c => c.Jewel)
                         .Include(c => c.Jewel.Brand)
                         .Where(c => c.UserID == userId)
                         .ToList();
            }
        }

        public static bool UpdateCartItemQuantity(int cartId, int quantity)
        {
            using (var db = new JawelsDBEntities1())
            {
                var item = db.Carts.Find(cartId);
                if (item != null)
                {
                    item.Quantity = quantity;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public static bool RemoveCartItem(int cartId)
        {
            using (var db = new JawelsDBEntities1())
            {
                var item = db.Carts.Find(cartId);
                if (item != null)
                {
                    db.Carts.Remove(item);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public static bool ClearCart(int userId)
        {
            using (var db = new JawelsDBEntities1())
            {
                var items = db.Carts.Where(c => c.UserID == userId).ToList();
                if (items.Any())
                {
                    db.Carts.RemoveRange(items);
                    db.SaveChanges();
                }
                return true;
            }
        }

        // *** KEMBALIKAN CHECKOUT METHOD (TANPA ALIAS) ***
        public static bool Checkout(int userId, string paymentMethod)
        {
            using (var db = new JawelsDBEntities1())
            {
                var cartItems = db.Carts
                                  .Include(c => c.Jewel)
                                  .Where(c => c.UserID == userId)
                                  .ToList();

                if (!cartItems.Any())
                {
                    return false;
                }

                // Gunakan nama class biasa: TransactionHeader
                var header = new TransactionHeader
                {
                    UserID = userId,
                    TransactionDate = DateTime.Now,
                    PaymentMethod = paymentMethod,
                    Status = "Payment Pending" // Gunakan 'Status'
                };

                foreach (var cartItem in cartItems)
                {
                    // Gunakan nama class biasa: TransactionDetail
                    header.TransactionDetails.Add(new TransactionDetail
                    {
                        JewelID = cartItem.JewelID,
                        Quantity = cartItem.Quantity
                    });
                }

                db.TransactionHeaders.Add(header);
                db.Carts.RemoveRange(cartItems);
                db.SaveChanges();
                return true;
            }
        }
    }
}