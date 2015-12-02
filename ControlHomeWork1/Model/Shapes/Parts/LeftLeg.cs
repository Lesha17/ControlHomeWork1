using System.Drawing;
using ControlHomeWork1.Model.Shapes.Primitives;

namespace ControlHomeWork1.Model.Shapes.Parts
{
    class LeftLeg : Parallelogram
    {
        // Параллелограмм образован точкой M и вокторами A и B
        
        public override Vector A { get; } = new Vector(0.225f, -0.05f);
        
        public override Vector B { get; } = new Vector (0f, -0.175f);

        //Координаты точки M
        public override Primitives.Point M { get; } = new Primitives.Point(0.135f, 0.7f);

        public override Color Color { get; set; } = Color.DarkCyan;
    }
}
