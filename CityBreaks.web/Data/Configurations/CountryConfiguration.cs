using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CityBreaks.Web.Models;

namespace CityBreaks.Web.Data.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.Property(c => c.CountryName)
                   .HasMaxLength(100)
                   .HasColumnName("Country_Name");

            builder.Property(c => c.CountryCode)
                   .HasColumnName("Country_Code");

            // Seed Data
            builder.HasData(
                new Country { Id = 1, CountryCode = "PT", CountryName = "Portugal" },
                new Country { Id = 2, CountryCode = "ES", CountryName = "Espanha" }
            );
        }
    }
}
