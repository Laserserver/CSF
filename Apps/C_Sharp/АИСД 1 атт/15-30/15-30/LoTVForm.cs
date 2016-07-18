using System;
using System.Windows.Forms;

namespace _15_30
{
  public partial class LoTVForm : Form
    {
        LoTVStack Stack = new LoTVStack();
        public LoTVForm()
        {
            InitializeComponent();
        }

        private void _ctrlBaton_Click(object sender, EventArgs e)
        {
            Stack.LoTVFillStack(_ctrlTxB.Text);
            Stack.LoTVGetResult();
            _ctrlLbl.Text = "Ответ: " + Stack.stack_Sum;
        }
    }
}
