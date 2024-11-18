using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE501_Blazor_API.Models.EntityFramework
{
    [Table("t_e_room_roo")]
    public class Room
    {
        [Key]
        [Column("roo_id")]
        public int Id 
        { 
            get { return Id; }
            set
            {
                if (value > 0)
                    Id = value;
                else
                    throw new ArgumentException("Room Id error : Ids must be strictly positive");
            }
        }

        //3-digits room code
        [Required]
        [Column("roo_code")]
        public string Code
        {
            get { return Code; }
            set
            {
                if (int.TryParse(value, out int result) && result >= 0 && result < 1000)
                    Code = value;
                else
                    throw new ArgumentException("Room Code error : room code have to be a 3 digit code");
            }
        }

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
        }

        public double Area()
        {
            return Length * Width;
        }

        public double Volume() 
        {
            return Length * Width * Height; 
        }


        [Required]
        [Column("roo_buildingid")]
        public int BuildingId
        {
            get { return BuildingId; }
            set
            {
                if (value > 0)
                    Id = value;
                else
                    throw new ArgumentException("Room foreign building Id error : Ids must be strictly positive");
            }
        }

        [Required]
        [Column("roo_roomtypeid")]
        public int RoomTypeId
        {
            get { return RoomTypeId; }
            set
            {
                if (value > 0)
                    Id = value;
                else
                    throw new ArgumentException("Room foreign RoomType Id error : Ids must be strictly positive");
            }
        }

        [ForeignKey(nameof(BuildingId))]
        [InverseProperty(nameof(Building.RoomsOfBuilding))]
        public Building BuildingRoom { get; set; } = null!;

        [ForeignKey(nameof(RoomTypeId))]
        [InverseProperty(nameof(RoomType.RoomsOfSuchRoomType))]
        public RoomType RoomTypeOfRoom { get; set; } = null!;

        [InverseProperty(nameof(Furniture.Room))]
        public ICollection<Furniture> FurnituresOfRoom { get; set; } = null!;

        
    }
}
