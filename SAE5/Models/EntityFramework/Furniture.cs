using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE501_Blazor_API.Models.EntityFramework
{
    [Table("t_e_furniture_fur")]
    public class Furniture
    {
        [Key]
        [Column("fur_id")]
        public int Id
        {
            get { return Id; }
            set
            {
                if (value > 0)
                    Id = value;
                else
                    throw new ArgumentException("Furniture Id error : Ids must be strictly positive");
            }
        }

        [Required]
        [Column("fur_name")]
        [MaxLength(50)]
        public string Name
        {
            get { return Name; }
            set
            {
                Name = value[0].ToString().ToUpper() + value.Substring(1).ToLower();
            }
        }

        [Required]
        [Column("fur_length")]
        public double Length
        {
            get { return Length; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Furniture Length error : length cannot be negative");
                Length = value;
            }
        }

        [Required]
        [Column("fur_width")]
        public double Width
        {
            get { return Width; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Furniture Width error : width cannot be negative");
                Width = value;
            }
        }

        [Required]
        [Column("fur_height")]
        public double Height
        {
            get { return Height; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Furniture Height error : height cannot be negative");
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
        [Column("fur_roomid")]
        public int RoomId
        {
            get { return Id; }
            set
            {
                if (value > 0)
                    Id = value;
                else
                    throw new ArgumentException("Furniture foreign key Id error : Ids must be strictly positive");
            }
        }

        [ForeignKey(nameof(RoomId))]
        [InverseProperty(nameof(Room.FurnituresOfRoom))]
        public Room Room { get; set; } = null!;

    }
}
