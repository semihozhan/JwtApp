using JwtApp.Back.Core.Domain;
using JwtApp.Back.Persistance.Configuraiton;
using Microsoft.EntityFrameworkCore;

namespace JwtApp.Back.Persistance.Context
{
    public class JwtContext : DbContext
    {
        public JwtContext(DbContextOptions<JwtContext> options) : base(options)
        {
        }

        public DbSet<Product> Products
        {
            get
            {
                return this.Set<Product>();
            }
        }
        public DbSet<Category> Categories
        {
            get
            {
                return this.Set<Category>();
            }
        }
        public DbSet<AppRole> AppRoles
        {
            get
            {
                return this.Set<AppRole>();
            }
        }
        public DbSet<AppUser> AppUsers
        {
            get
            {
                return this.Set<AppUser>();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            base.OnModelCreating(modelBuilder);
        }


    }
}
