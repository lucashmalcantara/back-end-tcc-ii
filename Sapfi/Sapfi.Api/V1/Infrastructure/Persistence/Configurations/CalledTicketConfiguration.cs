﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sapfi.Api.V1.Domain.Core.Entities;

namespace Sapfi.Api.V1.Infrastructure.Persistence.Configurations
{
    public class CalledTicketConfiguration : IEntityTypeConfiguration<CalledTicket>
    {
        public void Configure(EntityTypeBuilder<CalledTicket> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedAt).ValueGeneratedOnAdd();
        }
    }
}
