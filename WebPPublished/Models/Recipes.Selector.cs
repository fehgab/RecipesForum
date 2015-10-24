using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using WebPPublished.DTO;

namespace WebPPublished.Models
{
    public partial class Recipes
    {
        public static readonly Expression<Func<Recipes, RecipeHeaderData>> SelectHeader =
            p => new RecipeHeaderData
            {
                ID = p.ID,
                Category_ID = p.CategoryID,
                Title = p.Title,
                FriendlyUrl = p.FriendlyUrl,
                PictureUrl = p.PictureUrl,
                Ingredients = p.Ingredients,
                PrepareTime = p.PrepareTime,
                HowToPrepare = p.HowToPrepare,
                //PageNumber = p.PageNumber,
                //RaitingCount = p.RaitingCount,
                //SumRating = p.SumRating

            };
    }
}