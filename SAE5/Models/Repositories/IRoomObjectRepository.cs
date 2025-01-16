using Microsoft.AspNetCore.Mvc;
using SAE501_Blazor_API.Models.DTO;
using SAE501_Blazor_API.Models.EntityFramework.RoomObjects;

namespace SAE501_Blazor_API.Models.Repositories
{
    public interface IRoomObjectRepository : IDataRepository<RoomObject>
    {
        Task<ActionResult<IEnumerable<RoomObjectRoomDTO>>> GetAllRoomsDTOAsync();
    }
}
