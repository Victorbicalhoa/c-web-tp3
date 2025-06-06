using CityBreaks.Web.Models;
using CityBreaks.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CityBreaks.Web.Pages
{
    public class CityDetailsModel(ICityService cityService) : PageModel
    {
        private readonly ICityService _cityService = cityService;

        public City? City { get; set; }

        public async Task<IActionResult> OnGetAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
                return NotFound();

            City = await _cityService.GetByNameAsync(name);

            if (City == null)
                return NotFound();

            return Page();
        }
    }
}
