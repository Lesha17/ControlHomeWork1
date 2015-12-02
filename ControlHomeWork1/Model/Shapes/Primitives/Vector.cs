namespace ControlHomeWork1.Model.Shapes.Primitives
{
    public class Vector
    {
        public Vector() { }
        public Vector(float X, float Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public Vector(Point p1, Point p2)
        {
            this.X = p2.X - p1.X;
            this.Y = p2.Y - p1.Y;
        }

        public float X { get; set; }
        public float Y { get; set; }

        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y);
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1.X - v2.X, v1.Y - v2.Y);
        }

        public static Vector operator -(Vector v)
        {
            return new Vector(-v.X, -v.Y);
        }

    }
}
