﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace test_2
{
    class Line
    {
		private readonly Point[] _Line;

		//private static int x, y;
		private readonly Pointt Pointt = new Pointt(0, 0);
		private static int w, h;
        readonly Random rnd = new Random();
		public Line()
		{
			Pointt.SetX(rnd.Next(50, 50));
			Pointt.SetY(Pointt.GetX());
			w = rnd.Next(50, 150);
			h = w;
			Point[] points = new[]
			{
				new Point(Pointt.GetX(), Pointt.GetY()),
				new Point(w, h),
				new Point(w-10, h+10),
				new Point(Pointt.GetX()-10, Pointt.GetY()+10)
			};
			_Line = points;
		}
		public Line(int cx, int cy, int size)
		{
			Pointt.SetX(cx);
			Pointt.SetY(cy);

			Point[] points = new[]
			{
				new Point(Pointt.GetX(), Pointt.GetY()),
				new Point(w, h),
				new Point(w-10, h+10),
				new Point(Pointt.GetX()-10, Pointt.GetY()+10)
			};
			_Line = points;
		}

		public Line(Point[] points)
		{
			_Line = points;
		}

		public bool Contains(Point pt)
		{
			Point[] pts = new Point[_Line.Length + 1];
			_Line.CopyTo(pts, 0);
			pts[^1] = pts[0];
			//вектор из вершины к точке
			Point v1, v2;
			int newSign = 0;
			//Проходим по всем вершинам и проверяем знак векторного произведения
			for (int i = 0; i < pts.Length - 1; i++)
			{
				v1 = new Point(pt.X - pts[i].X, pt.Y - pts[i].Y);
				v2 = new Point(pts[i + 1].X - pts[i].X, pts[i + 1].Y - pts[i].Y);
				if (i == 0)
				{
					newSign = Math.Sign(v1.X * v2.Y - v1.Y * v2.X);
					continue;
				}
				int sign = Math.Sign(v1.X * v2.Y - v1.Y * v2.X);
				//Точка лежит на стороне
				if (sign == 0) return true;
				//Если знак поменялся, значит точка лежит вне
				if (sign != newSign) return false;
			}
			return true;
		}

		public void Draw(Graphics g)
		{

			Pen pen;
			pen = Pens.Black;
			g.DrawPolygon(Highlighted ? new Pen(pen.Color, pen.Width * 2) : pen, _Line);
		}

		public void Fill(Graphics g)
		{
			Brush brush = Brushes.Yellow;
			g.FillPolygon(brush, _Line);
		}

		public void Move(int dx, int dy)
		{
			using (Matrix m = new Matrix())
			{
				m.Translate(dx, dy);
				m.TransformPoints(_Line);
			}
			MoveF(dx, dy);
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
