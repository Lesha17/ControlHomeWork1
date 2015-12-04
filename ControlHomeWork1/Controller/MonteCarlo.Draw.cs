/*
    Контрольное домашнее задание модуль 2
    Дисциплина: Программирование
    Группа: БПИ154(2)
    Студент: Мачнев Алексей Евгеньевич
    Вариант: 14
    Дата: 04.12.2015
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ControlHomeWork1.Model;

using System.Drawing;

namespace ControlHomeWork1.Controller
{
    // Содержит метод отрисовки результатов работы метода Монте - Карло.
    partial class MonteCarlo
    {
        // Отрисовывает данное изображение и сгенерированные точки.
        public void Draw(Graphics gr, int width, int height)
        {
            // Сначала рисуем данное изображение.
            Picture.Draw(gr, width, height);
            
            // Рисуем точки, попавшие в данное изображение.
            foreach (KeyValuePair<Shape, HashSet<ControlHomeWork1.Model.Shapes.Primitives.Point>> entry in points)
            {
                if (entry.Value.Count > 0)
                {
                    gr.FillRectangles(new SolidBrush(entry.Key.Color), rects(entry.Value, width, height));
                }
            }

            // Рисуем точки, не попавшие в данное изображение.
            if (pointNotInPicture.Count > 0)
            {
                gr.FillRectangles(new SolidBrush(Color.DarkBlue), rects(pointNotInPicture, width, height));
            }
        }

        // Создает массив прямоугольников для рисования в System.Drawing.Graphics
        // из массива точек, представленных в относительных координатах.
        private Rectangle[] rects(IEnumerable<Model.Shapes.Primitives.Point> points, int width, int height)
        {
            // Set используется потому, что в него не будут добавлятся точки с одинаковыми координатами,
            // а, значит, впоследствии не будут обрабатываться несколько раз.
            HashSet<Point> dr_points = new HashSet<Point>();

            foreach(Model.Shapes.Primitives.Point p in points)
            {
                dr_points.Add(p.ToDrawingPoint(width, height));
            }

            Func<Point, Rectangle> selector =
                    delegate (Point p)
                    {
                        return new Rectangle(p.X, p.Y, 1, 1);
                    };

            return dr_points.Select(selector).ToArray();
        }
    }
}
