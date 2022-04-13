using System;

using System.Drawing;
using System.Drawing.Drawing2D;

namespace test_2
{
    abstract class Figures
    {
        protected int x, y, w, h;
		protected Rectangle _rectangle;
		protected Point[] _points;
		public bool Visible = false;

		Random rnd = new Random();

		public virtual void Rand() 
		{
			x = rnd.Next(75, 75);
			y = x;
			w = rnd.Next(50, 150);
			h = w;
		}
		public virtual void Creat() 
		{
			
		}
		public virtual void Creat(Rectangle rect) //перегрузка (параметра элипс)
		{
			_rectangle = rect;
		}
		public virtual void Creat(Point[] points)
		{
		}

		public int GetX()
		{
			return x;
		}
		public int GetY()
		{
			return y;
		}
		public int GetW()
		{
			return w;
		}
		public int GetH()
		{
			return h;
		}

		public void SetX(int _x)
		{
			x = _x;
		}
		public void SetY(int _y)
		{
			y = _y;
		}
		public void SetW(int _w)
		{
			w = _w;
		}
		public void SetH(int _h)
		{
			h = _h;
		}

		public Brush Brush { get; private set; }

		public Pen Pen { get; private set; }

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

		public virtual bool Contains(Point pt)
		{
			return false;
			//throw new NotImplementedException();
		}

		public virtual void Draw(Graphics g, Pen pen)
		{
			Pen = pen;
		}

		public virtual void Fill(Graphics g, Brush brush)
		{
			Brush = brush;
		}

		public void Move(int dx, int dy, Graphics g , int TT)
		{
			OnFigureChanged(new EventArgs());
			if (TT == 1) 
			{
				_rectangle.Offset(dx, dy);
			}
			else if (TT == 2)
			{
                using Matrix m = new Matrix();
                m.Translate(dx, dy);
                m.TransformPoints(_points);
            }
			this.Draw(g, Pen);
			this.Fill(g, Brush);
		}

        internal void Move(double x, double y, Graphics gc)
        {
            throw new NotImplementedException();
        }

        public Rectangle GetRectangle()
		{
			return _rectangle;
		}
		public Point[] GetPoint()
		{
			return _points;
		}
		protected virtual void OnFigureChanged(EventArgs e)
		{
			EventHandler handler = FigureChanged;
			if (handler == null) return;
			handler(this, e);
		}

		public event EventHandler FigureChanged;
	}
}
