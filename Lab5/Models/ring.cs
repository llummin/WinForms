using System;
using System.Drawing;

namespace test_2
{
    class Ring
    {
		private Rectangle _rectangle;
		private Rectangle _rectanglein;

		private bool _highlighted;
		public Ring(Ellipse rect, Ellipse rectin)
		{
			_rectangle = rect.GetRectangle(); ;
			_rectanglein = rectin.GetRectangle() ;
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

		protected void OnFigureChanged(EventArgs e)
		{
			EventHandler handler = FigureChanged;
			if (handler == null) return;
			handler(this, e);
		}
		public event EventHandler FigureChanged;

		public bool Contains(Point pt)
		{
			return _rectangle.Contains(pt);
		}

		public void Draw(Graphics g)
		{
			Pen pen;
			pen = Pens.Black;
			g.DrawEllipse(Highlighted ? new Pen(pen.Color, pen.Width * 2) : pen, _rectangle);
			g.DrawEllipse(Highlighted ? new Pen(pen.Color, pen.Width * 2) : pen, _rectanglein);
			
		}

		public void Fill(Graphics g)
		{
			Brush brush = Brushes.Yellow;
			g.FillEllipse(brush, _rectangle);
			//Brushes.White;
			g.FillEllipse(Brushes.White, _rectanglein);
		}


		public void Move(int dx, int dy)
		{
			_rectangle.Offset(dx, dy);
			_rectanglein.Offset(dx, dy);
			MoveF(dx, dy);
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
	}
}

