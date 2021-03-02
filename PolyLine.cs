using System;
using System.Collections.Generic;

namespace Closest_Point_To_Curve_Exersise
{
    /// <summary>List of line segments, with methods for calculating various parameters</summary>
   public class PolyLine:Curve
    {
        public List<LineSegment> lineSegments{get; set;}

        /// <summary>Constructs an empty LineSegment</summary>
        public PolyLine(){}

        /// <summary>Constructs a PolyLine from given List of LineSegments</summary>
        /// <param name="lineSegments">List of LineSegment to convert into PolyLine</param>
        public PolyLine(List<LineSegment> lineSegments)
        {
            this.lineSegments = lineSegments;
        }

        /// <summary>Generate a random PolyLine with numRandVertices vertices (will produce self intersecting curves)</summary>
        /// <param name="numRandVertices">number of vertices per curve</param>
        public PolyLine(int numRandVertices)
        {

            Random rand = new Random();

            Point nextEnd;
            Point prevEnd = new Point();
            
            lineSegments = new List<LineSegment>();

            for (int i = 0; i < numRandVertices+1; i++)
            {
                nextEnd = new Point();
                lineSegments.Add(new LineSegment(prevEnd, nextEnd));
                prevEnd = nextEnd;
            }
        }

        public override double GetDistance(Point point)   // Finds the closest distance along polyline to a given point
        {
            double distanceToPoint;
            double minDistance = double.MaxValue;

            foreach (LineSegment line in lineSegments)
            {
                distanceToPoint = line.GetDistance(point); // Only make this expensive call once 
                if (distanceToPoint < minDistance)
                {
                    minDistance = distanceToPoint;
                } 
            }

            return minDistance;

        }
        
        public override Point GetClosestPoint(Point point)   // Finds closest x,y point along polyline to a given point
        {
            //This function is only called once the closest curve is already known
            LineSegment closestLine = null;
            double distanceToPoint;
            double minDistance = double.MaxValue;

            foreach (LineSegment line in lineSegments)
            {
                distanceToPoint = line.GetDistance(point); // Only make this expensive call once 
                if (distanceToPoint < minDistance)
                {
                    minDistance = distanceToPoint;
                    closestLine = line;
                } 
            }
            return closestLine.GetClosestPoint(point);
        }

        public override void Print()     // Prints points in the polyline
        {
            Console.Write("PolyLine:");
            foreach (Point point in GetPoints())
            {
                Console.Write("  [{0},{1}]", point.X, point.Y);
            }
            Console.WriteLine();
        }

        public override List<Curve> GenerateCurves(int numLines, int numVertices) // Creates a list of [numLines] random line segments, with [numVertices] vertices
        {            
            List<Curve> polyLines = new List<Curve>();
            for (int i = 0; i < numLines; i++){polyLines.Add(new PolyLine(numVertices));}

            // Output to console
            Console.WriteLine("\nGenerated {0} PolyLines:",numLines);
            foreach (PolyLine polyline in polyLines){polyline.Print();}

            return polyLines;
        
        }

        private List<Point> GetPoints()     // Returns list of points in the polyline
        {
            List<Point> points = new List<Point>();
            points.Add(lineSegments[0].EndA);
            foreach (LineSegment line in lineSegments)
                {
                    points.Add(line.EndB);
                }
            return points;
        }
        
    }

}