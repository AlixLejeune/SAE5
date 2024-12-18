using ConsoleApp1.Models.Transform;

namespace ConsoleApp1.Models.RoomObjects
{
    public class Lamp : RoomObject, IPosition, IRotation
    {
        public double PosX { get; set; }
        public double PosY { get; set; }
        public double PosZ { get; set; }

        public double RotX { get; set; }
        public double RotY { get; set; }
        public double RotZ { get; set; }
    }
}
