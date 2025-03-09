using ImproveByFaz.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ImproveByFaz.Infrastructure.Persistence.Configurations
{
    public class SubTopicConfiguration : IEntityTypeConfiguration<SubTopic>
    {
        public void Configure(EntityTypeBuilder<SubTopic> builder)
        {
            builder.HasKey(st => st.Id);
            builder.Property(st => st.Name).IsRequired().HasMaxLength(100);
            builder.HasMany(st => st.Questions)
                   .WithOne(q => q.SubTopic)
                   .HasForeignKey(q => q.SubTopicId);
        }
    }
}
