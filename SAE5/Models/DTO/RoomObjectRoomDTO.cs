using SAE501_Blazor_API.Models.EntityFramework.RoomObjects;

namespace SAE501_Blazor_API.Models.DTO
{
    public class RoomObjectRoomDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BuildingName { get; set; }

        public List<RoomObject> RoomObjects { get; set; }
    }
}