/*
    Контрольное домашнее задание модуль 2
    Дисциплина: Программирование
    Группа: БПИ154(2)
    Студент: Мачнев Алексей Евгеньевич
    Вариант: 14
    Дата: 04.12.2015
*/

using System.Drawing;

namespace ControlHomeWork1.Model.Shapes.Primitives
{
    public class Triangle : Shape
    {
        //Треугольник образован точкой M и векторами A и B

        //точка M
        public Point M { get; set; }

        //Вектор A
        public Vector A { get; set; }

        //Вектор B
        public Vector B { get; set; }

        public Triangle() { }

        public Triangle(Point M, Vector A, Vector B)
        {
            this.M = M;
            this.A = A;
            this.B = B;
        }

        //Проверка на принадлежность треугольнику
        public override bool IsInside(Point p)
        {
            //Через два параллелограмма
            return Statics.IsInParallelogramm(p, M, A, B) && Statics.IsInParallelogramm(p, M, A, B - A);
        }

        //Нарисовать контур
        public override void Draw(Graphics gr, int width, int height)
        {
            System.Drawing.Point[] points = { M.ToDrawingPoint(width, height),
                                            (M+A).ToDrawingPoint(width, height),
                                            (M+B).ToDrawingPoint(width, height)};

            gr.DrawPolygon(Statics.PEN, points);
        }

        //Нарисовать контур и закрасить цветом Color
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
