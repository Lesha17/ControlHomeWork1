using System.Windows.Forms;
using ControlHomeWork1.Model.Shapes.Primitives;

namespace ControlHomeWork1
{
    public partial class Form1 : Form
    {
        private Model.Picture picture = new Model.Picture();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            pictureBox1.Refresh();
            picture.Draw(pictureBox1.CreateGraphics(), pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Update();
        }
        

        /*
        * Это тест))
        */
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            float x = (float)e.X / pictureBox1.Width;
            float y = (float)e.Y / pictureBox1.Height;

            Point p = new Point(x, y);

            pictureBox1.Refresh();
            picture.Draw(pictureBox1.CreateGraphics(), pictureBox1.Width, pictureBox1.Height);
            picture.PP(p, pictureBox1.CreateGraphics(), pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Update();
        }
    }
}
