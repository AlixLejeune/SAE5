using SAE501_Blazor_API.Models.EntityFramework.Transform;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE501_Blazor_API.Models.EntityFramework.RoomObjects
{
    [Table("t_e_customobject_cus")]
    public class CustomObject : RoomObject, IPosition, IRotation, ISize
    {
        [Column("cus_posx")]
        public double PosX { get; set; }
        [Column("cus_posy")]
        public double PosY { get; set; }
        [Column("cus_posz")]
        public double PosZ { get; set; }
        [Column("cus_rotx")]
        public double RotX { get; set; }
        [Column("cus_roty")]
        public double RotY { get; set; }
        [Column("cus_rotz")]
        public double RotZ { get; set; }
        [Column("cus_sizex")]
        public double SizeX { get; set; }
        [Column("cus_sizey")]
        public double SizeY { get; set; }
        [Column("cus_sizez")]
        public double SizeZ { get; set; }

        [Range(0, 16581375)]
        [Column("cus_color")]
        public int Color { get; set; }
    }
}
