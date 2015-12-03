using System.Windows.Forms;
using ControlHomeWork1.Model.Shapes.Primitives;

using System.Threading.Tasks;

using ControlHomeWork1.Controller;

namespace ControlHomeWork1
{
    public partial class Form1 : Form
    {
        private MonteCarlo monteCarlo = new MonteCarlo(new Model.Picture());

        private Timer paintTimer = new Timer();

        private System.Diagnostics.Stopwatch draw_watch = new System.Diagnostics.Stopwatch();

        private bool drawColorfull = false;

        public Form1()
        {
            InitializeComponent();

            paintTimer.Interval = 100;
            paintTimer.Tick += PaintTimer_Tick;
        }

        private void PaintTimer_Tick(object sender, System.EventArgs e)
        {
            pictureBox1.Invalidate();
            paintTimer.Interval = (int)(draw_watch.ElapsedMilliseconds * 2) + 10;
        }

        private async Task paint(System.Drawing.Graphics gr, int width, int height)
        {
            if (!drawColorfull)
            {
                draw_watch.Restart();
                lock (monteCarlo)
                {
                    monteCarlo.Draw(gr, width, height);
                    
                    show_sq();
                }
                draw_watch.Stop();
            }
            else
            {
                gr.Clear(System.Drawing.Color.DarkBlue);

                monteCarlo.Picture.DrawColorfull(gr, width, height);

                show_sq();
            }
        }

        private void show_sq()
        {
            float s = monteCarlo.Square() * 100;

            panel1.Visible = panel2.Visible = !float.IsNaN(s);

            label1.Visible = true;
            s1_label.Text = string.Format("{0} %", s);
            s1_label.Visible = true;

            label2.Visible = true;
            s2_label.Text = string.Format("{0} %", s);
            s2_label.Visible = true;
        }

        private async void button1_Click(object sender, System.EventArgs e)
        {
            button2.Enabled = true;
            button3.Enabled = false;

            monteCarlo.Reset();
            draw_watch.Reset();
            pictureBox1.Refresh();
            paintTimer.Start();

            await monteCarlo.Start();
        }

        private async void button2_Click(object sender, System.EventArgs e)
        {
            await monteCarlo.Stop();
            pictureBox1.Refresh();

            button2.Enabled = false;
            button3.Enabled = true;
        }

        private async void button3_Click(object sender, System.EventArgs e)
        {
            button2.Enabled = true;
            button3.Enabled = false;

            await monteCarlo.Start();
            pictureBox1.Refresh();
        }

        private async void button4_Click(object sender, System.EventArgs e)
        {
            button2.Enabled = true;
            button3.Enabled = false;

            monteCarlo.Reset();
            int val = 0;
            if (!int.TryParse(comboBox1.Text, out val))
            {
                return;
            }
            Timer timer = new Timer();
            timer.Enabled = false;
            timer.Interval = val;
            timer.Tick += Timer_Tick;

            timer.Start();
            await monteCarlo.Start();
            
            button2.Enabled = false;
            button3.Enabled = true;
        }

        private async void Timer_Tick(object sender, System.EventArgs e)
        {
            ((Timer)sender).Stop();
            await monteCarlo.Stop();
            pictureBox1.Refresh();
        }

        private async void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            await paint(e.Graphics, pictureBox1.Width, pictureBox1.Height);
        }

        private void pictureBox1_Resize(object sender, System.EventArgs e)
        {
            pictureBox1.Invalidate();
        }

        private void pictureBox1_DoubleClick(object sender, System.EventArgs e)
        {
            drawColorfull = !drawColorfull;

            pictureBox1.Invalidate();
        }
    }
}
