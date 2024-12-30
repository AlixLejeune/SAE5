using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SAE501_Blazor_API.Models.EntityFramework.RoomObjects;
using System.Numerics;

namespace SAE501_Blazor_API.Models.EntityFramework
{
    [Table("t_e_room_roo")]
    public class Room
    {
        [Key]
        [Column("roo_id")]
        public int Id { get; set; }

        [Required]
        [Column("roo_name")]
        public string Name { get; set; }

        [Column("roo_northorientation")]
        public double NorthOrientation { get; set; }

        [Required]
        [Column("roo_height")]
        public double Height { get; set; }

        [Required]
        [Column("roo_base")]
        public List<Vector2D> Base { get; set; }

        [Required]
        [Column("roo_buildingid")]
        public int IdBuilding { get; set; }

        [ForeignKey(nameof(IdBuilding))]
        [InverseProperty(nameof(Building.Rooms))]
        public virtual Building Building { get; set; }

        [Required]
        [Column("roo_idroomtype")]
        public int IdRoomType { get; set; }

        [ForeignKey(nameof(IdRoomType))]
        [InverseProperty(nameof(RoomType.Rooms))]
        public virtual RoomType RoomType { get; set; }


        [InverseProperty(nameof(RoomObject.Room))]
        public virtual List<RoomObject> ObjectsOfRoom { get; set; } = new List<RoomObject>();
    }

    
}
