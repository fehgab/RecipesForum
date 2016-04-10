using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebPPublished.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        // Identity and Authorization
        public DbSet<IdentityUserLogin> AspNetUserLogins { get; set; }
        public DbSet<IdentityUserClaim> AspNetUserClaims { get; set; }
        public DbSet<IdentityUserRole> AspNetUserRoles { get; set; }
        public DbSet<IdentityUser> AspNetUsers { get; set; }

        public System.Data.Entity.DbSet<WF_RecipesClient.RecipesModel.Recipes> Recipes { get; set; }

        public System.Data.Entity.DbSet<WF_RecipesClient.RecipesModel.Categories> Categories { get; set; }

        public System.Data.Entity.DbSet<WF_RecipesClient.RecipesModel.Comments> Comments { get; set; }

    }
}