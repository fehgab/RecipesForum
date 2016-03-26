using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesClient.DTO
{
    class RecipesHeaderData
    {
        public int ID { get; set; }
        public int? Category_ID { get; set; }
        public string Title { get; set; }
        public string Ingredients { get; set; }
        public string PrepareTime { get; set; }
        public string HowToPrepare { get; set; }
        public string PictureFullPath { get; set; }
    }
}
