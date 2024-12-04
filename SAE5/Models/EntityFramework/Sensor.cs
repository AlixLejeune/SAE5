using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE501_Blazor_API.Models.EntityFramework
{
    [Table("t_e_sensor_sen")]
    public class Sensor : Spatial
    {
        [Key]
        [Column("sen_id")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Ids must be positive")]
        public int Id { get; set; }

        [Required]
        [Column("sen_width")]
        [Range(0, Double.MaxValue, ErrorMessage = "Widths must be positive")]
        public override double Width { get; set; }

        [Required]
        [Column("sen_length")]
        [Range(0, Double.MaxValue, ErrorMessage = "Lengths must be positive")]
        public override double Length { get; set; }

        [Required]
        [Column("sen_height")]
        [Range(0, Double.MaxValue, ErrorMessage = "Heights must be positive")]
        public override double Height { get; set; }

        [Required]
        [Column("sen_x")]
        [Range(0, Double.MaxValue, ErrorMessage = "X coordinates must be positive")]
        public override double X { get; set; }

        [Required]
        [Column("sen_y")]
        [Range(0, Double.MaxValue, ErrorMessage = "Y coordinates must be positive")]
        public override double Y { get; set; }

        [Required]
        [Column("sen_z")]
        [Range(0, Double.MaxValue, ErrorMessage = "Z coordinates must be positive")]
        public override double Z { get; set; }

        [Required]
        [Column("sen_name")]
        public string Name { get; set; }

        
        
    }
}
