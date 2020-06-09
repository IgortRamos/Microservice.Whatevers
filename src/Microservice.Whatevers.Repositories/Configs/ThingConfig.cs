using Microservice.Whatevers.Domain.Entities.Things;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microservice.Whatevers.Repositories.Configs
{
    public class ThingConfig : IEntityTypeConfiguration<Thing>
    {
        public void Configure(EntityTypeBuilder<Thing> builder)
        {
            builder.ToTable(nameof(Thing));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.Type)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}