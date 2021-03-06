using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sapfi.Api.V1.Domain.Entities;

namespace Sapfi.Api.V1.Infrastructure.Data.Configurations
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();
            builder.Property(x => x.UpdatedAt).HasColumnName("updated_at");
            builder.Property(x => x.IsDeleted).HasColumnName("is_deleted").IsRequired();
            builder.Property(x => x.Title).HasColumnName("title").IsRequired();
            builder.Property(x => x.Body).HasColumnName("body").IsRequired();
            builder.Property(x => x.DeviceToken).HasColumnName("device_token").IsRequired();
            builder.Property(x => x.IsSent).HasColumnName("is_sent").IsRequired();
            builder.Property(x => x.ErrorSending).HasColumnName("error_sending").IsRequired();
            builder.Property(x => x.SendingMessage).HasColumnName("sending_message");
        }
    }
}
