using System;
using System.Windows.Forms;

namespace PenPlugin {
    public partial class UIPenControl : UserControl {
        public UIPenControl() {
            this.InitializeComponent();
            this.GetPenSize = (int) this.PenSizeValue.Value;
        }

        public int GetPenSize { get; private set; }

        private void PenSizeValue_ValueChanged(object sender, EventArgs e) {
            if (this.PenSizeValue.Value > this.PenSizeValue.Maximum ||
                this.PenSizeValue.Value < this.PenSizeValue.Minimum) {
                this.PenSizeValue.Text = this.GetPenSize.ToString();
                this.PenSizeValue.Value = this.GetPenSize;
                this.PenSizeValue.Invalidate();
            }
            else {
                this.GetPenSize = (int) this.PenSizeValue.Value;
            }
        }
    }
}