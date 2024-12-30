using SAE501_Blazor_API.Models.EntityFramework.Transform;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE501_Blazor_API.Models.EntityFramework.RoomObjects
{
    [Table("t_e_door_doo")]
    public class Door : RoomObject, IPosition, IOrientation, ISize
    {
        [Column("doo_posx")]
        public double PosX { get; set; }

        [Column("doo_posy")]
        public double PosY { get; set; }

        [Column("doo_posz")]
        public double PosZ { get; set; }

        [Column("doo_orientation")]
        public double Orientation { get; set; }

        [Column("doo_sizex")]
        public double SizeX { get; set; }

        [Column("doo_sizey")]
        public double SizeY { get; set; }

        [Column("doo_sizez")]
        public double SizeZ { get; set; }

    }
}
