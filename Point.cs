using System;

namespace Closest_Point_To_Curve_Exersise
{

    /// <summary>Stores an (x,y) coordinate/2D vector</summary>
    public class Point  // 
    { 
        public double X{get; set;}
        public double Y{get; set;}

        /// <summary>Constructs a random Point</summary>
        public Point() 
        {
            Random rand = new Random();
            X = (double)(rand.Next(Constants.MinX, Constants.MaxX));
            Y = (double)(rand.Next(Constants.MinY, Constants.MaxY));
        }

        /// <summary>Constructs a Point at (X,Y)</summary>
        public Point(double x, double y)
        {
            X = x; Y = y;
        }

        /// <summary>Returns X^2 * Y^2</summary>
        public Double SquareDiagonal()
        {
            return (X * X) + (Y * Y);
        }

        /// <summary>Vector from passed Point to this Point</summary>
        /// <param name="point">Subtrahend Point</param>
        public Point Minus(Point point)
        {
            return new Point(this.X - point.X, this.Y - point.Y);
        }

        /// <summary>Dot product of passed Point and this Point</summary>
        /// <param name="point">Point to find dot product</param>
        public double DotProduct(Point point)
        {
            return (this.X * point.X) + (this.Y * point.Y);
        }
    }

}