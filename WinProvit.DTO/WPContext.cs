using Microsoft.EntityFrameworkCore;

namespace WinProvit.DTO
{
    public class WPContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Candidate> Candidates { get; set; }

        public WPContext(DbContextOptions options) : base(options)
        {

        }
    }
}
