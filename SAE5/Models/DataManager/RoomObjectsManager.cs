using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE501_Blazor_API.Models.DTO;
using SAE501_Blazor_API.Models.EntityFramework;
using SAE501_Blazor_API.Models.EntityFramework.RoomObjects;
using SAE501_Blazor_API.Models.Repositories;

namespace SAE501_Blazor_API.Models.DataManager
{
    public class RoomObjectsManager : IRoomObjectRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public RoomObjectsManager() { }

        public RoomObjectsManager(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

            var typeToMap = updatedRoomObject.GetType();
            _mapper.Map(updatedRoomObject, originalRoomObject, typeToMap, typeToMap);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(RoomObject roomObjectToDelete)
        {
            _context.roomObjects.Remove(roomObjectToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<ActionResult<IEnumerable<RoomObjectRoomDTO>>> GetAllRoomsDTOAsync()
        {
            return await _context.rooms
                .Include(r => r.Building)
                .Include(r => r.ObjectsOfRoom)
                .Select(r => new RoomObjectRoomDTO()
                    {
                        Id = r.Id,
                        Name = r.Name,
                        BuildingName = r.Building.Name,
                        RoomObjects = r.ObjectsOfRoom
                    })
                .ToListAsync();
        }
    }
}
