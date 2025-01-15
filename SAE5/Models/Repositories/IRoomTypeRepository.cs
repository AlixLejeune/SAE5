using Microsoft.AspNetCore.Mvc;
using SAE501_Blazor_API.Models.DTO;
using SAE501_Blazor_API.Models.EntityFramework;

namespace SAE501_Blazor_API.Models.Repositories
{
    public interface IRoomTypeRepository : IDataRepository<RoomType>
    {
        Task<ActionResult<IEnumerable<RoomTypeDTO>>> GetAllDTOAsync();
        Task<RoomType> AddFromDTOAsync(RoomTypeDTO roomDto);
        Task UpdateFromDTOAsync(RoomType roomTypeToUpdate, RoomTypeDTO roomDto);
    }
}
