using PSDLab_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDLab_Project.Repositories
{
    public class UserRepository
    {
        // Checks if an email is unique in the database.
        public static bool IsEmailUnique(string email)
        {
            using (var db = new JawelsDBEntities1())
            {
                // Use the correct property name: Email
                return !db.Users.Any(u => u.Email == email);
            }
        }

        // Gets a user by matching email and PLAIN TEXT password.
        public static User GetUserByEmailAndPassword(string email, string password)
        {
            using (var db = new JawelsDBEntities1())
            {
                // Use the correct property names: Email and Password
                return db.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            }
        }

        // Adds a new user to the database.
        public static void AddUser(User user)
        {
            using (var db = new JawelsDBEntities1())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }
    }
}