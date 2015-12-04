/*
    Контрольное домашнее задание модуль 2
    Дисциплина: Программирование
    Группа: БПИ154(2)
    Студент: Мачнев Алексей Евгеньевич
    Вариант: 14
    Дата: 04.12.2015
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ControlHomeWork1.Model
{
    //Представляет абстрактный класс фигуры
    public abstract class Shape
    {
        public Shape() { }

        //Проверяет на принадлежность точки p фигуре
        public abstract bool IsInside(Shapes.Primitives.Point p);

        //Рисует контур фигуры
        public abstract void Draw(Graphics gr, int width, int height);

        //Рисует контур фигуры и красит её цветом Color
        public abstract void DrawColorful(Graphics gr, int width, int height);

        //Цвет для закрашивания фигуры
        public virtual Color Color { get; set; }
    }
}
