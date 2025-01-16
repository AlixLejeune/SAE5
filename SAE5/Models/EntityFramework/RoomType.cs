using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE501_Blazor_API.Models.EntityFramework
{
    [Table("t_e_roomtype_rty")]
    public class RoomType
    {
        [Key]
        [Column("rty_id")]
        public int Id { get; set; }

        [Required]
        [Column("rty_name")]
        [StringLength(30)]
        public string Name { get; set; }

        [InverseProperty(nameof(Room.RoomType))]
        public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}
