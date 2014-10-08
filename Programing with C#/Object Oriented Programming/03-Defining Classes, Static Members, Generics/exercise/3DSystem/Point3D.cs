using System.Text;

namespace _3DSystem
{
    class Point3D
    {
        private int _coordX;
        private int _coordY;
        private int _coordZ;
        public static readonly Point3D StartPoint = new Point3D(0,0,0);

        public Point3D()
        {
 
        }

        public Point3D(int x,int y, int z)
        {
            this._coordX = x;
            this._coordY = y;
            this._coordZ = z;
        }


        public int CoordZ
        {
            get { return _coordZ; }
            set { _coordZ = value; }
        }
        
        public int CoordY
        {
            get { return _coordY; }
            set { _coordY = value; }
        }
        
        public int CoordX
        {
            get { return _coordX; }
            set { _coordX = value; }
        }

        public string ToString(Point3D point)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(point._coordX.ToString());
            sb.Append(" ");
            sb.Append(point._coordY.ToString());
            sb.Append(" ");
            sb.Append(point._coordZ.ToString());
            return sb.ToString();
        }
    }
}
