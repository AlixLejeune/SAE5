using ConsoleApp1.Models.Transform;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1.Models.RoomObjects
{
    [Table("t_e_door_doo")]
    public class Door : RoomObject, IPosition, IOrientation, ISize
    {
        
        public double PosX { get; set; }
        public double PosY { get; set; }
        public double PosZ { get; set; }

        public double Orientation { get; set; }

        public double SizeX { get; set; }
        public double SizeY { get; set; }
        public double SizeZ { get; set; }

    }
}
