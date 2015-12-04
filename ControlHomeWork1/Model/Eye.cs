/*
    Контрольное домашнее задание модуль 2
    Дисциплина: Программирование
    Группа: БПИ154(2)
    Студент: Мачнев Алексей Евгеньевич
    Вариант: 14
    Дата: 04.12.2015
*/

using System.Drawing;
using ControlHomeWork1.Model.Shapes.Primitives;

namespace ControlHomeWork1.Model.Shapes.Parts
{
    class Eye : Ellipse
    {
        public override float HD { get; set; } = 0.02f; //Horizontal diameter
        public override float VD { get; set; } = 0.03f; //Vertical diameter

        // Незакрашенные глаза должны быть серыми...
        public override void Draw(Graphics gr, int width, int height)
        {
            Brush br = new SolidBrush(Color.Gray);
            Rectangle r = new Rectangle((int)(LC.X * width), (int)(LC.Y * height), (int)(HD * width), (int)(VD * height));
            gr.FillEllipse(br, r);
            gr.DrawEllipse(Statics.PEN, r);
        }
        
        public override Color Color { get; set; } = Color.LightBlue;
    }
}
