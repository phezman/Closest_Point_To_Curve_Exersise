using System;
using System.Xml.Linq;
using System.Collections.Generic;

namespace Closest_Point_To_Curve_Exersise
{   

    public class Program
    {

        /// <summary>Generates a list of curves and finds the closest point to an input point</summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            
            Console.WriteLine("\nCurve Comparator Program\n");

            // Ask user for a cartesian point to compare
            double user_x = GetDouble($"Enter Point x ({Constants.MinX}-{Constants.MaxX}):");
            double user_y = GetDouble($"Enter Point y ({Constants.MinY}-{Constants.MaxY}):");
            Point point = new Point(user_x, user_y);

            // Ask user for desired curves to generate
            int numLineSegments = GetInt("Number of Line Segments to Generate:");
            int numPolyLines = GetInt("Number of Poly Lines to Generate:");
            int numVertices = GetInt("Number of Poly Line Vertices:");

            // Generate Curve List
            List<Curve> curves = new List<Curve>();
            curves.AddRange(new LineSegment().GenerateCurves(numLines: numLineSegments));
            curves.AddRange(new PolyLine().GenerateCurves(numLines: numPolyLines, numVertices: numVertices));

            //Variables for finding the closest curve
            Double tempDistance = 0;
            Curve closestCurve = new Curve();
            Double minDistance = double.MaxValue;

            // Find the closest curve
            foreach (Curve curve in curves)
            {
                tempDistance = curve.GetDistance(point);
                if (tempDistance < minDistance)
                {
                    minDistance=tempDistance;
                    closestCurve = curve;
                }
            }

            // Curve is now be the closest curve to the supplied point
            Point closest = closestCurve.GetClosestPoint(point);
            
            // Print outputs
            Console.WriteLine("\nClosest Curve:");
            closestCurve.Print();
            Console.WriteLine("Closest point on curve: ({0},{1})",Math.Round(closest.X,2), Math.Round(closest.Y,2));
            Console.WriteLine("Distance from ({0},{1}): {2} ({3}cm on square paper)",point.X, point.Y, Math.Round(minDistance,2), Math.Round(minDistance/2,3));
        
        }

        /// <summary>Gets a double from the user</summary>
        /// <param name="prompt">The propmt to be given to the user</param>
        static double GetDouble(string prompt)
        {

            double outcome = 0;
            bool valid = false;

            while (!valid)
            {
                Console.WriteLine(prompt);
                string inValue = Console.ReadLine();
                if (double.TryParse(inValue, out outcome) == false)
                {
                    Console.WriteLine("Input must be numeric! {0}");
                }
                else
                {
                    valid = true;
                }
            }
            return outcome;

        }

        /// <summary>Gets a int from the user</summary>
        /// <param name="prompt">The propmt to be given to the user</param>
        static int GetInt(string prompt)
        {

            int outcome = 0;
            bool valid = false;

            while (!valid)
            {
                Console.WriteLine(prompt);
                string inValue = Console.ReadLine();
                if (Int32.TryParse(inValue, out outcome) == false)
                {
                    Console.WriteLine("Input must be numeric! {0}");
                }
                else
                {
                    valid = true;
                }
            }
            return outcome;

        }

    }
}

 
  

