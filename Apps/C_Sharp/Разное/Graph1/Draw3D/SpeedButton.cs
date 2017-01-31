using System;
using System.Windows.Forms;
using System.Drawing;

    class SpeedButton : Button
    {
        public SpeedButton()
        {
            FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            DownColor = //SystemColors.ControlDark;
                //SystemColors.ControlLight;
            Color.Orange;
            ForeColor = Color.Orange;
            //button1. .ForeColor .BackColor

            Click += new EventHandler(SpeedButton_Click);
        }

        void SpeedButton_Click(object sender, EventArgs e)
        {
            if (Down) return;
            if (GroupIndex > 0) { upGroupMembers(Parent); }
            Down = true;
        }

        private void upGroupMembers(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                SpeedButton sb = c as SpeedButton;
                if (sb != null && sb.GroupIndex == this.GroupIndex) { sb.Down = false; }
                upGroupMembers(c);
            }
            if (parent is Form) return;
        }

        public int GroupIndex { get; set; }
        private bool m_down;
        public bool Down
        {
            get { return m_down; }
            set
            {
                if (value)
                {
                    if (m_down)
                        return; //already set
                    OldColor = BackColor;
                    BackColor = DownColor;
                }
                else
                {
                    this.BackColor = OldColor;
                }
                m_down = value;
            }
        }
        public Color DownColor { get; set; }
        private Color OldColor { get; set; }
    }
