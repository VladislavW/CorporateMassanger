using Microsoft.EntityFrameworkCore;
using CorporateMassenger.Data.Mapping;
using CorporateMessenger.Data.Mapping;

namespace CorporateMassenger.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> UserMap { get; set; }
        public DbSet<UserMassage> UserMassageMap { get; set; }
        public DbSet<Massage> MassageMap { get; set; }
        public DbSet<Groups> GroupsMap { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options)
        {
        }
    }
}
