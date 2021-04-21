using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sapfi.Api.V1.Domain.Entities;

namespace Sapfi.Api.V1.Infrastructure.Data.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();
            builder.Property(x => x.UpdatedAt).HasColumnName("updated_at");
            builder.Property(x => x.IsDeleted).HasColumnName("is_deleted").IsRequired();
            builder.Property(x => x.ApiToken).HasColumnName("api_token").IsRequired();
            builder.Property(x => x.Document).HasColumnName("document").IsRequired();
            builder.Property(x => x.Name).HasColumnName("name").IsRequired();
            builder.Property(x => x.TradingName).HasColumnName("trading_name").IsRequired();
            builder.Property(x => x.FriendlyHumanCode).HasColumnName("friendly_human_code").IsRequired();
            builder.HasOne(x => x.Address).WithOne(y => y.Company).HasForeignKey<Address>(y => y.Id);
            builder.HasOne(x => x.Line).WithOne(y => y.Company).HasForeignKey<Line>(y => y.Id);
            builder.HasMany(x => x.Tickets).WithOne(y => y.Company).HasForeignKey(t => t.CompanyId);
        }
    }
}
