/*
    Контрольное домашнее задание модуль 2
    Дисциплина: Программирование
    Группа: БПИ154(2)
    Студент: Мачнев Алексей Евгеньевич
    Вариант: 14
    Дата: 04.12.2015
*/

using System.Windows.Forms;

namespace ControlHomeWork1
{
    public partial class Form1
    {
        // Событие отрисовки pictureBox1
        private async void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            await paint(e.Graphics, pictureBox1.Width, pictureBox1.Height);
        }

        // Событие изменения размеров pictureBox1
        private void pictureBox1_Resize(object sender, System.EventArgs e)
        {
            pictureBox1.Invalidate();
        }

        // Событие нажатия кнопки Начать для бесконечного режима
        private void button1_Click(object sender, System.EventArgs e)
        {
            start1();
        }

        // Событие нажатия кнопки Остановить
        private void button2_Click(object sender, System.EventArgs e)
        {
            stop();
        }
        // Событие нажатия кнопки Продолжить
        private void button3_Click(object sender, System.EventArgs e)
        {
            cont();
        }

        // Событие нажатия кнопки Начать для режима с таймером
        private void button4_Click(object sender, System.EventArgs e)
        {
            start2();
        }

        // Событие двойного щелчка мыши по pictureBox1
        private void pictureBox1_DoubleClick(object sender, System.EventArgs e)
        {
            drawColorfull = !drawColorfull;

            pictureBox1.Invalidate();
        }

        // Событие выбора пункта меню "Начать" для бесконечного режима
        private void start1ToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            start1();
        }

        // Событие выбора пункта меню "Остановить" для бесконечного режима 
        private void stopToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            stop();
        }

        // Событие выбора пункта меню "Продолжить" для бесконечного режима
        private void contToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            cont();
        }

        // Событие выбора пункта меню "Установить время" для режима с таймером
        private void setTimeToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            selectTime();
        }

        // Событие выбора пункта меню "Начать" для режима с таймером
        private void start2ToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            start2();
        }

        // на случай, если пользователь выберет не то
        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (comboBox1.Text == "100500100500")
            {
                MessageBox.Show("Ха - Ха", "Это шутка!");
            }
        }

        // Событие двойного щелчка по панели отображения результатов во вкладке бесконечного режима 
        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            showInfo();
        }

        // Событие двойного щелчка по панели отображения результатов во вкладке режима с таймером
        private void panel2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            showInfo();
        }

        // Событие нажатия клавиши на форме
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case ('S'):
                    switch (tabControl1.SelectedIndex)
                    {
                        case (0):
                            start1();
                            break;
                        case (1):
                            start2();
                            break;
                        default:
                            break;
                    }
                    break;
                case ('s'):
                    switch (tabControl1.SelectedIndex)
                    {
                        case (0):
                            start1();
                            break;
                        case (1):
                            start2();
                            break;
                        default:
                            break;
                    }
                    break;

                case ('P'):
                    if (button2.Enabled)
                    {
                        stop();
                    }
                    break;
                case ('p'):
                    if (button2.Enabled)
                    {
                        stop();
                    }
                    break;

                case ('C'):
                    if (button3.Enabled)
                    {
                        cont();
                    }
                    break;
                case ('c'):
                    if (button3.Enabled)
                    {
                        cont();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
