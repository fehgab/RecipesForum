namespace RecipesClient.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comments
    {
        public int Id { get; set; }

        public int RecipesId { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }

        [Required]
        [StringLength(500)]
        public string Text { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

        public virtual Recipes Recipes { get; set; }
    }
}
