using PSDLab_Project.Handlers;
using PSDLab_Project.Models;
using PSDLab_Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSDLab_Project.Views
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            // Basic validation
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                lblError.Text = "Email and Password must be filled.";
                return;
            }

            // Attempt to login using the handler
            User user = UserHandler.Login(email, password);

            if (user != null)
            {
                lblError.Text = "";

                // Store user in session
                Session["user"] = user;

                // Handle "Remember Me" cookie
                // *** CORRECTED to use chkRememberMe ***
                if (chkRememberMe.Checked)
                {
                    HttpCookie cookie = new HttpCookie("user_cookie");
                    cookie["Email"] = email;
                    cookie["Password"] = password;
                    cookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(cookie);
                }
                else
                {
                    // If "Remember Me" is not checked, ensure any existing cookie is removed.
                    HttpCookie cookie = Request.Cookies["user_cookie"];
                    if (cookie != null)
                    {
                        cookie.Expires = DateTime.Now.AddDays(-1); // Expire the cookie
                        Response.Cookies.Add(cookie);
                    }
                }

                // Redirect to Home Page
                Response.Redirect("~/Views/HomePage.aspx");
            }
            else
            {
                // Login failed
                lblError.Text = "Invalid Email or Password.";
                lblMessage.Text = "";
            }
        }
    }
}