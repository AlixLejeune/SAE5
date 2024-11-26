using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE501_Blazor_API.Models.EntityFramework;

namespace SAE501_Blazor_API.Models.DataManager
{
    public class SensorManager
    {
        readonly DataContext _context;

        public SensorManager() { }

        public SensorManager(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Sensor>>> GetAllAsync()
        {
            return await _context.sensors.ToListAsync();
        }

        public async Task<ActionResult<Sensor>> GetByIdAsync(int id)
        {
            return await _context.sensors.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task AddAsync(Sensor entity)
        {
            await _context.sensors.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Sensor originalSensor, Sensor updatedSensor)
        {
            _context.Entry(originalSensor).State = EntityState.Modified;
            originalSensor.Length = updatedSensor.Length;
            originalSensor.Height = updatedSensor.Height;
            originalSensor.Width = updatedSensor.Width;
            originalSensor.X = updatedSensor.X;
            originalSensor.Y = updatedSensor.Y;
            originalSensor.Z = updatedSensor.Z;
            originalSensor.Name = updatedSensor.Name;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Sensor sensorToDelete)
        {
            _context.sensors.Remove(sensorToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
