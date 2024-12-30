using SAE501_Blazor_API.Models.EntityFramework.Transform;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE501_Blazor_API.Models.EntityFramework.RoomObjects
{
    [Table("t_e_sensor9in1_nio")]
    public class Sensor9in1 : RoomObject, IPosition, IRotation
    {
        [Column("nio_posx")]
        public double PosX { get; set; }

        [Column("nio_posy")]
        public double PosY { get; set; }

        [Column("nio_posz")]
        public double PosZ { get; set; }

        [Column("nio_rotx")]
        public double RotX { get; set; }

        [Column("nio_roty")]
        public double RotY { get; set; }

        [Column("nio_rotz")]
        public double RotZ { get; set; }
    }
}
