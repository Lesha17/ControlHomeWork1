namespace ControlHomeWork1.Model.Shapes.Primitives
{
    public class Parallelogram : Shape
    {
        // Параллелограмм образован точкой M и вокторами A и B

        // вектор A
        public Vector A { get; set; }

        // вектор B
        public Vector B { get; set; }

        // точка M
        public Primitives.Point M { get; set; }

        public Parallelogram() { }

        public Parallelogram(Point M, Vector A, Vector B)
        {
            this.M = M;
            this.A = A;
            this.B = B;
        }

        // Проверка на принадлежность параллелограмму
        public override bool IsInside(Primitives.Point p)
        {
            return Statics.IsInParallelogramm(p, M, A, B);
        }

        //Нарисовать контур
        public override void Draw(System.Drawing.Graphics gr, int width, int height)
        {
            System.Drawing.Point[] points = {M.ToDrawingPoint(width, height),
            (M + A).ToDrawingPoint(width, height),
            (M + A + B).ToDrawingPoint(width, height),
            (M + B).ToDrawingPoint(width, height)};

            gr.DrawPolygon(Statics.PEN, points);

        }

        //Нарисовать контур и закрасить цветом Color
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
