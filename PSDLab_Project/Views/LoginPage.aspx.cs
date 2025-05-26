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

            var user = UserRepository.GetUserByEmailAndPassword(email, password);

            if (user != null)
            {
                Session["user"] = user;

                if (chkRemember.Checked)
                {
                    var cookie = new HttpCookie("userLogin");
                    cookie.Values["email"] = email;
                    cookie.Expires = DateTime.Now.AddDays(7);
                    Response.Cookies.Add(cookie);
                }

                Response.Redirect("~/Views/HomePage.aspx");
            }
            else
            {
                lblError.Text = "Invalid email or password.";
            }
        }
    }
}