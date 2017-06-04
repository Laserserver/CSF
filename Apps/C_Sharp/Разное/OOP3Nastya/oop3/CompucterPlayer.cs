using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace OOP3
{
    public class CompucterPlayer : PlayerBase
    {
        public int Id
        {
            get { return _gettedID; }
            private set { _gettedID = value; }
        }
        private int _gettedID;
        private Thread PcBrainThread;
        private Random _rnd;

        public CompucterPlayer()
        {
            _rnd = new Random(DateTime.Now.GetHashCode());
        }

        public void StartMakingTurn()
        {
            GameControlForm.Instance.BlockUserInput = true;

            if (PcBrainThread != null && PcBrainThread.IsAlive)
            {
                PcBrainThread.Abort();
            }
            PcBrainThread = new Thread(BrainFunction);
            PcBrainThread.Start();
        }

        public CompucterPlayer(int ID)
        {
            _gettedID = ID;
        }

        private void BrainFunction()
        {
            if (_rnd == null) _rnd = new Random(DateTime.Now.GetHashCode());
            Thread.Sleep(_rnd.Next(1,2) * 1000);
            //TODO пека ходит

            List<Figure> List = GameControlForm.Instance.AvaivalbleNextStepForAllFig();
            if (List.Count != 0)
            {
                if (GameControlForm.Instance.HardFigureControl == null)
                {
                    var figure = List[_rnd.Next(0, List.Count - 1)];
                    GameControlForm.Instance.CurrentSelectedFigure = figure;
                    var PosList = GameControlForm.Instance.AvailablePos();

                    Form1.Instance.Invoke(((MethodInvoker) (() => Game.Singletone.NextStep(figure, PosList[_rnd.Next(0, PosList.Count - 1)], GameControlForm.Instance.AttackedFiguresPosses))));
                    
                    GameControlForm.Instance.CurrentSelectedFigure = null;
                    return;
                }
                else
                {
                    GameControlForm.Instance.CurrentSelectedFigure = GameControlForm.Instance.HardFigureControl;
                    var PosList = GameControlForm.Instance.AvailablePos();

                    if (PosList.Count != 0)
                    Form1.Instance.Invoke(((MethodInvoker)(() => Game.Singletone.NextStep(GameControlForm.Instance.HardFigureControl, PosList[_rnd.Next(0, PosList.Count - 1)], GameControlForm.Instance.AttackedFiguresPosses))));
                    GameControlForm.Instance.CurrentSelectedFigure = null;
                    return;
                }

            }
            else
            {
                List<Figure> avaFigures = new List<Figure>();
                foreach (Figure fig in Game.Singletone.AllFigures)
                {
                    if (fig.OwnerID == Id)
                    {
                        GameControlForm.Instance.CurrentSelectedFigure = fig;
                        var PosList = GameControlForm.Instance.AvailablePos();
                        if (PosList.Count > 0)
                        {
                            avaFigures.Add(fig);
                        }
                    }
                }

                if (avaFigures.Count != 0)
                {
                    var figure = avaFigures[_rnd.Next(0, avaFigures.Count - 1)];
                    GameControlForm.Instance.CurrentSelectedFigure = figure;
                    var PosList = GameControlForm.Instance.AvailablePos();
                    
                    Form1.Instance.Invoke(((MethodInvoker)(() => Game.Singletone.NextStep(figure, PosList[_rnd.Next(0, PosList.Count - 1)], GameControlForm.Instance.AttackedFiguresPosses))));
                    GameControlForm.Instance.CurrentSelectedFigure = null;
                    return;
                }

                
                GameControlForm.Instance.BlockUserInput = false;
            }


        }
    }
}
