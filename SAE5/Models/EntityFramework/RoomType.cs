using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1.Models
{
    [Table("t_e_roomtype_rty")]
    public class RoomType
    {
        [Key]
        [Column("rty_id")]
        public int Id { get; set; }

        [Required]
        [Column("rty_name")]
        public string Name { get; set; }

        [InverseProperty(nameof(Room.IdRoomType))]
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
