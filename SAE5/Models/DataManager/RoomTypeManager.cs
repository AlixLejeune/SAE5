using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE501_Blazor_API.Models.DTO;
using SAE501_Blazor_API.Models.EntityFramework;
using SAE501_Blazor_API.Models.Repositories;

namespace SAE501_Blazor_API.Models.DataManager
{
    public class RoomTypeManager : IRoomTypeRepository
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
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(RoomType roomTypeToDelete)
        {
            _context.roomTypes.Remove(roomTypeToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<ActionResult<IEnumerable<RoomTypeDTO>>> GetAllDTOAsync()
        {
            return await _context.roomTypes.Include(t => t.Rooms)
                .ThenInclude(r => r.Building)
                .Select(t => new RoomTypeDTO()
                {
                    Id = t.Id,
                    Name = t.Name,
                    Rooms = t.Rooms.Select(r => new RoomTypeDTO.RoomDTO()
                    {
                        Id = r.Id,
                        Name = r.Name,
                        BuildingName = r.Building.Name
                    }).ToList()
                })
                .ToListAsync();
        }

        public async Task<RoomType> AddFromDTOAsync(RoomTypeDTO roomDto)
        {
            var roomType = new RoomType()
            {
                Id = roomDto.Id,
                Name = roomDto.Name
            };
            await AddAsync(roomType);
            return roomType;
        }

        public async Task UpdateFromDTOAsync(RoomType roomTypeToUpdate, RoomTypeDTO roomDto)
        {
            _context.Entry(roomTypeToUpdate).State = EntityState.Modified;
            roomTypeToUpdate.Name = roomDto.Name;
            await _context.SaveChangesAsync();
        }
    }
}
