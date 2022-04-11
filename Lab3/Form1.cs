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

		//счётчик общий массива----------------------------------------------------------------
		public int ellipseScore = 0;
		public int SqScore = 0;
		public int LineScore = 0;
		public int RingScore = 0;
		public int SEScore = 0;
		//-------------------------------------------------------------------------------------
		private Ellipse _figureToMove;													 //круг
		private Polygon _figureToMoveSq;											  //квадрат
		private Line _figureToMoveLine;                                                 //линия
		private Ring _figureToMoveRing;												   //кольцо
		private SE _figureToMoveSE;														   //SE
		//-------------------------------------------------------------------------------------

		private Point _startPoint;

		//-------Координаты для появления фигуры-----------------------------------------------
		int[] _CorX = new int[50];
		int[] _CorY = new int[50];
		int Cords = 0;
		int CordX = 0;
		int CordY = 0;
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
		//-------------------------------------------------------------------------------------
		void MainForm_MouseClick(object sender, MouseEventArgs e)
		{
			Ellipse f = DefinitionEl(e);
			Polygon k = DefinitionSq(e);
			Line b = DefinitionL(e);
			Ring r = DefinitionR(e);
			SE sqre = DefinitionSE(e);

			if (f == null && k == null && b == null && r == null && sqre == null)//выделение объекта
			{
				lightFalseEl();															 //круг
				lightFalseSq();														  //квадрат
				lightFalseL();                                                          //линия
				lightFalseR();														   //кольцо
				lightFalseSE();															   //SE

				Array.Clear(_CorX,0,50);
				Array.Clear(_CorY,0,50);
				Cords = 0;

				return;
			}
			else if (f != null)
			{                                            
				lightFalseSq();
				lightFalseL();
				lightFalseR();
				lightFalseSE();

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

				Array.Clear(_CorX, 0, 50);
				Array.Clear(_CorY, 0, 50);
				Cords = 0;

				k.Highlighted = true;
			}
			else if (b != null)
			{                                            
				lightFalseEl();
				lightFalseSq();
				lightFalseR();
				lightFalseSE();

				Array.Clear(_CorX, 0, 50);
				Array.Clear(_CorY, 0, 50);
				Cords = 0;

				b.Highlighted = true;
			}
			else if (r != null)
			{
				lightFalseEl();
				lightFalseSq();
				lightFalseL();
				lightFalseSE();

				Array.Clear(_CorX, 0, 50);
				Array.Clear(_CorY, 0, 50);
				Cords = 0;

				r.Highlighted = true;
			}
			else if (sqre != null)
			{
				lightFalseEl();
				lightFalseSq();
				lightFalseL();
				lightFalseR();

				Array.Clear(_CorX, 0, 50);
				Array.Clear(_CorY, 0, 50);
				Cords = 0;

				sqre.Highlighted = true;
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


			if (_figureToMove == null && _figureToMoveSq == null && _figureToMoveLine == null && _figureToMoveRing == null && _figureToMoveSE == null)
			{
				return;
			}
			else if (_figureToMove != null)
			{                                            
                lightFalseSq();
				lightFalseL();
				lightFalseR();
				lightFalseSE();

				_figureToMove.Highlighted = true;
				_startPoint = e.Location;
			}
			else if (_figureToMoveSq != null)
			{                                            
				lightFalseEl();
				lightFalseL();
				lightFalseR();
				lightFalseSE();

				_figureToMoveSq.Highlighted = true;
				_startPoint = e.Location;
			}
			else if (_figureToMoveLine != null)
			{                                            
				lightFalseEl();
				lightFalseSq();
				lightFalseR();
				lightFalseSE();

				_figureToMoveLine.Highlighted = true;
				_startPoint = e.Location;
			}
			else if (_figureToMoveRing != null)
			{
				lightFalseEl();
				lightFalseSq();
				lightFalseL();
				lightFalseSE();

				_figureToMoveRing.Highlighted = true;
				_startPoint = e.Location;
			}
			else if (_figureToMoveSE != null)
			{
				lightFalseEl();
				lightFalseSq();
				lightFalseL();
				lightFalseR();

				_figureToMoveSE.Highlighted = true;
				_startPoint = e.Location;
			}
		}
		//---------------------------------------------------------------------------------------
		void AllE(object sender, MouseEventArgs e)
        {
			for(int i = 0; i < ellipseScore;i++)
            {
				_figures[i].Move(e.X - _startPoint.X, e.Y - _startPoint.Y);
				this.Refresh();
			}
			_startPoint = e.Location;
		}
		void AllS(object sender, MouseEventArgs e)
		{
			for (int i = 0; i < SqScore; i++)
			{
				_figuresSq[i].Move(e.X - _startPoint.X, e.Y - _startPoint.Y);
				this.Refresh();
			}
			_startPoint = e.Location;
		}
		void AllL(object sender, MouseEventArgs e)
		{
			for (int i = 0; i < LineScore; i++)
			{
				_figuresLine[i].Move(e.X - _startPoint.X, e.Y - _startPoint.Y);
				this.Refresh();
			}
			_startPoint = e.Location;
		}
		void AllR(object sender, MouseEventArgs e)
		{
			for (int i = 0; i < RingScore; i++)
			{
				_figuresRing[i].Move(e.X - _startPoint.X, e.Y - _startPoint.Y);
				this.Refresh();
			}
			_startPoint = e.Location;
		}
		void AllSE(object sender, MouseEventArgs e)
		{
			for (int i = 0; i < SEScore; i++)
			{
				_figuresSE[i].Move(e.X - _startPoint.X, e.Y - _startPoint.Y);
				this.Refresh();
			}
			_startPoint = e.Location;
		}
		//-------------------------------------------------------------------------------------
		void MainForm_MouseMove(object sender, MouseEventArgs e)
		{
			switch (e.Button)
			{
				case MouseButtons.None:
					Cursor = FindSov(_figures, e) ?
						Cursors.Hand : Cursors.Default;
					break;

				case MouseButtons.Left:								 //перемещение одной фигуры

					if (_figureToMove == null && _figureToMoveSq == null && _figureToMoveLine == null && _figureToMoveRing == null && _figureToMoveSE == null)
					{
						return;
					}
					else if (_figureToMove != null)										 //круг
					{
						_figureToMove.Move(e.X - _startPoint.X, e.Y - _startPoint.Y);
						_startPoint = e.Location;

						//снятие выделениея
						lightFalseEl();
						lightFalseSq();
						lightFalseL();
						lightFalseR();
						lightFalseSE();
						// при перемещении и очистка списков
						Array.Clear(_CorX, 0, 50);
						Array.Clear(_CorY, 0, 50);
						Cords = 0;

					}
					else if (_figureToMoveSq != null)								  //квадрат
					{
						_figureToMoveSq.Move(e.X - _startPoint.X, e.Y - _startPoint.Y);
						_startPoint = e.Location;

						lightFalseEl();
						lightFalseSq();
						lightFalseL();
						lightFalseR();
						lightFalseSE();
					}
					else if (_figureToMoveLine != null)								    //линия
					{
						_figureToMoveLine.Move(e.X - _startPoint.X, e.Y - _startPoint.Y);
						_startPoint = e.Location;

						lightFalseEl();
						lightFalseSq();
						lightFalseL();
						lightFalseR();
						lightFalseSE();
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
					}
					break;

				case MouseButtons.Right:                             //перемещение класса фигур
					if (_figureToMove == null && _figureToMoveSq == null && _figureToMoveLine == null && _figureToMoveRing == null && _figureToMoveSE == null)
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
					break;
			}
		}

		void MainForm_Paint(object sender, PaintEventArgs e)              //обновление на форме
		{
			for (int i = 0; i < ellipseScore; i++)
			{
				_figures[i].Fill(e.Graphics);
				_figures[i].Draw(e.Graphics);
			}

			for (int i = 0; i < SqScore; i++)
			{
				_figuresSq[i].Fill(e.Graphics);
				_figuresSq[i].Draw(e.Graphics);
			}

			for (int i = 0; i < LineScore; i++)
			{
				_figuresLine[i].Fill(e.Graphics);
				_figuresLine[i].Draw(e.Graphics);
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

					_figures[ellipseScore] = (new Ellipse(Rectangle.FromLTRB(0, 0, Size, Size)));
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
					MessageBox.Show("Фигура создана", "Создание фигуры", MessageBoxButtons.OK);
				}
				else
				{
					MessageBox.Show("Введите число", "Ошибка", MessageBoxButtons.OK);
				}
			}

			for (int i = 0; i <= ellipseScore; i++)                       //обновление на форме
			{            //костыль т.к не смог создать переменную подходящую под PaintEventArgs
				_figures[i].Fill(t);
				_figures[i].Draw(t);
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

					_figuresSq[SqScore]=(new Polygon(new[]
					{
						new Point(0,0),
						new Point(SizeSq,0),
						new Point(SizeSq,SizeSq),
  						new Point(0,SizeSq)
					}));
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
					MessageBox.Show("Фигура создана", "Создание фигуры", MessageBoxButtons.OK);
				}
				else
				{
					MessageBox.Show("Введите число", "Ошибка", MessageBoxButtons.OK);
				}
			}
			for (int i = 0; i <= SqScore; i++)							  //обновление на форме
			{
				_figuresSq[i].Fill(l);
				_figuresSq[i].Draw(l);
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

					_figuresLine[LineScore]= (new Line(new[]
					{
						new Point(0,0),
						new Point(SizeLine,SizeLine),
						new Point(SizeLine-10,SizeLine+10),
						new Point(0-10,0+10)
					}));
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
					_figuresLine[SqScore] = (new Line(CordX, CordY, SizeLine));
					MessageBox.Show("Фигура создана", "Создание фигуры", MessageBoxButtons.OK);
				}
				else
				{
					MessageBox.Show("Введите число", "Ошибка", MessageBoxButtons.OK);
				}
			}
			for (int i = 0; i <= LineScore; i++)						  //обновление на форме
			{
				_figuresLine[LineScore].Fill(o);
				_figuresLine[LineScore].Draw(o);
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
					///Size = System.Convert.ToInt32(textBox7.Text);

					_figuresRing[RingScore] = (new Ring(
						new Ellipse(Rectangle.FromLTRB(Size - Size / 2, Size - Size / 2, Size + Size / 2, Size + Size / 2)),
						new Ellipse(Rectangle.FromLTRB(Size - ((Size-25) / 2), Size - ((Size-25) / 2), Size + ((Size-25) / 2), Size + ((Size-25) / 2)))));
					MessageBox.Show("Фигура создана", "Создание фигуры", MessageBoxButtons.OK);
				}
				else
				{
					MessageBox.Show("Введите число", "Ошибка", MessageBoxButtons.OK);
				}
			}
			else if (textBox7.Text == "sizeRing" || textBox7.Text == "")
			{
				_figuresRing[RingScore] = (new Ring(new Ellipse(), new Ellipse(20)));
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
					_figuresRing[RingScore] = (new Ring(new Ellipse(CordX, CordY, Size), new Ellipse(CordX, CordY, Size-25)));
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
					///Size = System.Convert.ToInt32(textBox7.Text);

					_figuresSE[SEScore] = (new SE(
						new Polygon(new[]
					{
						new Point(0,0),
						new Point(Size,0),
						new Point(Size,Size),
  						new Point(0,Size)
					}),
						new Ellipse(_reSE)));
					MessageBox.Show("Фигура создана", "Создание фигуры", MessageBoxButtons.OK);
				}
				else
				{
					MessageBox.Show("Введите число", "Ошибка", MessageBoxButtons.OK);
				}
			}
			else if (textBox8.Text == "sizeSE" || textBox8.Text == "")
			{
				_figuresSE[SEScore] = (new SE(new Polygon(), new Ellipse(COST)));
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
					Size = System.Convert.ToInt32(textBox8.Text);
					_figuresSE[SEScore] = (new SE(new Polygon(CordX, CordY, Size), new Ellipse(CordX, CordY, Size)));
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
							_figures[i]= new Ellipse(Rectangle.FromLTRB(0, 0, SizeR, SizeR));
							_figures[i].Move(_CorX[j] - (SizeR / 2), _CorY[j] - (SizeR / 2));

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

			lightFalseEl();
			lightFalseSq();
			lightFalseL();
			lightFalseR();
			lightFalseSE();

			Array.Clear(_CorX, 0, 50);
			Array.Clear(_CorY, 0, 50);
			Cords = 0;
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

			this.Refresh();
			MessageBox.Show("Фигуры удалены", "Удаление фигуры", MessageBoxButtons.OK);
		}
    }
}