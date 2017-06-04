using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP3
{
    public partial class GameControlForm : UserControl
    {
        #region Global vars
        [Category("Настроечки")]
        [Description("Кол-во ячеек в ширину")]
        public int WidthCells
        {
            get { return _widthCells; }
            set
            {
                _widthCells = value;
                Invalidate();
            }
        }
        private int _widthCells = 8;

        [Category("Настроечки")]
        [Description("Кол-во ячеек в высоту")]
        public int HeightCells
        {
            get { return _heightCells; }
            set
            {
                _heightCells = value;
                Invalidate();
            }
        }
        private int _heightCells = 8;

        [Category("Настроечки")]
        [Description("Цвет ячейки 1")]
        public Color Cell1Color
        {
            get { return _cell1Color; }
            set
            {
                _cell1Color = value;
                if (_cell1Brush != null) _cell1Brush.Dispose();
                _cell1Brush = new SolidBrush(_cell1Color);
                Invalidate();
            }
        }
        private Color _cell1Color = Color.White;
        private Brush _cell1Brush = new SolidBrush(Color.White);

        [Category("Настроечки")]
        [Description("Цвет ячейки 2")]
        public Color Cell2Color
        {
            get { return _cell2Color; }
            set
            {
                _cell2Color = value;
                if (_cell2Brush != null) _cell2Brush.Dispose();
                _cell2Brush = new SolidBrush(_cell2Color);
                Invalidate();
            }
        }
        private Color _cell2Color = Color.Black;
        private Brush _cell2Brush = new SolidBrush(Color.Black);

        #endregion

        #region localvars

        public bool BlockUserInput = false;

        public Figure HardFigureControl;

        private List<AttackedFigurePositions> _attackedFigPossess;
        public List<AttackedFigurePositions> AttackedFiguresPosses
        {
            get { return _attackedFigPossess; }
        }

        public static GameControlForm Instance;


        public Figure CurrentSelectedFigure;
        private Point _prevMousePos;
        private List<Point> nextMove;

        #endregion

        public bool IsPlayerControled=false;

        public GameControlForm()
        {
            InitializeComponent();
            base.DoubleBuffered = true;
            Instance = this;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics gr = e.Graphics;
            int seccondWidthCell = Width / WidthCells;
            int seccondHeightCell = Height / HeightCells;
            bool firstCell = true;
            nextMove = new List<Point>();

            if (CurrentSelectedFigure != null && !BlockUserInput)
            {
                nextMove = AvailablePos();
            }

            for (int i = 0; i < WidthCells; i++)
            {
                for (int j = 0; j < HeightCells; j++)
                {
                    Rectangle field = new Rectangle((i*seccondWidthCell), (j*seccondHeightCell), seccondWidthCell, seccondHeightCell);
                    gr.FillRectangle(firstCell ? _cell1Brush : _cell2Brush, field);
                    gr.DrawString(string.Format("{0}:{1}", i, j), SystemFonts.DefaultFont, Brushes.Black, field.X, field.Y);
                    firstCell = !firstCell;
                    if (nextMove.Contains(new Point(i, j)))
                    {
                        gr.DrawRectangle(new Pen(Color.Green){Width = 4}, field);
                    }
                }
                firstCell = !firstCell;
            }

           

            foreach (Figure figure in Game.Singletone.AllFigures)
            {
                if (!figure.IsVisible) continue;
                if (figure.OwnerID == 1)
                {
                    figure.Draw(gr, new Rectangle((figure.Position.X*seccondWidthCell), (figure.Position.Y*seccondHeightCell), seccondWidthCell, seccondHeightCell), Color.Wheat);
                }
                else
                {
                    figure.Draw(gr, new Rectangle((figure.Position.X * seccondWidthCell), (figure.Position.Y * seccondHeightCell), seccondWidthCell, seccondHeightCell), Color.PowderBlue);
                }
            }

            if (CurrentSelectedFigure != null && !BlockUserInput)
            {
                var tempRect = new Rectangle((_prevMousePos.X - seccondWidthCell / 2), (_prevMousePos.Y - seccondHeightCell/2), seccondWidthCell, seccondHeightCell);
                if (CurrentSelectedFigure.OwnerID == 1)
                {
                    CurrentSelectedFigure.Draw(gr, tempRect, Color.Wheat);
                }
                else
                {
                    CurrentSelectedFigure.Draw(gr, tempRect, Color.PowderBlue);
                }
            }
        }

        public List<Point> AvailablePos()
        {
            List<Point> posPoints = new List<Point>();
            bool attacker = false;
            _attackedFigPossess = new List<AttackedFigurePositions>();
            List<Point> allowedPoses = CurrentSelectedFigure.GetPossibleMovePoints();
            List<Size> queenSkipPosses = new List<Size>();
            foreach (Size point in allowedPoses)
            {
                Point tempPoint = CurrentSelectedFigure.Position + point;
                Figure thisfigure = Game.GetFigureByPos(tempPoint);

                

                if (CurrentSelectedFigure.DirType != Figure.FigureDirectionType.Queeen)
                {
                    if (thisfigure != null && CurrentSelectedFigure.OwnerID == thisfigure.OwnerID)
                        continue;
                    #region Simple figure turn
                    if (thisfigure != null)
                    {
                        Point tempPoint2 = thisfigure.Position + point;
                        if (tempPoint2.X >= 0 && tempPoint2.X < WidthCells && tempPoint2.Y >= 0 && tempPoint2.Y < HeightCells)
                        {
                            _attackedFigPossess.Add(new AttackedFigurePositions { FigureLink = thisfigure, Position = tempPoint2 });
                            Figure thisfigure2 = Game.GetFigureByPos(tempPoint2);
                            if (thisfigure2 == null)
                            {
                                if (!attacker)
                                {
                                    posPoints.Clear();
                                    attacker = true;
                                }
                                if (tempPoint2.X >= 0 && tempPoint2.X < WidthCells && tempPoint2.Y >= 0 && tempPoint2.Y < HeightCells)
                                posPoints.Add(tempPoint2);
                            }
                        }
                    }
                    else if (!attacker)
                    {
                        if (CurrentSelectedFigure.DirType == Figure.FigureDirectionType.OnlyDown && point.Height > 0)
                        {
                            if (tempPoint.X >= 0 && tempPoint.X < WidthCells && tempPoint.Y >= 0 && tempPoint.Y < HeightCells)
                            posPoints.Add(tempPoint);
                        }
                        else if (CurrentSelectedFigure.DirType == Figure.FigureDirectionType.OnlyUp && point.Height < 0)
                        {
                            if (tempPoint.X >= 0 && tempPoint.X < WidthCells && tempPoint.Y >= 0 && tempPoint.Y < HeightCells)
                            posPoints.Add(tempPoint);
                        }
                    }
                    #endregion
                }
                else
                {
                    #region Queen
                    Size addonSimplePoint = new Size(0, 0);
                    addonSimplePoint.Width = point.Width > 0 ? 1 : -1;
                    addonSimplePoint.Height = point.Height > 0 ? 1 : -1;

                    if (queenSkipPosses.Contains(addonSimplePoint) || point.Width == 0 || point.Height == 0)
                        continue;

                    if (thisfigure != null && CurrentSelectedFigure.DirType == Figure.FigureDirectionType.Queeen)
                    {
                        if (CurrentSelectedFigure.OwnerID == thisfigure.OwnerID)
                        {
                            queenSkipPosses.Add(addonSimplePoint);
                            continue;
                        }

                        Point tempPoint2 = thisfigure.Position + addonSimplePoint;
                        Figure figure3lvl = Game.GetFigureByPos(tempPoint2);
                        if (figure3lvl != null)
                        {
                            queenSkipPosses.Add(addonSimplePoint);
                            continue;
                        }
                        bool stopLink = false;
                        while (!stopLink)
                        {
                            if (tempPoint2.X >= 0 && tempPoint2.X < WidthCells && tempPoint2.Y >= 0 && tempPoint2.Y < HeightCells)
                            {
                                _attackedFigPossess.Add(new AttackedFigurePositions { FigureLink = thisfigure, Position = tempPoint2 });
                                Figure thisfigure2 = Game.GetFigureByPos(tempPoint2);
                                if (thisfigure2 == null)
                                {
                                    if (!attacker)
                                    {
                                        posPoints.Clear();
                                        attacker = true;
                                    }
                                    posPoints.Add(tempPoint2);
                                    tempPoint2 += addonSimplePoint;
                                }
                                else
                                {
                                    queenSkipPosses.Add(addonSimplePoint);
                                    stopLink = true;
                                }
                            }
                            else
                            {
                                stopLink = true;
                            }
                        }
                    }
                    else if (!attacker)
                    {
                        if ((CurrentSelectedFigure.DirType == Figure.FigureDirectionType.OnlyDown && point.Height > 0) || (CurrentSelectedFigure.DirType == Figure.FigureDirectionType.OnlyUp && point.Height < 0) || CurrentSelectedFigure.DirType == Figure.FigureDirectionType.Queeen)
                        {
                            if (tempPoint.X >= 0 && tempPoint.Y >= 0 && tempPoint.X <= WidthCells && tempPoint.Y <= HeightCells)
                            {
                                posPoints.Add(tempPoint);
                            }
                        }
                    }
                    #endregion
                }
            }

            List<Figure> coll = AvaivalbleNextStepForAllFig();
            if (coll.Count == 0 || coll.Contains(CurrentSelectedFigure))
            {
                return posPoints;
            }
            posPoints.Clear();
            return posPoints;
        }

        /// <summary>
        /// список всех фигур, способных атаковать
        /// </summary>
        /// <returns></returns>
        public List<Figure> AvaivalbleNextStepForAllFig()
        {
            List<Figure> _figuresAttakers = new List<Figure>();

            foreach (Figure fig in Game.Singletone.AllFigures)
            {
                if (fig.OwnerID == Game.Singletone.CurrentGameTurnOwner.Id)
                {
                    AvaivalbleNextStepForOneFig(fig, ref _figuresAttakers);
                }
            }

            return _figuresAttakers;
        }

        /// <summary>
        /// может ли одна фигура атаковать
        /// </summary>
        /// <param name="figure">сама фигура</param>
        /// <param name="AttFig">список</param>
        public void AvaivalbleNextStepForOneFig(Figure figure,ref List<Figure> AttFig)
        {
            List<AttackedFigurePositions> attackedFigPossess2 = new List<AttackedFigurePositions>();
            List<Point> allowedPoses = figure.GetPossibleMovePoints();
            foreach (Size point in allowedPoses)
            {
                Point tempPoint = figure.Position + point;
                Figure thisfigure = Game.GetFigureByPos(tempPoint);

                if (thisfigure != null && figure.OwnerID == thisfigure.OwnerID) 
                    continue;

                if (thisfigure != null)
                {
                    Point tempPoint2 = thisfigure.Position + point;
                    if (figure.DirType != Figure.FigureDirectionType.Queeen)
                    {
                        #region Simple fig
                        if (tempPoint2.X >= 0 && tempPoint2.X < WidthCells && tempPoint2.Y >= 0 && tempPoint2.Y < HeightCells)
                        {
                            attackedFigPossess2.Add(new AttackedFigurePositions() {FigureLink = thisfigure, Position = tempPoint2});
                            Figure thisfigure2 = Game.GetFigureByPos(tempPoint2);
                            if (thisfigure2 == null)
                            {
                                AttFig.Add(figure);
                                return;
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        #region Queen
                        if (_attackedFigPossess == null) _attackedFigPossess = new List<AttackedFigurePositions>();
                        Size addonSimplePoint = new Size(0, 0);
                        addonSimplePoint.Width = point.Width > 0 ? 1 : -1;
                        addonSimplePoint.Height = point.Height > 0 ? 1 : -1;
                        tempPoint2 = thisfigure.Position + addonSimplePoint;

                        bool stopLink = false;
                        while (!stopLink)
                        {
                            if (tempPoint2.X >= 0 && tempPoint2.X < WidthCells && tempPoint2.Y >= 0 && tempPoint2.Y < HeightCells)
                            {
                                _attackedFigPossess.Add(new AttackedFigurePositions { FigureLink = thisfigure, Position = tempPoint2 });
                                Figure thisfigure2 = Game.GetFigureByPos(tempPoint2);
                                if (thisfigure2 == null)
                                {
                                    AttFig.Add(figure);
                                }
                                stopLink = true;
                            }
                            else
                            {
                                stopLink = true;
                            }
                        }

                        #endregion
                    }
                }
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            _prevMousePos = e.Location;
            Invalidate();
            base.OnMouseMove(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            _prevMousePos = Point.Empty;
            if (CurrentSelectedFigure != null)
                CurrentSelectedFigure.IsVisible = true;
            CurrentSelectedFigure = null;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (BlockUserInput)
                return;

            if (e.Button== MouseButtons.Left)
            {
                _prevMousePos = e.Location;
                int seccondWidthCell = Width / WidthCells;
                int seccondHeightCell = Height / HeightCells;
                bool StopCycle=false;
                for (int i = 0; i < WidthCells; i++)
                {
                    for (int j = 0; j < HeightCells; j++)
                    {
                        Rectangle field = new Rectangle((i * seccondWidthCell), (j * seccondHeightCell), seccondWidthCell, seccondHeightCell);
                        if (field.Contains(e.Location))
                        {
                            StopCycle = true;
                            CurrentSelectedFigure = Game.GetFigureByPos(new Point(i, j));
                           
                            if (CurrentSelectedFigure != null)
                            {
                                if (CurrentSelectedFigure.OwnerID == Game.Singletone.CurrentGameTurnOwner.Id)
                                {
                                    CurrentSelectedFigure.IsVisible = false;
                                }
                                else
                                {
                                    CurrentSelectedFigure = null;
                                }

                                if (CurrentSelectedFigure != null && HardFigureControl != null && HardFigureControl != CurrentSelectedFigure)
                                {
                                    CurrentSelectedFigure.IsVisible = true;
                                    CurrentSelectedFigure = null;
                                }
                            }
                            break;
                        }
                    }
                    if (StopCycle)
                    {
                        break;
                    }
                }
            }
            Invalidate();
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            _prevMousePos = e.Location;
            //TODO move
            if (e.Button == MouseButtons.Left)
            {
                if (CurrentSelectedFigure != null)
                {
                    CurrentSelectedFigure.IsVisible = true;
                    int seccondWidthCell = Width / WidthCells;
                    int seccondHeightCell = Height / HeightCells;
                    bool StopCycle = false;
                    for (int i = 0; i < WidthCells; i++)
                    {
                        for (int j = 0; j < HeightCells; j++)
                        {
                            Rectangle field = new Rectangle((i*seccondWidthCell), (j*seccondHeightCell), seccondWidthCell, seccondHeightCell);
                            if (field.Contains(e.Location))
                            {
                                StopCycle = true;
                                if (nextMove.Contains(new Point(i, j)))
                                {
                                    Game.Singletone.NextStep(CurrentSelectedFigure, new Point(i, j), AttackedFiguresPosses);
                                }
                            }
                            if (StopCycle)
                            {
                                break;
                            }
                        }
                        if (StopCycle)
                        {
                            break;
                        }
                    }
                }

                CurrentSelectedFigure = null;

                

                Invalidate();
            }
            base.OnMouseUp(e);
        }

        #region AdditionalClasses

        public class AttackedFigurePositions
        {
            public Point Position;
            public Figure FigureLink;
        }

        #endregion
    }
}
