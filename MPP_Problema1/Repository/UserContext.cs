using MPP_Problema1.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace MPP_Problema1.Repository
{
    public class UserContext : DbContext
    {
        public UserContext() : base("Name=UserContext")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("user", "public")
                .HasKey(x => x.Id);
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<User> Users { get; set; }

    }
}
