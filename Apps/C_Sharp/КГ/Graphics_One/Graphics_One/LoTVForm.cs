using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Graphics_One
{
  public partial class LoTVForm : Form
  {
    //5.	Написать программу-мультфильм «Восход солнца» 
    Graphics Canvas;

    public LoTVForm()
    {
      InitializeComponent();
      Canvas = LoTVCanvas.CreateGraphics();
      LoTVDrawing.bitm = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
    }

    private void _ctrlBaton_Click(object sender, EventArgs e)
    {
      LoTVDrawing.LoTVPreDraw(Canvas);
      Canvas.DrawImage(LoTVDrawing.bitm, ClientRectangle);
    }

    private void _ctrlBatonStart_Click(object sender, EventArgs e)
    {
      LoTVDrawing.LoTVDraw(Canvas);
      Canvas.DrawImage(LoTVDrawing.bitm, ClientRectangle);

    }
  }
}