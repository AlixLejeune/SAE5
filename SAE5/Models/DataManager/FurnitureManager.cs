using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE501_Blazor_API.Models.EntityFramework;
using SAE501_Blazor_API.Models.Repositories;

namespace SAE501_Blazor_API.Models.DataManager
{
    public class FurnitureManager : IDataRepository<Furniture>
    {
        readonly DataContext _context;

        public FurnitureManager() { }

        public FurnitureManager(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Furniture>>> GetAllAsync()
        {
            return await _context.furnitures.ToListAsync();
        }

        public async Task<ActionResult<Furniture>> GetByIdAsync(int id)
        {
            return await _context.furnitures.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task AddAsync(Furniture entity)
        {
            await _context.furnitures.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Furniture originalFurniture, Furniture updatedFurniture)
        {
            _context.Entry(originalFurniture).State = EntityState.Modified;
            originalFurniture.Name = updatedFurniture.Name;
            originalFurniture.Length = updatedFurniture.Length;
            originalFurniture.Width = updatedFurniture.Width;
            originalFurniture.Height = updatedFurniture.Height;
            originalFurniture.X = updatedFurniture.X;
            originalFurniture.Y = updatedFurniture.Y;
            originalFurniture.Z = updatedFurniture.Z;
            originalFurniture.RoomId = updatedFurniture.RoomId;
            originalFurniture.Room = updatedFurniture.Room;
            originalFurniture.FurnitureTypeId = updatedFurniture.FurnitureTypeId;
            originalFurniture.Type = updatedFurniture.Type;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Furniture FurnitureToDelete)
        {
            _context.furnitures.Remove(FurnitureToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
