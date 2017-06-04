using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainTestForm
{
    class LinkedStackTest : MainStack
    {
        public LinkedStackTest(TabPage TP)
        {
            tp = TP;
            /*List<string> Lst = new List<string>();
            foreach (Control C in tp.Controls)
                Lst.Add(C.Name);*/
            tp.Controls["CtrlGrB_LS_Coms"].Controls["CtrlTB_LS_Peek_Sys"].Text = "Сасай";
        }
        
    }
}
