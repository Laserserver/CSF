using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OOP3
{
    public class Game
    {
        public PlayerBase Player1;
        public PlayerBase Player2;


        public static Game Singletone
        {
            get
            {
                if (_singletone == null)
                {
                    _singletone = new Game();
                }
                return _singletone;
            }
        }
        private static Game _singletone;
        public PlayerBase CurrentGameTurnOwner;

        public Size WidthHeightField;
        public List<Figure> AllFigures;

        public Label LabelLink;

        public Game()
        {
            AllFigures = new List<Figure>();
        }

        public static void StartGame(int widthCnt, int heightCnt, bool firstIsPc, bool seccondIsPc)
        {
            if (firstIsPc)
            {
                Singletone.Player1 = new CompucterPlayer(1);
            }
            else
            {
                Singletone.Player1 = new PlayerPlayer(1);
            }

            if (seccondIsPc)
            {
                Singletone.Player2 = new CompucterPlayer(2);
            }
            else
            {
                Singletone.Player2 = new PlayerPlayer(2);
            }
            Random rnd = new Random(125);
            Singletone.CurrentGameTurnOwner = rnd.Next(0, 3) >= 2 ? Singletone.Player1 : Singletone.Player2;
            Singletone.LabelLink.Text = string.Format("Turn for {0}", Singletone.CurrentGameTurnOwner);
            Singletone.AllFigures = new List<Figure>();
            Singletone.WidthHeightField = new Size(widthCnt, heightCnt);

            //debug
//            Instance.AllFigures.Add(new FigureSimple { OwnerID = 1, Position = new Point(0, 6), DirType = Figure.FigureDirectionType.OnlyDown });
//            Instance.AllFigures.Add(new FigureSimple { OwnerID = 2, Position = new Point(2, 6), DirType = Figure.FigureDirectionType.OnlyDown });
//            Instance.AllFigures.Add(new FigureSimple { OwnerID = 2, Position = new Point(6, 2), DirType = Figure.FigureDirectionType.OnlyDown });
//            Instance.CountPl1=12;
//            Instance.CountPl2=12;
            for (int i = 0; i < widthCnt/2; i++)
            {
                Singletone.AllFigures.Add(new FigureSimple { OwnerID = Singletone.Player1.Id, Position = new Point(i * 2, 0), DirType = Figure.FigureDirectionType.OnlyDown });
                
                Singletone.AllFigures.Add(new FigureSimple { OwnerID = Singletone.Player1.Id, Position = new Point(i * 2 + 1, 1), DirType = Figure.FigureDirectionType.OnlyDown });
                
                Singletone.AllFigures.Add(new FigureSimple { OwnerID = Singletone.Player1.Id, Position = new Point(i * 2, 2), DirType = Figure.FigureDirectionType.OnlyDown });
               

                Singletone.AllFigures.Add(new FigureSimple { OwnerID = Singletone.Player2.Id, Position = new Point(i * 2 + 1, heightCnt - 1), DirType = Figure.FigureDirectionType.OnlyUp });
                
                Singletone.AllFigures.Add(new FigureSimple { OwnerID = Singletone.Player2.Id, Position = new Point(i * 2, heightCnt - 2), DirType = Figure.FigureDirectionType.OnlyUp });
                
                Singletone.AllFigures.Add(new FigureSimple { OwnerID = Singletone.Player2.Id, Position = new Point(i * 2 + 1, heightCnt - 3), DirType = Figure.FigureDirectionType.OnlyUp });
                
            }
        }

        public static Figure GetFigureByPos(Point point)
        {
            foreach (Figure figure in Singletone.AllFigures)
            {
                if (figure.Position == point)
                {
                    
                    return figure;
                }
            }
            return null;
        }

        public void NextStep(Figure figure, Point nextStep, List<GameControlForm.AttackedFigurePositions> attackedFiguresPosses)
        {
            if (figure.Position != nextStep)
            {
                bool attaker = true;
                foreach (GameControlForm.AttackedFigurePositions poss in attackedFiguresPosses)
                {
                    if (poss.Position == nextStep)
                    {
                        
                        AllFigures.Remove(poss.FigureLink);
                        attaker = false;
                        break;
                    }
                }

                if (figure.DirType == Figure.FigureDirectionType.OnlyDown && nextStep.Y >= WidthHeightField.Height-1)
                {
                    FigureQueen tempQueen = new FigureQueen();
                    tempQueen.OwnerID = figure.OwnerID;
                    tempQueen.Position = nextStep;
                    AllFigures.Remove(figure);
                    AllFigures.Add(tempQueen);
                    if (figure == GameControlForm.Instance.HardFigureControl)
                    {
                        GameControlForm.Instance.HardFigureControl = tempQueen;
                    }
                }
                else if (figure.DirType == Figure.FigureDirectionType.OnlyUp && nextStep.Y <= 0)
                {
                    FigureQueen tempQueen = new FigureQueen();
                    tempQueen.OwnerID = figure.OwnerID;
                    tempQueen.Position = nextStep;
                    AllFigures.Remove(figure);
                    AllFigures.Add(tempQueen);
                    if (figure == GameControlForm.Instance.HardFigureControl)
                    {
                        GameControlForm.Instance.HardFigureControl = tempQueen;
                    }
                }
                else
                {
                    figure.Position = nextStep;
                }

                List<Figure> chechList = new List<Figure>();
                GameControlForm.Instance.AvaivalbleNextStepForOneFig(figure,ref chechList);

                if (chechList.Count == 0 || (attaker && chechList.Count != 0))
                {
                    if (CurrentGameTurnOwner == Player2)
                    {
                        CurrentGameTurnOwner = Player1;
                    }
                    else
                    {
                        CurrentGameTurnOwner = Player2;
                    }
                    if (GameControlForm.Instance.HardFigureControl != null)
                    {
                        GameControlForm.Instance.HardFigureControl = null;
                    }
                }
                else
                {
                    GameControlForm.Instance.HardFigureControl = figure;
                }
                CurrentGameTurnOwner.StartMakingTurn();

                List<Figure> avaFigures = new List<Figure>();
                foreach (Figure fig in Game.Singletone.AllFigures)
                {
                    if (fig.OwnerID == CurrentGameTurnOwner.Id)
                    {
                        GameControlForm.Instance.CurrentSelectedFigure = fig;
                        var PosList = GameControlForm.Instance.AvailablePos();
                        if (PosList.Count > 0)
                        {
                            avaFigures.Add(fig);
                        }
                    }
                }

                if (avaFigures.Count == 0)
                {
                    if (MessageBox.Show(string.Format("Player {0} lose", CurrentGameTurnOwner.Id), "Game", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        Form1.Instance.btnStartGame.Enabled = true;
                    }
                }

               
                Form1.Instance.Invoke( (MethodInvoker) delegate { Singletone.LabelLink.Text = string.Format("Turn for {0}", Singletone.CurrentGameTurnOwner.Id); } );
                GameControlForm.Instance.Invoke((MethodInvoker)(() => GameControlForm.Instance.Invalidate()));
            }
        }
    }
}
