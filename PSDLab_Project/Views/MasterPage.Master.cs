using PSDLab_Project.Models;
using PSDLab_Project.Handlers; // Make sure you need this, or remove it.
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
            // --- We should handle the cookie logic here as well ---
            User currentUser = Session["user"] as User;

            // If no session, try the cookie
            if (currentUser == null && Request.Cookies["user_cookie"] != null)
            {
                HttpCookie cookie = Request.Cookies["user_cookie"];
                string email = cookie["Email"];
                string password = cookie["Password"];

                currentUser = UserHandler.Login(email, password);
                if (currentUser != null)
                {
                    Session["user"] = currentUser; // Restore session
                }
                else
                {
                    // Cookie is invalid, remove it
                    cookie.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Add(cookie);
                }
            }

            // --- Set visibility based on currentUser ---
            phGuest.Visible = (currentUser == null);
            phCustomer.Visible = (currentUser != null && currentUser.Role == "Customer");
            phAdmin.Visible = (currentUser != null && currentUser.Role == "Admin");
            phLoggedIn.Visible = (currentUser != null); // Show profile/logout if logged in

            if (currentUser != null)
            {
                lblWelcome.Visible = true;
                lblWelcome.Text = $"Welcome, {currentUser.Username}";
            }
            else
            {
                lblWelcome.Visible = false;
            }
        }

        // *** RENAMED this method to match the .aspx file ***
        protected void lbLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();

            // Use the correct cookie name: "user_cookie"
            if (Request.Cookies["user_cookie"] != null)
            {
                HttpCookie cookie = Response.Cookies["user_cookie"];
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }
            Response.Redirect("~/Views/LoginPage.aspx"); // Redirect to Login
        }
    }
}