using PSDLab_Project.Models;
using PSDLab_Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDLab_Project.Handlers
{
    public class JewelHandler
    {
        // ... (Keep GetAllJewels, GetJewelById, GetAllCategories, GetAllBrands, AddJewel) ...
        public static List<Jewel> GetAllJewels()
        {
            return JewelRepository.GetAllJewels();
        }

        public static Jewel GetJewelById(int jewelId)
        {
            return JewelRepository.GetJewelById(jewelId);
        }

        public static List<Category> GetAllCategories()
        {
            return JewelRepository.GetAllCategories();
        }

        public static List<Brand> GetAllBrands()
        {
            return JewelRepository.GetAllBrands();
        }

        public static string AddJewel(string name, int categoryId, int brandId, decimal price, int releaseYear)
        {
            if (name.Length < 3 || name.Length > 25) return "Jewel Name must be between 3 to 25 characters.";
            if (price <= 25) return "Price must be more than $25.";
            if (releaseYear >= DateTime.Now.Year) return "Release Year must be less than the current year.";

            var newJewel = new Jewel
            {
                JewelName = name,
                CategoryID = categoryId,
                BrandID = brandId,
                Price = price,
                ReleaseYear = releaseYear
            };

            try
            {
                JewelRepository.AddJewel(newJewel);
                return null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Add Jewel Error: {ex.Message}");
                return "An error occurred while adding the jewel.";
            }
        }

        // *** ADD THIS METHOD ***
        public static string UpdateJewel(int jewelId, string name, int categoryId, int brandId, decimal price, int releaseYear)
        {
            // Perform the same validation as AddJewel
            if (name.Length < 3 || name.Length > 25) return "Jewel Name must be between 3 to 25 characters.";
            if (price <= 25) return "Price must be more than $25.";
            if (releaseYear >= DateTime.Now.Year) return "Release Year must be less than the current year.";

            try
            {
                if (JewelRepository.UpdateJewel(jewelId, name, categoryId, brandId, price, releaseYear))
                {
                    return null; // Success
                }
                else
                {
                    return "Jewel not found for update.";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Update Jewel Error: {ex.Message}");
                return "An error occurred while updating the jewel.";
            }
        }
        // *** END OF ADDED METHOD ***
    }
}