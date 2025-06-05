using CityBreaks.Web.Data;
using CityBreaks.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CityBreaks.Web.Pages
{
    public class CreatePropertyModel(CityBreaksContext context) : PageModel
    {
        private readonly CityBreaksContext _context = context;

        [BindProperty]
        public Property Property { get; set; } = new();

        public SelectList Cities { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var cities = await _context.Cities
                .OrderBy(c => c.Name)
                .ToListAsync();

            Cities = new SelectList(cities, nameof(City.Id), nameof(City.Name));
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await OnGetAsync(); // recarrega dropdown se houver erro
                return Page();
            }

            _context.Properties.Add(Property);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
