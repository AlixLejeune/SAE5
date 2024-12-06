using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE501_Blazor_API.Models.EntityFramework
{
    [Table("t_e_furniture_fur")]
    public class Furniture : Spatial
    {
        private string name;

        [Key]
        [Column("fur_id")]
        public int Id { get; set; }

        [Required]
        [Column("fur_name")]
        [MaxLength(50)]
        public string Name
        {
            get { return name; }
            set
            {
                name = value[0].ToString().ToUpper() + value.Substring(1).ToLower();
            }
        }

        [Required]
        [Column("fur_width")]
        [Range(0, Double.MaxValue, ErrorMessage = "Widths must be positive")]
        public override double Width { get; set; }

        [Required]
        [Column("fur_length")]
        [Range(0, Double.MaxValue, ErrorMessage = "Lengths must be positive")]
        public override double Length { get; set; }

        [Required]
        [Column("fur_height")]
        [Range(0, Double.MaxValue, ErrorMessage = "Heights must be positive")]
        public override double Height { get; set; }

        [Required]
        [Column("fur_x")]
        [Range(0, Double.MaxValue, ErrorMessage = "X coordinates must be positive")]
        public override double X { get; set; }

        [Required]
        [Column("fur_y")]
        [Range(0, Double.MaxValue, ErrorMessage = "Y coordinates must be positive")]
        public override double Y { get; set; }

        [Required]
        [Column("fur_z")]
        [Range(0, Double.MaxValue, ErrorMessage = "Z coordinates must be positive")]
        public override double Z { get; set; }

        [Required]
        [Column("fk_fur_roomid")]
        public int RoomId { get; set; }

        [Required]
        [Column("fk_fur_furnituretypeid")]
        public int FurnitureTypeId { get; set; }

        [ForeignKey(nameof(RoomId))]
        [InverseProperty(nameof(Room.FurnituresOfRoom))]
        public Room Room { get; set; } = null!;

        [ForeignKey(nameof(FurnitureTypeId))]
        [InverseProperty(nameof(FurnitureType.FurnituresOfSuchType))]
        public FurnitureType Type { get; set; } = null!;

    }
}
