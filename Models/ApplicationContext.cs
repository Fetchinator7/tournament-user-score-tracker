using Microsoft.EntityFrameworkCore;
namespace tournament_user_score_tracker.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}

        // Add our own models to the ApplicationContext so that they are database-aware.
        public DbSet<User> User { get; set; }
    }
}