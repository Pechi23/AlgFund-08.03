using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AlgFund_08._03
{
    public partial class FrmStart : Form
    {
        public FrmStart()
        {
            InitializeComponent();
        }

        private void FrmStart_Load(object sender, EventArgs e)
        {
            string[] dir = Directory.GetFiles(@"..\..\Resources\Maps");
            foreach(string s in dir) 
            {
                string[] local = s.Split('\\');
                listBox1.Items.Add(s);
                comboBox1.Items.Add(local[local.Length - 1]);

            }
            comboBox1.SelectedIndex = 0;
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            Engine.crtLevel = comboBox1.SelectedItem.ToString();
            FormGame myFormGame = new FormGame();
            myFormGame.ShowDialog();
        }
    }
}
