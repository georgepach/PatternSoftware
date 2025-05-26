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
        public static string Register(User user)
        {
            if (!UserRepository.IsEmailUnique(user.Email))
            {
                return "Email already registered.";
            }

            using (var db = new JawelsDBEntities1())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }

            return null; // success
        }
    }
}