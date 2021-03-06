﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesClient.DTO
{
    public class RecipesHeaderData
    {
        public int ID { get; set; }
        public int? Category_ID { get; set; }
        public string Title { get; set; }
        public string Ingredients { get; set; }
        public string PrepareTime { get; set; }
        public string HowToPrepare { get; set; }
        public string FriendlyUrl { get; set; }
        public string PictureUrl { get; set; }
        public string UserId { get; set; }
    }
}
