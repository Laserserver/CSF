using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steganography
{
    class ClassDataHandler
    {
        byte[] encodedData;
        byte[] normalData;

        public void GetEncodedData(byte[] data) => encodedData = data;

        public void GetData(byte[] data) => normalData = data;

        public byte[] SendData() => encodedData;

        public void DecodeData()
        {
            int L = encodedData.Length / 4;
            normalData = new byte[L];
            for (int i = 0; i < L; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    normalData[i] <<= 2;
                    normalData[i] += encodedData[i * 4 + j];
                }
            }
        }

        public void EncodeData()
        {
            int L = normalData.Length * 4;
            encodedData = new byte[L];
            L /= 4;
            byte temp;
            for (int i = 0; i < L; i++)
            {
                temp = normalData[i];
                for (int j = 0; j < 4; j++)
                {
                    encodedData[i * 4 + 3 - j] = (byte)(temp & 3);
                    temp >>= 2;
                }
            }
        }

        /// <summary>
        /// Кодирует строку в нормальный вид. Для кодировки в биты нужно вызвать Encode()
        /// </summary>
        /// <param name="Text">Кодируемая строка.</param>
        public void EncodeString(string Text)
        {
            DecodeData();
            int L = Text.Length;
            char worker;
            normalData[1] = (byte)(L & 255);
            normalData[0] = (byte)((L >> 8) & 255);
            for (int i = 0; i < L * 2; i+= 2)
            {
                worker = Text[i / 2];
                normalData[i + 3] = (byte)(worker & 255);
                normalData[i + 2] = (byte)((worker >> 8) & 255);
            }
        }

        public string ParseShit()
        {
            int Length = (normalData[0] << 8) + normalData[1];
            return ParseString(Length);
        }

        public string ParseString(int Length)
        {
            string Out = "";
            for (int i = 0; i < Length * 2; i += 2)
            {
                Out += Convert.ToChar((normalData[i + 2] << 8) + normalData[i + 3]);
            }
            return Out;
        }
    }
}
