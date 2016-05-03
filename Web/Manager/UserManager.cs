using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebPPublished.Models;

namespace WebPPublished.Manager
{
    public partial class UserManager
    {
        public ApplicationUser GetUserById(string id)
        {
            using (var context = new ApplicationDbContext())
            {
                var user = context.Users
                    .Where(p => p.Id == id).First();
                return user;
            };
        }

        public string GetUserIdByName(string userName)
        {
            using (var context = new ApplicationDbContext())
            {
                var userId = context.Users
                    .Where(p => p.UserName == userName).First().Id;
                return userId;
            };
        }
    }
}