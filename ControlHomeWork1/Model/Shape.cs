using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ControlHomeWork1.Model
{
    public abstract class Shape
    {
        public Shape() { }

        public abstract bool IsInside(Shapes.Primitives.Point p);
        public abstract void Draw(Graphics gr, int width, int height);
        public abstract void DrawColorful(Graphics gr, int width, int height);
        public abstract Color Color { get; set; }
    }
}
