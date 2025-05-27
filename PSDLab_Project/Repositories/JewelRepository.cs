using PSDLab_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PSDLab_Project.Repositories
{
    public class JewelRepository
    {
        // ... (Keep GetAllJewels, GetJewelById, GetAllCategories, GetAllBrands, AddJewel) ...
        public static List<Jewel> GetAllJewels()
        {
            using (var db = new JawelsDBEntities1())
            {
                return db.Jewels.ToList();
            }
        }

        public static Jewel GetJewelById(int jewelId)
        {
            using (var db = new JawelsDBEntities1())
            {
                return db.Jewels
                         .Include(j => j.Brand)
                         .Include(j => j.Category)
                         .FirstOrDefault(j => j.JewelID == jewelId);
            }
        }

        public static List<Category> GetAllCategories()
        {
            using (var db = new JawelsDBEntities1())
            {
                return db.Categories.ToList();
            }
        }

        public static List<Brand> GetAllBrands()
        {
            using (var db = new JawelsDBEntities1())
            {
                return db.Brands.ToList();
            }
        }

        public static void AddJewel(Jewel jewel)
        {
            using (var db = new JawelsDBEntities1())
            {
                db.Jewels.Add(jewel);
                db.SaveChanges();
            }
        }

        // *** ADD THIS METHOD ***
        public static bool UpdateJewel(int jewelId, string name, int categoryId, int brandId, decimal price, int releaseYear)
        {
            using (var db = new JawelsDBEntities1())
            {
                var existingJewel = db.Jewels.Find(jewelId);
                if (existingJewel == null)
                {
                    return false; // Jewel not found
                }

                // Update properties
                existingJewel.JewelName = name;
                existingJewel.CategoryID = categoryId;
                existingJewel.BrandID = brandId;
                existingJewel.Price = price;
                existingJewel.ReleaseYear = releaseYear;

                db.SaveChanges();
                return true; // Success
            }
        }
        // *** END OF ADDED METHOD ***
    }
}