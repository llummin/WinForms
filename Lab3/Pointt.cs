using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace test_2
{
    class Pointt
    {
        private int x,y;

        public Pointt(int x, int y)
        {
            this.x = x;
            this.y = y;
            MessageBox.Show("Точка создана", "Точка", MessageBoxButtons.OK);
        }

        public int GetX()
        {
            return x;
        }

        public void SetX(int x)
        {
            this.x = x;
        }
        public void Offset(int dx, int dy)
        {
            x += dx;
            y += dy;
        }

        public int GetY()
        {
            return y;
        }

        public void SetY(int y)
        {
            this.y = y;
        }
    }
}
