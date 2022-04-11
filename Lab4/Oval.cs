using System;

using System.Drawing;


namespace test_2
{
    class Oval : Ellipse
    {

		public Oval()
		{
			base.Rand();
		}
		public override void Creat()//random
		{
			Rectangle rect = (Rectangle.FromLTRB(x - (w / 2), y - (h / 2), x + (w / 2), (y + (h / 2))/2));

			_rectangle = rect;
		}
		public override void Creat(Rectangle rect) //перегрузка (параметра элипс)
		{
			_rectangle = rect;
		}


		public Oval(int cx, int cy, int size)//random
		{

			x = cx;
			y = cy;
			w = size;
			h = w;
		}
		public override bool Contains(Point pt)
		{
			return _rectangle.Contains(pt);
		}

		public override void Draw(Graphics g)
		{
			Pen pen;
			pen = Pens.Black;
			g.DrawEllipse(Highlighted ? new Pen(pen.Color, pen.Width * 2) : pen, _rectangle);
		}

		public override void Fill(Graphics g, Brush brush)
		{
			g.FillEllipse(brush, _rectangle);
			base.Fill(g, brush);
		}

		public void Swap(int _x, int _y, int _w, int _h, int t)
		{
			if (t == 1)
			{
				_rectangle = Rectangle.FromLTRB(_x - (_w / 2), _y - (_h / 2), (_y + (_h / 2)) / 2, _x + (_w / 2));
			}
			else
			{
				_rectangle = Rectangle.FromLTRB(_x - (_w / 2), _y - (_h / 2), _x + (_w / 2), (_y + (_h / 2)) / 2);
			}
		}

		public override void Move(int dx, int dy)
		{
			base.Move(dx, dy);
			x += dx;
			y += dy;
		}
	}
}
