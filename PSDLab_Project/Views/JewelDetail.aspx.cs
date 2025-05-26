using PSDLab_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSDLab_Project.Views
{
    public partial class JewelDetail : System.Web.UI.Page
    {
        private int JewelID => Convert.ToInt32(Request.QueryString["id"]);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadJewel();
            }
        }

        private void LoadJewel()
        {
            using (JawelsDBEntities1 db = new JawelsDBEntities1())
            {
                var jewel = db.Jewels.FirstOrDefault(j => j.JewelID == JewelID);

                if (jewel == null)
                {
                    lblError.Text = "Jewel not found.";
                    return;
                }

                lblName.Text = jewel.JewelName;
                lblBrand.Text = jewel.Brand.BrandName;
                lblClass.Text = jewel.Brand.Class;
                lblCategory.Text = jewel.Category.CategoryName;
                lblPrice.Text = jewel.Price.ToString("C");
                lblYear.Text = jewel.ReleaseYear.ToString();

                var user = Session["user"] as User;

                if (user != null)
                {
                    if (user.Role == "Customer")
                    {
                        btnAddToCart.Visible = true;
                    }
                    else if (user.Role == "Admin")
                    {
                        btnEdit.Visible = true;
                    }
                }
            }
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            var user = Session["user"] as User;
            if (user == null || user.Role != "Customer") return;

            using (JawelsDBEntities1 db = new JawelsDBEntities1())
            {
                var existing = db.Carts.FirstOrDefault(c => c.UserID == user.UserID && c.JewelID == JewelID);
                if (existing != null)
                {
                    existing.Quantity += 1;
                }
                else
                {
                    Cart cartItem = new Cart
                    {
                        UserID = user.UserID,
                        JewelID = JewelID,
                        Quantity = 1
                    };
                    db.Carts.Add(cartItem);
                }

                db.SaveChanges();
                Response.Redirect("~/Views/Cart.aspx"); // you can create Cart.aspx later
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect($"UpdateJewel.aspx?id={JewelID}");
        }
    }
}