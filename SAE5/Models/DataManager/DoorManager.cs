using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE501_Blazor_API.Models.EntityFramework;
using SAE501_Blazor_API.Models.Repositories;

namespace SAE501_Blazor_API.Models.DataManager
{
    public class DoorManager : IDataRepository<Door>
    {
        readonly DataContext _context;

        public DoorManager() { }

        public DoorManager(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Door>>> GetAllAsync()
        {
            return await _context.doors.ToListAsync();
        }

        public async Task<ActionResult<Door>> GetByIdAsync(int id)
        {
            return await _context.doors.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task AddAsync(Door entity)
        {
            await _context.doors.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Door originalDoor, Door updatedDoor)
        {
            _context.Entry(originalDoor).State = EntityState.Modified;
            originalDoor.Length = updatedDoor.Length;
            originalDoor.Height = updatedDoor.Height;
            originalDoor.WallId = updatedDoor.WallId;
            originalDoor.Wall = updatedDoor.Wall;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Door doorToDelete)
        {
            _context.doors.Remove(doorToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
