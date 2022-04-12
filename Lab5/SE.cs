using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace test_2
{
    class SE
    {
		private Rectangle _rectanglein;
		private Point[] _points;
		public SE(Polygon Re , Ellipse rectin)
		{
			_rectanglein = rectin.GetRectangle();
			_points = Re.GetPoint();
		}
		public bool Contains(Point pt)
		{
			return _rectanglein.Contains(pt);
		}
		private bool _highlighted;
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
		public void Draw(Graphics g)
		{
			Pen pen;
			pen = Pens.Black;
			g.DrawPolygon(Highlighted ? new Pen(pen.Color, pen.Width * 2) : pen, _points);
			g.DrawEllipse(Highlighted ? new Pen(pen.Color, pen.Width * 2) : pen, _rectanglein);

		}

		public void Fill(Graphics g)
		{
			Brush brush = Brushes.Yellow;
			g.FillPolygon(brush, _points);
			g.FillEllipse(Brushes.White, _rectanglein);
		}


		public void Move(int dx, int dy)
		{
			using (Matrix m = new Matrix())
			{
				m.Translate(dx, dy);
				m.TransformPoints(_points);
			}
			_rectanglein.Offset(dx, dy);
			MoveF(dx, dy);
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

