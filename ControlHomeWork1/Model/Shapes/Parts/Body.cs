using System.Drawing;
using ControlHomeWork1.Model.Shapes.Primitives;

namespace ControlHomeWork1.Model.Shapes.Parts
{
    class Body : Primitives.Parallelogram
    {
        // Параллелограмм образован точкой M и вокторами A и B
        
        public override Vector A { get; } = new Vector(0.4f, 0f);

        public override Vector B { get; } = new Vector(0f, 0.37f);

        public override Primitives.Point M { get; } = new Primitives.Point(0.36f, 0.29f);

        public override Color Color { get; set; } = Color.LawnGreen;
    }
}
