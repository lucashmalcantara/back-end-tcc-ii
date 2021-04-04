﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sapfi.Api.V1.Domain.Core.Entities;

namespace Sapfi.Api.V1.Infrastructure.Persistence.Configurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedAt).HasColumnName("created_at").ValueGeneratedOnAdd();
            builder.Property(x => x.UpdatedAt).HasColumnName("updated_at");
            builder.Property(x => x.IsDeleted).HasColumnName("is_deleted").IsRequired();
            builder.Property(x => x.Number).HasColumnName("number");
            builder.Property(x => x.IssueDate).HasColumnName("Issue_date");
            builder.Property(x => x.LinePosition).HasColumnName("line_position");
            builder.Property(x => x.WaitingTime).HasColumnName("waiting_time");
            builder.Property(x => x.CompanyId).HasColumnName("company_id");
        }
    }
}