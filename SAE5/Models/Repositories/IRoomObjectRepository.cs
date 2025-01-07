using Microsoft.AspNetCore.Mvc;
using SAE501_Blazor_API.Models.EntityFramework.RoomObjects;

namespace SAE501_Blazor_API.Models.Repositories
{
    public interface IRoomObjectRepository<TRoomObject> where TRoomObject : RoomObject
    {
        Task<ActionResult<IEnumerable<TRoomObject>>> GetAllAsync();
        Task<ActionResult<TRoomObject>> GetByIdAsync(int id);
        Task<ActionResult<TRoomObject>> GetByNameAsync(string customName);
    }
}
