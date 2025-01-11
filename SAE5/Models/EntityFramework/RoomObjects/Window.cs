using SAE501_Blazor_API.Models.EntityFramework.Transform;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE501_Blazor_API.Models.EntityFramework.RoomObjects
{
    [Table("t_e_window_win")]
    public class Window : RoomObject, IPosition, IOrientation, ISize
    {
        [Column("win_posx")]
        public double PosX { get; set; }

        [Column("win_posy")]
        public double PosY { get; set; }

        [Column("win_posz")]
        public double PosZ { get; set; }

        [Column("win_orientation")]
        public double Orientation { get; set; }

        [Column("win_sizex")]
        public double SizeX { get; set; }

        [Column("win_sizey")]
        public double SizeY { get; set; }

        [Column("win_sizez")]
        public double SizeZ { get; set; }
    }
}
