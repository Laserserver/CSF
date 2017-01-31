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


    // метод использует unsafe-код,
    // поэтому при "выкрученной" политике безопасности могут
    // быть проблемы с запуском,
    // зато работает очень быстро

    // закомментирован по следующей причине:
    // при попытке загрузить сборку с unsafe-кодом
    // с сетевого диска (L:, Z:) происходит security exception
    // (с локального диска (C:) - все нормально,
    //    - это для тех, кому станет интересно попробывать)
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


    // как и метод ProcessUnsafe() работает с данными изображения
    // в виде массива байт - RGB-точек;
    // в отличие от предыдущего метода не использует unsafe-кода,
    // но из-за этого происходит потеря производительности
    // (по прикидкам на пальцах не более чем в 2 раза,
    //  на копирование каждой строки в буфер и из буфера обратно)
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


    // самый медленный метод (на порядок/порядки относительно предыдущих),
    // зато простой и универсальный по отношению к формату пикселов
    // (здесь не актуально, т.к. формат известен -
    //  PixelFormat.Format24bppRgb, устанавливается основным приложением)
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

      //ProcessUnsafe();         // самый быстрый метод (см. описание)
      ProcessUseMarshalCopy(); // чуть медленне (см. описание)
      //ProcessUseGetSetPixel(); // самый медленный (см. описание)

      ApplicationContext.Invalidate();
    }


    public string Name {
      get {
        return this.GetType().Name;
      }
    }


    public string CommandName {
      get {
        return "Градации серого";
      }
    }
	}
}
