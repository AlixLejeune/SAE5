using SAE501_Blazor_API.Models.EntityFramework.Transform;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE501_Blazor_API.Models.EntityFramework.RoomObjects
{
    [Table("t_e_table_tab")]
    public class Table : RoomObject, IPosition, IOrientation, ISize
    {
        [Column("tab_posx")]
        public double PosX { get; set; }

        [Column("tab_posy")]
        public double PosY { get; set; }

        [Column("tab_posz")]
        public double PosZ { get; set; }

        [Column("tab_orientation")]
        public double Orientation { get; set; }

        [Column("tab_sizex")]
        public double SizeX { get; set; }

        [Column("tab_sizey")]
        public double SizeY { get; set; }

        [Column("tab_sizez")]
        public double SizeZ { get; set; }
    }
}
