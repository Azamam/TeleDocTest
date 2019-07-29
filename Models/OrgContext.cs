using System.Data.Entity;

namespace TeleDocTest.Models
{
    public class OrgContext : DbContext
    {
        public OrgContext() : base("OrgDataBase")
        {
        }

        public DbSet<Organization> Organizations { get; set; }
        public DbSet<FounderItem> FoundersItems { get; set; }
        public DbSet<Founder> FoundersList { get; set; }
    }
}