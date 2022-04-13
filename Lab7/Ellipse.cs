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
			Rectangle rect = (Rectangle.FromLTRB(x-(w/2), y-(h/2), x + (w / 2), y + (h / 2)));

			_rectangle = rect;
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
		
	}
}
