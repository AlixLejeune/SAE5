using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE501_Blazor_API.Models.EntityFramework
{
    [Table("t_e_furniture_fur")]
    public class Furniture : Spatial
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
        public override double Length
        {
            get { return Length; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Furniture Length error : length cannot be negative");
                Length = value;
            }
        }

        [Required]
        [Column("fur_width")]
        public override double Width
        {
            get { return Width; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Furniture Width error : width cannot be negative");
                Width = value;
            }
        }

        [Required]
        [Column("fur_height")]
        public override double Height
        {
            get { return Height; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Furniture Height error : height cannot be negative");
                Height = value;
            }
        }

        [Required]
        [Column("fur_x")]
        public override double X
        {
            get { return X; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Furniture X coordinate error : X cannot be negative");
                X = value;
            }
        }

        [Required]
        [Column("fur_y")]
        public override double Y
        {
            get { return Y; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Furniture Y coordinate error : Y cannot be negative");
                Y = value;
            }
        }

        [Required]
        [Column("fur_Z")]
        public override double Z
        {
            get { return Z; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Furniture Z coordinate error : Z cannot be negative");
                Z = value;
            }
        }

        [Required]
        [Column("fk_fur_roomid")]
        public int RoomId
        {
            get { return Id; }
            set
            {
                if (value > 0)
                    Id = value;
                else
                    throw new ArgumentException("Furniture Room foreign key Id error : Ids must be strictly positive");
            }
        }

        [Required]
        [Column("fk_fur_furnituretypeid")]
        public int FurnitureTypeId
        {
            get { return Id; }
            set
            {
                if (value > 0)
                    Id = value;
                else
                    throw new ArgumentException("Furniture FurnitureType foreign key Id error : Ids must be strictly positive");
            }
        }

        [ForeignKey(nameof(RoomId))]
        [InverseProperty(nameof(Room.FurnituresOfRoom))]
        public Room Room { get; set; } = null!;

        [ForeignKey(nameof(FurnitureTypeId))]
        [InverseProperty(nameof(FurnitureType.FurnituresOfSuchType))]
        public FurnitureType Type { get; set; } = null!;

    }
}
