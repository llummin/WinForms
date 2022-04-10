using System;
using System.Drawing;
using System.Windows.Forms;

namespace test_2
{

	public partial class Form1 : Form
	{
		Ellipse[] _figures = new Ellipse[50];											 //круг
		Polygon[] _figuresSq = new Polygon[50];										  //квадрта
		Line[] _figuresLine = new Line[50]; 											//линия

		//счётчик общий массива----------------------------------------------------------------
		public int ellipseScore = 0;
		public int SqScore = 0;
		public int LineScore = 0;
		//-------------------------------------------------------------------------------------
		private Ellipse _figureToMove;													 //круг
		private Polygon _figureToMoveSq;											  //квадрат
		private Line _figureToMoveLine;													//линия
		//-------------------------------------------------------------------------------------

		//private Ellipse _figurePlusSize;

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
		//-------------------------------------------------------------------------------------
		void MainForm_MouseClick(object sender, MouseEventArgs e)
		{
			Ellipse f = DefinitionEl(e);
			Polygon k = DefinitionSq(e);
			Line b = DefinitionL(e);

			if (f == null && k == null && b == null)						//выделение объекта
			{
				lightFalseEl();															 //круг
				lightFalseSq();														  //квадрат
				lightFalseL();															//линия

				Array.Clear(_CorX,0,50);
				Array.Clear(_CorY,0,50);
				Cords = 0;

				return;
			}
			else if (f != null)
			{                                            
				lightFalseSq();
				lightFalseL();
				//_figurePlusSize = f;

		//------------------------------------------------------------------------------костыль
				//_figurePlusSize.Move(e.X - _startPoint.X, e.Y - _startPoint.Y);

				_CorX[Cords] = e.X;                                         //добавление в массив
                _CorY[Cords] = e.Y;
				Cords++;

				f.Highlighted = true;
			}
			else if (k != null)
			{                                            
				lightFalseEl();
				lightFalseL();

				Array.Clear(_CorX, 0, 50);
				Array.Clear(_CorY, 0, 50);
				Cords = 0;

				k.Highlighted = true;
			}
			else if (b != null)
			{                                            
				lightFalseEl();
				lightFalseSq();

				Array.Clear(_CorX, 0, 50);
				Array.Clear(_CorY, 0, 50);
				Cords = 0;

				b.Highlighted = true;
			}
		}
		//---------------------------------------------------------------------------------------
		void MainForm_MouseUp(object sender, MouseEventArgs e)
		{
			_figureToMove = null;
			_figureToMoveSq = null;
			_figureToMoveLine = null;

			Cursor = Cursors.Default;
			this.Refresh();
		}
		//---------------------------------------------------------------------------------------
		
		void MainForm_MouseDown(object sender, MouseEventArgs e)
		{
			_figureToMove = DefinitionEl(e);
			_figureToMoveSq = DefinitionSq(e);
			_figureToMoveLine = DefinitionL(e);

			if (_figureToMove == null && _figureToMoveSq == null && _figureToMoveLine == null)
			{
				return;
			}
			else if (_figureToMove != null)
			{                                            
                lightFalseSq();
				lightFalseL();

				_figureToMove.Highlighted = true;
				_startPoint = e.Location;
			}
			else if (_figureToMoveSq != null)
			{                                            
				lightFalseEl();
				lightFalseL();
				
				_figureToMoveSq.Highlighted = true;
				_startPoint = e.Location;
			}
			else if (_figureToMoveLine != null)
			{                                            
				lightFalseEl();
				lightFalseSq();

				_figureToMoveLine.Highlighted = true;
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
		void MainForm_MouseMove(object sender, MouseEventArgs e)
		{
			switch (e.Button)
			{
				case MouseButtons.None:
					Cursor = FindSov(_figures, e) ?
						Cursors.Hand : Cursors.Default;
					break;

				case MouseButtons.Left:                         //перемещение одной фигуры

					if (_figureToMove == null && _figureToMoveSq == null && _figureToMoveLine == null)
					{
						return;
					}
					else if (_figureToMove != null)                                 //круг
					{
						_figureToMove.Move(e.X - _startPoint.X, e.Y - _startPoint.Y);
						_startPoint = e.Location;

						//снятие выделениея
						lightFalseEl();
						lightFalseSq();
						lightFalseL();
						// при перемещении и очистка списков
						Array.Clear(_CorX, 0, 50);
						Array.Clear(_CorY, 0, 50);
						Cords = 0;

					}
					else if (_figureToMoveSq != null)                            //квадрат
					{
						_figureToMoveSq.Move(e.X - _startPoint.X, e.Y - _startPoint.Y);
						_startPoint = e.Location;

						lightFalseEl();
						lightFalseSq();
						lightFalseL();

					}
					else if (_figureToMoveLine != null)                            //линия
					{
						_figureToMoveLine.Move(e.X - _startPoint.X, e.Y - _startPoint.Y);
						_startPoint = e.Location;

						lightFalseEl();
						lightFalseSq();
						lightFalseL();

					}
					break;

				case MouseButtons.Right:                        //перемещение класса фигур
					if (_figureToMove == null && _figureToMoveSq == null && _figureToMoveLine == null)
					{
						return;
					}
					else if (_figureToMove != null)                                 //круг
					{
						AllE(sender, e);
					}
					else if (_figureToMoveSq != null)                            //квадрат
					{
						AllS(sender, e);
					}
					else if (_figureToMoveLine != null)                              //линия
					{
						AllL(sender, e);

					}
					break;

			}
		}

		void MainForm_Paint(object sender, PaintEventArgs e)         //обновление на форме
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

		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			this.Refresh();
		}

		public void size1_Click(object sender, EventArgs e)               //создание круга
		{

			Graphics t = CreateGraphics();

			int Size = 0;

			if (textBox1.Text != "sizeEllips" && textBox1.Text != "")
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
			if ((textBox5.Text != "x" && textBox5.Text != "") && (textBox6.Text != "y" && textBox6.Text != "")) 
			{
				if (int.TryParse(textBox5.Text, out CordX) && int.TryParse(textBox6.Text, out CordY))
				{
					_figures[ellipseScore].Move(CordX, CordY);
				}
			}

			for (int i = 0; i <= ellipseScore; i++)                //обновление на форме
			{       //костыль т.к не смог создать переменную подходящую под PaintEventArgs
				_figures[i].Fill(t);
				_figures[i].Draw(t);
			}

			ellipseScore++;
		}

		private void size2_Click(object sender, EventArgs e)           //создание квадрата
		{
			Graphics l = CreateGraphics();

			int SizeSq = 0;

			if (textBox2.Text != "sizeSquar" && textBox2.Text != "")
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
			if ((textBox5.Text != "x" && textBox5.Text != "") && (textBox6.Text != "y" && textBox6.Text != ""))
			{
				if (int.TryParse(textBox5.Text, out CordX) && int.TryParse(textBox6.Text, out CordY))
				{
					_figuresSq[SqScore].Move(CordX, CordY);
				}
			}
			for (int i = 0; i <= SqScore; i++)              //обновление на форме
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

			if (textBox3.Text != "sizeLine" && textBox3.Text != "")
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
			if ((textBox5.Text != "x" && textBox5.Text != "") && (textBox6.Text != "y" && textBox6.Text != ""))
			{
				if (int.TryParse(textBox5.Text, out CordX) && int.TryParse(textBox6.Text, out CordY))
				{
					_figuresLine[LineScore].Move(CordX, CordY);
				}
			}
			for (int i = 0; i <= LineScore; i++)               //обновление на форме
			{
				_figuresLine[LineScore].Fill(o);
				_figuresLine[LineScore].Draw(o);
			}
			LineScore++;

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
			for (int i = 0; i < ellipseScore;i++)     //проверка на выделенную фигуру
			{
				if (true == _figures[i].Highlighted)								//круг
				{
					for (int j = i; j < ellipseScore; j++) 
					{
						_figures[j] = _figures[j + 1];
					}
					ellipseScore--;                               //для удаления последнего элемента
					i--;

					this.Refresh();
				}
			}
			for (int i = 0; i < SqScore;i++)   //проверка на выделенную фигуру
			{
				if (true == _figuresSq[i].Highlighted)							 //квадрат
				{
					for (int j = i; j < SqScore; j++)
					{
						_figuresSq[j] = _figuresSq[j + 1];
					}

					SqScore--;                                //для удаления последнего элемента
					i--;

					this.Refresh();
				}
			}
			for (int i = 0; i < LineScore;i++)  //проверка на выделенную фигуру
			{
				if (true == _figuresLine[i].Highlighted)                           //линия
				{
					for (int j = i; j < LineScore; j++)
					{
						_figuresLine[j] = _figuresLine[j + 1];
					}

					LineScore--;                                //для удаления последнего элемента
					i--;

					this.Refresh();
				}
			}
			lightFalseEl();
			lightFalseSq();
			lightFalseL();
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

			this.Refresh();
			MessageBox.Show("Фигуры удалены", "удаление фигуры", MessageBoxButtons.OK);
		}
	}
}