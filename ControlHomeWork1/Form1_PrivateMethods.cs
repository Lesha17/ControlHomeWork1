using System;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace ControlHomeWork1
{
    public partial class Form1
    {
        // Отрисовка данного изображения и результатов работы метода Монте - Карло на pictureBox1.
        private async Task paint(System.Drawing.Graphics gr, int width, int height)
        {
            try
            {
                if (!drawColorfull)
                {
                    // Измеряем время рисования результатов работы метода  Монте - Карло
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
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка");
            }
        }

        // Отображает площадь на панели отображения площади
        private void show_sq()
        {
            try
            {
                float s = monteCarlo.Square();

                panel1.Visible = panel2.Visible = !float.IsNaN(s) && !float.IsInfinity(s);

                s1_label.Text = string.Format("{0} %", s);
                
                s2_label.Text = string.Format("{0} %", s);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка");
            }
        }

        // Отображает более подробную информацию о результатах работы метода Монте - Карло в диалоговом окне.
        private void showInfo()
        {
            try
            {
                MessageBox.Show(string.Format("Всего вброшено: {0}\n" +
                     "Попало в фигуру: {1}\n" +
                    "Площадь: {2} %", monteCarlo.All(), monteCarlo.Inside(), monteCarlo.Square()),
                    "Информация");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка");
            }
        }

        // Направляет фокус на элемент выбора времени.
        private void selectTime()
        {
            try
            {
                tabControl1.SelectTab(1);
                comboBox1.Select();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка");
            }
        }

        // Запускает бесконечный режим работы метода Монте - Карло и отображает результаты при остановке.
        private async void start1()
        {
            try
            {
                button2.Enabled = true;
                stopToolStripMenuItem.Enabled = true;
                button3.Enabled = false;
                contToolStripMenuItem.Enabled = false;

                await monteCarlo.ResetAsync();
                draw_watch.Reset();
                pictureBox1.Refresh();
                paintTimer.Start();

                await monteCarlo.StartAsync();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка");
            }
        }

        // Останавливает работу метода Монте - Карло
        private async void stop()
        {
            try
            {
                paintTimer.Stop();

                await monteCarlo.StopAsync();

                pictureBox1.Refresh();

                button2.Enabled = false;
                stopToolStripMenuItem.Enabled = false;
                button3.Enabled = true;
                contToolStripMenuItem.Enabled = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка");
            }
        }

        // Продолжает работу метода Монте - Карло в бесконечном режиме
        private async void cont()
        {
            try
            {
                button2.Enabled = true;
                stopToolStripMenuItem.Enabled = true;
                button3.Enabled = false;
                contToolStripMenuItem.Enabled = false;

                paintTimer.Start();

                await monteCarlo.StartAsync();
                pictureBox1.Refresh();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка");
            }
        }

        // Запускает работу метода Монте - Карло в режиме с таймером 
        // и отображает результаты по завершении / при остановке
        private async void start2()
        {
            try
            {
                paintTimer.Stop();

                button2.Enabled = true;
                stopToolStripMenuItem.Enabled = true;
                button3.Enabled = false;
                contToolStripMenuItem.Enabled = false;

                await monteCarlo.StopAsync();

                await monteCarlo.ResetAsync();

                int val = 0;
                if (!int.TryParse(comboBox1.Text, out val))
                {
                    MessageBox.Show("Введённое время должно быть целым положительным числом", "Ошибка");
                    selectTime();
                    return;
                }

                if (val <= 0)
                {
                    MessageBox.Show("Введённое время должно быть целым положительным числом", "Ошибка");
                    selectTime();
                    return;
                }

                pictureBox1.Refresh();

                Timer timer = new Timer();
                timer.Enabled = false;
                timer.Interval = val;
                timer.Tick += Timer_Tick;

                timer.Start();
                await monteCarlo.StartAsync();

                button2.Enabled = false;
                stopToolStripMenuItem.Enabled = false;
                button3.Enabled = true;
                contToolStripMenuItem.Enabled = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка");
            }
        }

        // Событие срабатывания таймера перерисовки
        private void PaintTimer_Tick(object sender, System.EventArgs e)
        {
            try
            {
                pictureBox1.Invalidate();
                paintTimer.Interval = (int)(draw_watch.ElapsedMilliseconds * 2) + 10;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        // Событие срабатывания таймера для режима с таймером
        private async void Timer_Tick(object sender, System.EventArgs e)
        {
            try
            {
                ((Timer)sender).Stop();
                await monteCarlo.StopAsync();
                pictureBox1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }
    }
}
