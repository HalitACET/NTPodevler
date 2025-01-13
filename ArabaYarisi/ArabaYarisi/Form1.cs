using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArabaYarisi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            int x1 = araba1.Location.X;
            int y1 = araba1.Location.Y;

            int x2 = araba2.Location.X;
            int y2 = araba2.Location.Y;

            if (e.KeyCode == Keys.Up)
            {
                y1 -= 5;
            }
            if (e.KeyCode == Keys.Down)
            {
                y2 -= 5;
            }

            araba1.Location = new Point(x1, y1);
            araba2.Location = new Point(x2, y2);

            if (y1 < 50)
            {
                MessageBox.Show("Tebrikler kırmızı araba kazandı");
                araba1.Location = new Point(50, 420);
                araba2.Location = new Point(250, 420);
            }
            if (y2 < 50)
            {
                MessageBox.Show("Tebrikler beyaz araba kazandı");
                araba1.Location = new Point(50, 420);
                araba2.Location = new Point(250, 420);
            }
        }
    }
}
