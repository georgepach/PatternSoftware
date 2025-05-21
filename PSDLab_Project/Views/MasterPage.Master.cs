using PSDLab_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSDLab_Project.Views
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var user = Session["user"] as User;

                phGuest.Visible = (user == null);
                phCustomer.Visible = (user != null && user.Role == "Customer");
                phAdmin.Visible = (user != null && user.Role == "Admin");

                if (user != null)
                {
                    lblWelcome.Text = $"Welcome, {user.Username}";
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            if (Request.Cookies["userLogin"] != null)
            {
                Response.Cookies["userLogin"].Expires = DateTime.Now.AddDays(-1);
            }
            Response.Redirect("Login.aspx");
        }
    }
}