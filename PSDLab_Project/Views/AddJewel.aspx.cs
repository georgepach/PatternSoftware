using PSDLab_Project.Models;
using PSDLab_Project.Handlers;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSDLab_Project.Views
{
    public partial class AddJewel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Ensure user is an Admin
            User user = Session["user"] as User;
            if (user == null || user.Role != "Admin")
            {
                Response.Redirect("~/Views/HomePage.aspx"); // Or LoginPage
                return;
            }

            if (!IsPostBack)
            {
                LoadDropdowns();
            }
        }

        private void LoadDropdowns()
        {
            // Load Categories
            ddlCategory.DataSource = JewelHandler.GetAllCategories();
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("-- Select Category --", ""));

            // Load Brands
            ddlBrand.DataSource = JewelHandler.GetAllBrands();
            ddlBrand.DataBind();
            ddlBrand.Items.Insert(0, new ListItem("-- Select Brand --", ""));
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/HomePage.aspx");
        }

        protected void btnAddJewel_Click(object sender, EventArgs e)
        {
            string name = txtJewelName.Text.Trim();
            string categoryIdStr = ddlCategory.SelectedValue;
            string brandIdStr = ddlBrand.SelectedValue;
            string priceStr = txtPrice.Text.Trim();
            string yearStr = txtReleaseYear.Text.Trim();

            int categoryId, brandId, releaseYear;
            decimal price;

            // --- Basic Client-Side Validation (More robust in Handler) ---
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(categoryIdStr) ||
                string.IsNullOrEmpty(brandIdStr) || string.IsNullOrEmpty(priceStr) ||
                string.IsNullOrEmpty(yearStr))
            {
                lblError.Text = "All fields must be filled.";
                return;
            }

            if (!int.TryParse(categoryIdStr, out categoryId))
            {
                lblError.Text = "Please select a valid category.";
                return;
            }

            if (!int.TryParse(brandIdStr, out brandId))
            {
                lblError.Text = "Please select a valid brand.";
                return;
            }

            if (!decimal.TryParse(priceStr, out price))
            {
                lblError.Text = "Price must be a valid number.";
                return;
            }

            if (!int.TryParse(yearStr, out releaseYear))
            {
                lblError.Text = "Release year must be a valid number.";
                return;
            }
            // --- End Basic Validation ---


            // Call Handler to perform business logic validation and add
            string result = JewelHandler.AddJewel(name, categoryId, brandId, price, releaseYear);

            if (result == null)
            {
                // Success
                Response.Redirect("~/Views/HomePage.aspx?status=add_success");
            }
            else
            {
                // Show error from handler
                lblError.Text = result;
            }
        }
    }
}