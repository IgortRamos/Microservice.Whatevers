using System;
using Microservice.Whatevers.Domain.Entities.Whatevers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microservice.Whatevers.Repositories.Configs
{
    public class WhateverConfig : IEntityTypeConfiguration<Whatever>
    {
        public void Configure(EntityTypeBuilder<Whatever> builder)
        {
            builder.ToTable(nameof(Whatever));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.Time)
                .HasDefaultValue(DateTime.Now);
            builder.HasMany(x => x.Things);
        }
    }
}