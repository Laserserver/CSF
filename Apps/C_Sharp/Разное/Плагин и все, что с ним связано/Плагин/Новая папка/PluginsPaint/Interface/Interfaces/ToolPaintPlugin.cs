using System;
using System.Drawing;
using System.Windows.Forms;


namespace Oop.Tasks.Paint.Interface
{
  // ��������� �������-�����������
  // (�.�. ������, ������ � ������� �������������� �
  //  ������������� ������������� �����)
  //
	public interface IToolPaintPlugin: IPaintPlugin
	{
    // ���������� ��� ������� �� �����������
    // MouseDown;
    void MouseDown(MouseEventArgs me,
                   Keys modifierKeys);

    // ���������� ��� ������� �� �����������
    // MouseUp
    void MouseUp(MouseEventArgs me,
                 Keys modifierKeys);

    // ���������� ��� ������� �� �����������
    // MouseMove
    void MouseMove(MouseEventArgs me,
                   Keys modifierKeys);

    // ���������� ��� ������� ������� Escape
    void Escape();

    // ���������� ��� ������� ������� Enter
    void Enter();

    // ���������� ��� ��������� ������
    // ForegroundColor ��� BackgroundColor
    void ColorChange();

    // ���������� ��� ��������� (�����������
    // ���������) �����������
    // �� ����� ���������� �������
    // (��������, ��� �������� ������ �����������)
    void ImageChange();


    // �������� �����������
    // (��������, "��������" ��� "�������")
    string ToolName { get; }

    // ����������� ��� �����������
    // (����������� 24 x 24)
    // (���������� ��������� ���� �����
    //  � ������������ (0, 0))
    Image Icon { get; }
	}
}
