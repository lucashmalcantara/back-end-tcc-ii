using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sapfi.Api.V1.Domain.Core.Entities;

namespace Sapfi.Api.V1.Infrastructure.Persistence.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.CreatedAt).HasColumnName("created_at").ValueGeneratedOnAdd();
            builder.Property(x => x.UpdatedAt).HasColumnName("updated_at");
            builder.Property(x => x.IsDeleted).HasColumnName("is_deleted");
            builder.Property(x => x.Country).HasColumnName("country");
            builder.Property(x => x.State).HasColumnName("state");
            builder.Property(x => x.City).HasColumnName("city");
            builder.Property(x => x.ZipCode).HasColumnName("zip_code");
            builder.Property(x => x.Neighborhood).HasColumnName("neighborhood");
            builder.Property(x => x.Street).HasColumnName("street");
            builder.Property(x => x.Number).HasColumnName("number");
            builder.Property(x => x.Complement).HasColumnName("complement");
        }
    }
}
