using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Yaisp3_v._0._1
{
  public partial class _FormAgency : Form
  {
    int Strategy;
    public _FormAgency()
    {
      InitializeComponent();
    }

    private void _ctrlButCreate_Click(object sender, EventArgs e)
    {
      if (!MainUnitProcessor.AgencyCreate(_ctrlTxbName.Text, _ctrlTxbDeposit.Text, _ctrlTxbBillboards.Text, Strategy))
        MessageBox.Show("Вы ввели недопустимое значение в каком-то из полей. Проверьте правильность информации.", "Ошибка значений", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      else
        Close();
    }  
    private void _ctrlButEdit_Click(object sender, EventArgs e)
    {
      MainUnitProcessor.AgencyChangeData(_ctrlTxbName.Text, Strategy);
      Close();
    }

    private void _FormAgency_Load(object sender, EventArgs e)
    {
      _ctrlButEdit.Enabled = MainUnitProcessor.AgencyIsPresent();
      _ctrlButCreate.Enabled = _ctrlTxbBillboards.Enabled = _ctrlTxbDeposit.Enabled = !MainUnitProcessor.AgencyIsPresent();
      if (MainUnitProcessor.AgencyIsPresent())
      {
        string Name;
        int Money, Bills, Strat;
        MainUnitProcessor.AgencyGetData(out Name, out Money, out Bills, out Strat);
        _ctrlTxbBillboards.Text = Bills.ToString();
        _ctrlTxbDeposit.Text = Money.ToString();
        _ctrlTxbName.Text = Name;
        switch (Strat)
        {
          case 1:
            _ctrlRadConserv.Checked = true;
            break;
          case 2:
            _ctrlRadNormal.Checked = true;
            break;
          case 3:
            _ctrlRadAggro.Checked = true;
            break;
        }
      }
      else
      {
        _ctrlTxbName.Text = "ООО \"Вектор\"";
        _ctrlTxbDeposit.Text = "100000";
        _ctrlTxbBillboards.Text = "5";
        _ctrlRadConserv.Checked = true;
      }
    }
     
    private void ChangeStrategyEvent(object sender, EventArgs e)
    {
      Strategy = Convert.ToInt32((sender as RadioButton).Tag);
    }
  }
}
