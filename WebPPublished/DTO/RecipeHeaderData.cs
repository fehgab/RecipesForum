using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPPublished.DTO
{
    public class RecipeHeaderData
    {
        public int ID { get; set; }
        public int? Category_ID { get; set; }
        public int? PageNumber { get; set; }
        public int? SumRating { get; set; }
        public int? RaitingCount { get; set; }
        public string Title { get; set; }
        public string Ingredients { get; set; }
        public string PrepareTime { get; set; }
        public string HowToPrepare { get; set; }
        public string FriendlyUrl { get; set; }
        public string PictureUrl { get; set; }
    }
}