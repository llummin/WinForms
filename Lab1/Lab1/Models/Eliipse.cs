using System;
using System.Drawing;

namespace Lab1
{
	class Ellipse
	{
		private int x;
		private int y;
		private int w;
		private int h;
		Random rnd = new Random();

		private bool _highlighted;

		public Ellipse()//random
		{

			x = rnd.Next(10, 10);
			y = x;
			w = rnd.Next(50, 150);
			h = w;

			Rectangle rect = new Rectangle(x, y, w, h);

			_rectangle = rect;
		}
		public Ellipse(Rectangle rect)//параметр
		{
			_rectangle = rect;
		}

		private Rectangle _rectangle;


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


		public void Move(int dx, int dy)
		{
			_rectangle.Offset(dx, dy);
			MoveF(dx, dy);
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

		public void MoveF(int dx, int dy)
		{
			OnFigureChanged(new EventArgs());
		}
		protected void OnFigureChanged(EventArgs e)
		{
			EventHandler handler = FigureChanged;
			if (handler == null) return;
			handler(this, e);
		}
		public event EventHandler FigureChanged;
	}
}