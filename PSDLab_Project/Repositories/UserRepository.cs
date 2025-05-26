using PSDLab_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDLab_Project.Repositories
{
    public class UserRepository
    {
        public static bool IsEmailUnique(string email)
        {
            using (var db = new JawelsDBEntities1())
            {
                return !db.Users.Any(u => u.Email == email);
            }
        }

        public static User GetUserByEmailAndPassword(string email, string password)
        {
            using (var db = new JawelsDBEntities1())
            {
                return db.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            }
        }
    }
}