using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlugIn;

namespace MyPlugin
{
    public class PlugIn : IPlugin
    {
        private string _PluginName = "MyPlugin";
        private string _DisplayPluginName = "Дачник против кротов";
        private string _PluginDescription = "Плагин к задаче №3";
        private string _Author = "Зинькевич Георгий";
        private double _Version = 2;
        private IPluginHost _Host;

        public void Show()
        {
            MyPlugForm form = new MyPlugForm(this);
            form.ShowDialog();
        }

        public IPluginHost Host
        {
            get { return this._Host; }
            set
            {
                this._Host = value;
                this._Host.Register(this);
            }
        }

        public string PluginName
        {
            get { return this._PluginName; }
        }

        public string DisplayPluginName
        {
            get { return this._DisplayPluginName; }
        }

        public string PluginDescription
        {
            get { return this._PluginDescription; }
        }

        public string Author
        {
            get { return this._Author; }
        }

        public double Version
        {
            get { return this._Version; }
        }
    }
}
