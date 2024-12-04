using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace SAE501_Blazor_API.Models.EntityFramework
{
    [Table("t_e_building_bui")]
    public class Building
    {
        private string name;

        [Key]
        [Column("bui_id")]
        [Range(1,Int32.MaxValue, ErrorMessage = "Ids must be positive")]
        public int Id { get; set; }

        //Letter identifier for each building
        [Required]
        [MaxLength(1)]
        [Column("bui_letter")]
        [RegularExpression("^[A-Z]$", ErrorMessage = "Not an upper case letter")]
        public string Letter { get; set; }

        [Required]
        [Column("bui_name")]
        [MaxLength(50)]
        public string Name
        {
            get { return name; }
            set
            {
                name = Char.ToUpper(value[0]) + value.Substring(1).ToLower();
            }
        }

        [InverseProperty(nameof(Room.BuildingRoom))]
        public ICollection<Room> RoomsOfBuilding { get; set; } = null!;


    }
}
