namespace PlantillaMicroAPI.Infrastructure.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PlantillaMicroAPI.Domain.NombreEntidad;

    internal sealed class NombreEntidadConfiguration : IEntityTypeConfiguration<NombreEntidad>
    {
        public void Configure(EntityTypeBuilder<NombreEntidad> builder)
        {
            builder.HasKey(x => x.Id);

            // examples

            // builder.Property(x => x.xxx).HasMaxLength(200);
            // builder.HasMany(x => x...).WithOne(x => x...).OnDelete(DeleteBehavior.NoAction);
            // builder.HasIndex(x => x...).IsUnique();
        }
    }
}
