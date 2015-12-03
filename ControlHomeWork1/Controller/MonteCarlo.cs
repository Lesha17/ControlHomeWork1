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
    partial class MonteCarlo
    {
        private Dictionary<Shape, HashSet<Point>> points = new Dictionary<Shape, HashSet<Point>>();
        private HashSet<Point> pointNotInPicture = new HashSet<Point>();
        private Boolean running = false;

        public Picture Picture { get; set; }

        public MonteCarlo(Picture pict)
        {
            this.Picture = pict;

            Reset();
        }



        public async Task Start()
        {
            lock (this)
            {
                running = true;
            }

            await createPoints();
        }

        public async Task Stop()
        {
            lock (this)
            {
                running = false;
            }
        }

        public async Task Reset()
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

        public int Inside()
        {
            int inside = 0;

            foreach (HashSet<Point> set in points.Values)
            {
                inside += set.Count;
            }

            return inside;
        }

        public int All()
        {
            return Inside() + pointNotInPicture.Count;
        }

        public float Square()
        {
            return 100 * (float)Inside() / All();
        }

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

        private void addPoint(Point p)
        {
            Shape sh = Picture.Shape(p);
            if (sh != null)
            {
                points[sh].Add(p);
            }
            else
            {
                pointNotInPicture.Add(p);
            }
        }
    }
}
