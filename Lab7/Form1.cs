using System;
using System.Drawing;
using System.Windows.Forms;

namespace test_2
{
	public partial class Form1 : Form
	{
		Array Ar;
		list<Figures> Arl;

		bool Go = false;
		bool Go2 = false;

		Random rnd = new Random();
		//-------------------------------------------------------------------------------------
		public Form1()
		{
			InitializeComponent();
			DoubleBuffered = true;

			Paint += MainForm_Paint;

			KeyDown += PressKey;
		}
		//-------------------------------------------------------------------------------------
		void MainForm_Paint(object sender, PaintEventArgs e)              //обновление на форме
		{
			if (Go2) 
			{
				for (int i = 0; i < Ar.GetCo()-1; i++) 
				{
					if (Ar.Fig(i).Visible) 
					{
						Ar.Fig(i).Fill(e.Graphics, Ar.Fig(i).Brush ?? Brushes.Yellow);
						Ar.Fig(i).Draw(e.Graphics, Ar.Fig(i).Pen ?? Pens.Black);
					}
				}
			}
			if (Go)
			{
				Node<Figures> _temp = Arl.GetFirst();
				for (; 1 <= Arl.Count;)
				{
					if (_temp.Data.Visible)
					{
						_temp.Data.Fill(e.Graphics, _temp.Data.Brush ?? Brushes.Yellow);
						_temp.Data.Draw(e.Graphics, _temp.Data.Pen ?? Pens.Black);

					}
					if (_temp.Next == null) break;
					_temp = _temp.Next;
				}
			}
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			this.Refresh();
		}

		private void buttonRE_Click(object sender, EventArgs e)//удаление
		{
			if (Go)//лист
			{
				Node<Figures> _temp = Arl.GetFirst();
				Node<Figures> _temp2 = _temp.Next;
				while (Arl.Count != 0) 
				{
					Arl.Delete(_temp.Data);
					if (_temp.Next == null) break;
					_temp = _temp2;
					_temp2 = _temp.Next;
				}
				Arl.Clear();
				Go = false;
				
			}
			else
			{
				//Ar.Delete();
				Go2 = false;
			}
			this.Refresh();
		}

		private void Dele(Graphics g)//полное стиранеи
		{
			Color color = Color.FromName("White");
			g.Clear(color);
		}

		
        private void button4_Click(object sender, EventArgs e)//стиранеи всех
        {
			Graphics t = CreateGraphics();
			Dele(t);
			if (Go)//лист
			{
				Arl.invis(t);

			}
			else
			{
				Ar.invis(t);
			}
			this.Refresh();
        }

        private void button5_Click(object sender, EventArgs e)//показ всех
        {
			Graphics t = CreateGraphics();
			if (Go)//лист
			{
				Arl.Vis(t);
				
			}
			else 
			{
				Ar.Vis(t);
			}
			this.Refresh();
		}

		private void PressKey(object sender, KeyEventArgs e)
		{

			Graphics g = CreateGraphics();

			if (Go)
			{
				Arl.key(e,g);
				this.Refresh();
			}
			if (Go2) 
			{
				Ar.Key(e, g);
				this.Refresh();
			}

		}

        private void Creat_Click(object sender, EventArgs e)
        {
			if (comboBox1.SelectedItem == null)
			{
				MessageBox.Show("Значение не выбрано", "Выбор", MessageBoxButtons.OK);
				return;
			}
			string Indexe = comboBox1.SelectedItem.ToString();
			if (Indexe == "Массив Пустой")
			{
				Ar = new Array();
				Go = false;
				Go2 = true;
				MessageBox.Show("Массив создан", "Массив создан", MessageBoxButtons.OK);
			}
			else if (Indexe == "Массив Заполненый")
			{
				Graphics t = CreateGraphics();

				Ar = new Array(t);
				Dele(t);
				Go = false;
				Go2 = true;
				MessageBox.Show("Массив создан", "Массив создан", MessageBoxButtons.OK);
				MessageBox.Show("Фигуры созданы", "Создание фигуры", MessageBoxButtons.OK);
			}
			else if (Indexe == "Список Пустой")
			{
				Arl = new list<Figures>();
				Go = true;
				MessageBox.Show("Лист создан", "Лист создан", MessageBoxButtons.OK);
				
			}
			else if (Indexe == "Список Заполненый")
			{
				Graphics t = CreateGraphics();

				Arl = new list<Figures>();
				Go = true;
				for (int i = 0; i < 13; i++) 
				{
					Arl.Create(t);
					Dele(t);
				}
				MessageBox.Show("Лист создан", "Лист создан", MessageBoxButtons.OK);
				MessageBox.Show("Фигуры созданы", "Создание фигуры", MessageBoxButtons.OK);
			}

		}

        private void button1_Click(object sender, EventArgs e)
        {
			Graphics t = CreateGraphics();
			if (Go) 
			{
				Arl.Create(t);
				if (Arl.GetFirst().Data.Visible) Arl.Vis(t);
			}
			if (Go2) 
			{
				Ar.Add(t);
				if (Ar.Fig(0).Visible) Ar.Vis(t);
			}
			this.Refresh();
        }
    }
}