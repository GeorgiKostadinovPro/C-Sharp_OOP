using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Height
        {
            get { return this.height; }
            private set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Height cannot be zero or negative.");
                }

                this.height = value; 
            }
        }


        public double Width
        {
            get { return this.width; }
            private set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Width cannot be zero or negative.");
                }

                this.width = value;
            }
        }


        public double Length
        {
            get { return this.length; }
            private set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Length cannot be zero or negative.");
                }

                this.length = value;
            }
        }

        public double SurfaceArea()
        {
            return 2 * (this.Length * this.Width)  
                 + 2 * (this.Height * this.Length)  
                 + 2 * (this.Height * this.Width);
        }

        public double LateralSurfaceArea()
        {
            return 2 * (this.Height * this.Length) 
                 + 2 * (this.Height * this.Width);
        }

        public double Volume()
        { 
           return this.Length * this.Width * this.Height;
        }
    }
}
