using Microsoft.AspNetCore.Mvc;
using SAE501_Blazor_API.Models.DTO;
using SAE501_Blazor_API.Models.EntityFramework;

namespace SAE501_Blazor_API.Models.Repositories
{
    public interface IBuildingRepository : IDataRepository<Building>
    {
        Task<ActionResult<IEnumerable<BuildingListElementDTO>>> GetAllDTOAsync();
    }
}
