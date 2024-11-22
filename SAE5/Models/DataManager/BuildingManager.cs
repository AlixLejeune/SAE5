using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE501_Blazor_API.Models.EntityFramework;
using SAE501_Blazor_API.Models.Repositories;

namespace SAE501_Blazor_API.Models.DataManager
{
    public class BuildingManager : IDataRepository<Building>
    {
        readonly DataContext _context;

        public BuildingManager() { }

        public BuildingManager(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Building>>> GetAllAsync()
        {
            return await _context.buildings.ToListAsync();
        }

        public async Task<ActionResult<Building>> GetByIdAsync(int id)
        {
            return await _context.buildings.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task AddAsync(Building entity)
        {
            await _context.buildings.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Building originalBuilding, Building updatedBuilding)
        {
            _context.Entry(originalBuilding).State = EntityState.Modified;
            originalBuilding.Name = updatedBuilding.Name;
            originalBuilding.Letter = updatedBuilding.Letter;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Building buildingToDelete)
        {
            _context.buildings.Remove(buildingToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
