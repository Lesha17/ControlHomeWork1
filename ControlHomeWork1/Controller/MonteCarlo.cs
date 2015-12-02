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
        private Dictionary<Shape, HashSet<Point>> points;
        private HashSet<Point> pointNotInPicture;
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

        public void Reset()
        {
            points = new Dictionary<Shape, HashSet<Point>>();
            pointNotInPicture = new HashSet<Point>();

            foreach (Shape sh in Picture.Shapes)
            {
                points.Add(sh, new HashSet<Point>());
            }
        }

        public float Square()
        {
            float inside = 0f;

            foreach(HashSet<Point> set in points.Values)
            {
                inside += set.Count;
            }

            return inside / (inside + pointNotInPicture.Count);
        }

        private async Task createPoints()
        {
            await Task.Run(delegate {
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
            if(sh != null)
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
