using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1.Models
{
    [Table("t_e_building_bui")]
    public class Building
    {
        [Key]
        [Column("bui_id")]
        public int Id { get; set; }

        [Required]
        [Column("bui_name")]
        public string Name { get; set; }

        [InverseProperty(nameof(Room.IdBuilding))]
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
