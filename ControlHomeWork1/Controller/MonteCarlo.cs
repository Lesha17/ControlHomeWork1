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
        private Dictionary<Shape, List<Point>> points = new Dictionary<Shape, List<Point>>();
        private List<Point> pointNotInPicture = new List<Point>();
        private Boolean running = false;

        public Picture Picture { get; set; }

        public MonteCarlo(Picture pict)
        {
            this.Picture = pict;

            foreach(Shape sh in pict.Shapes)
            {
                points.Add(sh, new List<Point>());
            }
        }

        

        public async Task Start(int duration)
        {
            lock (this)
            {
                running = true;
            }

            await createPoints(duration);
        }

        public async Task Stop()
        {
            lock (this)
            {
                running = false;
            }
        }

        private async Task createPoints(int duration)
        {
            Random rand = new Random();

            while (running)
            {
                float x = (float)rand.NextDouble();
                float y = (float)rand.NextDouble();
                Point p = new Point(x, y);
                addPoint(p);

                if (running && duration > 0)
                {
                    Thread.Sleep(duration);
                }
            }
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
