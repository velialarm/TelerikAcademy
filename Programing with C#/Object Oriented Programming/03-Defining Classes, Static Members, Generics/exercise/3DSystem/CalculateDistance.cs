using System;

namespace _3DSystem
{
    class CalculateDistance
    {
        public double Calculate(Point3D a, Point3D b)
        {
            double dist;
            dist = Math.Sqrt(Math.Pow(a.CoordX - b.CoordX, 2) + Math.Pow(a.CoordY - b.CoordY, 2) + Math.Pow(a.CoordZ - b.CoordZ, 2));
            return dist;
        }
    }
}
