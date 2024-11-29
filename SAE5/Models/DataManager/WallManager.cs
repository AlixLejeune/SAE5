using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE501_Blazor_API.Models.EntityFramework;
using SAE501_Blazor_API.Models.Repositories;

namespace SAE501_Blazor_API.Models.DataManager
{
    public class WallManager : IDataRepository<Wall>
    {
        readonly DataContext _context;

        public WallManager() { }

        public WallManager(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Wall>>> GetAllAsync()
        {
            return await _context.walls.ToListAsync();
        }

        public async Task<ActionResult<Wall>> GetByIdAsync(int id)
        {
            return await _context.walls.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task AddAsync(Wall entity)
        {
            await _context.walls.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Wall originalWall, Wall updatedWall)
        {
            _context.Entry(originalWall).State = EntityState.Modified;
            originalWall.Length = updatedWall.Length;
            originalWall.Height = updatedWall.Height;
            originalWall.RoomId = updatedWall.RoomId;
            originalWall.Room = updatedWall.Room;
            originalWall.WindowsOfWall = updatedWall.WindowsOfWall;
            originalWall.DoorsOfWall = updatedWall.DoorsOfWall;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Wall wallToDelete)
        {
            _context.walls.Remove(wallToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
