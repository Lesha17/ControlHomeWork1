using System.Drawing;
using ControlHomeWork1.Model.Shapes.Primitives;

namespace ControlHomeWork1.Model.Shapes.Parts
{
    class LeftArm : Parallelogram
    {
        // Параллелограмм образован точкой M и вокторами A и B

        public override Vector A { get; } = new Vector(0.3f, -0.04f);
        
        public override Vector B { get; } = new Vector(0f, -0.14f);

        public override Primitives.Point M { get; } = new Primitives.Point(0.43f, 0.84f);
        
        public override Color Color { get; set; } = Color.Green;
    }
}
