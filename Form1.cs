using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgFund_08._03
{
    public partial class FormGame : Form
    {
       
        public FormGame()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Engine.t.InitGraph(pictureBox1);
            Engine.Load(Engine.crtLevel);
            Engine.DoMath(Engine.t);
            Engine.Draw(Engine.t);
            Engine.t.RefreshGraph();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Engine.t.ClearGraph();
            Engine.Tick();
            if (Engine.CheckForGameOver())
                timer1.Enabled = false;
            Engine.Draw(Engine.t);
            Engine.t.RefreshGraph();

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.W:
                    Engine.player1.MoveUp();
                    break;
                case Keys.S:
                    Engine.player1.MoveDown();
                    break;
                case Keys.A:
                    Engine.player1.MoveLeft();
                    break;
                case Keys.D:
                    Engine.player1.MoveRight();
                    break;
                case Keys.Space:
                    timer1.Enabled = !timer1.Enabled;
                    break;
            }
            if (Engine.gMatrix[Engine.player1.locX, Engine.player1.locY] == 9)
            {
                Engine.gMatrix[Engine.player1.locX, Engine.player1.locY] = 0;
                Engine.nrDiamonds--;
            }

            Engine.t.ClearGraph();
            Engine.Draw(Engine.t);
            Engine.t.RefreshGraph();

            Engine.CheckForWin(Engine.player1);
            if (Engine.isWin)
            {
                MessageBox.Show("You won");
                timer1.Enabled = false;
            }

        }
    }
}
