using System;


namespace Oop.Tasks.Paint.Interface
{
  // ���������, ����������� �������� �������
  //
	public interface IPaintPluginContext
	{
    // ������ ���� � ���������� �������
    string PluginDir { get; }

    // �������� ����������
    IPaintApplicationContext ApplicationContext { get; }
	}
}
