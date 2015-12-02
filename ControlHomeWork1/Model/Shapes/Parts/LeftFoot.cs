using System.Drawing;
using ControlHomeWork1.Model.Shapes.Primitives;

namespace ControlHomeWork1.Model.Shapes.Parts
{
    class LeftFoot : Triangle
    {
        public override Primitives.Point M { get; } = new Primitives.Point(0f, 0f);
        public override Vector A { get; } = new Vector(0f, 0.4f);
        public override Vector B { get; } = new Vector(0.135f, 0.4f);

        public override Color Color { get; set; } = Color.SaddleBrown;
    }
}
