using PSDLab_Project.Models;
using PSDLab_Project.Handlers;
using System;
using System.Linq;
using System.Web.UI;

namespace PSDLab_Project.Views
{
    public partial class JewelDetail : System.Web.UI.Page
    {
        private int JewelID
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
            if (!IsPostBack)
            {
                LoadJewel();
                SetButtonVisibility();
            }
        }

        private void LoadJewel()
        {
            if (JewelID <= 0)
            {
                ShowError("Invalid Jewel ID.");
                return;
            }

            var jewel = JewelHandler.GetJewelById(JewelID);

            if (jewel == null)
            {
                ShowError("Jewel not found.");
                return;
            }

            // Populate labels
            lblName.Text = jewel.JewelName;
            lblCategory.Text = jewel.Category?.CategoryName ?? "N/A";
            lblBrand.Text = jewel.Brand?.BrandName ?? "N/A";
            lblCountry.Text = jewel.Brand?.Country ?? "N/A";
            lblClass.Text = jewel.Brand?.Class ?? "N/A";
            // *** CORRECTED LINES ***
            lblPrice.Text = jewel.Price.ToString("C");
            lblYear.Text = jewel.ReleaseYear.HasValue ? jewel.ReleaseYear.Value.ToString() : "N/A";
            // *** END OF CORRECTION ***

            pnlDetails.Visible = true;
            lblError.Visible = false;
        }

        private void SetButtonVisibility()
        {
            var user = Session["user"] as User;

            if (user != null)
            {
                if (user.Role == "Customer")
                {
                    phCustomerActions.Visible = true;
                }
                else if (user.Role == "Admin")
                {
                    phAdminActions.Visible = true;
                }
            }
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            var user = Session["user"] as User;
            if (user == null || user.Role != "Customer" || JewelID <= 0)
            {
                ShowError("You must be logged in as a customer to add items.");
                return;
            }

            using (JawelsDBEntities1 db = new JawelsDBEntities1())
            {
                var existing = db.Carts.FirstOrDefault(c => c.UserID == user.UserID && c.JewelID == JewelID);
                if (existing != null)
                {
                    existing.Quantity = (existing.Quantity ?? 0) + 1;
                }
                else
                {
                    Models.Cart cartItem = new Models.Cart
                    {
                        UserID = user.UserID,
                        JewelID = JewelID,
                        Quantity = 1
                    };
                    db.Carts.Add(cartItem);
                }

                db.SaveChanges();
                Response.Redirect("~/Views/Cart.aspx");
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect($"~/Views/UpdateJewel.aspx?id={JewelID}");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (JawelsDBEntities1 db = new JawelsDBEntities1())
                {
                    var jewelToDelete = db.Jewels.Find(JewelID);
                    if (jewelToDelete != null)
                    {
                        db.Jewels.Remove(jewelToDelete);
                        db.SaveChanges();
                        Response.Redirect("~/Views/HomePage.aspx");
                    }
                    else
                    {
                        ShowError("Jewel could not be found for deletion.");
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError($"Could not delete jewel. It might be referenced elsewhere. Error: {ex.Message}");
            }
        }

        private void ShowError(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
            pnlDetails.Visible = false;
        }
    }
}