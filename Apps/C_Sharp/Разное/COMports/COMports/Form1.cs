using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace COMports
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void CtrlButReset_Click(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            CtrlLBPorts.Items.Clear();
            CtrlLBPorts.DataSource = ports;
        }

        private void CtrlLBPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            CtrlSP = new SerialPort(CtrlLBPorts.Items[CtrlLBPorts.SelectedIndex].ToString());
        }

        private void CtrlSP_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            char[] Buf = new char[CtrlSP.ReadBufferSize];
            CtrlSP.Read(Buf, 0, CtrlSP.ReadBufferSize);
            for (int i = 0; i < Buf.Length; i++)
            {
                CtrlRTB.Text += Buf[i];
            }
        }
    }
}
