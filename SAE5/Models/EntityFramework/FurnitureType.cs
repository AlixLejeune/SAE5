using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE501_Blazor_API.Models.EntityFramework
{
    [Table("t_e_furnituretype_frt")]
    public class FurnitureType
    {
        private string name;

        [Key]
        [Column("frt_id")]
        public int Id { get; set; }

        [Required]
        [Column("frt_name")]
        [MaxLength(50)]
        public string Name
        {
            get { return name; }
            set
            {
                name = Char.ToUpper(value[0]) + value.Substring(1).ToLower();
            }
        }

        [InverseProperty(nameof(Furniture.Type))]
        public ICollection<Furniture> FurnituresOfSuchType { get; set; } = null!;

        
    }
}
