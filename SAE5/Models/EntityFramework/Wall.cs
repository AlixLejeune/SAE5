using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE501_Blazor_API.Models.EntityFramework
{
    [Table("t_e_wall_wal")]
    public class Wall
    {
        [Key]
        [Column("wal_id")]
        public int Id { get; set; }

        [Required]
        [Column("wal_length")]
        [Range(0, Double.MaxValue, ErrorMessage = "Lengths must be positive")]
        public double Length { get; set; }

        [Required]
        [Column("wal_height")]
        [Range(0, Double.MaxValue, ErrorMessage = "Heights must be positive")]
        public double Height { get; set; }

        [Required]
        [Column("fk_wal_roomid")]
        public int RoomId { get; set; }

        public double Area()
        {
            return Height * Length;
        }

        [ForeignKey(nameof(RoomId))]
        [InverseProperty(nameof(Room.WallsOfRoom))]
        public Room Room { get; set; } = null!;

        [InverseProperty(nameof(Window.Wall))]
        public ICollection<Window> WindowsOfWall { get; set; } = null!;

        [InverseProperty(nameof(Door.Wall))]
        public ICollection<Door> DoorsOfWall { get; set; } = null!;
    }
}
