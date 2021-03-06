using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sapfi.Api.V1.Domain.Entities;

namespace Sapfi.Api.V1.Infrastructure.Data.Configurations
{
    public class TicketFollowUpConfiguration : IEntityTypeConfiguration<TicketFollowUp>
    {
        public void Configure(EntityTypeBuilder<TicketFollowUp> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();
            builder.Property(x => x.UpdatedAt).HasColumnName("updated_at");
            builder.Property(x => x.IsDeleted).HasColumnName("is_deleted").IsRequired();
            builder.Property(x => x.TicketId).HasColumnName("ticket_id").IsRequired();
            builder.Property(x => x.DeviceToken).HasColumnName("device_token").IsRequired();
            builder.Property(x => x.IsNotified).HasColumnName("is_notified").IsRequired();
        }
    }
}
