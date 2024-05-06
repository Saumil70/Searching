using Microsoft.EntityFrameworkCore;

namespace Searching.Models
{
    public class DbEntites: DbContext
    {
        public DbEntites(DbContextOptions<DbEntites> options) : base(options)
        {

        }   

        public DbSet<Categories> Categories { get; set; }
        public DbSet<Products> Products { get; set; }   
        public DbSet<Variants> Variants { get; set; }
        public DbSet<ProductVariantMappings> ProductVariantMappings { get; set; }   

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
