using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;

namespace AlgFund_08._03
{
    public class MyGraphics
    {
        PictureBox display;
        Bitmap bmp;
        public Graphics grp;
        Color backColor = Color.FromArgb(200,200,180);
        public int resX, resY;

        public void InitGraph(PictureBox display)
        {
            this.display = display;
            bmp = new Bitmap(display.Width, display.Height);
            grp = Graphics.FromImage(bmp);
            ClearGraph();
            RefreshGraph();
            resX = display.Width;
            resY = display.Height;
        }

        public void ClearGraph()
        {
            grp.Clear(backColor);
        }

        public void RefreshGraph()
        {
            this.display.Image = bmp;
        }

    }
}
