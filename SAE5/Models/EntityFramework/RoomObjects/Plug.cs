using SAE501_Blazor_API.Models.EntityFramework.Transform;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE501_Blazor_API.Models.EntityFramework.RoomObjects
{
    [Table("t_e_plug_plu")]
    public class Plug : RoomObject, IPosition, IRotation
    {
        [Column("plu_posx")]
        public double PosX { get; set; }

        [Column("plu_posy")]
        public double PosY { get; set; }

        [Column("plu_posz")]
        public double PosZ { get; set; }

        [Column("plu_rotx")]
        public double RotX { get; set; }

        [Column("plu_roty")]
        public double RotY { get; set; }

        [Column("plu_rotz")]
        public double RotZ { get; set; }
    }
}
