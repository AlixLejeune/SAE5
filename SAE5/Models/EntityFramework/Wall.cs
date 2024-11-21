using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE501_Blazor_API.Models.EntityFramework
{
    [Table("t_e_wall_wal")]
    public class Wall
    {
        [Key]
        [Column("wal_id")]
        public int Id
        {
            get { return Id; }
            set
            {
                if (value > 0)
                    Id = value;
                else
                    throw new ArgumentException("Wall Id error : Ids must be strictly positive");
            }
        }

        [Required]
        [Column("wal_length")]
        public double Length
        {
            get { return Length; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Wall Length error : length cannot be negative");
                Length = value;
            }
        }

        [Required]
        [Column("wal_height")]
        public double Height
        {
            get { return Height; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Wall Height error : height cannot be negative");
                Height = value;
            }
        }

        [Required]
        [Column("fk_wal_roomid")]
        public int RoomId
        {
            get { return RoomId; }
            set
            {
                if (value > 0)
                    Id = value;
                else
                    throw new ArgumentException("Wall foreign RoomId error : Ids must be strictly positive");
            }
        }

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
