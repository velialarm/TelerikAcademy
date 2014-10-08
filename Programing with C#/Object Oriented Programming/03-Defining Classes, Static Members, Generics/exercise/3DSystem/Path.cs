using System.Collections.Generic;

namespace _3DSystem
{
    class Path
    {
        public readonly List<Point3D> AllPoints = new List<Point3D>();

        public void AddPoint(Point3D point)
        {
            AllPoints.Add(point);
        }
        public void ClearPath()
        {
            AllPoints.Clear();
        }
    }
}
