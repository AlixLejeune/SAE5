using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAE501_Blazor_API.Models.EntityFramework
{
    [Table("t_e_sensor_sen")]
    public class Sensor : Spatial
    {
        [Key]
        [Column("sen_id")]
        public int Id
        {
            get { return Id; }
            set
            {
                if (value > 0)
                    Id = value;
                else
                    throw new ArgumentException("Sensor Id error : Ids must be strictly positive");
            }
        }

        [Required]
        [Column("sen_x")]
        public override double X
        {
            get { return X; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Sensor X coordinate error : X cannot be negative");
                X = value;
            }
        }

        [Required]
        [Column("sen_y")]
        public override double Y
        {
            get { return Y; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Sensor Y coordinate error : Y cannot be negative");
                Y = value;
            }
        }

        [Required]
        [Column("sen_Z")]
        public override double Z
        {
            get { return Z; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Sensor Z coordinate error : Z cannot be negative");
                Z = value;
            }
        }

        [Required]
        [Column("sen_length")]
        public override double Length
        {
            get { return Length; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Sensor Length error : length cannot be negative");
                Length = value;
            }
        }

        [Required]
        [Column("sen_width")]
        public override double Width
        {
            get { return Width; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Sensor Width error : width cannot be negative");
                Width = value;
            }
        }

        [Required]
        [Column("sen_height")]
        public override double Height
        {
            get { return Height; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Sensor Height error : height cannot be negative");
                Height = value;
            }
        }

        [Required]
        [Column("sen_name")]
        public string Name { get; set; }

        
        
    }
}
