using Microsoft.EntityFrameworkCore;
using CorporateMassenger.Data.Mapping;
using CorporateMessenger.Data.Mapping;

namespace CorporateMassenger.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> UserMap { get; set; }
        public DbSet<UserMessage> UserMessageMap { get; set; }
        public DbSet<Message> MessageMap { get; set; }
        public DbSet<Groups> GroupsMap { get; set; }
        public DbSet<Role> RoleMap { get; set; }


        public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options)
        {
        }
    }
}
