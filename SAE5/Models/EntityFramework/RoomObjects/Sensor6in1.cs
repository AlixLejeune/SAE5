using SAE501_Blazor_API.Models.EntityFramework.Transform;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE501_Blazor_API.Models.EntityFramework.RoomObjects
{
    [Table("t_e_sensor6in1_sio")]
    public class Sensor6in1 : RoomObject, IPosition, IRotation
    {
        [Column("sio_posx")]
        public double PosX { get; set; }

        [Column("sio_posy")]
        public double PosY { get; set; }

        [Column("sio_posz")]
        public double PosZ { get; set; }

        [Column("sio_rotx")]
        public double RotX { get; set; }

        [Column("sio_roty")]
        public double RotY { get; set; }

        [Column("sio_rotz")]
        public double RotZ { get; set; }
    }
}
