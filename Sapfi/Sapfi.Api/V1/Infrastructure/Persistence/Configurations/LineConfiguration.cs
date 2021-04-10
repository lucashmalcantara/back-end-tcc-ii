using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sapfi.Api.V1.Domain.Entities;
using System;

namespace Sapfi.Api.V1.Infrastructure.Persistence.Configurations
{
    public class LineConfiguration : IEntityTypeConfiguration<Line>
    {
        public void Configure(EntityTypeBuilder<Line> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();
            builder.Property(x => x.UpdatedAt).HasColumnName("updated_at");
            builder.Property(x => x.IsDeleted).HasColumnName("is_deleted").IsRequired();
            builder.Property(x => x.QuantityOfTicket).HasColumnName("quantity_of_ticket").IsRequired();
            builder.Property(x => x.WaitingTime).HasColumnName("waiting_time").IsRequired();
            builder.HasOne(x => x.Company).WithOne(y => y.Line).HasForeignKey<Line>(y => y.Id);
        }
    }
}
