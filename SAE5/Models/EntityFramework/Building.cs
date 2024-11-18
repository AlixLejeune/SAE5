using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE501_Blazor_API.Models.EntityFramework
{
    [Table("t_e_building_bui")]
    public class Building
    {
        [Key]
        [Column("bui_id")]
        public int Id
        {
            get { return Id; }
            set
            {
                if (value > 0)
                    Id = value;
                else
                    throw new ArgumentException("Building Id error : Ids must be strictly positive");
            }
        }

        //Letter identifier for each building
        [Required]
        [MaxLength(1)]
        [Column("bui_letter")]
        public char Letter
        {
            get { return Letter; }
            set
            {
                if (value >= 'A' && value <= 'Z')
                    Letter = value;
                else if (value >= 'a' && value <= 'z')
                    Letter = Char.ToUpper(value);
                else
                    throw new ArgumentException("Building Letter error : Not a letter");
            }
        }

        [Required]
        [Column("bui_name")]
        [MaxLength(50)]
        public string Name
        {
            get { return Name; }
            set
            {
                Name = Char.ToUpper(value[0]) + value.Substring(1).ToLower();
            }
        }

        [InverseProperty(nameof(Room.BuildingRoom))]
        public ICollection<Room> RoomsOfBuilding { get; set; } = null!;


    }
}
