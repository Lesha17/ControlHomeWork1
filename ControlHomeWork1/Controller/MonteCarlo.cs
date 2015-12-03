using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using ControlHomeWork1.Model;
using ControlHomeWork1.Model.Shapes.Primitives;
using ControlHomeWork1.Model.Shapes.Parts;

namespace ControlHomeWork1.Controller
{
    /* Хранит методы для вычисления плозади данного изображения методом Монте - Карло,
    *   а также точки, испульзукмые для вычисления этим методом
    *   и методы для отрисовки этих точек.
    */
    partial class MonteCarlo
    {
        // Хранит точки, попавшие в изображение
        // HashSet используется потому, что в него не добавляется объект, если в нём уже имеется
        // другой объект с таким же хэш - кодом.
        private Dictionary<Shape, HashSet<Point>> points = new Dictionary<Shape, HashSet<Point>>();

        // Хранит точки, не попавшие в рисунок
        // HashSet используется потому, что в него не добавляется объект, если в нём уже имеется
        // другой объект с таким же хэш - кодом.
        private HashSet<Point> pointNotInPicture = new HashSet<Point>();

        // Показывает, выполняется ли метод
        private Boolean running = false;

        // Хранит данное изображение
        public Picture Picture { get; set; }

        // pict - объект данного изображения
        public MonteCarlo(Picture pict)
        {
            this.Picture = pict;

            ResetAsync();
        }

        // Запускает выполнение метода, не блокируя вызывающий поток.
        // При вызове используйте await.
        public async Task StartAsync()
        {
            lock (this)
            {
                running = true;
            }

            await createPoints();
        }

        // Останавливает выполнение метода, не блокируя вызывающий поток.
        // При вызове используйте await.
        public async Task StopAsync()
        {
            lock (this)
            {
                running = false;
            }
        }

        // Сбрасывает хранящиеся значения сгенерированных точек, не блокируя вызывающий поток.
        // При вызове используйте await.
        public async Task ResetAsync()
        {
            lock (this)
            {
                points.Clear();
                pointNotInPicture.Clear();

                foreach (Shape sh in Picture.Shapes)
                {
                    points.Add(sh, new HashSet<Point>());
                }
            }
        }

        // Возвращает количество точек внутри данного изображения.
        public int Inside()
        {
            int inside = 0;

            foreach (HashSet<Point> set in points.Values)
            {
                inside += set.Count;
            }

            return inside;
        }

        // Возвращает общее количество сгенерированных точек.
        public int All()
        {
            return Inside() + pointNotInPicture.Count;
        }

        // Возвращает площадь данного изображения в процентах.
        public float Square()
        {
            return 100 * (float)Inside() / All();
        }

        // Генерирует точки для выполнения метода.
        private async Task createPoints()
        {
            await Task.Run(delegate
            {
                Random rand = new Random();

                while (running)
                {
                    lock (this)
                    {
                        float x = (float)rand.NextDouble();
                        float y = (float)rand.NextDouble();
                        Point p = new Point(x, y);
                        addPoint(p);
                    }

                }
            });
        }

        // Добавляет точки в соответсвующий массив.
        private void addPoint(Point p)
        {
            Shape sh = Picture.Shape(p);

            if (sh != null)
            {
                // Если точка принадлежит какой - нибудь фигуре данного изабражения,
                // добавим её в массив, соответствующий этой фигуре.
                points[sh].Add(p);
            }
            else
            {
                // Если точка не принадлежит какой - нибудь фигуре данного изабражения,
                // добавим её в массив точек, не принадлежащих изображению.
                pointNotInPicture.Add(p);
            }
        }
    }
}
