using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace WebPPublished.Models
{
    [Table("Comments")]
    public partial class Comments
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        //[Column(TypeName = "date")]
        public DateTime CreatedDate { get; set; }

        public virtual int RecipesId { get; set; }
        [ForeignKey("RecipesId")]
        public virtual Recipes Recipes{ get; set; }

        public virtual string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    }
}