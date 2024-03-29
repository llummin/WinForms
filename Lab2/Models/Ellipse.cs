﻿using System;
using System.Drawing;

namespace test_2
{
	class Ellipse //: function
	{
		private static int x;
		private static int y;
		private static int w;
		private static int h;
		Random rnd = new Random();

		/*public Brush Brush { get; private set; }

		public Pen Pen { get; private set; }*/

		private bool _highlighted;

		public Ellipse()//random
		{

			x = rnd.Next(10, 10);
            y = x;
			w = rnd.Next(50, 150);
			h = w;

			Rectangle rect = new Rectangle(x,y,w,h);

			_rectangle = rect;
		}
		public Ellipse(Rectangle rect)//параметр
		{
			_rectangle = rect;
		}

		private Rectangle _rectangle;


		public  bool Contains(Point pt)
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
			Brush brush = Brushes.Turquoise;
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
