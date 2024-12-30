using SAE501_Blazor_API.Models.EntityFramework.Transform;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE501_Blazor_API.Models.EntityFramework.RoomObjects
{
    [Table("t_e_heater_hea")]
    public class Heater : RoomObject, IPosition, IOrientation, ISize
    {
        [Column("hea_posx")]
        public double PosX { get; set; }

        [Column("hea_posy")]
        public double PosY { get; set; }

        [Column("hea_posz")]
        public double PosZ { get; set; }

        [Column("hea_orientation")]
        public double Orientation { get; set; }

        [Column("hea_sizex")]
        public double SizeX { get; set; }

        [Column("hea_sizey")]
        public double SizeY { get; set; }

        [Column("hea_sizez")]
        public double SizeZ { get; set; }
    }
}
