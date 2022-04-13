using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
namespace test_2
{
	class Array
	{

		private int FiguresAllScore = 0;
        readonly Random rnd = new Random();
		private int maxsize = 13;

		public int GetMaxsize()
		{
			return maxsize;
		}
		private int Co = 0;
		public int GetCo()
		{
			return Co;
		}

		private Figures[] _FiguresAll = new Figures[13];//пустой

		public Figures Fig(int i)
		{
			return _FiguresAll[i];

		}

		public Array(Graphics t) //rand
		{
			for (int OGO = 0; OGO < 13; OGO++)
			{
				Create(t);
			}
			Co = maxsize;

		}

		public Array() //пустой
		{

		}

		private void RandCord(Graphics g)
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

		public void Create(Graphics t)
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
					break;
			}
		}

		public void Add(Graphics t) //добавление
		{
			if (Chech())
			{
				Create(t);
				
			}
			else 
			{
				Figures[] _temp = new Figures[maxsize];


				for (int i = 0; i < maxsize; i++) 
				{
					_temp[i] = _FiguresAll[i];
				}
				Delete();
				
				_FiguresAll = new Figures[maxsize + 3];

				for (int i = 0; i < maxsize; i++)
				{
					_FiguresAll[i] = _temp[i];
				}

				maxsize += 3;
				
			}
			Co++;
		}

		private bool Chech() //проверка
		{
            return (FiguresAllScore >= maxsize)?false:true;
		}



		public void Vis(Graphics t)
		{

			for (int i = 0; i < Co-1; i++) 
			{
				_FiguresAll[i].Visible = true;
				_FiguresAll[i].Fill(t, _FiguresAll[i].Brush ?? Brushes.Yellow);
				_FiguresAll[i].Draw(t, _FiguresAll[i].Pen ?? Pens.Black);
			}
		}
		public void invis(Graphics t)
		{

			for (int i = 0; i < Co-1; i++)
			{
				_FiguresAll[i].Visible = false;
			}
		}
		public void Delete() //удаление
		{
			for (int i = 0; i < maxsize; i++)
			{
				_FiguresAll[i] = null;

			}
			_FiguresAll = null;
		}
		public void Key(KeyEventArgs e, Graphics g) 
		{
			if (e.KeyCode == Keys.W)
			{
				for (int i = 0; i < maxsize; i++)
				{
					if (_FiguresAll[i] is Ellipse && _FiguresAll[i] is Oval != null)
					{
						_FiguresAll[i]?.Move(0, -13, g, 1);

					}
					else
					{
						_FiguresAll[i]?.Move(0, -13, g, 2);

					}

				}
			}
			else if (e.KeyCode == Keys.S)
			{
				for (int i = 0; i < maxsize; i++)
				{
					if (_FiguresAll[i] is Ellipse && _FiguresAll[i] is Oval != null)
					{
						_FiguresAll[i]?.Move(0, 13, g, 1);

					}
					else
					{
						_FiguresAll[i]?.Move(0, 13, g, 2);

					}

				}
			}
			else if (e.KeyCode == Keys.D)
			{
				for (int i = 0; i < maxsize; i++)
				{
					if (_FiguresAll[i] is Ellipse && _FiguresAll[i] is Oval != null)
					{
						_FiguresAll[i]?.Move(13, 0, g, 1);

					}
					else
					{
                        _FiguresAll[i]?.Move(13, 0, g, 2);

					}
				}
			}
			else if (e.KeyCode == Keys.A)
			{
				for (int i = 0; i < maxsize; i++)
				{
					if (_FiguresAll[i] is Ellipse && _FiguresAll[i] is Oval != null)
					{
						_FiguresAll[i]?.Move(-13, 0, g, 1);

					}
					else
					{
						_FiguresAll[i]?.Move(-13, 0, g, 2);

					}
				}
			}
		}
	}
}
