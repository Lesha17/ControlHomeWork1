/*
    Контрольное домашнее задание модуль 2
    Дисциплина: Программирование
    Группа: БПИ154(2)
    Студент: Мачнев Алексей Евгеньевич
    Вариант: 14
    Дата: 04.12.2015
*/

using System.Windows.Forms;
using ControlHomeWork1.Controller;

namespace ControlHomeWork1
{
    public partial class Form1 : Form
    {
        // Экземпляр метода Монте - Карло
        private MonteCarlo monteCarlo = new MonteCarlo(new Model.Picture());

        // Таймер для периодической перерисовки результатов работы метода Монте - Карло
        private Timer paintTimer = new Timer();

        // Измеряет время перерисовки;
        // Используется для более эффективного использования времени
        // и для задания интервала таймера paintTimer
        private System.Diagnostics.Stopwatch draw_watch = new System.Diagnostics.Stopwatch();

        // Показывает режим отображения изображения:
        // рисовать результаты работы метода Монте - Карло 
        // или раскрашенного изображения
        private bool drawColorfull = false;

        public Form1()
        {
            InitializeComponent();

            // Запуск таймера
            paintTimer.Interval = 100;
            paintTimer.Tick += PaintTimer_Tick;
        }
    }
}
