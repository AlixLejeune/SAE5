
namespace SAE501_Blazor_API.Models.EntityFramework
{
    public class Vector2D
    {
        private double x;
        private double y;

        //getter and setter in case we need to place verification of values etc
        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }

        public Vector2D(double x, double y)
        {
            X = x;
            Y = y;
        }
        public Vector2D() : this(0, 0) { }

        public override bool Equals(object? obj)
        {
            return obj is Vector2D d &&
                   X == d.X &&
                   Y == d.Y;
        }

        public override string ToString()
        {
            return $"{{X : {X}, Y : {Y}}}";
        }
    }

    //JSON mapper method ?
}
