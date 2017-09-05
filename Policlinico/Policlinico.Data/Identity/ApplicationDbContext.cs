using Microsoft.AspNet.Identity.EntityFramework;

namespace Policlinico.Data.Identity
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("policlinico", throwIfV1Schema: false)
        { }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
