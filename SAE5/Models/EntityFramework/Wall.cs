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
        [Column("wal_width")]
        public double Width
        {
            get { return Width; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Wall Width error : width cannot be negative");
                Width = value;
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

        public double Area()
        {
            return Height * Width;
        }
    }
}
