using System;
using System.Collections.Generic;

namespace Closest_Point_To_Curve_Exersise
{
    /// <summary>Backing class for all curve types</summary>
    public class Curve
    {   
        /// <summary>Creates a list of [numLines] random curves</summary>
        /// <param name="numLines">number of curves to generate</param>
        public virtual List<Curve> GenerateCurves(int numLines){return null;}
        
        /// <summary>Creates a list of [numLines] random curves</summary>
        /// <param name="numLines">number of curves to generate</param>
        /// <param name="numVertices">number of vertices per curve</param>
        public virtual List<Curve> GenerateCurves(int numLines, int numVertices){return null;}
        
        /// <summary>Calculates distance of point P from this line</summary>
        /// <param name="point">Point to calculate</param>
        public virtual double GetDistance(Point point){return -1;}
        
        /// <summary>Calculates the closest Point to the passed Point on this line</summary>
        /// <param name="point">Point to calculate</param>
        public virtual Point GetClosestPoint(Point point){return null;}
        
        /// <summary>Outputs data about curve to console</summary>
        public virtual void Print(){}
    }

}