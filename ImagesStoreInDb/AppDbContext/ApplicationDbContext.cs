using ImagesStoreInDb;
using Microsoft.EntityFrameworkCore;

namespace ImagesStoreInDb.AppDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<ImageEntity> Images { get; set; }
    }
}
