using PSDLab_Project.Factories;
using PSDLab_Project.Handlers;
using PSDLab_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSDLab_Project.Views
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var user = UserFactory.CreateUser(
                    txtEmail.Text,
                    txtUsername.Text,
                    txtPassword.Text,
                    rdoGender.SelectedValue,
                    DateTime.Parse(txtDob.Text)
                );

                string error = UserHandler.Register(user);
                if (error != null)
                {
                    lblError.Text = error;
                    return;
                }

                Response.Redirect("LoginPage.aspx");
            }
        }
    }
}