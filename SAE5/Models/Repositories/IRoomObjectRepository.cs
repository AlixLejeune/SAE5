using Microsoft.AspNetCore.Mvc;

namespace SAE501_Blazor_API.Models.Repositories
{
    public interface IRoomObjectRepository<RoomObject>
    {
        Task<ActionResult<IEnumerable<RoomObject>>> GetAllAsync();
        Task<ActionResult<RoomObject>> GetByIdAsync(int id);
        Task<ActionResult<RoomObject>> GetByNameAsync(string customName);
    }
}
