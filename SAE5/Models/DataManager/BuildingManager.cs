using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE501_Blazor_API.Models.EntityFramework;
using SAE501_Blazor_API.Models.Repositories;

namespace SAE501_Blazor_API.Models.DataManager
{
    public class BuildingManager : IBuildingRepository
    {
        readonly DataContext _context;

        public BuildingManager() { }

        public BuildingManager(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Building>>> GetAllAsync()
        {
            return await _context.buildings.Include(b => b.Rooms).ThenInclude(r => r.RoomType).ToListAsync();
        }

        public async Task<ActionResult<Building>> GetByIdAsync(int id)
        {
            return await _context.buildings.Include(b => b.Rooms).FirstOrDefaultAsync(b => b.Id == id);
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
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Building buildingToDelete)
        {
            _context.buildings.Remove(buildingToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
