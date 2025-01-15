using SAE501_Blazor_API.Models.EntityFramework;

namespace SAE501_Blazor_API.Models.DTO
{
    public class RoomTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<RoomDTO> Rooms { get; set; }

        public class RoomDTO
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string BuildingName { get; set; }
        }
    }
}
