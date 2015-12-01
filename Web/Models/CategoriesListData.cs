using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebPPublished.DTO;

namespace WebPPublished.Models
{
    public class CategoriesListData
    {
        public CategoryHeaderData SelectedCategory { get; set; }
        public List<CategoryHeaderData> AllCategory { get; set; }
        public IPagedList<RecipeHeaderData> Recipes { get; set; }
        public Recipes RecipesDB { get; set; }
        public IPagedList<CommentHeaderData> Comments { get; set; }
        public Comments CommentsDB { get; set; }
        public RecipeHeaderData SelectedRecipe { get; set; }
    }
}