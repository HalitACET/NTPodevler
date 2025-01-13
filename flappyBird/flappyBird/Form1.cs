using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace flappyBird
{
    public partial class Form1 : Form
    {
        int pipeSpeed = 3;
        int gravity = 10 ;
        int score = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void game_Down(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -15;
            }
        }

        private void game_Up(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 15;
            }
        }

        public void EndGame()
        {
            timer_GameControl.Stop();
            label1.Text = "GAME OVER!";
        }

        private void gameTimer(object sender, EventArgs e)
        {
            pictureBox_Bird.Top += gravity;
            pictureBox_Bottom.Left -= pipeSpeed;
            pictureBox_Top.Left -= pipeSpeed;
            label1.Text = "SCORE: " + score;

            if (pictureBox_Bottom.Left < -150)
            {
                pictureBox_Bottom.Left = 800;
                score++;
            }
            if (pictureBox_Top.Left < -180)
            {
                pictureBox_Top.Left = 950;
                score++;
            }
            if (pictureBox_Bird.Bounds.IntersectsWith(pictureBox_Bottom.Bounds) ||
                pictureBox_Bird.Bounds.IntersectsWith(pictureBox_Top.Bounds) ||
                pictureBox_Bird.Bounds.IntersectsWith(pictureBox_Ground.Bounds) || pictureBox_Bird.Top < -25)
            {
                EndGame();
            }
        }
    }
}
