namespace ControlHomeWork1.Model.Shapes.Primitives
{
    public class Point
    {
        public Point() { }
        public Point(float x, float y)
        {
            this.X = x;
            this.Y = y;
        } 

        public float X { get; set; }
        public float Y { get; set; }

        public override int GetHashCode()
        {
            return (int)(X * (1 << 16)) << 16 + (int)(Y * (1 << 16));
        }

        public System.Drawing.Point ToDrawingPoint(int Width, int Height)
        {
            return new System.Drawing.Point((int)(X * Width), (int)(Y * Height));
        }

        public static Point operator +(Point p, Vector v)
        {
            return new Point(p.X + v.X, p.Y + v.Y);
        }

    }
}
