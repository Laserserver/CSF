using System;


namespace Oop.Tasks.Paint.Interface
{
  // ����� ���������, ������� ���������, ��� ������
  // ������ (���������� IPaintPlugin) ������������ ��� ��������
  // (� ��, ��������, �����-������ ������ �������� ��������)
  //
  [AttributeUsage(AttributeTargets.Class, Inherited=true)]
	public sealed class PluginForLoadAttribute: Attribute
	{
    private bool forLoad=false;


    public PluginForLoadAttribute(bool forLoad) {
      this.forLoad=forLoad;
    }


    public bool ForLoad {
      get {
        return forLoad;
      }
    }
	}
}
