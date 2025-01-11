using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE501_Blazor_API.Models.EntityFramework.RoomObjects
{
    [Table("t_e_roomboject_rob")]
    public abstract class RoomObject
    {
        [Key]
        [Column("rob_id")]
        public int Id { get; set; }

        [Required]
        [Column("rob_name")]
        public string CustomName { get; set; }

        [Required]
        [Column("rob_roomid")]
        public int IdRoom { get; set; }

        [ForeignKey(nameof(IdRoom))]
        [InverseProperty(nameof(Room.ObjectsOfRoom))]
        public virtual Room Room { get; set; } = null!;
    }
}
