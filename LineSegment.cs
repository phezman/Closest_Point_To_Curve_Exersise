using System;
using System.Collections.Generic;

namespace Closest_Point_To_Curve_Exersise
{
    /// <summary>A line segment, with methods for calculating various parameters</summary>
    public class LineSegment:Curve 
    {
        public Point EndA{get; set;}
        public Point EndB{get; set;}

        /// <summary>Constructs a random LineSegment</summary>
        public LineSegment()
        {
            EndA = new Point();
            EndB = new Point();
        }
        
        /// <summary>Constructs a line between points endA/endB</summary>
        /// <param name="endA">First point</param>
        /// <param name="endB">Second point</param>
        public LineSegment(Point endA, Point endB)
        {
            EndA = endA;
            EndB = endB;
        }
        
        public override double GetDistance(Point point)
        {
            Point closestPoint = GetClosestPoint(point);
            double abx = point.X - closestPoint.X;
            double aby = point.Y - closestPoint.Y;
            return (Math.Sqrt((abx*abx)+(aby*aby)));
        }

        /// <summary>Calculates the closest Point to the passed Point on this line
        /// https://math.stackexchange.com/questions/2193720/find-a-point-on-a-line-segment-which-is-the-closest-to-other-point-not-on-the-li</summary>
        /// <param name="point">Point to calculate</param>
        public override Point  GetClosestPoint (Point point)
        {

            Point zero = new Point(0,0);
            Point v = EndB.Minus(EndA);
            Point u = EndA.Minus(point); 
            double vu = v.DotProduct(u); 
            double vv = v.DotProduct(v); 
            double t = -vu / vv;

            if (t >= 0 && t <= 1) {return VectorToSegment(t, zero);}
            double g0 = VectorToSegment(0, point).SquareDiagonal();
            double g1 = VectorToSegment(1, point).SquareDiagonal();
            return g0 <= g1 ? EndA : EndB;
        }

        /// <summary>Calculates distance of point P from this line</summary>
        /// <param name="point">Point to calculate</param>
        private Point  VectorToSegment (double t, Point point)
        {
            return new Point((1 - t) * EndA.X + t * EndB.X - point.X,(1 - t) * EndA.Y + t * EndB.Y - point.Y);
        } 
        
        public override void Print()
        {
            Console.WriteLine("Line Segment:  [{0},{1}] to [{2},{3}]", EndA.X, EndA.X, EndB.X, EndB.Y);
        }

        /// <summary>Creates a list of [numLines] random line segments</summary>
        /// <param name="numLines">number of curves to generate</param>
        public override List<Curve> GenerateCurves(int numLines)
        {
            List<Curve> lineSegments = new List<Curve>();
            for (int i = 0; i < numLines; i++){lineSegments.Add(new LineSegment());}
            
            // Output to console
            Console.WriteLine("\nGenerated {0} Line Segments:",numLines);
            foreach (LineSegment line in lineSegments){line.Print();}

            return lineSegments;
        }
    }
}