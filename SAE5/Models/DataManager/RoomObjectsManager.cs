using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE501_Blazor_API.Models.EntityFramework;
using SAE501_Blazor_API.Models.EntityFramework.RoomObjects;
using SAE501_Blazor_API.Models.Repositories;

namespace SAE501_Blazor_API.Models.DataManager
{
    public class RoomObjectsManager : IRoomObjectRepository
    {
        readonly DataContext _context;

        public RoomObjectsManager() { }

        public RoomObjectsManager(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<RoomObject>>> GetAllAsync()
        {
            return await _context.roomObjects.ToListAsync();
        }

        public async Task<ActionResult<RoomObject>> GetByIdAsync(int id)
        {
            return await _context.roomObjects.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task AddAsync(RoomObject entity)
        {
            await _context.roomObjects.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RoomObject originalRoomObject, RoomObject updatedRoomObject)
        {
            _context.Entry(originalRoomObject).State = EntityState.Modified;
            originalRoomObject.CustomName = updatedRoomObject.CustomName;
            originalRoomObject.IdRoom = updatedRoomObject.IdRoom;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(RoomObject roomObjectToDelete)
        {
            _context.roomObjects.Remove(roomObjectToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
