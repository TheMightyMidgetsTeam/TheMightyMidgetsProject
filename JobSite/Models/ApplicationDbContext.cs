using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JobSite.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

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

        public System.Data.Entity.DbSet<JobSite.Models.JobPost> JobPosts { get; set; }

        public System.Data.Entity.DbSet<JobSite.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<JobSite.Models.City> Cities { get; set; }

        public System.Data.Entity.DbSet<JobSite.Models.ApplyJob> ApplayJobs { get; set; }

        public System.Data.Entity.DbSet<JobSite.Models.File> Files { get; set; }

    }

}