namespace ControlHomeWork1.Model.Shapes.Primitives
{
    abstract class Parallelogram : Shape
    {
        // Параллелограмм образован точкой M и вокторами A и B

        // вектор A
        public abstract Vector A { get; }

        // вектор B
        public abstract Vector B { get; }

        // точка M
        public abstract Primitives.Point M { get; }
        // Проверка на принадлежность параллелограмму
        public override bool IsInside(Primitives.Point p)
        {
            return Statics.IsInParallelogramm(p, M, A, B);
        }

        public override void Draw(System.Drawing.Graphics gr, int width, int height)
        {
            System.Drawing.Point[] points = {M.ToDrawingPoint(width, height),
            (M + A).ToDrawingPoint(width, height),
            (M + A + B).ToDrawingPoint(width, height),
            (M + B).ToDrawingPoint(width, height)};

            gr.DrawPolygon(Statics.PEN, points);

        }

        public override void DrawColorful(System.Drawing.Graphics gr, int width, int height)
        {
            System.Drawing.Point[] points = {M.ToDrawingPoint(width, height),
            (M + A).ToDrawingPoint(width, height),
            (M + A + B).ToDrawingPoint(width, height),
            (M + B).ToDrawingPoint(width, height)};

            gr.FillPolygon(new System.Drawing.SolidBrush(Color), points);
            gr.DrawPolygon(Statics.PEN, points);
        }
    }
}
