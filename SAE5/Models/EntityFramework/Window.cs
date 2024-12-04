using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE501_Blazor_API.Models.EntityFramework
{
    [Table("t_e_window_win")]
    public class Window
    {
        [Key]
        [Column("win_id")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Ids must be positive")]
        public int Id { get; set; }

        [Required]
        [Column("win_length")]
        [Range(0, Double.MaxValue, ErrorMessage = "Lengths must be positive")]
        public double Length { get; set; }

        [Required]
        [Column("win_height")]
        [Range(0, Double.MaxValue, ErrorMessage = "Heights must be positive")]
        public double Height { get; set; }

        [Column("fk_win_wallid")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Ids must be positive")]
        public int WallId { get; set; }

        [ForeignKey(nameof(WallId))]
        [InverseProperty(nameof(Wall.WindowsOfWall))]
        public Wall Wall { get; set; } = null!;

    }
}
