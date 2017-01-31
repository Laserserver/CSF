using System;
using System.Drawing;
using System.Windows.Forms;


namespace Oop.Tasks.Paint.Interface
{
  // »нтерфейс плагина-инструмента
  // (т.е. такого, работа с которым продолжительна и
  //  подразумевает использование мышки)
  //
	public interface IToolPaintPlugin: IPaintPlugin
	{
    // вызываетс€ при событии на изображении
    // MouseDown;
    void MouseDown(MouseEventArgs me,
                   Keys modifierKeys);

    // вызываетс€ при событии на изображении
    // MouseUp
    void MouseUp(MouseEventArgs me,
                 Keys modifierKeys);

    // вызываетс€ при событии на изображении
    // MouseMove
    void MouseMove(MouseEventArgs me,
                   Keys modifierKeys);

    // вызываетс€ при нажатии клавиши Escape
    void Escape();

    // вызываетс€ при нажатии клавиши Enter
    void Enter();

    // вызываетс€ при изменении цветов
    // ForegroundColor или BackgroundColor
    void ColorChange();

    // вызываетс€ при изменении (возможности
    // изменени€) изображени€
    // во врем€ активности плагина
    // (например, при загрузке нового изображени€)
    void ImageChange();


    // название инструмента
    // (например, " арандаш" или "–езинка")
    string ToolName { get; }

    // пиктограмма дл€ инструмента
    // (изображение 24 x 24)
    // (прозрачным считаетс€ цвет точки
    //  с координатами (0, 0))
    Image Icon { get; }
	}
}
