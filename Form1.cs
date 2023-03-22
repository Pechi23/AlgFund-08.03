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
        MyGraphics t = new MyGraphics();
        public FormGame()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            t.InitGraph(pictureBox1);
            Engine.Load(Engine.crtLevel);
            Engine.DoMath(t);
            Engine.Draw(t);
            t.RefreshGraph();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            t.ClearGraph();
            Engine.Tick();
            Engine.Draw(t);
            t.RefreshGraph();

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
            t.ClearGraph();
            Engine.Draw(t);
            t.RefreshGraph();
        }
    }
}
