using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Web.UI.WebControls;
using iBuy.Models;
using Microsoft.AspNet.Identity.EntityFramework;

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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }
    }
}