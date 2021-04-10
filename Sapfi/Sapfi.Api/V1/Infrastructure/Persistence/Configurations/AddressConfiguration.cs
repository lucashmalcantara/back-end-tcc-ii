using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sapfi.Api.V1.Domain.Entities;

namespace Sapfi.Api.V1.Infrastructure.Persistence.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();
            builder.Property(x => x.UpdatedAt).HasColumnName("updated_at");
            builder.Property(x => x.IsDeleted).HasColumnName("is_deleted").IsRequired();
            builder.Property(x => x.Country).HasColumnName("country").IsRequired();
            builder.Property(x => x.State).HasColumnName("state").IsRequired();
            builder.Property(x => x.City).HasColumnName("city").IsRequired();
            builder.Property(x => x.ZipCode).HasColumnName("zip_code").IsRequired();
            builder.Property(x => x.Neighborhood).HasColumnName("neighborhood").IsRequired();
            builder.Property(x => x.Street).HasColumnName("street").IsRequired();
            builder.Property(x => x.Number).HasColumnName("number").IsRequired();
            builder.Property(x => x.Complement).HasColumnName("complement");
        }
    }
}
