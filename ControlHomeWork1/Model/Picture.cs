using System.Collections.Generic;
using System.Drawing;
using ControlHomeWork1.Model.Shapes.Parts;
using ControlHomeWork1.Model.Shapes.Primitives;

namespace ControlHomeWork1.Model
{
    // Представляет исследуемый рисунок
    public class Picture
    {
        //Список всех фигур
        List<Shape> shapes = new List<Shape>();

        public Picture()
        {
            init();
        }

        public List<Shape> Shapes
        {
            get { return shapes; }
        }

        // Рисует контуром данный рисунок
        public void Draw(Graphics gr, int width, int height)
        {
            foreach (Shape shape in shapes)
            {
                shape.Draw(gr, width, height);
            }
        }

        // Рисует данный рисунок контуром и закрашивает каждую фигуру в соответствующий ей цвет
        public void DrawColorfull(Graphics gr, int width, int height)
        {
            foreach (Shape shape in shapes)
            {
                shape.DrawColorful(gr, width, height);
            }
        }

        // Определяет, какой фигуре принадлежит точка
        public Shape Shape(Shapes.Primitives.Point p)
        {
            return shapes.FindLast((System.Predicate<Model.Shape>)delegate (Shape sh)
           {
               return sh.IsInside(p);
           });
        }

        // Строит рисунок из фигур
        private void init()
        {

            //Left Foot 
            Triangle lf = new Triangle();
            lf.M = new Shapes.Primitives.Point(0f, 0f);
            lf.A = new Vector(0f, 0.4f);
            lf.B = new Vector(0.135f, 0.4f);
            lf.Color = Color.SaddleBrown;

            //RightFoot 
            Triangle rf = new Triangle();
            rf.M = new Shapes.Primitives.Point(0f, 1.0f);
            rf.A = new Vector(0f, -0.45f);
            rf.B = new Vector(0.135f, -0.45f);
            rf.Color = Color.SaddleBrown;

            //Left Leg 
            Parallelogram ll = new Parallelogram();
            ll.M = new Shapes.Primitives.Point(0.135f, 0.7f);
            ll.A = new Vector(0.225f, -0.05f);
            ll.B = new Vector(0f, -0.175f);
            ll.Color = Color.DarkCyan;

            //Right Leg 
            Parallelogram rl = new Parallelogram();
            rl.M = new Shapes.Primitives.Point(0.135f, 0.24f);
            rl.A = new Vector(0.225f, 0.05f);
            rl.B = new Vector(0f, 0.175f);
            rl.Color = Color.DarkCyan;

            //Left Hand
            Ellipse lh = new Ellipse();
            lh.LC = new Shapes.Primitives.Point(0.34f, 0.69f); //Левый верхний угол
            lh.HD = 0.09f; //Horizontal diameter
            lh.VD = 0.16f; //Vertical diameter
            lh.Color = Color.Bisque;

            //Left Arm 
            Parallelogram la = new Parallelogram();
            la.M = new Shapes.Primitives.Point(0.43f, 0.84f);
            la.A = new Vector(0.3f, -0.04f);
            la.B = new Vector(0f, -0.14f);
            la.Color = Color.Green;

            //Right Arm 
            Parallelogram ra = new Parallelogram();
            ra.M = new Shapes.Primitives.Point(0.43f, 0.11f);
            ra.A = new Vector(0.3f, 0.04f);
            ra.B = new Vector(0f, 0.14f);
            ra.Color = Color.Green;

            //Right Hand 
            Ellipse rh = new Ellipse();
            rh.LC = new Shapes.Primitives.Point(0.34f, 0.1f);
            rh.HD = 0.09f; //Horizontal diameter
            rh.VD = 0.16f; //Vertical diameter
            rh.Color = Color.Bisque;

            //Body 
            // Параллелограмм образован точкой M и вокторами A и B
            Parallelogram b = new Parallelogram();
            b.M = new Shapes.Primitives.Point(0.36f, 0.29f);
            b.A = new Vector(0.4f, 0f);
            b.B = new Vector(0f, 0.37f);
            b.Color = Color.LawnGreen;

            //Head 
            Ellipse h = new Ellipse();
            h.LC = new Shapes.Primitives.Point(0.76f, 0.29f);
            h.HD = 0.23f; //Horizontal diameter
            h.VD = 0.37f; //Vertical diameter
            h.Color = Color.Bisque;

            /*
            * Все остальные параметры переопределены в классе Eye
            */

            //Left Eye
            Eye le = new Eye();
            le.LC = new Shapes.Primitives.Point(0.89f, 0.41f);

            //Right Eye 
            Eye re = new Eye();
            re.LC = new Shapes.Primitives.Point(0.89f, 0.52f);

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
