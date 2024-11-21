using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAE501_Blazor_API.Models.EntityFramework
{
    public abstract class Spatial
    {
        protected double x, y, z, width, length, height;

        public abstract double X { get; set; }
        public abstract double Y { get; set; }
        public abstract double Z { get; set; }
        public abstract double Width { get; set; }
        public abstract double Length { get; set; } 
        public abstract double Height { get; set; }

        public virtual double Area()
        {
            return Length * Width;
        }

        public virtual double Volume()
        {
            return Length * Width * Height;
        }
    }
}
