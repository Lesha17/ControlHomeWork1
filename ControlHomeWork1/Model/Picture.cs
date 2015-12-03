using System.Collections.Generic;
using System.Drawing;
using ControlHomeWork1.Model.Shapes.Parts;
using ControlHomeWork1.Model.Shapes.Primitives;

namespace ControlHomeWork1.Model
{
    public class Picture
    {
        List<Shape> shapes = new List<Shape>();

        public Picture()
        {
            init();
        }

        public List<Shape> Shapes
        {
            get { return shapes; }
        }

        public void Draw(Graphics gr, int width, int height)
        {
            foreach(Shape shape in shapes)
            {
                shape.Draw(gr, width, height);
            }
        }

        public void DrawColorfull(Graphics gr, int width, int height)
        {
            foreach (Shape shape in shapes)
            {
                shape.DrawColorful(gr, width, height);
            }
        }

        public Shape Shape(Shapes.Primitives.Point p)
        {
            return shapes.FindLast((System.Predicate<Model.Shape>) delegate (Shape sh)
            {
                return sh.IsInside(p);
            });
        }

        private void init()
        {
            LeftFoot lf = new LeftFoot();
            RightFoot rf = new RightFoot();

            LeftLeg ll = new LeftLeg();
            RightLeg rl = new RightLeg();

            LeftHand lh = new LeftHand();
            LeftArm la = new LeftArm();

            Body b = new Body();

            RightHand rh = new RightHand();
            RightArm ra = new RightArm();

            LeftEye le = new LeftEye();
            RightEye re = new RightEye();

            Head h = new Head();

            shapes.Add(lf);
            shapes.Add(rf);

            shapes.Add(ll);
            shapes.Add(rl);

            shapes.Add(lh);
            shapes.Add(la);

            shapes.Add(b);

            shapes.Add(ra);
            shapes.Add(rh);

            shapes.Add(h);

            shapes.Add(le);
            shapes.Add(re);

        }
    }
}
