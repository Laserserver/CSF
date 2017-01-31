using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ДачникVSКрот
{
    public class MyEventArg : EventArgs
    {
        public MainAction mainAction;

        public MyEventArg(MainAction mainAction)
        {
            this.mainAction = mainAction;
        }
    }
}
