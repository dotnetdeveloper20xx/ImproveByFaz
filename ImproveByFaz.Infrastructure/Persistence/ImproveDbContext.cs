using ImproveByFaz.Domain.Entities;
using ImproveByFaz.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace ImproveByFaz.Infrastructure.Persistence
{
    public class ImproveDbContext : DbContext
    {
        public ImproveDbContext(DbContextOptions<ImproveDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<SubTopic> SubTopics { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<StudentMisconception> StudentMisconceptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ImproveDbContext).Assembly);

            modelBuilder.Entity<Question>()
                .OwnsMany(q => q.Options, options =>
                {
                    options.WithOwner().HasForeignKey("QuestionId");
                    options.Property(o => o.Label).IsRequired();
                    options.Property(o => o.Description).IsRequired();
                });
         
            base.OnModelCreating(modelBuilder);
        }
    }
}
