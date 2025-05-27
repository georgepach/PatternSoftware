using PSDLab_Project.Models;
using PSDLab_Project.Handlers;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSDLab_Project.Views
{
    public partial class UpdateJewel : System.Web.UI.Page
    {
        // Helper to safely get JewelID from QueryString
        private int JewelIDFromQuery
        {
            get
            {
                int id = 0;
                int.TryParse(Request.QueryString["id"], out id);
                return id;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Ensure user is an Admin
            User user = Session["user"] as User;
            if (user == null || user.Role != "Admin")
            {
                Response.Redirect("~/Views/HomePage.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadDropdowns();
                LoadJewelData();
            }
        }

        private void LoadDropdowns()
        {
            ddlCategory.DataSource = JewelHandler.GetAllCategories();
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("-- Select Category --", ""));

            ddlBrand.DataSource = JewelHandler.GetAllBrands();
            ddlBrand.DataBind();
            ddlBrand.Items.Insert(0, new ListItem("-- Select Brand --", ""));
        }

        private void LoadJewelData()
        {
            int jewelId = JewelIDFromQuery;
            if (jewelId <= 0)
            {
                lblError.Text = "Invalid Jewel ID provided.";
                btnUpdateJewel.Enabled = false;
                return;
            }

            var jewel = JewelHandler.GetJewelById(jewelId);

            if (jewel == null)
            {
                lblError.Text = "Jewel not found.";
                btnUpdateJewel.Enabled = false;
                return;
            }

            // Populate form fields
            hfJewelID.Value = jewel.JewelID.ToString(); // Store ID for postback
            txtJewelName.Text = jewel.JewelName;
            txtPrice.Text = jewel.Price.ToString(); // Use Price
            txtReleaseYear.Text = jewel.ReleaseYear?.ToString() ?? ""; // Use ReleaseYear

            // Set dropdown selections (handle nulls)
            if (jewel.CategoryID.HasValue)
            {
                ddlCategory.SelectedValue = jewel.CategoryID.Value.ToString();
            }
            if (jewel.BrandID.HasValue)
            {
                ddlBrand.SelectedValue = jewel.BrandID.Value.ToString();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            // Go back to details or home
            int jewelId = JewelIDFromQuery;
            if (jewelId > 0)
            {
                Response.Redirect($"~/Views/JewelDetail.aspx?id={jewelId}");
            }
            else
            {
                Response.Redirect("~/Views/HomePage.aspx");
            }
        }

        protected void btnUpdateJewel_Click(object sender, EventArgs e)
        {
            int jewelId;
            if (!int.TryParse(hfJewelID.Value, out jewelId))
            {
                lblError.Text = "Could not identify the jewel to update.";
                return;
            }

            string name = txtJewelName.Text.Trim();
            string categoryIdStr = ddlCategory.SelectedValue;
            string brandIdStr = ddlBrand.SelectedValue;
            string priceStr = txtPrice.Text.Trim();
            string yearStr = txtReleaseYear.Text.Trim();

            int categoryId, brandId, releaseYear;
            decimal price;

            // --- Basic Client-Side Validation ---
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(categoryIdStr) ||
                string.IsNullOrEmpty(brandIdStr) || string.IsNullOrEmpty(priceStr) ||
                string.IsNullOrEmpty(yearStr))
            {
                lblError.Text = "All fields must be filled.";
                return;
            }
            if (!int.TryParse(categoryIdStr, out categoryId)) { lblError.Text = "Select a valid category."; return; }
            if (!int.TryParse(brandIdStr, out brandId)) { lblError.Text = "Select a valid brand."; return; }
            if (!decimal.TryParse(priceStr, out price)) { lblError.Text = "Price must be a number."; return; }
            if (!int.TryParse(yearStr, out releaseYear)) { lblError.Text = "Year must be a number."; return; }
            // --- End Basic Validation ---

            // Call Handler to perform validation and update
            string result = JewelHandler.UpdateJewel(jewelId, name, categoryId, brandId, price, releaseYear);

            if (result == null)
            {
                // Success - Redirect back to the detail page
                Response.Redirect($"~/Views/JewelDetail.aspx?id={jewelId}&status=update_success");
            }
            else
            {
                // Show error from handler
                lblError.Text = result;
            }
        }
    }
}