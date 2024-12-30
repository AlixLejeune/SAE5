using SAE501_Blazor_API.Models.EntityFramework.Transform;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE501_Blazor_API.Models.EntityFramework.RoomObjects
{
    [Table("t_e_lamp_lam")]
    public class Lamp : RoomObject, IPosition, IRotation
    {
        [Column("lam_posx")]
        public double PosX { get; set; }

        [Column("lam_posy")]
        public double PosY { get; set; }

        [Column("lam_posz")]
        public double PosZ { get; set; }

        [Column("lam_rotx")]
        public double RotX { get; set; }

        [Column("lam_roty")]
        public double RotY { get; set; }

        [Column("lam_rotz")]
        public double RotZ { get; set; }
    }
}
