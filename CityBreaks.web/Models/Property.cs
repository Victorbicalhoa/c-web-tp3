namespace CityBreaks.Web.Models
{
    public class Property
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal PricePerNight { get; set; }

        // Foreign key
        public int CityId { get; set; }

        // Navigation property
        public City? City { get; set; }

        // Soft delete
        public DateTime? DeletedAt { get; set; }

    }
}
