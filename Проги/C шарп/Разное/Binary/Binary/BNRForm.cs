using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Binary
{
  public partial class BNRForm : Form
  {
    byte[] BinCodeUp, BinCodeDown, BinCodeResult;
    byte[,] BinTemp;
    int UpLength, DownLength;
    int[,] BinConverted;
    public BNRForm()
    {
      InitializeComponent();
    }
    private void GridMarkdown()
    {
      _ctrlDGVBinary.ColumnCount = UpLength + 1;
      _ctrlDGVBinary.RowCount = 3;
      _ctrlDGVDHOBView.ColumnCount = 2;
      _ctrlDGVDHOBView.RowCount = 3;

      for (byte i = 0; i < 3; i++)
        _ctrlDGVBinary.Rows[i].Height = 20;
      for (byte i = 0; i < UpLength + 1; i++)
        _ctrlDGVBinary.Columns[i].Width = 20;

      for (sbyte i = (sbyte)UpLength; i > 0; i--)
        _ctrlDGVBinary.Rows[0].Cells[i].Value = BinCodeUp[i - 1];

      for (byte i = 0; i < DownLength; i++)
        _ctrlDGVBinary.Rows[1].Cells[i + UpLength - DownLength + 1].Value = BinCodeDown[i];

      for (sbyte i = (sbyte)UpLength; i >= 0; i--)
        _ctrlDGVBinary.Rows[2].Cells[i].Value = BinCodeResult[i];

      for (byte i = 0; i < 3; i++)
        for (byte k = 0; k < 2; k++)
        _ctrlDGVDHOBView.Rows[i].Cells[0].Value = BinConverted[i, k];
    }

    private void _ctrlBinBaton_Click(object sender, EventArgs e)
    {
      _ctrlDGVBinary.ColumnCount = 0;
      if (_ctrlTxbFirst.Text != null && _ctrlTxbSecond.Text != null)
      {
        if (_ctrlTxbFirst.Text.Length >= _ctrlTxbSecond.Text.Length)
        {
          BinCodeUp = BinLogics.ParseBin(_ctrlTxbFirst.Text);
          BinCodeDown = BinLogics.ParseBin(_ctrlTxbSecond.Text);
        }
        else
        {
          BinCodeDown = BinLogics.ParseBin(_ctrlTxbFirst.Text);
          BinCodeUp = BinLogics.ParseBin(_ctrlTxbSecond.Text);
        }
        UpLength = BinCodeUp.Length;
        DownLength = BinCodeDown.Length;

        BinTemp = new byte[2, UpLength + 1];

        for (byte i = 0; i < UpLength; i++)
          BinTemp[0, i + 1] = BinCodeUp[i];

        for (byte i = 0; i < DownLength; i++)
          BinTemp[1, i + UpLength - DownLength + 1] = BinCodeDown[i];

        BinCodeResult = BinLogics.Calculate(BinTemp);
        BinConverted = BinLogics.Convert(BinCodeUp, BinCodeDown, BinCodeResult);
        GridMarkdown();
      }
    }
  }
}
