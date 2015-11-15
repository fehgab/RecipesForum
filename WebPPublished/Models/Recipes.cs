﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebPPublished.Models
{
    [Table("Recipes")]
    public partial class Recipes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Recipes()
        {
            //Comments = new HashSet<Comment>();
            //Ratings = new HashSet<Rating>();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Étel neve")]
        public string Title { get; set; }

        [StringLength(100)]
        public string FriendlyUrl { get; set; }

        [StringLength(100)]
        [Display(Name = "Kép")]
        public string PictureUrl { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Hozzávalók")]
        public string Ingredients { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Elkészítési idő")]
        public string PrepareTime { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Elkészítés")]
        public string HowToPrepare { get; set; }
        [Display(Name = "Kategória")]
        public virtual int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public virtual Categories Category { get; set; }
        public virtual string UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual ApplicationUser User { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Comment> Comments { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Rating> Ratings { get; set; }
    }
}