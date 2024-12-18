using ConsoleApp1.Models.Transform;

namespace ConsoleApp1.Models.RoomObjects
{
    public class Table : RoomObject, IPosition, IOrientation, ISize
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
