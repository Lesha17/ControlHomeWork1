/*
    Контрольное домашнее задание модуль 2
    Дисциплина: Программирование
    Группа: БПИ154(2)
    Студент: Мачнев Алексей Евгеньевич
    Вариант: 14
    Дата: 04.12.2015
*/

namespace ControlHomeWork1.Model.Shapes.Primitives
{
    // Точка в относительных координатах
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

        // Хитрое вычисление хэша
        // Необходимо для определения одинаковых точек
        public override int GetHashCode()
        {
            return ((int)(X * (1 << 16))) << 16 + (int)(Y * (1 << 16));
        }

        //Перевод в System.Drawing.Point
        public System.Drawing.Point ToDrawingPoint(int Width, int Height)
        {
            return new System.Drawing.Point((int)(X * Width), (int)(Y * Height));
        }

        //Транспонирование на вектор v
        public static Point operator +(Point p, Vector v)
        {
            return new Point(p.X + v.X, p.Y + v.Y);
        }

    }
}
