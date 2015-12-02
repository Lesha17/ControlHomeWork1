using System.Drawing;
using ControlHomeWork1.Model.Shapes.Primitives;

namespace ControlHomeWork1.Model.Shapes.Parts
{
    class Head : Ellipse
    {
        public override Primitives.Point LC { get; } = new Primitives.Point(0.76f, 0.3f); // Left Corner
        public override float HD { get; } = 0.23f; //Horizontal diameter
        public override float VD { get; } = 0.37f; //Vertical diameter

        public override void Draw(Graphics gr, int width, int height)
        {
            Rectangle r = new Rectangle((int)(LC.X * width), (int)(LC.Y * height), (int)(HD * width), (int)(VD * height));
            gr.DrawEllipse(Statics.PEN, r);
        }
         
        public override Color Color { get; set; } = Color.Bisque;
    }
}
