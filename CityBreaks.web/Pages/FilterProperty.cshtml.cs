using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CityBreaks.Web.Services;
using CityBreaks.Web.Models;

namespace CityBreaks.Web.Pages;

public class FilterPropertiesModel(IPropertyService propertyService) : PageModel
{
    private readonly IPropertyService _propertyService = propertyService;

    public List<Property>? Properties { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? PropertyName { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? CityName { get; set; }

    [BindProperty(SupportsGet = true)]
    public decimal? MinPrice { get; set; }

    [BindProperty(SupportsGet = true)]
    public decimal? MaxPrice { get; set; }

    public async Task OnGetAsync()
    {
        Properties = await _propertyService.GetFilteredAsync(MinPrice, MaxPrice, CityName, PropertyName);
    }
}
