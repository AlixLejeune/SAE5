using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE501_Blazor_API.Models.EntityFramework
{
    [Table("t_e_building_bui")]
    public class Building
    {
        [Key]
        [Column("bui_id")]
        public int Id { get; set; }

        [Required]
        [Column("bui_name")]
        [StringLength(50)]
        public string Name { get; set; }

        [InverseProperty(nameof(Room.Building))]
        public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}
