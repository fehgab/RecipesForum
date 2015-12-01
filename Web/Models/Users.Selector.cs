using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using WebPPublished.DTO;

namespace WebPPublished.Models
{
    public partial class ApplicationUsers
    {
        public static readonly Expression<Func<ApplicationUser, UserHeaderData>> SelectHeader =
            p => new UserHeaderData
            {
                Id = p.Id,
                RealName = p.RealName,
                UserName = p.UserName,
                Email = p.Email,
                Role = p.Roles

            };
    }
}