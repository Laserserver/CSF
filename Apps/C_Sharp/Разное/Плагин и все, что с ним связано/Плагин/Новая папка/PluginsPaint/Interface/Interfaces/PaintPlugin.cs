using System;


namespace Oop.Tasks.Paint.Interface
{
  // ������� ��������� �������
  //
  public interface IPaintPlugin
  {
    // ���������� ����� �������� �������
    // (���������� ������ �������)
    void AfterCreate(IPaintPluginContext
                     pluginContext);

    // ���������� ����� ������������ �������
    void BeforeDestroy();

    // ���������� ��� ������ ������� �� ������
    // ������������ � ��� ������ ������
    // (��������, ���������� ������ ������);
    // selection - ����������, ������ ��
    //     ������ (true) ��� ��, ��������,
    //     ������ � ��������� ������������
    void Select(bool selection);


    // �������� �������
    string Name { get; }

    // ��������, ������� ��������� ������ ������
    // (��������, "������� �����������")
    string CommandName { get; }
  }
}
