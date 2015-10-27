using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebPPublished.Models;

namespace WebPPublished.Manager
{
    public class UserManager
    {
        public string GetUserIdByName(string UserName)
        {
            using (var context = new ApplicationDbContext())
            {
                var id = context.Users
                    .Where(p => p.UserName == UserName)
                    .Select(ApplicationUsers.SelectHeader).First().Id;
                return id;
            };
        }
    }
}