using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP3
{
    public class PlayerPlayer : PlayerBase
    {
        public int Id
        {
            get { return _gettedID; }
            private set { _gettedID = value; }
        }

        private int _gettedID;

        public void StartMakingTurn()
        {
            GameControlForm.Instance.BlockUserInput = false;
            //на этом всё
        }

        public PlayerPlayer(int ID)
        {
            _gettedID = ID;
        }
    }
}
