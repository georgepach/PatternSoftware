using PSDLab_Project.Models;
using PSDLab_Project.Handlers;
using System;
using System.Text.RegularExpressions;
using System.Net.Mail;
using PSDLab_Project.Factories; // We might need this later, or create User directly

namespace PSDLab_Project.Views
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // If a user is already logged in, redirect them to the home page [cite: 47, 51, 53, 56]
            if (Session["user"] != null || Request.Cookies["user_cookie"] != null)
            {
                Response.Redirect("~/Views/HomePage.aspx");
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text; // Don't trim password
            string confirmPassword = txtConfirmPassword.Text;
            string gender = rblGender.SelectedValue;
            string dobText = txtDOB.Text;

            string errorMessage = ValidateInputs(email, username, password, confirmPassword, gender, dobText);

            if (string.IsNullOrEmpty(errorMessage))
            {
                DateTime dob;
                DateTime.TryParse(dobText, out dob); // We know it's valid from validation

                // Create User object
                // If you had a UserFactory, you'd use it here.
                // Since we don't have one provided yet, we'll create it directly.
                User newUser = new User
                {
                    Email = email,
                    Username = username,
                    Password = password, // Storing plain text as per our agreement
                    Gender = gender,
                    DateOfBirth = dob,
                    Role = "Customer" // New registrations are customers
                };

                // Call the handler to attempt registration
                string handlerResult = UserHandler.Register(newUser);

                if (handlerResult == null)
                {
                    // Success! Redirect to login page.
                    Response.Redirect("~/Views/LoginPage.aspx?status=registered");
                }
                else
                {
                    // Handler returned an error (e.g., email not unique)
                    lblError.Text = handlerResult;
                }
            }
            else
            {
                // Display validation errors
                lblError.Text = errorMessage;
            }
        }

        // --- Validation Logic ---
        private string ValidateInputs(string email, string username, string password, string confirmPassword, string gender, string dobText)
        {
            // Email Validation [cite: 49]
            if (string.IsNullOrWhiteSpace(email)) return "Email must be filled.";
            try
            {
                var addr = new MailAddress(email);
                if (addr.Address != email) return "Email must be a valid email format.";
            }
            catch
            {
                return "Email must be a valid email format.";
            }

            // Username Validation [cite: 49]
            if (string.IsNullOrWhiteSpace(username)) return "Username must be filled.";
            if (username.Length < 3 || username.Length > 25) return "Username must be between 3 to 25 characters (inclusive).";

            // Password Validation [cite: 49]
            if (string.IsNullOrWhiteSpace(password)) return "Password must be filled.";
            if (password.Length < 8 || password.Length > 20) return "Password must be 8 to 20 characters (inclusive).";
            if (!Regex.IsMatch(password, @"^[a-zA-Z0-9]+$")) return "Password must be alphanumeric.";

            // Confirm Password Validation [cite: 49]
            if (password != confirmPassword) return "Confirm Password must be the same as password.";

            // Gender Validation [cite: 49]
            if (string.IsNullOrWhiteSpace(gender)) return "Gender must be chosen.";

            // Date of Birth Validation [cite: 49]
            if (string.IsNullOrWhiteSpace(dobText)) return "Date of Birth must be chosen.";
            DateTime dob;
            if (!DateTime.TryParse(dobText, out dob)) return "Invalid Date of Birth format.";
            if (dob >= new DateTime(2010, 1, 1)) return "Date of Birth must be earlier than 01/01/2010.";

            // If all validations pass
            return null;
        }
    }
}