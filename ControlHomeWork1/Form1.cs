using System.Windows.Forms;
using ControlHomeWork1.Model.Shapes.Primitives;

using ControlHomeWork1.Controller;

namespace ControlHomeWork1
{
    public partial class Form1 : Form
    {
        private MonteCarlo monteCarlo = new MonteCarlo(new Model.Picture());

        public Form1()
        {
            InitializeComponent();
        }

        private async void repaint()
        {
            pictureBox1.Refresh();
            monteCarlo.Draw(pictureBox1.CreateGraphics(), pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Update();
        }
        
        private async void button1_Click(object sender, System.EventArgs e)
        {
            monteCarlo.Reset();
            repaint();
            await monteCarlo.Start();

            label1.Visible = true;
            s1_label.Text = string.Format("{0} %", monteCarlo.Square() * 100);
            s1_label.Visible = true;
        }

        private async void button2_Click(object sender, System.EventArgs e)
        {
            await monteCarlo.Stop();
            repaint();
        }

        private async void button3_Click(object sender, System.EventArgs e)
        {
            await monteCarlo.Start();
            repaint();

            label1.Visible = true;
            s1_label.Text = string.Format("{0} %", monteCarlo.Square() * 100);
            s1_label.Visible = true;
        }

        private async void button4_Click(object sender, System.EventArgs e)
        {
            monteCarlo.Reset();
            int val = 0;
            if(!int.TryParse(comboBox1.Text, out val))
            {
                return;
            }
            Timer timer = new Timer();
            timer.Enabled = false;
            timer.Interval = val;
            timer.Tick += Timer_Tick;

            timer.Start();
            await monteCarlo.Start();

            label2.Visible = true;
            s2_label.Text = string.Format("{0} %", monteCarlo.Square() * 100);
            s2_label.Visible = true;
        }

        private async void Timer_Tick(object sender, System.EventArgs e)
        {
            ((Timer)sender).Stop();
            await monteCarlo.Stop();
            repaint();
        }

        private void Form1_Resize(object sender, System.EventArgs e)
        {
            repaint();
        }
    }
}
