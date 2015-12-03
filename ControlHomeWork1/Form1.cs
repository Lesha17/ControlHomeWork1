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
            float s = monteCarlo.Square();

            panel1.Visible = panel2.Visible = !float.IsNaN(s);

            label1.Visible = true;
            s1_label.Text = string.Format("{0} %", s);
            s1_label.Visible = true;

            label2.Visible = true;
            s2_label.Text = string.Format("{0} %", s);
            s2_label.Visible = true;
        }

        private async void start1()
        {
            button2.Enabled = true;
            stopToolStripMenuItem.Enabled = true;
            button3.Enabled = false;
            contToolStripMenuItem.Enabled = false;

            await monteCarlo.Reset();
            draw_watch.Reset();
            pictureBox1.Refresh();
            paintTimer.Start();

            await monteCarlo.Start();
        }

        private async void stop()
        {
            paintTimer.Stop();

            await monteCarlo.Stop();
            
            pictureBox1.Refresh();

            button2.Enabled = false;
            stopToolStripMenuItem.Enabled = false;
            button3.Enabled = true;
            contToolStripMenuItem.Enabled = true;
        }

        private async void cont()
        {
            button2.Enabled = true;
            stopToolStripMenuItem.Enabled = true;
            button3.Enabled = false;
            contToolStripMenuItem.Enabled = false;

            paintTimer.Start();

            await monteCarlo.Start();
            pictureBox1.Refresh();
        }

        private async void start2()
        {
            paintTimer.Stop();
            
            button2.Enabled = true;
            stopToolStripMenuItem.Enabled = true;
            button3.Enabled = false;
            contToolStripMenuItem.Enabled = false;

            await monteCarlo.Stop();

            await monteCarlo.Reset();

            pictureBox1.Refresh();

            int val = 0;
            if (!int.TryParse(comboBox1.Text, out val))
            {
                MessageBox.Show("Введите время должно быть целым положительным числом", "Ошибка");
                return;
            }

            if(val <= 0)
            {
                MessageBox.Show("Введите время должно быть целым положительным числом", "Ошибка");
                return;
            }
            
            Timer timer = new Timer();
            timer.Enabled = false;
            timer.Interval = val;
            timer.Tick += Timer_Tick;

            timer.Start();
            await monteCarlo.Start();

            button2.Enabled = false;
            stopToolStripMenuItem.Enabled = false;
            button3.Enabled = true;
            contToolStripMenuItem.Enabled = true;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            start1();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            stop();
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            cont();
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            start2();
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
        
        private void start1ToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            start1();
        }

        private void stopToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            stop();
        }

        private void contToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            cont();
        }

        private void setTimeToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            tabControl1.SelectTab(1);
            comboBox1.Select();
        }

        private void pictureBox1_MouseHover(object sender, System.EventArgs e)
        {
            toolTip1.Show("", this);
        }

        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if(comboBox1.Text == "100500100500")
            {
                MessageBox.Show("Ха - Ха", "Это шутка!");
            }
        }

        private void showInfo()
        {
            MessageBox.Show(string.Format("Всего вброшено: {0}\n" +
                 "Попало в фигуру: {1}\n" +
                "Площадь: {2} %", monteCarlo.All(), monteCarlo.Inside(), monteCarlo.Square()),
                "Информация");
        }

        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            showInfo();
        }

        private void panel2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            showInfo();
        }
    }
}
