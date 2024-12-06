using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE501_Blazor_API.Models.EntityFramework
{
    [Table("t_e_room_roo")]
    public class Room
    {
        private string code;

        [Key]
        [Column("roo_id")]
        public int Id { get; set; }

        //3-digits room code
        [Required]
        [Column("roo_code")]
        public string Code
        {
            get { return code; }
            set
            {
                if (int.TryParse(value, out int result) && result >= 0 && result < 1000)
                    code = value;
                else
                    throw new ArgumentException("Room Code error : room code have to be a 3 digit code");
            }
        }

        /* #region room size ?
        [Required]
        [Column("roo_length")]
        public double Length
        {
            get { return Length; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Room Length error : length cannot be negative");
                Length = value;
            }
        }

        [Required]
        [Column("roo_width")]
        public double Width
        {
            get { return Width; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Room Width error : width cannot be negative");
                Width = value;
            }
        }

        [Required]
        [Column("roo_height")]
        public double Height
        {
            get { return Height; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Room Height error : height cannot be negative");
                Height = value;
            }
        }*/

        public double Area()
        {
            if (WallsOfRoom == null || WallsOfRoom.Count == 0)
                throw new ArgumentNullException("Room Area Exception : no walls in this room.");
            else if (WallsOfRoom.Count == 4)
            {
                IEnumerable<Wall> walls = WallsOfRoom.OrderBy(wall => wall.Length);
                return walls.First().Length * walls.Last().Length;
            }
            else if (WallsOfRoom.Count == 3)
            {
                List<Wall> walls = WallsOfRoom.ToList();
                return 0.25 * Math.Sqrt(walls[0].Length + walls[1].Length + walls[2].Length);
            }
            else
                throw new Exception("Room Area Exception : this room is not a triangle or a rectangle, area is not defined for those cases.");
                
        }

        public double Volume() 
        {
            return Area() * WallsOfRoom.First().Height;
        }


        [Required]
        [Column("fk_roo_buildingid")]
        public int BuildingId { get; set; }

        [Required]
        [Column("fk_roo_roomtypeid")]
        public int RoomTypeId { get; set; }

        [ForeignKey(nameof(BuildingId))]
        [InverseProperty(nameof(Building.RoomsOfBuilding))]
        public Building BuildingRoom { get; set; } = null!;

        [ForeignKey(nameof(RoomTypeId))]
        [InverseProperty(nameof(RoomType.RoomsOfSuchRoomType))]
        public RoomType RoomTypeOfRoom { get; set; } = null!;

        [InverseProperty(nameof(Furniture.Room))]
        public ICollection<Furniture> FurnituresOfRoom { get; set; } = null!;

        [InverseProperty(nameof(Wall.Room))]
        public ICollection<Wall> WallsOfRoom { get; set; } = null!;
        

    }
}
