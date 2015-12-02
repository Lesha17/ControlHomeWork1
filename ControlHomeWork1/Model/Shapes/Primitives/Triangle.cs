using System.Drawing;

namespace ControlHomeWork1.Model.Shapes.Primitives
{
    abstract class Triangle : Shape
    {
        public abstract Point M { get; }

        public abstract Vector A { get; }

        public abstract Vector B { get; }

        public override bool IsInside(Point p)
        {
            return Statics.IsInParallelogramm(p, M, A, B) && Statics.IsInParallelogramm(p, M, A, B - A);
        }

        public override void Draw(Graphics gr, int width, int height)
        {
            System.Drawing.Point[] points = { M.ToDrawingPoint(width, height),
                                            (M+A).ToDrawingPoint(width, height),
                                            (M+B).ToDrawingPoint(width, height)};

            gr.DrawPolygon(Statics.PEN, points);
        }

        public override void DrawColorful(System.Drawing.Graphics gr, int width, int height)
        {
            System.Drawing.Point[] points = {M.ToDrawingPoint(width, height),
            (M + A).ToDrawingPoint(width, height),
            (M + B).ToDrawingPoint(width, height)};

            gr.FillPolygon(new System.Drawing.SolidBrush(Color), points);
            gr.DrawPolygon(Statics.PEN, points);
        }
    }
}
