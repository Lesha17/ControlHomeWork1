using System;
using System.Drawing;

namespace ControlHomeWork1.Model.Shapes.Primitives
{
    public class Ellipse : Shape
    {
        public virtual Point LC { get; set; } //Left Corner
        public virtual float HD { get; set; } //Horizontal diameter
        public virtual float VD { get; set; } //Vertical diameter

        public Ellipse() { }

        public Ellipse(Point LC, float HD, float VD, Color Color)
        {
            this.LC = LC;
            this.HD = HD;
            this.VD = VD;
            this.Color = Color;
        }

        //Принадлежность точки еллипсу
        public override bool IsInside(Primitives.Point p)
        {
            float a = Math.Max(HD, VD) / 2f; // большая полуось
            float b = Math.Min(HD, VD) / 2f; // малая полуось

            //эксцентриситет
            float e = (float)Math.Sqrt(Math.Pow(a, 2) - Math.Pow(b, 2)) / a;

            // Фокусы в Системе координат с центром, совпадающем с центром еллипса
            float f1 = -a * e;
            float f2 = a * e;

            // Приводим к другой системе координат
            float _x = p.X - LC.X - HD / 2;
            float _y = p.Y - LC.Y - VD / 2;

            //Важно, была большая полуось вертикальной, или горизонтальной
            if (VD > HD)
            {
                return (Math.Sqrt(Math.Pow(_x, 2) + Math.Pow(f1 - _y, 2)) + Math.Sqrt(Math.Pow(_x, 2) + Math.Pow(f2 - _y, 2))) <= 2 * a;
            }
            else
            {
                return (Math.Sqrt(Math.Pow(f1 - _x, 2) + Math.Pow(_y, 2)) + Math.Sqrt(Math.Pow(f2 - _x, 2) + Math.Pow(_y, 2))) <= 2 * a;
            }
        }

        //Нарисовать контур
        public override void Draw(Graphics gr, int width, int height)
        {
            Rectangle r = new Rectangle((int)(LC.X * width), (int)(LC.Y * height), (int)(HD * width), (int)(VD * height));
            gr.DrawEllipse(Statics.PEN, r);
        }

        //Нарисовать контур и закрасить цветом Color
        public override void DrawColorful(Graphics gr, int width, int height)
        {
            Rectangle r = new Rectangle((int)(LC.X * width), (int)(LC.Y * height), (int)(HD * width), (int)(VD * height));
            gr.FillEllipse(new SolidBrush(Color), r);
            gr.DrawEllipse(Statics.PEN, r);
        }
    }
}
