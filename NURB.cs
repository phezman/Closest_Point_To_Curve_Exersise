using System;
using System.Collections.Generic;

namespace Closest_Point_To_Curve_Exersise
{
  public class NURB:Curve
    {
        public NURB(){}
        public override double GetDistance(Point point){throw new NotImplementedException();}
        public override Point GetClosestPoint(Point point){throw new NotImplementedException();}
        public override void Print(){throw new NotImplementedException();}
        public override List<Curve> GenerateCurves(int numLines){throw new NotImplementedException();}
    }
}
