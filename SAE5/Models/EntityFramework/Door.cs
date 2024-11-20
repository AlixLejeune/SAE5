using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE501_Blazor_API.Models.EntityFramework
{
    [Table("t_e_door_doo")]
    public class Door
    {
        [Key]
        [Column("doo_id")]
        public int Id
        {
            get { return Id; }
            set
            {
                if (value > 0)
                    Id = value;
                else
                    throw new ArgumentException("Door Id error : Ids must be strictly positive");
            }
        }

        [Required]
        [Column("doo_width")]
        public double Width
        {
            get { return Width; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Door Width error : width cannot be negative");
                Width = value;
            }
        }

        [Required]
        [Column("doo_height")]
        public double Height
        {
            get { return Height; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Door Height error : height cannot be negative");
                Height = value;
            }
        }

        [Column("fk_doo_wallid")]
        public int WallId
        {
            get { return Id; }
            set
            {
                if (value > 0)
                    Id = value;
                else
                    throw new ArgumentException("Door foreign WallId error : Ids must be strictly positive");
            }
        }

        [ForeignKey(nameof(WallId))]
        [InverseProperty(nameof(Wall.DoorsOfWall))]
        public Wall Wall { get; set; } = null!;
    }
}
