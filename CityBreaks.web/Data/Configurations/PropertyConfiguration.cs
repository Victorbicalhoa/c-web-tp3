using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CityBreaks.Web.Models;

namespace CityBreaks.Web.Data.Configurations
{
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.Property(p => p.Name)
                   .HasMaxLength(150)
                   .HasColumnName("Property_Name");

            builder.Property(p => p.PricePerNight)
                   .HasColumnName("Price_Per_Night");

            builder.HasData(
                new Property { Id = 1, Name = "Apartamento Central Lisboa", PricePerNight = 80.00m, CityId = 1 },
                new Property { Id = 2, Name = "Estúdio Moderno no Porto", PricePerNight = 65.50m, CityId = 2 },
                new Property { Id = 3, Name = "Apartamento Plaza Mayor", PricePerNight = 120.00m, CityId = 3 }
    );
        }
    }
}
