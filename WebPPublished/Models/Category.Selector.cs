using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using WebPPublished.DTO;

namespace WebPPublished.Models
{
    public partial class Categories
    {
        public static readonly Expression<Func<Categories, CategoryHeaderData>> SelectHeader =
           p => new CategoryHeaderData
           {
               ID = p.ID,
               FriendlyUrl = p.FriendlyUrl,
               DisplayName = p.DisplayName
           };
    }
}