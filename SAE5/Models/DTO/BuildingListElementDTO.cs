using SAE501_Blazor_API.Models.EntityFramework;
using SAE501_Blazor_API.Models.EntityFramework.RoomObjects;
using System.Text.Json.Serialization;

namespace SAE501_Blazor_API.Models.DTO
{
    public class BuildingListElementDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BuildingListRoomDTO> Rooms { get; set; }
    }

    public class BuildingListRoomDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RoomTypeName { get; set; }
        public List<BuildingListRoomObjectDTO> EmptyObjects { get; set; }
    }

    // Hack : Sending only three properties, and building true (empty) objects Client-side to have Type logic
    public class BuildingListRoomObjectDTO
    {
        [JsonPropertyName(nameof(RoomObjectType))]
        public string RoomObjectType { get; set; }
        public int Id { get; set; }
        public string? CustomName { get; set; }
    }
}
