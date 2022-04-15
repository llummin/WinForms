using System;
using System.Drawing;

namespace test_2
{
	class Ellipse : Figures
	{

		Random rnd = new Random();

		public Ellipse()
		{
			base.Rand();
		}
		public override void Creat()//random
		{
			Form1.COST = w;
			Rectangle rect = (Rectangle.FromLTRB(x-(w/2), y-(h/2), x + (w / 2), y + (h / 2)));

			_rectangle = rect;
		}
		public Ellipse(int a)//random
		{

			x=rnd.Next(75, 75);
			y = x;
			w = Form1.COST;
			w = w - 25;
			h = w;
		}

		public override void Creat(Rectangle rect) //перегрузка (параметра элипс)
		{
			base.Creat(rect);
		}

		public Ellipse(int cx,int cy ,int size)//random
		{

			x=cx;
			y=cy;
			w = size;
			h = w;
		}

		public override bool Contains(Point pt)
		{
			return _rectangle.Contains(pt);
		}

		public override void Draw(Graphics g, Pen pen)
		{
			g.DrawEllipse(Highlighted ? new Pen(pen.Color, pen.Width * 2) : pen, _rectangle);
			base.Draw(g, pen);
		}

		public override void Fill(Graphics g, Brush brush)
		{
			g.FillEllipse(brush, _rectangle);
			base.Fill(g, brush);
		}
		public Rectangle GetRectangle() 
		{
			return _rectangle;
		}
	}
}
