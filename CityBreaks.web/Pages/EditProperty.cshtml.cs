using CityBreaks.Web.Data;
using CityBreaks.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CityBreaks.Web.Pages;

public class EditPropertyModel(CityBreaksContext context) : PageModel
{
    private readonly CityBreaksContext _context = context;

    [BindProperty]
    public Property Property { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var property = await _context.Properties
            .Include(p => p.City)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (property == null)
        {
            return NotFound();
        }

        Property = property;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        var propertyToUpdate = await _context.Properties.FindAsync(id);

        if (propertyToUpdate == null)
        {
            return NotFound();
        }

        // Segurança: apenas campos autorizados são atualizados
        if (await TryUpdateModelAsync(propertyToUpdate, "Property",
            p => p.Name, p => p.PricePerNight))
        {
            await _context.SaveChangesAsync();
            return RedirectToPage("/Index");
        }

        return Page();
    }
}
