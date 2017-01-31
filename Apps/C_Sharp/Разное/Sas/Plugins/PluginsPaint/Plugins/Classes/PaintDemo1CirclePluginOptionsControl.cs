using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Oop.Tasks.Paint.Interface;


namespace Oop.Tasks.Paint.Plugins
{
	public class PaintDemo1CirclePluginOptionsControl: System.Windows.Forms.UserControl
	{
    private IPaintApplicationContext applicationContext=null;
    private string[] brushStyleNames=null;
    private HatchStyle[] brushStyleValues=null;


    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.NumericUpDown sizeNumericUpDown;
    private System.Windows.Forms.ListBox brushStyleListBox;
    private System.Windows.Forms.Label sizeLabel;
    private System.Windows.Forms.Label resultLabel;
    private System.Windows.Forms.Panel resultPanel;

		private System.ComponentModel.Container components=null;


		public PaintDemo1CirclePluginOptionsControl(
               IPaintApplicationContext applicationContext) {
      this.applicationContext=applicationContext;

			InitializeComponent();

      Type brushStyleType=typeof(HatchStyle);
      brushStyleNames=Enum.GetNames(brushStyleType);
      brushStyleValues=(HatchStyle[])Enum.GetValues(brushStyleType);
      brushStyleListBox.Items.Add("Solid");
      brushStyleListBox.Items.AddRange(brushStyleNames);
      brushStyleListBox.SelectedIndex=0;
		}


		protected override void Dispose(bool disposing) {
			if(disposing) {
				if(components!=null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}


    internal void InvalidateResult() {      
      resultPanel.Invalidate();
    }


    internal Pen GetPen() {
      if(applicationContext==null)
        return null;

      Pen result=new Pen(applicationContext.ForegroundColor, 1);
      return result;
    }


    internal Brush GetBrush() {
      if(applicationContext==null)
        return null;

      Brush result=null;
      int index=brushStyleListBox.SelectedIndex;
      if(index==0)
        result=new SolidBrush(applicationContext.BackgroundColor);
      else {
        HatchStyle brushStyle=brushStyleValues[index-1];
        result=new HatchBrush(brushStyle,
                              applicationContext.ForegroundColor,
                              applicationContext.BackgroundColor);
      }

      return result;
    }


    internal int CircleSize {
      get {
        return (int)sizeNumericUpDown.Value;
      }
    }


    private void resultPanel_Paint(object sender, PaintEventArgs e) {
      if(applicationContext==null)
        return;

      Pen pen=GetPen();
      Brush brush=GetBrush();      
      int size=CircleSize;

      size--;
      e.Graphics.FillEllipse(brush, 0, 0, size, size);
      e.Graphics.DrawEllipse(pen, 0, 0, size, size);

      pen.Dispose();
      brush.Dispose();
    }


    private void circleProperties_Changed(object sender, System.EventArgs e) {
      InvalidateResult();
    }


		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
      this.sizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
      this.brushStyleListBox = new System.Windows.Forms.ListBox();
      this.label1 = new System.Windows.Forms.Label();
      this.sizeLabel = new System.Windows.Forms.Label();
      this.resultPanel = new System.Windows.Forms.Panel();
      this.resultLabel = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.sizeNumericUpDown)).BeginInit();
      this.SuspendLayout();
      // 
      // sizeNumericUpDown
      // 
      this.sizeNumericUpDown.Location = new System.Drawing.Point(48, 8);
      this.sizeNumericUpDown.Minimum = new System.Decimal(new int[] {
                                                                      1,
                                                                      0,
                                                                      0,
                                                                      0});
      this.sizeNumericUpDown.Name = "sizeNumericUpDown";
      this.sizeNumericUpDown.Size = new System.Drawing.Size(48, 20);
      this.sizeNumericUpDown.TabIndex = 0;
      this.sizeNumericUpDown.Value = new System.Decimal(new int[] {
                                                                    50,
                                                                    0,
                                                                    0,
                                                                    0});
      this.sizeNumericUpDown.ValueChanged += new System.EventHandler(this.circleProperties_Changed);
      // 
      // brushStyleListBox
      // 
      this.brushStyleListBox.Location = new System.Drawing.Point(0, 48);
      this.brushStyleListBox.Name = "brushStyleListBox";
      this.brushStyleListBox.ScrollAlwaysVisible = true;
      this.brushStyleListBox.Size = new System.Drawing.Size(156, 56);
      this.brushStyleListBox.TabIndex = 1;
      this.brushStyleListBox.SelectedIndexChanged += new System.EventHandler(this.circleProperties_Changed);
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(-2, 32);
      this.label1.Name = "label1";
      this.label1.TabIndex = 2;
      this.label1.Text = "Стиль кисти:";
      // 
      // sizeLabel
      // 
      this.sizeLabel.Location = new System.Drawing.Point(-2, 12);
      this.sizeLabel.Name = "sizeLabel";
      this.sizeLabel.Size = new System.Drawing.Size(50, 23);
      this.sizeLabel.TabIndex = 3;
      this.sizeLabel.Text = "Размер:";
      // 
      // resultPanel
      // 
      this.resultPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
      this.resultPanel.Location = new System.Drawing.Point(16, 136);
      this.resultPanel.Name = "resultPanel";
      this.resultPanel.Size = new System.Drawing.Size(156, 140);
      this.resultPanel.TabIndex = 4;
      this.resultPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.resultPanel_Paint);
      // 
      // resultLabel
      // 
      this.resultLabel.Location = new System.Drawing.Point(-2, 116);
      this.resultLabel.Name = "resultLabel";
      this.resultLabel.Size = new System.Drawing.Size(63, 23);
      this.resultLabel.TabIndex = 5;
      this.resultLabel.Text = "Результат:";
      // 
      // PaintDemo1CirclePluginOptionsControl
      // 
      this.Controls.Add(this.brushStyleListBox);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.resultPanel);
      this.Controls.Add(this.resultLabel);
      this.Controls.Add(this.sizeNumericUpDown);
      this.Controls.Add(this.sizeLabel);
      this.Name = "PaintDemo1CirclePluginOptionsControl";
      this.Size = new System.Drawing.Size(172, 276);
      ((System.ComponentModel.ISupportInitialize)(this.sizeNumericUpDown)).EndInit();
      this.ResumeLayout(false);

    }
		#endregion    
	}
}
