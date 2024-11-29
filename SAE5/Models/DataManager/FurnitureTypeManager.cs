using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE501_Blazor_API.Models.EntityFramework;
using SAE501_Blazor_API.Models.Repositories;

namespace SAE501_Blazor_API.Models.DataManager
{
    public class FurnitureTypeManager : IDataRepository<FurnitureType>
    {
        readonly DataContext _context;

        public FurnitureTypeManager() { }

        public FurnitureTypeManager(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<FurnitureType>>> GetAllAsync()
        {
            return await _context.furnitureTypes.ToListAsync();
        }

        public async Task<ActionResult<FurnitureType>> GetByIdAsync(int id)
        {
            return await _context.furnitureTypes.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task AddAsync(FurnitureType entity)
        {
            await _context.furnitureTypes.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(FurnitureType originalFurnitureType, FurnitureType updatedFurnitureType)
        {
            _context.Entry(originalFurnitureType).State = EntityState.Modified;
            originalFurnitureType.Name = updatedFurnitureType.Name;
            originalFurnitureType.FurnituresOfSuchType = updatedFurnitureType.FurnituresOfSuchType;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(FurnitureType furnitureTypeToDelete)
        {
            _context.furnitureTypes.Remove(furnitureTypeToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
