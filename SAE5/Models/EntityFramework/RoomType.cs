using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE501_Blazor_API.Models.EntityFramework
{
    [Table("t_e_roomtype_rty")]
    public class RoomType
    {
        private string name;

        [Key]
        [Column("rty_id")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Ids must be positive")]
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        [Column("rty_name")]
        public string Name
        {
            get { return name; }
            set
            {
                name = value.ToUpper();
            }
        }

        [InverseProperty(nameof(Room.RoomTypeOfRoom))]
        public ICollection<Room> RoomsOfSuchRoomType { get; set; } = null!;
    }
}
