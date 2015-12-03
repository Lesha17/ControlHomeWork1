using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ControlHomeWork1.Model;

using System.Drawing;

namespace ControlHomeWork1.Controller
{
    partial class MonteCarlo
    {
        public void Draw(Graphics gr, int width, int height)
        {
            Picture.Draw(gr, width, height);

            


            foreach (KeyValuePair<Shape, HashSet<ControlHomeWork1.Model.Shapes.Primitives.Point>> entry in points)
            {
                if (entry.Value.Count > 0)
                {
                    gr.FillRectangles(new SolidBrush(entry.Key.Color), rects(entry.Value, width, height));
                }
            }

            if (pointNotInPicture.Count > 0)
            {
                gr.FillRectangles(new SolidBrush(Color.DarkBlue), rects(pointNotInPicture, width, height));
            }
        }

        private Rectangle[] rects(IEnumerable<Model.Shapes.Primitives.Point> points, int width, int height)
        {
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
