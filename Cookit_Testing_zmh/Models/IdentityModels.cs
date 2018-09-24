using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Cookit_Testing_zmh.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
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

        public DbSet<user_list> user_list { get; set; }
        public DbSet<recipe> recipes { get; set; }
        public DbSet<ingredient> ingredients { get; set; }
        public DbSet<instruction> instructions { get; set; }
        public DbSet<post_recipe> post_recipe { get; set; }
        public DbSet<post_ingredient> post_ingredient { get; set; }
        public DbSet<post_instruction> post_instruction { get; set; }
        public DbSet<grocery_list> grocery_list { get; set; }
        public DbSet<calorie> calories { get; set; }
        public DbSet<fav_recipe> fav_recipe { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}