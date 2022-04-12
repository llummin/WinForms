using System;
using System.Drawing;
using System.Windows.Forms;

namespace test_2
{
	public partial class Form1 : Form
	{
        readonly Figures[] _FiguresAll = new Figures[50]; //объявление массива
        readonly Random rnd = new Random();
		//счётчик общий массива----------------------------------------------------------------
		public int FiguresAllScore = 0;
		//-------------------------------------------------------------------------------------
		public Form1()
		{
			InitializeComponent();
			DoubleBuffered = true;

			Paint += MainForm_Paint;

			KeyDown += PressKey;
		}
		//-------------------------------------------------------------------------------------
		void MainForm_Paint(object sender, PaintEventArgs e)              //обновление на форме
		{
			for (int i = 0; i < FiguresAllScore; i++)
			{
				if (_FiguresAll[i].Visible)
				{
					_FiguresAll[i].Fill(e.Graphics, _FiguresAll[i].Brush ?? Brushes.Yellow);
					_FiguresAll[i].Draw(e.Graphics, _FiguresAll[i].Pen ?? Pens.Black);
				}
			}
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			this.Refresh();
		}
		void RandCord(Graphics g)
		{

			if (_FiguresAll[FiguresAllScore] is Ellipse || _FiguresAll[FiguresAllScore] is Oval)
			{
				_FiguresAll[FiguresAllScore].Move(rnd.Next(0, 900), rnd.Next(0, 500), g, 1);
			}
			else
			{
				_FiguresAll[FiguresAllScore].Move(rnd.Next(0, 900), rnd.Next(0, 500), g, 2);
			}
		}
		private void Creat_Click(object sender, EventArgs e)
		{
			Graphics t = CreateGraphics();

			for (int OGO = 0; OGO < 13; OGO++)
			{
				switch (rnd.Next(0, 6))
				{
					case 0:

						_FiguresAll[FiguresAllScore] = (new Ellipse());
						_FiguresAll[FiguresAllScore].Creat();
						

						for (int i = 0; i <= FiguresAllScore; i++)                      
						{            
							_FiguresAll[i].Fill(t, _FiguresAll[i].Brush ?? Brushes.Yellow);
							_FiguresAll[i].Draw(t, _FiguresAll[i].Pen ?? Pens.Black);
						}
						RandCord(t);
						FiguresAllScore++;
						this.Refresh();
						break;
					case 1:

						_FiguresAll[FiguresAllScore] = (new Polygon());
						_FiguresAll[FiguresAllScore].Creat();
						

						for (int i = 0; i <= FiguresAllScore; i++)                            //обновление на форме
						{
							_FiguresAll[i].Fill(t, _FiguresAll[i].Brush ?? Brushes.Yellow);
							_FiguresAll[i].Draw(t, _FiguresAll[i].Pen ?? Pens.Black);
						}

						RandCord(t);
						FiguresAllScore++;
						this.Refresh();
						break;
					case 2:

						_FiguresAll[FiguresAllScore] = (new Line());
						_FiguresAll[FiguresAllScore].Creat();
						

						for (int i = 0; i <= FiguresAllScore; i++)                          //обновление на форме
						{
							_FiguresAll[i].Fill(t, _FiguresAll[i].Brush ?? Brushes.Yellow);
							_FiguresAll[i].Draw(t, _FiguresAll[i].Pen ?? Pens.Black);
						}

						RandCord(t);
						FiguresAllScore++;
						this.Refresh();
						break;
					case 3:

						_FiguresAll[FiguresAllScore] = (new Oval());
						_FiguresAll[FiguresAllScore].Creat();


						for (int i = 0; i <= FiguresAllScore; i++)                       //обновление на форме
						{            //костыль т.к не смог создать переменную подходящую под PaintEventArgs
							_FiguresAll[i].Fill(t, _FiguresAll[i].Brush ?? Brushes.Yellow);
							_FiguresAll[i].Draw(t, _FiguresAll[i].Pen ?? Pens.Black);
						}

						RandCord(t);
						FiguresAllScore++;
						this.Refresh();
						break;
					case 4:
						_FiguresAll[FiguresAllScore] = (new Romb());
						_FiguresAll[FiguresAllScore].Creat();

						for (int i = 0; i <= FiguresAllScore; i++)                            //обновление на форме
						{
							_FiguresAll[i].Fill(t, _FiguresAll[i].Brush ?? Brushes.Yellow);
							_FiguresAll[i].Draw(t, _FiguresAll[i].Pen ?? Pens.Black);
						}

						RandCord(t);
						FiguresAllScore++;
						this.Refresh();
						break;
					case 5:
						_FiguresAll[FiguresAllScore] = (new Quadrilateral());
						_FiguresAll[FiguresAllScore].Creat();


						for (int i = 0; i <= FiguresAllScore; i++)                            //обновление на форме
						{
							_FiguresAll[i].Fill(t, _FiguresAll[i].Brush ?? Brushes.Yellow);
							_FiguresAll[i].Draw(t, _FiguresAll[i].Pen ?? Pens.Black);
						}

						RandCord(t);
						FiguresAllScore++;
						this.Refresh();
						break;
				}	
			}
			this.Refresh();
			MessageBox.Show("Фигура создана", "Создание фигуры", MessageBoxButtons.OK);
		}

		private void Swap_Click(object sender, EventArgs e)
		{

			Graphics h = CreateGraphics();
			int _x, _y, _w, _h;

			for (int i = 0; i < FiguresAllScore; i++)     //проверка на выделенную фигуру
			{
				if (_FiguresAll[i] is Oval)
				{
					Rectangle _rect = _FiguresAll[i].GetRectangle();
					_x = _FiguresAll[i].GetX();
					_y = _FiguresAll[i].GetY();
					_w = _FiguresAll[i].GetW();
					_h = _FiguresAll[i].GetH();

					if (_FiguresAll[i] is Oval) 
					{
						_FiguresAll[i].GetRectangle();
						if (_FiguresAll[i].GetRectangle().Width > _FiguresAll[i].GetRectangle().Height)
						{
							(_FiguresAll[i] as Oval).Swap(_x, _y, _w, _h, 1);

							_FiguresAll[i].Creat(_FiguresAll[i].GetRectangle());
							_FiguresAll[i].Move(_rect.X - (_w / 2), _rect.Y - (_w / 2), h, 1);
						}
						else if (_FiguresAll[i].GetRectangle().Width < _FiguresAll[i].GetRectangle().Height)
						{
							(_FiguresAll[i] as Oval).Swap(_x, _y, _w, _h, 2);
							_FiguresAll[i].Creat(_FiguresAll[i].GetRectangle());
							_FiguresAll[i].Move(_rect.X - (_w / 2), _rect.Y - (_w / 2), h, 1);
						}
					}

					this.Refresh();                                     //обновление формы
					MessageBox.Show("Фигура изменена", "Изменение фигуры", MessageBoxButtons.OK);
				}

			}
		}

		private void buttonRE_Click(object sender, EventArgs e)//удаление
		{
			for (int i = 0; i < FiguresAllScore; i++)
			{
				_FiguresAll[i] = null;

			}
			FiguresAllScore = 0;

			this.Refresh();
			MessageBox.Show("Фигуры удалены", "удаление фигуры", MessageBoxButtons.OK);

		}

        private void button1_Click(object sender, EventArgs e)//стирание
        {
			Graphics g=CreateGraphics();
			Dele(g);
			INAN(false);

		}
		private void Dele(Graphics g)//полное стиранеи
		{
			Color color = Color.FromName("White");
			g.Clear(color);
		}

        private void button2_Click(object sender, EventArgs e)//показ
        {
			INAN(true);
		}
		private void INAN(bool CH) //сравнение
		{
			if (comboBox1.SelectedItem == null)
			{
				MessageBox.Show("Значение не выбрано", "Выбор", MessageBoxButtons.OK);
				return;
			}
			string Indexe = comboBox1.SelectedItem.ToString();
			if (Indexe == "Круг")
			{
				for (int i = 0; i < FiguresAllScore; i++)
				{
					if (_FiguresAll[i] is Ellipse && !(_FiguresAll[i] is Oval))
					{
						(_FiguresAll[i] as Ellipse).Visible = CH;
					}
					this.Refresh();
				}
			}
			else if (Indexe == "Квадрат")
			{
				for (int i = 0; i < FiguresAllScore; i++)
				{
					if (_FiguresAll[i] is Polygon && !(_FiguresAll[i] is Romb) && !(_FiguresAll[i] is Quadrilateral))
					{
						(_FiguresAll[i] as Polygon).Visible = CH;
					}
					this.Refresh();
				}
			}
			else if (Indexe == "Линия")
			{
				for (int i = 0; i < FiguresAllScore; i++)
				{
					if (_FiguresAll[i] is Line)
					{
						(_FiguresAll[i] as Line).Visible = CH;
					}
					this.Refresh();
				}
			}
			else if (Indexe == "Ромб")
			{
				for (int i = 0; i < FiguresAllScore; i++)
				{
					if (_FiguresAll[i] is Romb)
					{
						(_FiguresAll[i] as Romb).Visible = CH;
					}
					this.Refresh();
				}
			}
			else if (Indexe == "Прямоугольник")
			{
				for (int i = 0; i < FiguresAllScore; i++)
				{
					if (_FiguresAll[i] is Quadrilateral)
					{
						(_FiguresAll[i] as Quadrilateral).Visible = CH;
					}
					this.Refresh();
				}
			}
			else if (Indexe == "Овал")
			{
				for (int i = 0; i < FiguresAllScore; i++)
				{
					if (_FiguresAll[i] is Oval)
					{
						(_FiguresAll[i] as Oval).Visible = CH;
					}
					this.Refresh();
				}
			}
		}

        private void button4_Click(object sender, EventArgs e)//стиранеи всех
        {
			Graphics g = CreateGraphics();
			Dele(g);
			for (int i = 0; i < FiguresAllScore; i++) 
			{
				_FiguresAll[i].Visible = false;
			}
			this.Refresh();
        }

			private void button5_Click(object sender, EventArgs e)//показ всех
			{

				for (int i = 0; i < FiguresAllScore; i++)
				{
					_FiguresAll[i].Visible = true;
				}
				this.Refresh();
			}

			private void button3_Click(object sender, EventArgs e)//базовая точка для класса
			{
				Graphics g = CreateGraphics();
				if (comboBox1.SelectedItem == null) 
				{
					MessageBox.Show("Значение не выбрано", "Выбор", MessageBoxButtons.OK);
					return;
				}
				//оператор is – проверяет, совпадает ли тип выражения с заданным типом данных;
				//оператор as – предназначен для избежания возникновения исключительной ситуации в случае неудачного приведения типов;
				string Indexe = comboBox1.SelectedItem.ToString();
				if (Indexe == "Круг")
				{
					for (int i = 0; i < FiguresAllScore; i++)
					{
						Rectangle _rect=_FiguresAll[i].GetRectangle();
						if (_FiguresAll[i] is Ellipse && !(_FiguresAll[i] is Oval))
						{
							(_FiguresAll[i] as Ellipse).Move(100-_rect.X, 100-_rect.Y, g, 1);
						}
						this.Refresh();
					}
				}
			
				else if (Indexe == "Квадрат")
				{
					for (int i = 0; i < FiguresAllScore; i++)
					{
						Point[] _points = _FiguresAll[i].GetPoint();
						if (_FiguresAll[i] is Polygon && !(_FiguresAll[i] is Romb) && !(_FiguresAll[i] is Quadrilateral))
						{
							(_FiguresAll[i] as Polygon).Move(200-_points[0].X, 200-_points[0].Y, g, 2);
						}
						this.Refresh();
					}
				}
				else if (Indexe == "Линия")
				{
					for (int i = 0; i < FiguresAllScore; i++)
					{
						Point[] _points = _FiguresAll[i].GetPoint();
						if (_FiguresAll[i] is Line)
						{
							(_FiguresAll[i] as Line).Move(400 - _points[0].X, 400 - _points[0].Y, g, 2);
						}
						this.Refresh();
					}
				}
				else if (Indexe == "Ромб")
				{
					for (int i = 0; i < FiguresAllScore; i++)
					{
						Point[] _points = _FiguresAll[i].GetPoint();
						if (_FiguresAll[i] is Romb)
						{
							(_FiguresAll[i] as Romb).Move(100 - _points[0].X, 400 - _points[0].Y, g, 2);
						}
						this.Refresh();
					}
				}
				else if (Indexe == "Прямоугольник")
				{
					for (int i = 0; i < FiguresAllScore; i++)
					{
						Point[] _points = _FiguresAll[i].GetPoint();
						if (_FiguresAll[i] is Quadrilateral)
						{
							(_FiguresAll[i] as Quadrilateral).Move(400 - _points[0].X, 100 - _points[0].Y, g, 2);
						}
						this.Refresh();
					}
				}
				else if (Indexe == "Овал")
				{
					for (int i = 0; i < FiguresAllScore; i++)
					{
						Rectangle _rect = _FiguresAll[i].GetRectangle();
						if (_FiguresAll[i] is Oval)
						{
							(_FiguresAll[i] as Oval).Move(500-_rect.X, 300-_rect.Y, g, 1);
						}
						this.Refresh();
					}
				}
			}

			private void button6_Click(object sender, EventArgs e)//базовая точка для всех
			{
				Graphics g = CreateGraphics();
				for (int i = 0; i < FiguresAllScore; i++)
				{
					if (_FiguresAll[i] is Ellipse || _FiguresAll[i] is Oval)
					{
						Rectangle _rect = _FiguresAll[i].GetRectangle();
						_FiguresAll[i].Move(500 - _rect.X, 500 - _rect.Y, g, 1);
						this.Refresh();
					}
					else
					{
						Point[] _points = _FiguresAll[i].GetPoint();
						_FiguresAll[i].Move(500 - _points[0].X, 500 - _points[0].Y, g, 2);
						this.Refresh();
					}
				}
			}

			private void PressKey(object sender, KeyEventArgs e)
			{

				Graphics g = CreateGraphics();

				if (e.KeyCode == Keys.Up)
				{
					for (int i = 0; i < FiguresAllScore; i++)
					{
						if (_FiguresAll[i] is Ellipse || _FiguresAll[i] is Oval)
						{
							_FiguresAll[i].Move(0,-24, g, 1);
							this.Refresh();
						}
						else
						{
							_FiguresAll[i].Move(0, -24, g, 2);
							this.Refresh();
						}
					}
				}
				else if (e.KeyCode == Keys.Down)
				{
					for (int i = 0; i < FiguresAllScore; i++)
					{
						if (_FiguresAll[i] is Ellipse || _FiguresAll[i] is Oval)
						{
							_FiguresAll[i].Move(0, 24, g, 1);
							this.Refresh();
						}
						else
						{
							_FiguresAll[i].Move(0, 24, g, 2);
							this.Refresh();
						}
					}
				}
				else if (e.KeyCode == Keys.Right)
				{
					for (int i = 0; i < FiguresAllScore; i++)
					{
						if (_FiguresAll[i] is Ellipse || _FiguresAll[i] is Oval)
						{
							_FiguresAll[i].Move(24, 0, g, 1);
							this.Refresh();
						}
						else
						{
							_FiguresAll[i].Move(24, 0, g, 2);
							this.Refresh();
						}
					}
				}
				else if (e.KeyCode == Keys.Left)
				{
					for (int i = 0; i < FiguresAllScore; i++)
					{
						if (_FiguresAll[i] is Ellipse || _FiguresAll[i] is Oval)
						{
							_FiguresAll[i].Move(-24, 0, g, 1);
							this.Refresh();
						}
						else
						{
							_FiguresAll[i].Move(-24, 0, g, 2);
							this.Refresh();
						}
					}
				}
			}
		}
	}