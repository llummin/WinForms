using System;

using System.Drawing;


namespace test_2
{
    abstract class Figures
    {
        protected int x, y, w, h;
		protected Rectangle _rectangle;
		protected Point[] _points;
        readonly Random rnd = new Random();

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

		public abstract void Draw(Graphics g);


		public virtual void Fill(Graphics g, Brush brush)
		{
			Brush = brush;
		}

		public abstract void Move(int dx, int dy);
		protected virtual void OnFigureChanged(EventArgs e)
		{
			EventHandler handler = FigureChanged;
			if (handler == null) return;
			handler(this, e);
		}

		public event EventHandler FigureChanged;
	}
}
