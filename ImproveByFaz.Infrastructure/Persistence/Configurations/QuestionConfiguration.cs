using ImproveByFaz.Domain.Entities;
using ImproveByFaz.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ImproveByFaz.Infrastructure.Persistence.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(q => q.Id);
            builder.Property(q => q.ImageUrl).IsRequired();
            builder.Property(q => q.CorrectAnswer).IsRequired().HasConversion<string>();
        }
    }
}
