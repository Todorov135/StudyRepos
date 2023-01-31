using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double width;
        private double height;
        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }       
        public double Width
        {
            get 
            { 
                return width;
            }
            set 
            {
                if (value > 0)
                {
                    width = value;
                }
                else
                {
                throw new ArgumentException(); 
                }
            }
        }
        public double Height
        {
            get 
            { 
                return height;
            }
            set 
            {
                if (value > 0)
                {
                    height = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public override double CalculateArea()
        {
            return this.Width * this.Height;
        }

        public override double CalculatePerimeter()
        {
            return 2 * this.Height + 2 * this.Width;
        }

        public override string Draw()
        {

            return base.Draw() + " " +this.GetType().Name;
            
        }
        
    }
}
