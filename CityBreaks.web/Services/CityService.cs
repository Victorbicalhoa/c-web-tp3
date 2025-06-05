using Microsoft.EntityFrameworkCore;
using CityBreaks.Web.Data;
using CityBreaks.Web.Models;

namespace CityBreaks.Web.Services
{
    public class CityService(CityBreaksContext context) : ICityService
    {
        private readonly CityBreaksContext _context = context;

        public async Task<List<City>> GetAllAsync()
        {
            return await _context.Cities
                .Include(c => c.Country)
                .Include(c => c.Properties!.Where(p => p.DeletedAt == null))
                .ToListAsync();
        }

        public async Task<City?> GetByNameAsync(string name)
        {
            return await _context.Cities
                .Include(c => c.Country)
                .Include(c => c.Properties)
                .FirstOrDefaultAsync(c =>
                    EF.Functions.Collate(c.Name, "NOCASE") == name);
        }

        public async Task DeletePropertyAsync(int id)
        {
            var property = await _context.Properties.FindAsync(id);

            if (property != null && property.DeletedAt == null)
            {
                property.DeletedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
        }
    }
}
