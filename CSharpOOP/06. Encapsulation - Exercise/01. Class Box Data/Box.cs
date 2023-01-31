using System;

namespace ClassBoxData
{
    public class Box
    {
		private double length;
		private double width;
		private double height;

        public Box(double length, double width,double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }
		

		public double Length
        {
			get 
            {
                return length;
            }
			private set
            {
                if (!IsValid(value))
                {
                    throw new ArgumentException($"{nameof(Box.Length)} cannot be zero or negative.");
                }
                length = value; 
            }
		}
        public double Width
        {
            get
            { 
                return width;
            }
            private set
            {
                if (!IsValid(value))
                {
                    throw new ArgumentException($"{nameof(Box.Width)} cannot be zero or negative.");
                }
                width = value;
            }
        }
        public double Height
        {
            get 
            {
                return height;
            }
            private set 
            {
                if (!IsValid(value))
                {
                    throw new ArgumentException($"{nameof(Box.Height)} cannot be zero or negative.");
                }
                height = value;
            }
        }

        private bool IsValid(double value)
        {
            if (value >0)
            {
                return true;
            }
            return false;
        }

        public double SurfaceArea() 
        {
            double result = (this.Length* this.Width * 2) + (this.Width * this.Height * 2) + (this.Height* this.Length * 2);
            return result;
        }
        public double LateralSurfaceArea()
        {
            double result = 2 * (this.Length + this.Width) * this.Height;
            return result;
        }
        public double Volume()
        {
            return this.Height * this.Width * this.Length;
        }
    }
}
