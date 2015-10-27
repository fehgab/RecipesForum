using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPPublished.DTO
{
    public class UserHeaderData
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string RealName { get; set; }
        public string UserName { get; set; }
        public ICollection<IdentityUserRole> Role { get; set; }
    }
}