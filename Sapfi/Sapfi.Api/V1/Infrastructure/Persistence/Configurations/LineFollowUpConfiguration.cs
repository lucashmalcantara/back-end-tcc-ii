using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sapfi.Api.V1.Domain.Core.Entities;

namespace Sapfi.Api.V1.Infrastructure.Persistence.Configurations
{
    public class LineFollowUpConfiguration : IEntityTypeConfiguration<LineFollowUp>
    {
        public void Configure(EntityTypeBuilder<LineFollowUp> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedAt).ValueGeneratedOnAdd();
        }
    }
}
