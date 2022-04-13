using System;
using System.Drawing;
using System.Windows.Forms;

namespace test_2
{
    class Node<T> // Класс, хранящий указатель
    {
        public Node(T data)
        {
            Data = data; 
        }
        public T Data { get; set; } // Свойство Data предназначено для хранения данных
        public Node<T> Next { get; set; } // Свойство Next для ссылки на следующий узел
    }

    class list<T> 
    {
		Random rnd = new Random();
		Node<Figures> first;

        public Node<Figures> GetFirst() 
        {
            return first;
        }
        

        Node<Figures> last;


        int Score=0;

        public void Add(Figures data) 
        {
            Node<Figures> node = new Node<Figures>(data);

            if (first == null)
            {
                first = node;
            }
            else 
            {
                last.Next = node;
            }
            last = node;
            Score++;
        }

        public bool Delete(Figures data) 
        {
            Node<Figures> current = first;
            Node<Figures> previous = null;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;

                        if (current.Next == null)
                            last = previous;
                    }
                    else
                    {
                        first = first.Next;

                        if (first == null)
                            last = null;
                    }
                    Score--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }
            return false;
        }
        public int Count { get { return Score; } }
        public bool IsEmpty { get { return Score == 0; } }
        public void Clear()
        {
            first = null;
            last = null;
            Score = 0;
        }

		public void Create(Graphics t)
		{
			switch (rnd.Next(0, 6))
			{
				case 0:

                    Ellipse datae =new Ellipse();
					datae.Creat();

                    datae.Fill(t, datae.Brush ?? Brushes.Yellow);
                    datae.Draw(t, datae.Pen ?? Pens.Black);

                    datae.Move(rnd.Next(0, 900), rnd.Next(0, 500), t, 1);

                    Add(datae);
                    break;
				case 1:

                    Polygon datap = new Polygon();
                    datap.Creat();

                    datap.Fill(t, datap.Brush ?? Brushes.Yellow);
                    datap.Draw(t, datap.Pen ?? Pens.Black);

                    datap.Move(rnd.Next(0, 900), rnd.Next(0, 500), t, 2);

                    Add(datap);
                    break;
				case 2:

                    Line datal = new Line();
					datal.Creat();

                    datal.Fill(t, datal.Brush ?? Brushes.Yellow);
                    datal.Draw(t, datal.Pen ?? Pens.Black);

                    datal.Move(rnd.Next(0, 900), rnd.Next(0, 500), t, 2);

                    Add(datal);
                    break;
				case 3:

					Oval datao = new Oval();
					datao.Creat();

                    datao.Fill(t, datao.Brush ?? Brushes.Yellow);
                    datao.Draw(t, datao.Pen ?? Pens.Black);

                    datao.Move(rnd.Next(0, 900), rnd.Next(0, 500), t, 1);

                    Add(datao);
                    break;
				case 4:
					Romb datar = new Romb();
					datar.Creat();

                    datar.Fill(t, datar.Brush ?? Brushes.Yellow);
                    datar.Draw(t, datar.Pen ?? Pens.Black);

                    datar.Move(rnd.Next(0, 900), rnd.Next(0, 500), t, 2);

                    Add(datar);
                    break;
				case 5:
					Quadrilateral dataq = new Quadrilateral();
					dataq.Creat();

                    dataq.Fill(t, dataq.Brush ?? Brushes.Yellow);
                    dataq.Draw(t, dataq.Pen ?? Pens.Black);

                    dataq.Move(rnd.Next(0, 900), rnd.Next(0, 500), t, 2);

                    Add(dataq);
                    break;
			}
		}

        public void Vis(Graphics t) 
        {
            Node<Figures> _temp = this.first;
            for (; 1 <= Count;) 
            {
                _temp.Data.Visible = true;
                _temp.Data.Fill(t, _temp.Data.Brush ?? Brushes.Yellow);
                _temp.Data.Draw(t, _temp.Data.Pen ?? Pens.Black);

                if (_temp.Next == null) break;
                _temp = _temp.Next;
            }
        }
        public void invis(Graphics t)
        {
            Node<Figures> _temp = this.first;
            for (; 1 <= Count;)
            {
                _temp.Data.Visible = false;
                _temp.Data.Fill(t, _temp.Data.Brush ?? Brushes.Yellow);
                _temp.Data.Draw(t, _temp.Data.Pen ?? Pens.Black);

                if (_temp.Next == null) break;
                _temp = _temp.Next;
            }
        }

        public void key(KeyEventArgs e, Graphics g) 
        {
            Node<Figures> _temp = first;
            if (e.KeyCode == Keys.W)
            {
                for (; ; )
                {
                    if (_temp.Data is Ellipse || _temp.Data is Oval)
                    {
                        _temp.Data.Move(0, -13, g, 1);
                    }
                    else
                    {
                        _temp.Data.Move(0, -13, g, 2);
                    }
                    if (_temp.Next == null) break;
                    _temp = _temp.Next;
                }
            }
            else if (e.KeyCode == Keys.S)
            {
                for (; ; )
                {
                    if (_temp.Data is Ellipse || _temp.Data is Oval)
                    {
                        _temp.Data.Move(0, 13, g, 1);
                    }
                    else
                    {
                        _temp.Data.Move(0, 13, g, 2);
                    }
                    if (_temp.Next == null) break;
                    _temp = _temp.Next;
                }
            }
            else if (e.KeyCode == Keys.D)
            {
                for (; ; )
                {
                    if (_temp.Data is Ellipse || _temp.Data is Oval)
                    {
                        _temp.Data.Move(13, 0, g, 1);
                    }
                    else
                    {
                        _temp.Data.Move(13, 0, g, 2);
                    }
                    if (_temp.Next == null) break;
                    _temp = _temp.Next;
                }
            }
            else if (e.KeyCode == Keys.A)
            {
                for (; ; )
                {
                    if (_temp.Data is Ellipse || _temp.Data is Oval)
                    {
                        _temp.Data.Move(-13, 0, g, 1);

                    }
                    else
                    {
                        _temp.Data.Move(-13, 0, g, 2);
                    }
                    if (_temp.Next == null) break;
                    _temp = _temp.Next;
                }
            }
        }
    }
}
