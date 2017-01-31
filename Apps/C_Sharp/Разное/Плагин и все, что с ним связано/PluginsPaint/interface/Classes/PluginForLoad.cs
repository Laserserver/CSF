using System;


namespace Oop.Tasks.Paint.Interface
{
  // Класс аттрибута, который указывает, что данный
  // плагин (реализация IPaintPlugin) предназначен для загрузки
  // (а не, допустим, какой-нибудь предок конечных плагинов)
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
