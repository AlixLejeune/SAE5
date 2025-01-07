


using System.ComponentModel.DataAnnotations.Schema;

namespace SAE501_Blazor_API.Models.EntityFramework.RoomObjects.ConnectedObjects
{
    [Table("t_e_connectedobjects_cobj")]
    public class ConnectedObject : RoomObject
    {
        [Column("cobj_id")]
        public string CustomId;
    }
}
