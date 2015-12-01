using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using WebPPublished.DTO;

namespace WebPPublished.Models
{
    public partial class Comments
    {
        public static readonly Expression<Func<Comments, CommentHeaderData>> SelectHeader =
                p => new CommentHeaderData
                {
                    ID = p.Id,
                    CreateDate = p.CreatedDate,
                    RecipeId = p.RecipesId,
                    Text = p.Text,
                    UserId = p.UserId,
                    User = p.User,
                    Recipes = p.Recipes                    
                };
    }
}