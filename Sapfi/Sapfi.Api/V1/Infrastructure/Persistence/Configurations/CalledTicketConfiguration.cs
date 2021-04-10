using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sapfi.Api.V1.Domain.Entities;

namespace Sapfi.Api.V1.Infrastructure.Persistence.Configurations
{
    public class CalledTicketConfiguration : IEntityTypeConfiguration<CalledTicket>
    {
        public void Configure(EntityTypeBuilder<CalledTicket> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();
            builder.Property(x => x.UpdatedAt).HasColumnName("updated_at");
            builder.Property(x => x.IsDeleted).HasColumnName("is_deleted").IsRequired();
            builder.Property(x => x.Number).HasColumnName("number");
            builder.Property(x => x.CalledAt).HasColumnName("called_at");
            builder.Property(x => x.CompanyId).HasColumnName("company_id");
        }
    }
}
