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
    public partial class Form1 : Form
    {
        MyGraphics t = new MyGraphics();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            t.InitGraph(pictureBox1);
            Engine.Load("D:\\Faculta\\AlgFund 08.03\\Maps.txt");
            Engine.DoMath(t);
            Engine.Draw(t);
            t.RefreshGraph();
        }
    }
}
