using Microsoft.EntityFrameworkCore;
using CorporateMassenger.Data.Mapping;

namespace CorporateMassenger.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> UserMap { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options)
        {
        }
    }
}
