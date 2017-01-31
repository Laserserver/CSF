using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Oop.Tasks.Paint.Interface;


namespace Oop.Tasks.Paint.Plugins
{
  [PluginForLoad(true)]
	public class PaintDemo3ToGrayScalePlugin: IActionPaintPlugin
	{
    private IPaintPluginContext pluginContext=null;


    private IPaintApplicationContext ApplicationContext {
      get {
        if(pluginContext==null)
          return null;
        else
          return pluginContext.ApplicationContext;
      }
    }


    public void AfterCreate(IPaintPluginContext pluginContext) {
      this.pluginContext=pluginContext;      
    }


    public void BeforeDestroy() {
    }


    // ����� ���������� unsafe-���,
    // ������� ��� "�����������" �������� ������������ �����
    // ���� �������� � ��������,
    // ���� �������� ����� ������

    // ��������������� �� ��������� �������:
    // ��� ������� ��������� ������ � unsafe-�����
    // � �������� ����� (L:, Z:) ���������� security exception
    // (� ���������� ����� (C:) - ��� ���������,
    //    - ��� ��� ���, ���� ������ ��������� �����������)
/*
    private void ProcessUnsafe() {
      Bitmap bitmap=ApplicationContext.Image;
      Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
      BitmapData bitmapData=bitmap.LockBits(rect, ImageLockMode.ReadWrite,
                                            PixelFormat.Format24bppRgb);
      try {
        unsafe {
          byte* pixels=(byte*)bitmapData.Scan0.ToPointer();
          for(int y=0; y<bitmapData.Height; y++) {
            for(int x=0; x<bitmapData.Width*3; x+=3) {
              byte avg=(byte)((pixels[x]+pixels[x+1]+pixels[x+2])/3);
              for(int i=0; i<3; i++)
                pixels[x+i]=avg;
            }
            pixels+=bitmapData.Stride;
          }
        }
      }
      finally {
        bitmap.UnlockBits(bitmapData);
      }
    }
*/


    // ��� � ����� ProcessUnsafe() �������� � ������� �����������
    // � ���� ������� ���� - RGB-�����;
    // � ������� �� ����������� ������ �� ���������� unsafe-����,
    // �� ��-�� ����� ���������� ������ ������������������
    // (�� ��������� �� ������� �� ����� ��� � 2 ����,
    //  �� ����������� ������ ������ � ����� � �� ������ �������)
    public void ProcessUseMarshalCopy() {
      Bitmap bitmap=ApplicationContext.Image;
      Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
      BitmapData bitmapData=bitmap.LockBits(rect, ImageLockMode.ReadWrite,
                                            PixelFormat.Format24bppRgb);
      byte[] line=new byte[bitmapData.Width*3];      
      try {
        IntPtr pixelsAddr=bitmapData.Scan0;
        long pixelsAddrInt=pixelsAddr.ToInt64();

        for(int y=0; y<bitmapData.Height; y++) {
          pixelsAddr=(IntPtr)pixelsAddrInt;
          Marshal.Copy(pixelsAddr, line, 0, bitmapData.Width*3);

          for(int x=0; x<bitmapData.Width*3; x+=3) {
            byte avg=(byte)((line[x]+line[x+1]+line[x+2])/3);
            for(int i=0; i<3; i++)
              line[x+i]=avg;
          }

          Marshal.Copy(line, 0, pixelsAddr, bitmapData.Width*3);
          pixelsAddrInt+=bitmapData.Stride;
        }        
      }
      finally {
        bitmap.UnlockBits(bitmapData);
      }
    }


    // ����� ��������� ����� (�� �������/������� ������������ ����������),
    // ���� ������� � ������������� �� ��������� � ������� ��������
    // (����� �� ���������, �.�. ������ �������� -
    //  PixelFormat.Format24bppRgb, ��������������� �������� �����������)
    private void ProcessUseGetSetPixel() {
      Bitmap bitmap=ApplicationContext.Image;

      for(int y=0; y<bitmap.Height; y++)
        for(int x=0; x<bitmap.Width; x++) {
          Color color=bitmap.GetPixel(x, y);
          byte avg=(byte)((color.R+color.G+color.B)/3);
          color=Color.FromArgb(avg, avg, avg);          
          bitmap.SetPixel(x, y, color);
        }
    }


    public void Select(bool selection) {
      if(!selection)
        return;

      //ProcessUnsafe();         // ����� ������� ����� (��. ��������)
      ProcessUseMarshalCopy(); // ���� �������� (��. ��������)
      //ProcessUseGetSetPixel(); // ����� ��������� (��. ��������)

      ApplicationContext.Invalidate();
    }


    public string Name {
      get {
        return this.GetType().Name;
      }
    }


    public string CommandName {
      get {
        return "�������� ������";
      }
    }
	}
}
