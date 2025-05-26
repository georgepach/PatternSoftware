using PSDLab_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSDLab_Project.Factories
{
    public class UserFactory
    {
        public static User CreateUser(string email, string username, string password, string gender, DateTime dob)
        {
            return new User
            {
                Email = email,
                Username = username,
                Password = password,
                Gender = gender,
                DateOfBirth = dob,
                Role = "Customer"
            };
        }
    }
}