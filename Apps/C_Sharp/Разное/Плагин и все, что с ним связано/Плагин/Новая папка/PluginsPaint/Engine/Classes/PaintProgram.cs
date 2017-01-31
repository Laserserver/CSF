using System;
using System.Windows.Forms;


namespace Oop.Tasks.Paint.Engine
{
	public class PaintProgram
	{
    private PaintMainForm mainForm=null;
		

    public PaintProgram() {
      mainForm=new PaintMainForm();
    }


    public PaintProgram(bool start): this() {
      if(start)
        Run();
    }


    public void Run() {
      Application.Run(mainForm);
    }


    static void Main() {
      new PaintProgram(true);
    }
	}
}
