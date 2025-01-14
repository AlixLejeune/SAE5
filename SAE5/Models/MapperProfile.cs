using AutoMapper;
using SAE501_Blazor_API.Models.DTO;
using SAE501_Blazor_API.Models.EntityFramework;
using SAE501_Blazor_API.Models.EntityFramework.RoomObjects;
using SAE501_Blazor_API.Models.EntityFramework.RoomObjects.ConnectedObjects;
using System.Reflection;

namespace SAE501_Blazor_API.Models
{
    public class MapperProfile : Profile
    {
        private static readonly Type[] ROOM_OBJECT_TYPES = 
            Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.IsAssignableTo(typeof(RoomObject)) && !t.IsAbstract).ToArray();

        public MapperProfile()
        {
            foreach (var type in ROOM_OBJECT_TYPES) CreateMap(type, type);
        }
    }
}
