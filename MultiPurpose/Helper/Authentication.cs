using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MultiPurpose.Context;
using MultiPurpose.Models;

namespace MultiPurpose.Helper
{
    public class Authentication
    {
        private static DatabaseContext db = new DatabaseContext();

        public static bool Login(string username, string password)
        {
            return true;
            //var isValidUser = db.Users.Any(u => u.UserName.Equals(username, StringComparison.OrdinalIgnoreCase) && u.Password == password);
            //return isValidUser;
        }
    }
}