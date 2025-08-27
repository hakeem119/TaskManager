using Microsoft.EntityFrameworkCore;
namespace TaskManger.Models
{
    public class AppDbContext:DbContext
    {
        public DbSet<Items> Tasks { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Items>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Items>()
                .Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(200);

            base.OnModelCreating(modelBuilder);
        }
    }
}
