namespace WF_RecipesClient.RecipesModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Recipes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Recipes()
        {
            Comments = new HashSet<Comments>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(40)]
        public string Title { get; set; }

        [Required]
        [StringLength(100)]
        public string FriendlyUrl { get; set; }

        [StringLength(100)]
        public string PictureUrl { get; set; }

        [Required]
        [StringLength(100)]
        public string Ingredients { get; set; }

        [Required]
        [StringLength(10)]
        public string PrepareTime { get; set; }

        [Required]
        [StringLength(500)]
        public string HowToPrepare { get; set; }

        [StringLength(128)]
        public string UserID { get; set; }

        public int? CategoryID { get; set; }

        public virtual Categories Categories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comments> Comments { get; set; }
    }
}
