using SAE501_Blazor_API.Models.EntityFramework.Transform;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE501_Blazor_API.Models.EntityFramework.RoomObjects
{
    [Table("t_e_sensorco2_co2")]
    public class SensorCO2 : RoomObject, IPosition, IRotation
    {
        [Column("co2_posx")]
        public double PosX { get; set; }

        [Column("co2_posy")]
        public double PosY { get; set; }

        [Column("co2_posz")]
        public double PosZ { get; set; }

        [Column("co2_rotx")]
        public double RotX { get; set; }

        [Column("co2_roty")]
        public double RotY { get; set; }

        [Column("co2_rotz")]
        public double RotZ { get; set; }
    }
}
