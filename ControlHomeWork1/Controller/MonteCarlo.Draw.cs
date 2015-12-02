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

            Func<ControlHomeWork1.Model.Shapes.Primitives.Point, Rectangle> selector =
                    delegate (ControlHomeWork1.Model.Shapes.Primitives.Point p)
                    {
                        return new Rectangle((int)(p.X * width), (int)(p.Y * height), 1, 1);
                    };

            foreach (KeyValuePair<Shape, List<ControlHomeWork1.Model.Shapes.Primitives.Point>> entry in points)
            {
                gr.FillRectangles(new SolidBrush(entry.Key.Color), entry.Value.Select(selector).ToArray());
            }
        }
    }
}
