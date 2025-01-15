using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE501_Blazor_API.Models.EntityFramework;
using SAE501_Blazor_API.Models.Repositories;

namespace SAE501_Blazor_API.Models.DataManager
{
    public class RoomManager : IRoomRepository
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
            return await _context.rooms.Include(r => r.ObjectsOfRoom).Include(r => r.Building).FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task AddAsync(Room entity)
        {
            if(entity.Base.Count < 3)
            {
                throw new ArgumentException("Less than 3 vectors in room base, unable to create a valide 2D shape.");
            }

            await _context.rooms.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Room originalRoom, Room updatedRoom)
        {
            _context.Entry(originalRoom).State = EntityState.Modified;
            originalRoom.Name = updatedRoom.Name;
            originalRoom.NorthOrientation = updatedRoom.NorthOrientation;
            originalRoom.Height = updatedRoom.Height;

            if (updatedRoom.Base.Count < 3)
                throw new ArgumentException("Less than 3 vectors in room base, unable to create a valide 2D shape.");

            originalRoom.Base = updatedRoom.Base;
            originalRoom.IdBuilding = updatedRoom.IdBuilding;
            originalRoom.IdRoomType = updatedRoom.IdRoomType;

            if(updatedRoom.ObjectsOfRoom is not null)
                originalRoom.ObjectsOfRoom = updatedRoom.ObjectsOfRoom;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Room roomToDelete)
        {
            _context.rooms.Remove(roomToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
