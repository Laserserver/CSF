using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace Steganography
{
    class ClassImage
    {
        private Image normalImg;
        private Image changedImg;
        private ClassDataHandler dataHandler;

        public ClassImage(string Path)
        {
            normalImg = Image.FromFile(Path);
            dataHandler = new ClassDataHandler();
        }

        public Image GetNormal() => normalImg;
        public Image GetChanged() => changedImg;


        public int RetAvailableSize()
        {
            return normalImg.Height * normalImg.Width * 8;
        }

        public void Temp()
        {
            byte[] Data = new byte[RetAvailableSize()];
            long Pointer = 0;
            changedImg = (Image)normalImg.Clone();
            Bitmap Bm = new Bitmap(changedImg);
            Color workingPixel;
            for (int i = 0; i < normalImg.Width; i++)
            {
                for (int j = 0; j < normalImg.Height; j++)
                {
                    workingPixel = Bm.GetPixel(i, j);
                    Data[Pointer++] = (byte)(workingPixel.A & 3);
                    Data[Pointer++] = (byte)(workingPixel.R & 3);
                    Data[Pointer++] = (byte)(workingPixel.G & 3);
                    Data[Pointer++] = (byte)(workingPixel.B & 3);
                }
            }
            dataHandler.GetEncodedData(Data);
            dataHandler.DecodeData();
            dataHandler.EncodeData();
        }

        public void Decode()
        {
            byte[] Data = new byte[RetAvailableSize()];
            long Pointer = 0;
            changedImg = (Image)normalImg.Clone();
            Bitmap Bm = new Bitmap(changedImg);
            Color workingPixel;
            for (int i = 0; i < normalImg.Width; i++)
            {
                for (int j = 0; j < normalImg.Height; j++)
                {
                    workingPixel = Bm.GetPixel(i, j);
                    Data[Pointer++] = (byte)(workingPixel.A & 3);
                    Data[Pointer++] = (byte)(workingPixel.R & 3);
                    Data[Pointer++] = (byte)(workingPixel.G & 3);
                    Data[Pointer++] = (byte)(workingPixel.B & 3);
                }
            }
            dataHandler.GetEncodedData(Data);
        }

        public void Encode(byte[] Array)
        {
            Bitmap Bm = new Bitmap(changedImg);
            int Pointer = 0;
            Color Cl;
            for (int i = 0; i < changedImg.Width; i++)
            {
                for (int j = 0; j < changedImg.Height; j++)
                {
                    Cl = Color.FromArgb(
                        Array[Pointer++],
                        Array[Pointer++],
                        Array[Pointer++],
                        Array[Pointer++]);
                    Bm.SetPixel(i, j, Cl);
                }
            }
        }

        public void EncodeString(string Text)
        {
            dataHandler.EncodeString(Text);
            dataHandler.EncodeData();
            Encode(dataHandler.SendData());
        }

        public string DecodeString()
        {
            return dataHandler.ParseShit();
        }
    }
}