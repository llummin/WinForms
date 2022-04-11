using System;
using System.Drawing;
using System.Windows.Forms;


namespace test_2
{
	class Ellipse : Figures
	{
		readonly Random rnd = new Random();

		public Ellipse()
		{
			base.Rand();
		}
		public override void Creat()//random
		{
			Form1.COST = w;
			Rectangle rect = Rectangle.FromLTRB(x-(w/2), y-(h/2), x + (w / 2), y + (h / 2));

			_rectangle = rect;
		}
		public Ellipse(int a)//random
		{

			x = rnd.Next(75, 75);
			y = x;
			w = Form1.COST;
			w -= 25;
			h = w;
		}

		public override void Creat(Rectangle rect) //перегрузка (параметра элипс)
		{
			base.Creat(rect);
		}

		public Ellipse(int cx,int cy ,int size)//random
		{

			x  =cx;
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


		public override void Move(int dx, int dy)
		{
			OnFigureChanged(new EventArgs());
			_rectangle.Offset(dx, dy);
			x += dx;
			y += dy; 
		}

		public Rectangle GetRectangle()
		{
			return _rectangle;
		}
	}
}
