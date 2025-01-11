using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE501_Blazor_API.Models.EntityFramework.RoomObjects;
using SAE501_Blazor_API.Models.EntityFramework;
using SAE501_Blazor_API.Models.Repositories;

namespace SAE501_Blazor_API.Models.DataManager
{
    public class HeaterManager : IDataRepository<Heater>
    {
        readonly DataContext _context;

        public HeaterManager() { }

        public HeaterManager(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Heater>>> GetAllAsync()
        {
            return await _context.heaters.ToListAsync();
        }

        public async Task<ActionResult<Heater>> GetByIdAsync(int id)
        {
            return await _context.heaters.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task AddAsync(Heater entity)
        {
            await _context.heaters.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Heater originalHeater, Heater updatedHeater)
        {
            _context.Entry(originalHeater).State = EntityState.Modified;
            originalHeater.CustomName = updatedHeater.CustomName;
            originalHeater.IdRoom = updatedHeater.IdRoom;
            originalHeater.PosX = updatedHeater.PosX;
            originalHeater.PosY = updatedHeater.PosY;
            originalHeater.PosZ = updatedHeater.PosZ;
            originalHeater.Orientation = updatedHeater.Orientation;
            originalHeater.SizeX = updatedHeater.SizeX;
            originalHeater.SizeY = updatedHeater.SizeY;
            originalHeater.SizeZ = updatedHeater.SizeZ;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Heater heaterToDelete)
        {
            _context.heaters.Remove(heaterToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
