using System.Drawing;
using ControlHomeWork1.Model.Shapes.Primitives;

namespace ControlHomeWork1.Model.Shapes.Parts
{
    class RightFoot : Triangle
    {
        public override Primitives.Point M { get; } = new Primitives.Point(0f, 1.0f);
        public override Vector A { get; } = new Vector(0f, -0.45f);
        public override Vector B { get; } = new Vector(0.135f, -0.45f);

        public override Color Color { get; set; } = Color.SaddleBrown;
    }
}
