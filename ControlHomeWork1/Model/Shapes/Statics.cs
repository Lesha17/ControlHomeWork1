/*
    Контрольное домашнее задание модуль 2
    Дисциплина: Программирование
    Группа: БПИ154(2)
    Студент: Мачнев Алексей Евгеньевич
    Вариант: 14
    Дата: 04.12.2015
*/

using System.Drawing;
using ControlHomeWork1.Model.Shapes.Primitives;

namespace ControlHomeWork1.Model.Shapes
{
    // Кое - какой повторяющийся код 
    class Statics
    {
        // Pen для рисованя контура фигур
        public static readonly System.Drawing.Pen PEN = new System.Drawing.Pen(Color.DimGray, 4f);
        
        // Проверяет, принадлежит ли точка p параллелограмму, образованному точкой M и векторами A и B
        public static bool IsInParallelogramm(Primitives.Point p, Primitives.Point M, Vector A, Vector B)
        {
            //Координаты вектора c = Mp
            float xc = p.X - M.X;
            float yc = p.Y - M.Y;

            /*
            *   Решим систему
            *   
            *   alpha * xa + beta * xb = xc
            *   alpha * ya + beta * yb = yc
            *
            *   Где alpha, beta - координаты вектора c = Mp в базисе A, B
            *
            */
            float delta = A.X * B.Y - A.Y * B.X;
            float delta_alpha = xc * B.Y - yc * B.X;
            float delta_beta = A.X * yc - A.Y * xc;

            if (delta == 0)
            {
                return false;
            }

            float alpha = delta_alpha / delta;
            float beta = delta_beta / delta;

            //Точка принадлежит параллелограмму, если координаты c в базисе A, B меньше или равны 1
            return (0 <= alpha && alpha <= 1f) && (0 <= beta && beta <= 1f);
        }
    }
}
