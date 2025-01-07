using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE501_Blazor_API.Models.EntityFramework.RoomObjects;
using SAE501_Blazor_API.Models.EntityFramework;

namespace SAE501_Blazor_API.Models.DataManager
{
    public class TableManager
    {
        readonly DataContext _context;

        public TableManager() { }

        public TableManager(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Table>>> GetAllAsync()
        {
            return await _context.tables.ToListAsync();
        }

        public async Task<ActionResult<Table>> GetByIdAsync(int id)
        {
            return await _context.tables.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task AddAsync(Table entity)
        {
            await _context.tables.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Table originalTable, Table updatedTable)
        {
            _context.Entry(originalTable).State = EntityState.Modified;
            originalTable.CustomName = updatedTable.CustomName;
            originalTable.IdRoom = updatedTable.IdRoom;
            originalTable.PosX = updatedTable.PosX;
            originalTable.PosY = updatedTable.PosY;
            originalTable.PosZ = updatedTable.PosZ;
            originalTable.Orientation = updatedTable.Orientation;
            originalTable.SizeX = updatedTable.SizeX;
            originalTable.SizeY = updatedTable.SizeY;
            originalTable.SizeZ = updatedTable.SizeZ;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Table tableToDelete)
        {
            _context.tables.Remove(tableToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
