using System.Collections.Generic;

namespace CityBreaks.Web.Models
{
    public class City
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public int CountryId { get; set; }
        public Country? Country { get; set; }

        // Navegação 1:N
        public List<Property>? Properties { get; set; }
    }
}
