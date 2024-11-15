using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE501_Blazor_API.Models.EntityFramework
{
    [Table("t_e_roomtype_rty")]
    public class RoomType
    {
        [Key]
        [Column("rty_id")]
        public int Id
        {
            get { return Id; }
            set
            {
                if (value > 0)
                    Id = value;
                else
                    throw new ArgumentException("RoomType Id error : Ids must be strictly positive");
            }
        }

        [Required]
        [MaxLength(25)]
        [Column("rty_name")]
        public string Name { get; set; }

        [InverseProperty(nameof(Room.RoomTypeOfRoom))]
        public ICollection<Room> RoomsOfSuchRoomType { get; set; } = null!;
    }
}
