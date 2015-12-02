using System.Drawing;
using ControlHomeWork1.Model.Shapes.Primitives;

namespace ControlHomeWork1.Model.Shapes.Parts
{
    class RightEye : Ellipse
    {
        public override Primitives.Point LC { get; } =  new Primitives.Point(0.89f, 0.41f);
        public override float HD { get; } =  0.02f; //Horizontal diameter
        public override float VD { get; } =  0.03f; //Vertical diameter

        public override void Draw(Graphics gr, int width, int height)
        {
            Brush br = new SolidBrush(Color.Gray);
            Rectangle r = new Rectangle((int)(LC.X * width), (int)(LC.Y * height), (int)(HD * width), (int)(VD * height));
            gr.FillEllipse(br, r);
            gr.DrawEllipse(Statics.PEN, r);
        }

        public override Color Color { get; set; } = Color.LightBlue;
    }
}
