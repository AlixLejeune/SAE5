using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE501_Blazor_API.Models.EntityFramework;
using SAE501_Blazor_API.Models.Repositories;

namespace SAE501_Blazor_API.Models.DataManager
{
    public class RoomManager : IDataRepository<Room>
    {
        readonly DataContext _context;

        public RoomManager() { }

        public RoomManager(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Room>>> GetAllAsync()
        {
            return await _context.rooms.ToListAsync();
        }

        public async Task<ActionResult<Room>> GetByIdAsync(int id)
        {
            return await _context.rooms.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task AddAsync(Room entity)
        {
            await _context.rooms.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Room originalRoom, Room updatedRoom)
        {
            _context.Entry(originalRoom).State = EntityState.Modified;
            originalRoom.Code = updatedRoom.Code;
            originalRoom.BuildingId = updatedRoom.BuildingId;
            originalRoom.BuildingRoom = updatedRoom.BuildingRoom;
            originalRoom.RoomTypeId = updatedRoom.RoomTypeId;
            originalRoom.RoomTypeOfRoom = updatedRoom.RoomTypeOfRoom;
            originalRoom.FurnituresOfRoom = updatedRoom.FurnituresOfRoom;
            originalRoom.WallsOfRoom = updatedRoom.WallsOfRoom;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Room roomToDelete)
        {
            _context.rooms.Remove(roomToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
