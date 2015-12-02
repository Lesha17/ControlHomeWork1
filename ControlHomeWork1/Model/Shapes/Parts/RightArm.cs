using System.Drawing;
using ControlHomeWork1.Model.Shapes.Primitives;

namespace ControlHomeWork1.Model.Shapes.Parts
{
    class RightArm : Parallelogram
    {
        // Параллелограмм образован точкой M и вокторами A и B

        // Координаты вектора a
        public override Vector A { get; } =  new Vector(0.3f, 0.04f);

        // Координаты вектора B
        public override Vector B { get; } =  new Vector(0f, 0.14f);

        //Координаты точки M
        public override Primitives.Point M { get; } =  new Primitives.Point(0.43f, 0.11f);

        public override Color Color { get; set; } = Color.Green;
    }
}
