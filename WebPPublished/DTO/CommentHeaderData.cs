using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebPPublished.Models;

namespace WebPPublished.DTO
{
    public class CommentHeaderData
    {
        public int ID { get; set; }
        public string CreateDate { get; set; }
        public string Text { get; set; }
        public string UserId { get; set; }
        public int RecipeId { get; set; }
        public ApplicationUser User { get; set; }
        public Recipes Recipes { get; set; }
    }
}