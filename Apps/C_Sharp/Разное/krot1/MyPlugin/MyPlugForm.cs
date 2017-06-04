using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PlugIn;

namespace MyPlugin
{
    public partial class MyPlugForm : Form
    {
        private readonly IPlugin _plug;
        public MyPlugForm(IPlugin _plug)
        {
            InitializeComponent();
            this._plug = _plug;
        }

        private void MyPlugForm_Load(object sender, EventArgs e)
        {
            this.Info.AppendText(this._plug.Author + "\r\n");
            this.Info.AppendText(this._plug.DisplayPluginName + "\r\n");
            this.Info.AppendText(this._plug.PluginDescription + "\r\n");
            this.Info.AppendText(this._plug.PluginName + "\r\n");
            this.Info.AppendText(this._plug.Version + "\r\n");
        }
    }
}
