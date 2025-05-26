using PSDLab_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSDLab_Project.Views
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCart();
            }
        }

        private void LoadCart()
        {
            var user = Session["user"] as User;
            if (user == null || user.Role != "Customer")
            {
                Response.Redirect("LoginPage.aspx");
                return;
            }

            using (var db = new JawelsDBEntities1())
            {
                var data = db.Carts
                    .Where(c => c.UserID == user.UserID)
                    .Select(c => new
                    {
                        c.Jewel.JewelName,
                        c.Jewel.Price,
                        c.Quantity,
                        Subtotal = c.Quantity * c.Jewel.Price,
                        c.CartID
                    }).ToList();

                gvCart.DataSource = data;
                gvCart.DataBind();
            }
        }

        protected void gvCart_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int cartId = Convert.ToInt32(gvCart.DataKeys[index].Value);

                using (var db = new JawelsDBEntities1())
                {
                    var cartItem = db.Carts.Find(cartId);
                    if (cartItem != null)
                    {
                        db.Carts.Remove(cartItem);
                        db.SaveChanges();
                    }
                }

                LoadCart();
            }
        }
    }
}