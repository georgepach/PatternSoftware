using PSDLab_Project.Models;
using PSDLab_Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDLab_Project.Handlers
{
    public class UserHandler
    {
        // Registers a user (handles uniqueness check, but no hashing).
        public static string Register(User user)
        {
            // Use the correct property 'Email' from your User model.
            if (!UserRepository.IsEmailUnique(user.Email))
            {
                return "Email already registered.";
            }

            // Adds the user (with plain text password) via the repository.
            try
            {
                UserRepository.AddUser(user);
                return null; // Indicates success.
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString()); // Basic logging
                return "An error occurred during registration. Please try again.";
            }
        }

        // *** ADD THIS METHOD ***
        // Logs in a user using plain text email and password.
        public static User Login(string email, string password)
        {
            // Calls the repository method to find the user.
            return UserRepository.GetUserByEmailAndPassword(email, password);
        }
        // *** END OF ADDED METHOD ***
    }
}