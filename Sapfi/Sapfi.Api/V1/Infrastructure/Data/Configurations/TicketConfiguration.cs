using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sapfi.Api.V1.Domain.Entities;

namespace Sapfi.Api.V1.Infrastructure.Data.Configurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();
            builder.Property(x => x.UpdatedAt).HasColumnName("updated_at");
            builder.Property(x => x.IsDeleted).HasColumnName("is_deleted").IsRequired();
            builder.Property(x => x.ExternalId).HasColumnName("external_id").IsRequired();
            builder.Property(x => x.Number).HasColumnName("number").IsRequired();
            builder.Property(x => x.IssueDate).HasColumnName("Issue_date").IsRequired();
            builder.Property(x => x.LinePosition).HasColumnName("line_position").IsRequired();
            builder.Property(x => x.WaitingTime).HasColumnName("waiting_time").IsRequired();
            builder.Property(x => x.CompanyId).HasColumnName("company_id").IsRequired();
        }
    }
}
