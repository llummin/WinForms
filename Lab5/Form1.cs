using System;
using System.Drawing;
using System.Windows.Forms;

namespace test_2
{
	public partial class Form1 : Form
	{
		public static int COST = 0;									 //точка при рандоме для SE
		public static Rectangle _reSE;										  //параметр для SE
		//-------------------------------------------------------------------------------------
		Ellipse[] _figures = new Ellipse[50];											 //круг
		Polygon[] _figuresSq = new Polygon[50];										  //квадрта
		Line[] _figuresLine = new Line[50];                                             //линия
		Ring[] _figuresRing = new Ring[50];
		SE[] _figuresSE = new SE[50];
		Oval[] _figuresOval = new Oval[50];
		Romb[] _figuresRomb = new Romb[50];
		Quadrilateral[] _figuresQu = new Quadrilateral[50];

		//счётчик общий массива----------------------------------------------------------------
		public int ellipseScore = 0;
		public int SqScore = 0;
		public int LineScore = 0;
		public int RingScore = 0;
		public int SEScore = 0;
		public int OvalScore = 0;
		public int RombScore = 0;
		public int QuScore = 0;
		//-------------------------------------------------------------------------------------
		private Ellipse _figureToMove;													 //круг
		private Polygon _figureToMoveSq;											  //квадрат
		private Line _figureToMoveLine;                                                 //линия
		private Ring _figureToMoveRing;												   //кольцо
		private SE _figureToMoveSE;                                                        //SE
		private Oval _figureToMoveOval;                                                  //овал
		private Romb _figureToMoveRomb;
		private Quadrilateral _figureToMoveQu;
		//-------------------------------------------------------------------------------------

		private Point _startPoint;

		//-------Координаты для появления фигуры-----------------------------------------------
		int[] _CorX = new int[50];
		int[] _CorY = new int[50];
		int Cords = 0;
		int CordX = 0;
		int CordY = 0;

		int[] _CorXO = new int[50];
		int[] _CorYO = new int[50];
		int CordsO = 0;
		//-------------------------------------------------------------------------------------
		public Form1()
		{
			InitializeComponent();
			DoubleBuffered = true;

			Paint += MainForm_Paint;
			MouseDown += MainForm_MouseDown;
			MouseMove += MainForm_MouseMove;
			MouseUp += MainForm_MouseUp;
			MouseClick += MainForm_MouseClick;

			// Вывод формы по центру экрана
			StartPosition = FormStartPosition.CenterScreen;
		}
		//-------------------------------------------------------------------------------------
		bool FindSov(Ellipse[] _ellipse, MouseEventArgs _e)					  //позиция курсора
		{

			for (int i = 0; i < ellipseScore; i++)
			{
				if (_ellipse[i].Contains(_e.Location))
				{
					return true;
				}
			}
			return false;
		}
		//-------------------------------//определение фигуры//------------------------------//
		Ellipse DefinitionEl(MouseEventArgs e)											 //круг
		{
			for (int i = 0; i < ellipseScore; i++)
			{
				if (_figures[i].Contains(e.Location))
				{
					return _figures[i];
				}
			}
			return null;
		}
		Polygon DefinitionSq(MouseEventArgs e)										  //квадрат
		{
			for (int i = 0; i < SqScore; i++)
			{
				if (_figuresSq[i].Contains(e.Location))
				{
					return _figuresSq[i];
				}
			}
			return null;
		}
		Line DefinitionL(MouseEventArgs e)												//линия
		{
			for (int i = 0; i < LineScore; i++)
			{
				if (_figuresLine[i].Contains(e.Location))
				{
					return _figuresLine[i];
				}
			}
			return null;
		}
		Ring DefinitionR(MouseEventArgs e)                                             //кольцо
		{
			for (int i = 0; i < RingScore; i++)
			{
				if (_figuresRing[i].Contains(e.Location))
				{
					return _figuresRing[i];
				}
			}
			return null;
		}
		SE DefinitionSE(MouseEventArgs e)											       //SE
		{
			for (int i = 0; i < SEScore; i++)
			{
				if (_figuresSE[i].Contains(e.Location))
				{
					return _figuresSE[i];
				}
			}
			return null;
		}
		Oval DefinitionOval(MouseEventArgs e)                                                //овал
		{
			for (int i = 0; i < OvalScore; i++)
			{
				if (_figuresOval[i].Contains(e.Location))
				{
					return _figuresOval[i];
				}
			}
			return null;
		}
		Romb DefinitionRomb(MouseEventArgs e)                                                //овал
		{
			for (int i = 0; i < RombScore; i++)
			{
				if (_figuresRomb[i].Contains(e.Location))
				{
					return _figuresRomb[i];
				}
			}
			return null;
		}
		Quadrilateral DefinitionQu(MouseEventArgs e)                                                //овал
		{
			for (int i = 0; i < QuScore; i++)
			{
				if (_figuresQu[i].Contains(e.Location))
				{
					return _figuresQu[i];
				}
			}
			return null;
		}
		//---------------------------------//выделение//---------------------------------------
		void lightFalseEl()																 //круг
		{
			for (int i = 0; i < ellipseScore; i++)
			{
				_figures[i].Highlighted = false;
			}
			this.Refresh();
		}
		void lightFalseSq()                                                           //квадрат
		{
			for (int i = 0; i < SqScore; i++)
			{
				_figuresSq[i].Highlighted = false;
			}
			this.Refresh();
		}
		void lightFalseL()                                                              //линия
		{
			for (int i = 0; i < LineScore; i++)
			{
				_figuresLine[i].Highlighted = false;
			}
			this.Refresh();
		}
		void lightFalseR()                                                             //кольцо
		{
			for (int i = 0; i < RingScore; i++)
			{
				_figuresRing[i].Highlighted = false;
			}
			this.Refresh();
		}
		void lightFalseSE()																   //SE
		{
			for (int i = 0; i < SEScore; i++)
			{
				_figuresSE[i].Highlighted = false;
			}
			this.Refresh();
		}
		void lightFalseOval()                                                              //oval
		{
			for (int i = 0; i < OvalScore; i++)
			{
				_figuresOval[i].Highlighted = false;
			}
			this.Refresh();
		}
		void lightFalseRomb()                                                              //oval
		{
			for (int i = 0; i < RombScore; i++)
			{
				_figuresRomb[i].Highlighted = false;
			}
			this.Refresh();
		}
		void lightFalseQu()                                                              //oval
		{
			for (int i = 0; i < QuScore; i++)
			{
				_figuresQu[i].Highlighted = false;
			}
			this.Refresh();
		}
		//-------------------------------------------------------------------------------------
		void MainForm_MouseClick(object sender, MouseEventArgs e)
		{
			Ellipse f = DefinitionEl(e);
			Polygon k = DefinitionSq(e);
			Line b = DefinitionL(e);
			Ring r = DefinitionR(e);
			SE sqre = DefinitionSE(e);
			Oval o = DefinitionOval(e);
			Romb Ro = DefinitionRomb(e);
			Quadrilateral Qu = DefinitionQu(e);

			if (f == null && k == null && b == null && r == null && sqre == null && o == null && Ro == null && Qu==null)//выделение объекта
			{
				lightFalseEl();															 //круг
				lightFalseSq();														  //квадрат
				lightFalseL();                                                          //линия
				lightFalseR();														   //кольцо
				lightFalseSE();                                                            //SE
				lightFalseOval();
				lightFalseRomb();
				lightFalseQu();

				Array.Clear(_CorX,0,50);
				Array.Clear(_CorY,0,50);
				Cords = 0;

				Array.Clear(_CorXO, 0, 50);
				Array.Clear(_CorYO, 0, 50);
				CordsO = 0;

				return;
			}
			else if (f != null)
			{                                            
				lightFalseSq();
				lightFalseL();
				lightFalseR();
				lightFalseSE();
				lightFalseOval();
				lightFalseRomb();
				lightFalseQu();

				Array.Clear(_CorXO, 0, 50);
				Array.Clear(_CorYO, 0, 50);
				CordsO = 0;

				_CorX[Cords] = e.X;                                         //добавление в массив
                _CorY[Cords] = e.Y;
				Cords++;

				f.Highlighted = true;
			}
			else if (k != null)
			{                                            
				lightFalseEl();
				lightFalseL();
				lightFalseR();
				lightFalseSE();
				lightFalseOval();
				lightFalseRomb();
				lightFalseQu();

				Array.Clear(_CorX, 0, 50);
				Array.Clear(_CorY, 0, 50);
				Cords = 0;
				Array.Clear(_CorXO, 0, 50);
				Array.Clear(_CorYO, 0, 50);
				CordsO = 0;

				k.Highlighted = true;
			}
			else if (b != null)
			{                                            
				lightFalseEl();
				lightFalseSq();
				lightFalseR();
				lightFalseSE();
				lightFalseOval();
				lightFalseRomb();
				lightFalseQu();

				Array.Clear(_CorX, 0, 50);
				Array.Clear(_CorY, 0, 50);
				Cords = 0;
				Array.Clear(_CorXO, 0, 50);
				Array.Clear(_CorYO, 0, 50);
				CordsO = 0;

				b.Highlighted = true;
			}
			else if (r != null)
			{
				lightFalseEl();
				lightFalseSq();
				lightFalseL();
				lightFalseSE();
				lightFalseOval();
				lightFalseRomb();
				lightFalseQu();

				Array.Clear(_CorX, 0, 50);
				Array.Clear(_CorY, 0, 50);
				Cords = 0;
				Array.Clear(_CorXO, 0, 50);
				Array.Clear(_CorYO, 0, 50);
				CordsO = 0;

				r.Highlighted = true;
			}
			else if (sqre != null)
			{
				lightFalseEl();
				lightFalseSq();
				lightFalseL();
				lightFalseR();
				lightFalseOval();
				lightFalseRomb();
				lightFalseQu();

				Array.Clear(_CorX, 0, 50);
				Array.Clear(_CorY, 0, 50);
				Cords = 0;
				Array.Clear(_CorXO, 0, 50);
				Array.Clear(_CorYO, 0, 50);
				CordsO = 0;

				sqre.Highlighted = true;
			}
			else if (o != null)
			{
				lightFalseEl();
				lightFalseSq();
				lightFalseL();
				lightFalseR();
				lightFalseSE();
				lightFalseRomb();
				lightFalseQu();

				Array.Clear(_CorX, 0, 50);
				Array.Clear(_CorY, 0, 50);
				Cords = 0;

				_CorXO[CordsO] = e.X;                                         //добавление в массив
				_CorYO[CordsO] = e.Y;
				CordsO++;

				o.Highlighted = true;
			}
			else if (Ro != null)
			{
				lightFalseEl();
				lightFalseSq();
				lightFalseL();
				lightFalseR();
				lightFalseSE();
				lightFalseOval();
				lightFalseQu();

				Array.Clear(_CorX, 0, 50);
				Array.Clear(_CorY, 0, 50);
				Cords = 0;
				Array.Clear(_CorXO, 0, 50);
				Array.Clear(_CorYO, 0, 50);
				CordsO = 0;

				Ro.Highlighted = true;
			}
			else if (Qu != null)
			{
				lightFalseEl();
				lightFalseSq();
				lightFalseL();
				lightFalseR();
				lightFalseSE();
				lightFalseOval();
				lightFalseRomb();

				Array.Clear(_CorX, 0, 50);
				Array.Clear(_CorY, 0, 50);
				Cords = 0;
				Array.Clear(_CorXO, 0, 50);
				Array.Clear(_CorYO, 0, 50);
				CordsO = 0;

				Qu.Highlighted = true;
			}
		}
		//-------------------------------------------------------------------------------------
		void MainForm_MouseUp(object sender, MouseEventArgs e)
		{
			_figureToMove = null;
			_figureToMoveSq = null;
			_figureToMoveLine = null;
			_figureToMoveRing = null;
			_figureToMoveSE = null;
			_figureToMoveOval = null;
			_figureToMoveRomb = null;
			_figureToMoveQu = null;

			Cursor = Cursors.Default;
			this.Refresh();
		}
		//---------------------------------------------------------------------------------------
		void MainForm_MouseDown(object sender, MouseEventArgs e)
		{
			_figureToMove = DefinitionEl(e);
			_figureToMoveSq = DefinitionSq(e);
			_figureToMoveLine = DefinitionL(e);
			_figureToMoveRing = DefinitionR(e);
			_figureToMoveSE = DefinitionSE(e);
			_figureToMoveOval = DefinitionOval(e);
			_figureToMoveRomb = DefinitionRomb(e);
			_figureToMoveQu = DefinitionQu(e);


			if (_figureToMove == null && _figureToMoveSq == null && _figureToMoveLine == null && 
				_figureToMoveRing == null && _figureToMoveSE == null && _figureToMoveOval == null && 
				_figureToMoveRomb == null && _figureToMoveQu == null) 
			{
				return;
			}
			else if (_figureToMove != null)
			{                                            
                lightFalseSq();
				lightFalseL();
				lightFalseR();
				lightFalseSE();
				lightFalseOval();
				lightFalseRomb();
				lightFalseQu();

				_figureToMove.Highlighted = true;
				_startPoint = e.Location;
			}
			else if (_figureToMoveSq != null)
			{                                            
				lightFalseEl();
				lightFalseL();
				lightFalseR();
				lightFalseSE();
				lightFalseOval();
				lightFalseRomb();
				lightFalseQu();

				_figureToMoveSq.Highlighted = true;
				_startPoint = e.Location;
			}
			else if (_figureToMoveLine != null)
			{                                            
				lightFalseEl();
				lightFalseSq();
				lightFalseR();
				lightFalseSE();
				lightFalseOval();
				lightFalseRomb();
				lightFalseQu();

				_figureToMoveLine.Highlighted = true;
				_startPoint = e.Location;
			}
			else if (_figureToMoveRing != null)
			{
				lightFalseEl();
				lightFalseSq();
				lightFalseL();
				lightFalseSE();
				lightFalseOval();
				lightFalseRomb();
				lightFalseQu();

				_figureToMoveRing.Highlighted = true;
				_startPoint = e.Location;
			}
			else if (_figureToMoveSE != null)
			{
				lightFalseEl();
				lightFalseSq();
				lightFalseL();
				lightFalseR();
				lightFalseOval();
				lightFalseRomb();
				lightFalseQu();

				_figureToMoveSE.Highlighted = true;
				_startPoint = e.Location;
			}
			else if (_figureToMoveOval != null)
			{
				lightFalseEl();
				lightFalseSq();
				lightFalseL();
				lightFalseR();
				lightFalseSE();
				lightFalseRomb();
				lightFalseQu();

				_figureToMoveOval.Highlighted = true;
				_startPoint = e.Location;
			}
			else if (_figureToMoveRomb != null)
			{
				lightFalseEl();
				lightFalseSq();
				lightFalseL();
				lightFalseR();
				lightFalseSE();
				lightFalseOval();
				lightFalseQu();

				_figureToMoveRomb.Highlighted = true;
				_startPoint = e.Location;
			}
			else if (_figureToMoveQu != null)
			{
				lightFalseEl();
				lightFalseSq();
				lightFalseL();
				lightFalseR();
				lightFalseSE();
				lightFalseOval();
				lightFalseQu();

				_figureToMoveQu.Highlighted = true;
				_startPoint = e.Location;
			}
		}
		//---------------------------------------------------------------------------------------

		void AllE (object sender, MouseEventArgs e)
        {
			Graphics g = CreateGraphics();

			for (int i = 0; i < ellipseScore;i++)
            {
				_figures[i].Move(e.X - _startPoint.X, e.Y - _startPoint.Y,g,1);
				this.Refresh();
			}
			_startPoint = e.Location;
		}
		void AllS(object sender, MouseEventArgs e)
		{
			Graphics g = CreateGraphics();
			for (int i = 0; i < SqScore; i++)
			{
				_figuresSq[i].Move(e.X - _startPoint.X, e.Y - _startPoint.Y, g, 2);
				this.Refresh();
			}
			_startPoint = e.Location;
		}
		void AllL(object sender, MouseEventArgs e)
		{
			Graphics g = CreateGraphics();
			for (int i = 0; i < LineScore; i++)
			{
				_figuresLine[i].Move(e.X - _startPoint.X, e.Y - _startPoint.Y,g, 2);
				this.Refresh();
			}
			_startPoint = e.Location;
		}
		void AllR(object sender, MouseEventArgs e)
		{
			Graphics g = CreateGraphics();
			for (int i = 0; i < RingScore; i++)
			{
				_figuresRing[i].Move(e.X - _startPoint.X, e.Y - _startPoint.Y);
				this.Refresh();
			}
			_startPoint = e.Location;
		}
		void AllSE(object sender, MouseEventArgs e)
		{
			Graphics g = CreateGraphics();
			for (int i = 0; i < SEScore; i++)
			{
				_figuresSE[i].Move(e.X - _startPoint.X, e.Y - _startPoint.Y);
				this.Refresh();
			}
			_startPoint = e.Location;
		}
		void AllO(object sender, MouseEventArgs e)
		{
			Graphics g = CreateGraphics();
			for (int i = 0; i < OvalScore; i++)
			{
				_figuresOval[i].Move(e.X - _startPoint.X, e.Y - _startPoint.Y,g,1);
				this.Refresh();
			}
			_startPoint = e.Location;
		}
		void AllRomb(object sender, MouseEventArgs e)
		{
			Graphics g = CreateGraphics();
			for (int i = 0; i < RombScore; i++)
			{
				_figuresRomb[i].Move(e.X - _startPoint.X, e.Y - _startPoint.Y,g,2);
				this.Refresh();
			}
			_startPoint = e.Location;
		}
		void AllQu(object sender, MouseEventArgs e)
		{
			Graphics g = CreateGraphics();
			for (int i = 0; i < QuScore; i++)
			{
				_figuresQu[i].Move(e.X - _startPoint.X, e.Y - _startPoint.Y,g,2);
				this.Refresh();
			}
			_startPoint = e.Location;
		}
		//-------------------------------------------------------------------------------------
		void MainForm_MouseMove(object sender, MouseEventArgs e)
		{
			Graphics g = CreateGraphics();
			switch (e.Button)
			{
				case MouseButtons.None:
					Cursor = FindSov(_figures, e) ?
						Cursors.Hand : Cursors.Default;
					break;

				case MouseButtons.Left:                              //перемещение одной фигуры

					if (_figureToMove == null && _figureToMoveSq == null && _figureToMoveLine == null &&
						_figureToMoveRing == null && _figureToMoveSE == null && _figureToMoveOval == null &&
						_figureToMoveRomb == null && _figureToMoveQu == null)
					{
						return;
					}
					else if (_figureToMove != null)										 //круг
					{
						_figureToMove.Move(e.X - _startPoint.X, e.Y - _startPoint.Y, g, 1);
						_startPoint = e.Location;

						//снятие выделениея
						lightFalseEl();
						lightFalseSq();
						lightFalseL();
						lightFalseR();
						lightFalseSE();
						lightFalseOval();
						lightFalseRomb();
						lightFalseQu();

						// при перемещении и очистка списков
						Array.Clear(_CorX, 0, 50);
						Array.Clear(_CorY, 0, 50);
						Cords = 0;

					}
					else if (_figureToMoveSq != null)								  //квадрат
					{
						_figureToMoveSq.Move(e.X - _startPoint.X, e.Y - _startPoint.Y, g, 2);
						_startPoint = e.Location;

						lightFalseEl();
						lightFalseSq();
						lightFalseL();
						lightFalseR();
						lightFalseSE();
						lightFalseOval();
						lightFalseRomb();
						lightFalseQu();
					}
					else if (_figureToMoveLine != null)								    //линия
					{
						_figureToMoveLine.Move(e.X - _startPoint.X, e.Y - _startPoint.Y, g, 2);
						_startPoint = e.Location;

						lightFalseEl();
						lightFalseSq();
						lightFalseL();
						lightFalseR();
						lightFalseSE();
						lightFalseOval();
						lightFalseRomb();
						lightFalseQu();
					}
					else if (_figureToMoveRing != null)								   //кольцо
					{
						_figureToMoveRing.Move(e.X - _startPoint.X, e.Y - _startPoint.Y);
						_startPoint = e.Location;

						lightFalseEl();
						lightFalseSq();
						lightFalseL();
						lightFalseR();
						lightFalseSE();
						lightFalseOval();
						lightFalseRomb();
						lightFalseQu();
					}
					else if (_figureToMoveSE != null)									   //SE
					{
						_figureToMoveSE.Move(e.X - _startPoint.X, e.Y - _startPoint.Y);
						_startPoint = e.Location;

						lightFalseEl();
						lightFalseSq();
						lightFalseL();
						lightFalseR();
						lightFalseSE();
						lightFalseOval();
						lightFalseRomb();
						lightFalseQu();
					}
					else if (_figureToMoveOval != null)                                      //SE
					{
						_figureToMoveOval.Move(e.X - _startPoint.X, e.Y - _startPoint.Y, g, 1);
						_startPoint = e.Location;

						lightFalseEl();
						lightFalseSq();
						lightFalseL();
						lightFalseR();
						lightFalseSE();
						lightFalseOval();
						lightFalseRomb();
						lightFalseQu();
					}
					else if (_figureToMoveRomb != null)                                      //SE
					{
						_figureToMoveRomb.Move(e.X - _startPoint.X, e.Y - _startPoint.Y, g, 2);
						_startPoint = e.Location;

						lightFalseEl();
						lightFalseSq();
						lightFalseL();
						lightFalseR();
						lightFalseSE();
						lightFalseOval();
						lightFalseRomb();
						lightFalseQu();
					}
					else if (_figureToMoveQu != null)                                      //SE
					{
						_figureToMoveQu.Move(e.X - _startPoint.X, e.Y - _startPoint.Y, g, 2);
						_startPoint = e.Location;

						lightFalseEl();
						lightFalseSq();
						lightFalseL();
						lightFalseR();
						lightFalseSE();
						lightFalseOval();
						lightFalseRomb();
						lightFalseQu();
					}
					break;

				case MouseButtons.Right:                             //перемещение класса фигур
					if (_figureToMove == null && _figureToMoveSq == null && _figureToMoveLine == null && 
						_figureToMoveRing == null && _figureToMoveSE == null && _figureToMoveOval == null && 
						_figureToMoveRomb == null && _figureToMoveQu == null)
					{
						return;
					}
					else if (_figureToMove != null)										 //круг
					{
						AllE(sender, e);
					}
					else if (_figureToMoveSq != null)								  //квадрат
					{
						AllS(sender, e);
					}
					else if (_figureToMoveLine != null)									//линия
					{
						AllL(sender, e);
					}
					else if (_figureToMoveRing != null)                                //кольцо
					{
						AllR(sender, e);
					}
					else if (_figureToMoveSE != null)									   //SE
					{
						AllSE(sender, e);
					}
					else if (_figureToMoveOval != null)                                      //SE
					{
						AllO(sender, e);
					}
					else if (_figureToMoveRomb != null)                                      //SE
					{
						AllRomb(sender, e);
					}
					else if (_figureToMoveQu != null)                                      //SE
					{
						AllQu(sender, e);
					}
					break;
			}
		}

		void MainForm_Paint(object sender, PaintEventArgs e)              //обновление на форме
		{
			for (int i = 0; i < ellipseScore; i++)
			{
				_figures[i].Fill(e.Graphics, _figures[i].Brush ?? Brushes.Yellow);
				_figures[i].Draw(e.Graphics, _figures[i].Pen ?? Pens.Black);
			}

			for (int i = 0; i < SqScore; i++)
			{
				_figuresSq[i].Fill(e.Graphics, _figuresSq[i].Brush ?? Brushes.Yellow);
				_figuresSq[i].Draw(e.Graphics, _figuresSq[i].Pen ?? Pens.Black);
			}

			for (int i = 0; i < LineScore; i++)
			{
				_figuresLine[i].Fill(e.Graphics, _figuresLine[i].Brush ?? Brushes.Yellow);
				_figuresLine[i].Draw(e.Graphics, _figuresLine[i].Pen ?? Pens.Black);
		}
			for (int i = 0; i < RingScore; i++)
			{
				_figuresRing[i].Fill(e.Graphics);
				_figuresRing[i].Draw(e.Graphics);
			}
			for (int i = 0; i < SEScore; i++)
			{
				_figuresSE[i].Fill(e.Graphics);
				_figuresSE[i].Draw(e.Graphics);
			}
			for (int i = 0; i < OvalScore; i++)
			{
				_figuresOval[i].Fill(e.Graphics, _figuresOval[i].Brush ?? Brushes.Yellow);
				_figuresOval[i].Draw(e.Graphics, _figuresOval[i].Pen ?? Pens.Black);
			}
			for (int i = 0; i < RombScore; i++)
			{
				_figuresRomb[i].Fill(e.Graphics, _figuresRomb[i].Brush ?? Brushes.Yellow);
				_figuresRomb[i].Draw(e.Graphics, _figuresRomb[i].Pen ?? Pens.Black);
			}
			for (int i = 0; i < QuScore; i++)
			{
				_figuresQu[i].Fill(e.Graphics, _figuresQu[i].Brush ?? Brushes.Yellow);
				_figuresQu[i].Draw(e.Graphics, _figuresQu[i].Pen ?? Pens.Black);
			}
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			this.Refresh();
		}

		public void size1_Click(object sender, EventArgs e)                    //создание круга
		{

			Graphics t = CreateGraphics();

			int Size = 0;

			if (textBox1.Text != "sizeEllips" && textBox1.Text != ""
				&& (textBox5.Text == "x" || textBox5.Text == "")
				&& (textBox6.Text == "y" || textBox6.Text == ""))
			{
				if (int.TryParse(textBox1.Text, out Size))
				{
					Size = System.Convert.ToInt32(textBox1.Text);

					_figures[ellipseScore] = (new Ellipse());
					_figures[ellipseScore].Creat(Rectangle.FromLTRB(0, 0, Size, Size));
					MessageBox.Show("Фигура создана", "Создание фигуры", MessageBoxButtons.OK);
				}
				else
				{
					MessageBox.Show("Введите число", "Ошибка", MessageBoxButtons.OK);
				}
			}
			else if (textBox1.Text == "sizeEllips" || textBox1.Text == "")
			{
				_figures[ellipseScore] = (new Ellipse());
				_figures[ellipseScore].Creat();
				MessageBox.Show("Фигура создана", "Создание фигуры", MessageBoxButtons.OK);
			}
			else if ((textBox5.Text != "x" && textBox5.Text != "") 
				  && (textBox6.Text != "y" && textBox6.Text != "") 
				  && (textBox1.Text != "sizeEllips" && textBox1.Text != ""))  
			{
				if (int.TryParse(textBox5.Text, out CordX) 
				 && int.TryParse(textBox6.Text, out CordY) 
				 && int.TryParse(textBox1.Text, out Size))
				{
					Size = System.Convert.ToInt32(textBox1.Text);
					_figures[ellipseScore] = (new Ellipse(CordX, CordY, Size));
					_figures[ellipseScore].Creat();
					
					MessageBox.Show("Фигура создана", "Создание фигуры", MessageBoxButtons.OK);
				}
				else
				{
					MessageBox.Show("Введите число", "Ошибка", MessageBoxButtons.OK);
				}
			}

			for (int i = 0; i <= ellipseScore; i++)                       //обновление на форме
			{            //костыль т.к не смог создать переменную подходящую под PaintEventArgs
				_figures[i].Fill(t, _figures[i].Brush ?? Brushes.Yellow);
				_figures[i].Draw(t, _figures[i].Pen ?? Pens.Black);
		}

			ellipseScore++;
		}

		private void size2_Click(object sender, EventArgs e)				//создание квадрата
		{
			Graphics l = CreateGraphics();

			int SizeSq = 0;

			if (textBox2.Text != "sizeSquar" && textBox2.Text != ""
				&& (textBox5.Text == "x" || textBox5.Text == "")
				&& (textBox6.Text == "y" || textBox6.Text == ""))
			{
				if (int.TryParse(textBox2.Text, out SizeSq))
				{
					SizeSq = System.Convert.ToInt32(textBox2.Text);

                    _figuresSq[SqScore] = (new Polygon());
					_figuresSq[SqScore].Creat(new[]
					{
						new Point(0,0),
						new Point(SizeSq,0),
						new Point(SizeSq,SizeSq),
  						new Point(0,SizeSq)
					});
					MessageBox.Show("Фигура создана", "Создание фигуры", MessageBoxButtons.OK);
				}
				else
				{
					MessageBox.Show("Введите число", "Ошибка", MessageBoxButtons.OK);
				}
			}
			else if (textBox2.Text == "sizeSquar" || textBox2.Text == "")
			{
				_figuresSq[SqScore] =(new Polygon());
				_figuresSq[SqScore].Creat();
				MessageBox.Show("Фигура создана", "Создание фигуры", MessageBoxButtons.OK);
			}
			else if ((textBox5.Text != "x" && textBox5.Text != "") 
				  && (textBox6.Text != "y" && textBox6.Text != "")
				  && (textBox2.Text != "sizeSquar" && textBox2.Text != ""))
			{
				if (int.TryParse(textBox5.Text, out CordX) 
				 && int.TryParse(textBox6.Text, out CordY)
				 && int.TryParse(textBox2.Text, out SizeSq))
				{
					_figuresSq[SqScore] = (new Polygon(CordX, CordY, SizeSq));
					_figuresSq[SqScore].Creat();
					MessageBox.Show("Фигура создана", "Создание фигуры", MessageBoxButtons.OK);
				}
				else
				{
					MessageBox.Show("Введите число", "Ошибка", MessageBoxButtons.OK);
				}
			}
			for (int i = 0; i <= SqScore; i++)							  //обновление на форме
			{
				_figuresSq[i].Fill(l, _figuresSq[i].Brush ?? Brushes.Yellow);
				_figuresSq[i].Draw(l, _figuresSq[i].Pen ?? Pens.Black);
			}

			SqScore++;
		}

		private void size3_Click(object sender, EventArgs e)
		{
			Graphics o = CreateGraphics();

			int SizeLine = 0;

			if (textBox3.Text != "sizeLine" && textBox3.Text != ""
			&& (textBox5.Text == "x" || textBox5.Text == "")
			&& (textBox6.Text == "y" || textBox6.Text == ""))
			{
				if (int.TryParse(textBox3.Text, out SizeLine))
				{
					SizeLine = System.Convert.ToInt32(textBox3.Text);


					_figuresLine[LineScore] = (new Line());
					_figuresLine[LineScore].Creat(new[]
					{
						new Point(0,0),
						new Point(SizeLine,SizeLine),
						new Point(SizeLine-10,SizeLine+10),
						new Point(0-10,0+10)
					});
					MessageBox.Show("Фигура создана", "Создание фигуры", MessageBoxButtons.OK);
				}
				else
				{
					MessageBox.Show("Введите число", "Ошибка", MessageBoxButtons.OK);
				}
			}
			else if (textBox3.Text == "sizeLine" || textBox3.Text == "")
			{
				_figuresLine[LineScore]=(new Line());
				_figuresLine[LineScore].Creat();
				MessageBox.Show("Фигура создана", "Создание фигуры", MessageBoxButtons.OK);
			}
			else if ((textBox5.Text != "x" && textBox5.Text != "") 
				  && (textBox6.Text != "y" && textBox6.Text != "")
				  && (textBox3.Text != "sizeLine" && textBox3.Text != ""))
			{
				if (int.TryParse(textBox5.Text, out CordX) 
				 && int.TryParse(textBox6.Text, out CordY)
				 && int.TryParse(textBox3.Text, out SizeLine))
				{
					_figuresLine[LineScore] = (new Line(CordX, CordY, SizeLine));
					_figuresLine[LineScore].Creat();
					MessageBox.Show("Фигура создана", "Создание фигуры", MessageBoxButtons.OK);
				}
				else
				{
					MessageBox.Show("Введите число", "Ошибка", MessageBoxButtons.OK);
				}
			}
			for (int i = 0; i <= LineScore; i++)						  //обновление на форме
			{
				_figuresLine[LineScore].Fill(o, _figuresLine[i].Brush ?? Brushes.Yellow);
				_figuresLine[LineScore].Draw(o, _figuresLine[i].Pen ?? Pens.Black);
			}
			LineScore++;

		}
		private void size4_Click(object sender, EventArgs e)
		{
			Graphics t = CreateGraphics();

			int Size;

			if (textBox7.Text != "sizeRing" && textBox7.Text != ""
				&& (textBox5.Text == "x" || textBox5.Text == "")
				&& (textBox6.Text == "y" || textBox6.Text == ""))
			{
				if (int.TryParse(textBox7.Text, out Size))
				{
					Ellipse _FiEllipse = new Ellipse();
					_FiEllipse.Creat(Rectangle.FromLTRB(Size - Size / 2, Size - Size / 2, Size + Size / 2, Size + Size / 2));
					Ellipse _ToEllipse = new Ellipse();
					_ToEllipse.Creat(Rectangle.FromLTRB(Size - ((Size - 25) / 2), Size - ((Size - 25) / 2), Size + ((Size - 25) / 2), Size + ((Size - 25) / 2)));
					_figuresRing[RingScore] = (new Ring(_FiEllipse, _ToEllipse));
					MessageBox.Show("Фигура создана", "Создание фигуры", MessageBoxButtons.OK);
				}
				else
				{
					MessageBox.Show("Введите число", "Ошибка", MessageBoxButtons.OK);
				}
			}
			else if (textBox7.Text == "sizeRing" || textBox7.Text == "")
			{
				Ellipse _FiEllipse = new Ellipse();
				_FiEllipse.Creat();
				Ellipse _ToEllipse = new Ellipse(20);
				_ToEllipse.Creat();
				_figuresRing[RingScore] = (new Ring(_FiEllipse, _ToEllipse)) ;
				MessageBox.Show("Фигура создана", "Создание фигуры", MessageBoxButtons.OK);
			}
			else if ((textBox5.Text != "x" && textBox5.Text != "")
				  && (textBox6.Text != "y" && textBox6.Text != "")
				  && (textBox7.Text != "sizeRing" && textBox7.Text != ""))
			{
				if (int.TryParse(textBox5.Text, out CordX)
				 && int.TryParse(textBox6.Text, out CordY)
				 && int.TryParse(textBox7.Text, out Size))
				{
					Size = System.Convert.ToInt32(textBox7.Text);
					Ellipse _FiEllipse = new Ellipse(CordX, CordY, Size);
					_FiEllipse.Creat();
					Ellipse _ToEllipse = new Ellipse(CordX, CordY, Size - 25);
					_ToEllipse.Creat();
					_figuresRing[RingScore] = (new Ring(_FiEllipse, _ToEllipse));
					MessageBox.Show("Фигура создана", "Создание фигуры", MessageBoxButtons.OK);
				}
				else
				{
					MessageBox.Show("Введите число", "Ошибка", MessageBoxButtons.OK);
				}
			}

			for (int i = 0; i <= RingScore; i++)                //обновление на форме
			{       //костыль т.к не смог создать переменную подходящую под PaintEventArgs
				_figuresRing[i].Fill(t);
				_figuresRing[i].Draw(t);
			}

			RingScore++;

		}
		private void size5_Click(object sender, EventArgs e)
		{
			Graphics t = CreateGraphics();

			int Size;

			if (textBox8.Text != "sizeSE" && textBox8.Text != ""
				&& (textBox5.Text == "x" || textBox5.Text == "")
				&& (textBox6.Text == "y" || textBox6.Text == ""))
			{
				if (int.TryParse(textBox8.Text, out Size))
				{
					//Size = System.Convert.ToInt32(textBox7.Text);
					Polygon _Polyg = new Polygon();
					_Polyg.Creat(new[]{
						new Point(0, 0),
						new Point(Size, 0),
						new Point(Size, Size),
  						new Point(0, Size)
					});
					Ellipse _Elip = new Ellipse();
					_Elip.Creat(_reSE);
					_figuresSE[SEScore] = (new SE(_Polyg,_Elip));
					MessageBox.Show("Фигура создана", "Создание фигуры", MessageBoxButtons.OK);
				}
				else
				{
					MessageBox.Show("Введите число", "Ошибка", MessageBoxButtons.OK);
				}
			}
			else if (textBox8.Text == "sizeSE" || textBox8.Text == "")
			{
				Polygon _Polyg = new Polygon();
				_Polyg.Creat();
				Ellipse _Elip = new Ellipse(COST);
				_Elip.Creat();
				_figuresSE[SEScore] = (new SE(_Polyg, _Elip));
				MessageBox.Show("Фигура создана", "Создание фигуры", MessageBoxButtons.OK);
			}
			else if ((textBox5.Text != "x" && textBox5.Text != "")
				  && (textBox6.Text != "y" && textBox6.Text != "")
				  && (textBox8.Text != "sizeSE" && textBox8.Text != ""))
			{
				if (int.TryParse(textBox5.Text, out CordX)
				 && int.TryParse(textBox6.Text, out CordY)
				 && int.TryParse(textBox8.Text, out Size))
				{
					Polygon _Polyg = new Polygon(CordX, CordY, Size);
					_Polyg.Creat();
					Ellipse _Elip = new Ellipse(CordX, CordY, Size);
					_Elip.Creat();
					_figuresSE[SEScore] = (new SE(_Polyg, _Elip));
					MessageBox.Show("Фигура создана", "Создание фигуры", MessageBoxButtons.OK);
				}
				else
				{
					MessageBox.Show("Введите число", "Ошибка", MessageBoxButtons.OK);
				}
			}

			for (int i = 0; i <= SEScore; i++)                //обновление на форме
			{       //костыль т.к не смог создать переменную подходящую под PaintEventArgs
				_figuresSE[i].Fill(t);
				_figuresSE[i].Draw(t);
			}

			SEScore++;

		}
		private void size6_Click(object sender, EventArgs e)
		{
			Graphics t = CreateGraphics();

			int Size = 0;

			if (textBox9.Text != "sizeOval" && textBox9.Text != ""
				&& (textBox5.Text == "x" || textBox5.Text == "")
				&& (textBox6.Text == "y" || textBox6.Text == ""))
			{
				if (int.TryParse(textBox9.Text, out Size))
				{

					_figuresOval[OvalScore] = (new Oval());
					_figuresOval[OvalScore].Creat(Rectangle.FromLTRB(0, 0, Size, Size/2));
					MessageBox.Show("Фигура создана", "Создание фигуры", MessageBoxButtons.OK);
				}
				else
				{
					MessageBox.Show("Введите число", "Ошибка", MessageBoxButtons.OK);
				}
			}
			else if (textBox9.Text == "sizeOval" || textBox9.Text == "")
			{
				_figuresOval[OvalScore] = (new Oval());
				_figuresOval[OvalScore].Creat();
				MessageBox.Show("Фигура создана", "Создание фигуры", MessageBoxButtons.OK);
			}
			else if ((textBox5.Text != "x" && textBox5.Text != "")
				  && (textBox6.Text != "y" && textBox6.Text != "")
				  && (textBox9.Text != "sizeOval" && textBox9.Text != ""))
			{
				if (int.TryParse(textBox5.Text, out CordX)
				 && int.TryParse(textBox6.Text, out CordY)
				 && int.TryParse(textBox9.Text, out Size))
				{
					_figuresOval[OvalScore] = (new Oval(CordX, CordY, Size));
					_figuresOval[OvalScore].Creat();

					MessageBox.Show("Фигура создана", "Создание фигуры", MessageBoxButtons.OK);
				}
				else
				{
					MessageBox.Show("Введите число", "Ошибка", MessageBoxButtons.OK);
				}
			}

			for (int i = 0; i <= OvalScore; i++)                       //обновление на форме
			{            //костыль т.к не смог создать переменную подходящую под PaintEventArgs
				_figuresOval[i].Fill(t, _figuresOval[i].Brush ?? Brushes.Yellow);
				_figuresOval[i].Draw(t, _figuresOval[i].Pen ?? Pens.Black);
			}

			OvalScore++;
		}

		private void size7_Click(object sender, EventArgs e)
		{
			Graphics l = CreateGraphics();

			int Size = 0;

			if (textBox10.Text != "sizeRomb" && textBox10.Text != ""
				&& (textBox5.Text == "x" || textBox5.Text == "")
				&& (textBox6.Text == "y" || textBox6.Text == ""))
			{
				if (int.TryParse(textBox10.Text, out Size))
				{

					_figuresRomb[RombScore] = (new Romb());
					_figuresRomb[RombScore].Creat(new[]
					{
						new Point(Size,0),
						new Point(Size*2,Size),
						new Point(Size,Size*2),
  						new Point(0,Size)
					});
					MessageBox.Show("Фигура создана", "Создание фигуры", MessageBoxButtons.OK);
				}
				else
				{
					MessageBox.Show("Введите число", "Ошибка", MessageBoxButtons.OK);
				}
			}
			else if (textBox10.Text == "sizeRomb" || textBox10.Text == "")
			{
				_figuresRomb[RombScore] = (new Romb());
				_figuresRomb[RombScore].Creat();
				MessageBox.Show("Фигура создана", "Создание фигуры", MessageBoxButtons.OK);
			}
			else if ((textBox5.Text != "x" && textBox5.Text != "")
				  && (textBox6.Text != "y" && textBox6.Text != "")
				  && (textBox10.Text != "sizeRomb" && textBox10.Text != ""))
			{
				if (int.TryParse(textBox5.Text, out CordX)
				 && int.TryParse(textBox6.Text, out CordY)
				 && int.TryParse(textBox10.Text, out Size))
				{
					_figuresRomb[RombScore] = (new Romb(CordX, CordY, Size));
					_figuresRomb[RombScore].Creat();
					MessageBox.Show("Фигура создана", "Создание фигуры", MessageBoxButtons.OK);
				}
				else
				{
					MessageBox.Show("Введите число", "Ошибка", MessageBoxButtons.OK);
				}
			}
			for (int i = 0; i <= RombScore; i++)                            //обновление на форме
			{
				_figuresRomb[i].Fill(l, _figuresRomb[i].Brush ?? Brushes.Yellow);
				_figuresRomb[i].Draw(l, _figuresRomb[i].Pen ?? Pens.Black);
			}

			RombScore++;

		}
		private void size8_Click(object sender, EventArgs e)
		{
			Graphics l = CreateGraphics();

			int Size = 0;

			if (textBox11.Text != "sizeQuad" && textBox11.Text != ""
				&& (textBox5.Text == "x" || textBox5.Text == "")
				&& (textBox6.Text == "y" || textBox6.Text == ""))
			{
				if (int.TryParse(textBox11.Text, out Size))
				{

					_figuresQu[QuScore] = (new Quadrilateral());
					_figuresQu[QuScore].Creat(new[]
					{
						new Point(0,0),
						new Point(Size*2,0),
						new Point(Size*2,Size),
  						new Point(0,Size)
					});
					MessageBox.Show("Фигура создана", "Создание фигуры", MessageBoxButtons.OK);
				}
				else
				{
					MessageBox.Show("Введите число", "Ошибка", MessageBoxButtons.OK);
				}
			}
			else if (textBox11.Text == "sizeQuad" || textBox11.Text == "")
			{
				_figuresQu[QuScore] = (new Quadrilateral());
				_figuresQu[QuScore].Creat();
				MessageBox.Show("Фигура создана", "Создание фигуры", MessageBoxButtons.OK);
			}
			else if ((textBox5.Text != "x" && textBox5.Text != "")
				  && (textBox6.Text != "y" && textBox6.Text != "")
				  && (textBox11.Text != "sizeQuad" && textBox11.Text != ""))
			{
				if (int.TryParse(textBox5.Text, out CordX)
				 && int.TryParse(textBox6.Text, out CordY)
				 && int.TryParse(textBox11.Text, out Size))
				{
					_figuresQu[QuScore] = (new Quadrilateral(CordX, CordY, Size));
					_figuresQu[QuScore].Creat();
					MessageBox.Show("Фигура создана", "Создание фигуры", MessageBoxButtons.OK);
				}
				else
				{
					MessageBox.Show("Введите число", "Ошибка", MessageBoxButtons.OK);
				}
			}
			for (int i = 0; i <= QuScore; i++)                            //обновление на форме
			{
				_figuresQu[i].Fill(l, _figuresQu[i].Brush ?? Brushes.Yellow);
				_figuresQu[i].Draw(l, _figuresQu[i].Pen ?? Pens.Black);
			}

			QuScore++;

		}

		private void SizeR_Click(object sender, EventArgs e)
		{
			Graphics h = CreateGraphics();

			int U = 0;
			int j = 0;

			int SizeR = 0;

			if (textBox4.Text != "Size" && textBox4.Text != "")
			{
				if (int.TryParse(textBox4.Text, out SizeR))
				{
					SizeR = System.Convert.ToInt32(textBox4.Text);

					for (int i = 0; i < ellipseScore; i++)     //проверка на выделенную фигуру
					{
						if (true == _figures[i].Highlighted)
						{
							_figures[i]= new Ellipse();
							_figures[i].Creat(Rectangle.FromLTRB(0, 0, SizeR, SizeR));
							_figures[i].Move(_CorX[j] - (SizeR / 2), _CorY[j] - (SizeR / 2), h, 1);

							j++;
							this.Refresh();                                     //обновление формы
							MessageBox.Show("Фигура изменена", "Создание фигуры", MessageBoxButtons.OK);
							U = 1;
						}
						else 
						{
							if (i == ellipseScore - 1 && U == 0)
							{
								MessageBox.Show("Выберите фигуру", "Ошибка", MessageBoxButtons.OK);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("Введите число", "Ошибка", MessageBoxButtons.OK);
				}
			}
			else if (textBox4.Text == "Size" || textBox4.Text == "")
			{
				MessageBox.Show("Введите значение", "ошибка", MessageBoxButtons.OK);
			}
			lightFalseEl();
			Array.Clear(_CorX, 0, 50);
			Array.Clear(_CorY, 0, 50);
			Cords = 0;
		}

		private void Swap_Click(object sender, EventArgs e)
		{
			Graphics h = CreateGraphics();

			int U = 0;
			int j = 0;

			int _x, _y, _w, _h;

			Rectangle _rect;

			for (int i = 0; i < OvalScore; i++)     //проверка на выделенную фигуру
			{
				if (true == _figuresOval[i].Highlighted)
				{
					_x = _figuresOval[i].GetX();
					_y = _figuresOval[i].GetY();
					_w = _figuresOval[i].GetW();
					_h = _figuresOval[i].GetH();

                    _figuresOval[i].GetRectangle();
					if (_figuresOval[i].GetRectangle().Width > _figuresOval[i].GetRectangle().Height) 
					{
						_rect = (Rectangle.FromLTRB(_x - (_w / 2), _y - (_h / 2), (_y + (_h / 2)) / 2, _x + (_w / 2)));
						_figuresOval[i].Creat(_rect);
						_figuresOval[i].Move(_CorXO[j] - (_w / 2), _CorYO[j] - (_w / 2), h, 1);
					}
					else if (_figuresOval[i].GetRectangle().Width < _figuresOval[i].GetRectangle().Height)
					{
						_rect = (Rectangle.FromLTRB(_x - (_w / 2), _y - (_h / 2), _x + (_w / 2), (_y + (_h / 2)) / 2));
						_figuresOval[i].Creat(_rect);
						_figuresOval[i].Move(_CorXO[j] - (_w / 2), _CorYO[j] - (_w / 2), h, 1);
					}

					j++;
					this.Refresh();                                     //обновление формы
					MessageBox.Show("Фигура изменена", "Изменение фигуры", MessageBoxButtons.OK);
					U = 1;
				}
				else
				{
					if (i == OvalScore - 1 && U == 0)
					{
						MessageBox.Show("Выберите фигуру", "Ошибка", MessageBoxButtons.OK);
					}
				}
			}
			lightFalseOval();
			Array.Clear(_CorXO, 0, 50);
			Array.Clear(_CorYO, 0, 50);
			CordsO = 0;

		}

		private void buttonRemSolo_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < ellipseScore;i++)				//проверка на выделенную фигуру
			{
				if (true == _figures[i].Highlighted)									 //круг
				{
					for (int j = i; j < ellipseScore; j++) 
					{
						_figures[j] = _figures[j + 1];
					}
					ellipseScore--;                          //для удаления последнего элемента
					i--;

					this.Refresh();
				}
			}
			for (int i = 0; i < SqScore;i++)					//проверка на выделенную фигуру
			{
				if (true == _figuresSq[i].Highlighted)								  //квадрат
				{
					for (int j = i; j < SqScore; j++)
					{
						_figuresSq[j] = _figuresSq[j + 1];
					}

					SqScore--;                               //для удаления последнего элемента
					i--;

					this.Refresh();
				}
			}
			for (int i = 0; i < LineScore;i++)				    //проверка на выделенную фигуру
			{
				if (true == _figuresLine[i].Highlighted)								//линия
				{
					for (int j = i; j < LineScore; j++)
					{
						_figuresLine[j] = _figuresLine[j + 1];
					}

					LineScore--;                             //для удаления последнего элемента
					i--;

					this.Refresh();
				}
			}
			for (int i = 0; i < RingScore; i++)					//проверка на выделенную фигуру
			{
				if (true == _figuresRing[i].Highlighted)							   //кольцо
				{
					for (int j = i; j < RingScore; j++)
					{
						_figuresRing[j] = _figuresRing[j + 1];
					}

					RingScore--;                             //для удаления последнего элемента
					i--;

					this.Refresh();
				}
			}
			for (int i = 0; i < SEScore; i++)					//проверка на выделенную фигуру
			{
				if (true == _figuresSE[i].Highlighted)									   //SE
				{
					for (int j = i; j < SEScore; j++)
					{
						_figuresSE[j] = _figuresSE[j + 1];
					}

					SEScore--;                               //для удаления последнего элемента
					i--;

					this.Refresh();
				}
			}
			for (int i = 0; i < OvalScore; i++)                   //проверка на выделенную фигуру
			{
				if (true == _figuresOval[i].Highlighted)                                     //SE
				{
					for (int j = i; j < OvalScore; j++)
					{
						_figuresOval[j] = _figuresOval[j + 1];
					}

					OvalScore--;                               //для удаления последнего элемента
					i--;

					this.Refresh();
				}
			}
			for (int i = 0; i < RombScore; i++)                   //проверка на выделенную фигуру
			{
				if (true == _figuresRomb[i].Highlighted)                                     //SE
				{
					for (int j = i; j < RombScore; j++)
					{
						_figuresRomb[j] = _figuresRomb[j + 1];
					}

					RombScore--;                               //для удаления последнего элемента
					i--;

					this.Refresh();
				}
			}
			for (int i = 0; i < QuScore; i++)                   //проверка на выделенную фигуру
			{
				if (true == _figuresQu[i].Highlighted)                                     //SE
				{
					for (int j = i; j < QuScore; j++)
					{
						_figuresQu[j] = _figuresQu[j + 1];
					}

					QuScore--;                               //для удаления последнего элемента
					i--;

					this.Refresh();
				}
			}

			lightFalseEl();
			lightFalseSq();
			lightFalseL();
			lightFalseR();
			lightFalseSE();
			lightFalseOval();
			lightFalseRomb();
			lightFalseQu();

			Array.Clear(_CorX, 0, 50);
			Array.Clear(_CorY, 0, 50);
			Cords = 0;
			lightFalseOval();
			Array.Clear(_CorXO, 0, 50);
			Array.Clear(_CorYO, 0, 50);
			CordsO = 0;
		}

		private void buttonRE_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < ellipseScore; i++)
			{
				_figures[i] = null;
				
			}
            ellipseScore = 0;

			Array.Clear(_CorX, 0, 50);
			Array.Clear(_CorY, 0, 50);
			Cords = 0;

			lightFalseEl();
			lightFalseSq();
			lightFalseL();
			lightFalseR();
			lightFalseSE();
			lightFalseOval();
			lightFalseRomb();
			lightFalseQu();

			this.Refresh();
			MessageBox.Show("Фигуры удалены", "удаление фигуры", MessageBoxButtons.OK);

		}

		private void buttonRS_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < SqScore; i++)
			{
				_figuresSq[i]=null;			
			}
			SqScore = 0;

			lightFalseEl();
			lightFalseSq();
			lightFalseL();
			lightFalseR();
			lightFalseSE();
			lightFalseOval();
			lightFalseRomb();
			lightFalseQu();

			this.Refresh();
			MessageBox.Show("Фигуры удалены", "удаление фигуры", MessageBoxButtons.OK);
		}

		private void buttonRL_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < LineScore; i++)
			{
				_figuresLine[i] = null;
			}
			LineScore = 0;

			lightFalseEl();
			lightFalseSq();
			lightFalseL();
			lightFalseR();
			lightFalseSE();
			lightFalseOval();
			lightFalseRomb();
			lightFalseQu();

			this.Refresh();
			MessageBox.Show("Фигуры удалены", "удаление фигуры", MessageBoxButtons.OK);
		}

        private void buttonRR_Click(object sender, EventArgs e)
        {
			for (int i = 0; i < RingScore; i++)
			{
				_figuresRing[i] = null;
			}
			RingScore = 0;

			lightFalseEl();
			lightFalseSq();
			lightFalseL();
			lightFalseR();
			lightFalseSE();
			lightFalseOval();
			lightFalseRomb();
			lightFalseQu();

			this.Refresh();
			MessageBox.Show("Фигуры удалены", "удаление фигуры", MessageBoxButtons.OK);
		}

        private void buttonRSE_Click(object sender, EventArgs e)
        {
			for (int i = 0; i < SEScore; i++)
			{
				_figuresSE[i] = null;
			}
			SEScore = 0;

			lightFalseEl();
			lightFalseSq();
			lightFalseL();
			lightFalseR();
			lightFalseSE();
			lightFalseOval();
			lightFalseRomb();
			lightFalseQu();

			this.Refresh();
			MessageBox.Show("Фигуры удалены", "удаление фигуры", MessageBoxButtons.OK);
		}

        private void buttonRO_Click(object sender, EventArgs e)
        {
			for (int i = 0; i < OvalScore; i++)
			{
				_figuresOval[i] = null;
			}
			OvalScore = 0;

			lightFalseEl();
			lightFalseSq();
			lightFalseL();
			lightFalseR();
			lightFalseSE();
			lightFalseOval();
			lightFalseRomb();
			lightFalseQu();

			this.Refresh();
			MessageBox.Show("Фигуры удалены", "удаление фигуры", MessageBoxButtons.OK);

		}
		private void buttonRRomb_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < RombScore; i++)
			{
				_figuresRomb[i] = null;
			}
			RombScore = 0;

			lightFalseEl();
			lightFalseSq();
			lightFalseL();
			lightFalseR();
			lightFalseSE();
			lightFalseOval();
			lightFalseRomb();
			lightFalseQu();

			this.Refresh();
			MessageBox.Show("Фигуры удалены", "удаление фигуры", MessageBoxButtons.OK);

		}

        private void buttonRQ_Click(object sender, EventArgs e)
        {
			for (int i = 0; i < QuScore; i++)
			{
				_figuresQu[i] = null;
			}
			QuScore = 0;

			lightFalseEl();
			lightFalseSq();
			lightFalseL();
			lightFalseR();
			lightFalseSE();
			lightFalseOval();
			lightFalseRomb();
			lightFalseQu();

			this.Refresh();
			MessageBox.Show("Фигуры удалены", "удаление фигуры", MessageBoxButtons.OK);
		}
    }
}