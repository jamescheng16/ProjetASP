using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using iBuy.Models;

namespace iBuy.DAL
{
    public class AnnounceContext:DbContext
    {
        public AnnounceContext() : base("AnnounceContext")
        { }

        public DbSet<Announce> Announces { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}