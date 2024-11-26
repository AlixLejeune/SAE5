using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE501_Blazor_API.Models.EntityFramework;

namespace SAE501_Blazor_API.Models.DataManager
{
    public class RoomTypeManager
    {
        readonly DataContext _context;

        public RoomTypeManager() { }

        public RoomTypeManager(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<RoomType>>> GetAllAsync()
        {
            return await _context.roomTypes.ToListAsync();
        }

        public async Task<ActionResult<RoomType>> GetByIdAsync(int id)
        {
            return await _context.roomTypes.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task AddAsync(RoomType entity)
        {
            await _context.roomTypes.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RoomType originalRoomType, RoomType updatedRoomType)
        {
            _context.Entry(originalRoomType).State = EntityState.Modified;
            originalRoomType.Name = updatedRoomType.Name;
            originalRoomType.RoomsOfSuchRoomType = updatedRoomType.RoomsOfSuchRoomType;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(RoomType roomTypeToDelete)
        {
            _context.roomTypes.Remove(roomTypeToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
