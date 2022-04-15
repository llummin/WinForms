using System;
using System.Drawing;

namespace test_2
{
	class Ellipse
	{
		/*private static int x;
		private static int y;*/
		private readonly int w;
		private readonly int h;
		readonly Random rnd = new Random();

		private readonly Pointt Pointt = new Pointt(0, 0);
		private bool _highlighted;
		public Ellipse()//random
		{

			Pointt.SetX(rnd.Next(75, 75));
			Pointt.SetY(Pointt.GetX());
			w = rnd.Next(50, 150);
			h = w;
			Form1.COST = w;
			Rectangle rect = (Rectangle.FromLTRB(Pointt.GetX() - (w / 2), Pointt.GetY() - (h / 2), Pointt.GetX() + (w / 2), Pointt.GetY() + (h / 2)));

			_rectangle = rect;

		}
		public Ellipse(int a)//random
		{

			Pointt.SetX(rnd.Next(75, 75));
			Pointt.SetY(Pointt.GetX());
			w = Form1.COST;
			w -= 25;
			h = w;

			Rectangle rect = (Rectangle.FromLTRB(Pointt.GetX() - (w / 2), Pointt.GetY() - (h / 2), Pointt.GetX() + (w / 2), Pointt.GetY() + (h / 2)));

			_rectangle = rect;
		}
		public Ellipse(Rectangle rect)//параметр
		{
			_rectangle = rect;
		}
		public Ellipse(int cx, int cy, int size)//random
		{

			Pointt.SetX(cx);
			Pointt.SetY(cy);

			Rectangle rect = (Rectangle.FromLTRB(Pointt.GetX() - (size / 2), Pointt.GetY() - (size / 2), Pointt.GetX() + (size / 2), Pointt.GetY() + (size / 2)));

			_rectangle = rect;
		}

		private Rectangle _rectangle;
		private Point _point;


		public bool Contains(Point pt)
		{
			return _rectangle.Contains(pt);
		}

		public void Draw(Graphics g)
		{

			Pen pen;
			pen = Pens.Black;
			g.DrawEllipse(Highlighted ? new Pen(pen.Color, pen.Width * 2) : pen, _rectangle);
		}

		public void Fill(Graphics g)
		{
			Brush brush = Brushes.Yellow;
			g.FillEllipse(brush, _rectangle);
		}

		public void OffsetPoint(int dx, int dy)
        {
			_point.Offset(dx, dy);
		}

		public void Move(int dx, int dy)
		{
			OnFigureChanged(new EventArgs());
			_rectangle.Offset(dx, dy);
			
		}

		public bool Highlighted
		{
			get
			{
				return _highlighted;
			}
			set
			{
				_highlighted = value;
				OnFigureChanged(new EventArgs());
			}
		}

		public bool ContainsF(Point pt)
		{
			return false;
			//throw new NotImplementedException();
		}

		protected void OnFigureChanged(EventArgs e)
		{
			EventHandler handler = FigureChanged;
			if (handler == null) return;
			handler(this, e);
		}
		public event EventHandler FigureChanged;
	
	public Rectangle GetRectangle() 
		{
			return _rectangle;
		}
	}
}
