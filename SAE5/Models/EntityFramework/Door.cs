using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE501_Blazor_API.Models.EntityFramework
{
    [Table("t_e_door_doo")]
    public class Door
    {
        [Key]
        [Column("doo_id")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Ids must be positive")]
        public int Id { get; set; }

        [Required]
        [Column("doo_length")]
        [Range(0, Double.MaxValue, ErrorMessage = "Lengths must be positive")]
        public double Length { get; set; }

        [Required]
        [Column("doo_height")]
        [Range(0, Double.MaxValue, ErrorMessage = "Heights must be positive")]
        public double Height { get; set; }

        [Column("fk_doo_wallid")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Ids must be positive")]
        public int WallId { get; set; }

        [ForeignKey(nameof(WallId))]
        [InverseProperty(nameof(Wall.DoorsOfWall))]
        public Wall Wall { get; set; } = null!;
    }
}
