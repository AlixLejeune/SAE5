using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE501_Blazor_API.Models.EntityFramework
{
    [Table("t_e_window_win")]
    public class Window
    {
        [Key]
        [Column("win_id")]
        public int Id
        {
            get { return Id; }
            set
            {
                if (value > 0)
                    Id = value;
                else
                    throw new ArgumentException("Window Id error : Ids must be strictly positive");
            }
        }

        [Required]
        [Column("doo_length")]
        public double Length
        {
            get { return Length; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Window Length error : length cannot be negative");
                Length = value;
            }
        }

        [Required]
        [Column("win_height")]
        public double Height
        {
            get { return Height; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Window Height error : height cannot be negative");
                Height = value;
            }
        }

        [Column("fk_win_wallid")]
        public int WallId
        {
            get { return Id; }
            set
            {
                if (value > 0)
                    Id = value;
                else
                    throw new ArgumentException("Window foreign WallId error : Ids must be strictly positive");
            }
        }

        [ForeignKey(nameof(WallId))]
        [InverseProperty(nameof(Wall.WindowsOfWall))]
        public Wall Wall { get; set; } = null!;

    }
}
