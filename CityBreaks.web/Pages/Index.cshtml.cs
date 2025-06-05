using CityBreaks.Web.Models;
using CityBreaks.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CityBreaks.Web.Pages
{
    public class IndexModel(ICityService cityService) : PageModel
    {
        private readonly ICityService _cityService = cityService;

        public required List<City> Cities { get; set; }

        public async Task OnGetAsync()
        {
            Cities = await _cityService.GetAllAsync();
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _cityService.DeletePropertyAsync(id);
            return RedirectToPage();
        }
    }


}
