using SAE501_Blazor_API.Models.EntityFramework.Transform;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE501_Blazor_API.Models.EntityFramework.RoomObjects.ConnectedObjects
{
    [Table("t_e_siren_sir")]
    public class Siren : ConnectedObject, IPosition, IRotation
    {
        [Column("sir_posx")]
        public double PosX { get; set; }

        [Column("sir_posy")]
        public double PosY { get; set; }

        [Column("sir_posz")]
        public double PosZ { get; set; }

        [Column("sir_rotx")]
        public double RotX { get; set; }

        [Column("sir_roty")]
        public double RotY { get; set; }

        [Column("sir_rotz")]
        public double RotZ { get; set; }
    }
}
