using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE501_Blazor_API.Models.EntityFramework;
using SAE501_Blazor_API.Models.Repositories;

namespace SAE501_Blazor_API.Models.DataManager
{
    public class WindowManager : IDataRepository<Window>
    {
        readonly DataContext _context;

        public WindowManager() { }

        public WindowManager(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Window>>> GetAllAsync()
        {
            return await _context.windows.ToListAsync();
        }

        public async Task<ActionResult<Window>> GetByIdAsync(int id)
        {
            return await _context.windows.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task AddAsync(Window entity)
        {
            await _context.windows.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Window originalWindow, Window updatedWindow)
        {
            _context.Entry(originalWindow).State = EntityState.Modified;
            originalWindow.Length = updatedWindow.Length;
            originalWindow.Height = updatedWindow.Height;
            originalWindow.WallId = updatedWindow.WallId;
            originalWindow.Wall = updatedWindow.Wall;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Window windowToDelete)
        {
            _context.windows.Remove(windowToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
