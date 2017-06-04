using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainTestForm
{
    public partial class MainForm : Form
    {
        private ArrayStackTest AS;
        private LinkedStackTest LS;
        private LinkedQueueTest LQ;
        private ArrayQueueTest AQ;
        private PriorityQueueTest PQ;

        public MainForm()
        {
            InitializeComponent();
            AS = new ArrayStackTest(CtrlTPAS);
            LS = new LinkedStackTest(CtrlTPLS);
            LQ = new LinkedQueueTest(CtrlTPLQ);
            AQ = new ArrayQueueTest(CtrlTPAQ);
            PQ = new PriorityQueueTest(CtrlTPPQ);
        }
    }
}
