using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgFund_08._03
{
    public static class Engine
    {
        public static int[,] gMatrix;
        public static void Load(string fileName)
        {
            TextReader load = new StreamReader(fileName);
            List<string> data = new List<string>();
            string buffer;
            while ((buffer =load.ReadLine())!=null)
                data.Add(buffer);
            load.Close();
            gMatrix = new int[data.Count, data[0].Split(' ').Length];
            for(int i = 0; i < data.Count; i++) 
            {
                string[] local = data[i].Split(' ');
                for(int j = 0 ; j < local.Length; j++) 
                {
                    gMatrix[i,j] = int.Parse(local[j]);
                }
            }
        }
        public static void Draw(MyGraphics handler)
        {
            for (int i = 0; i < gMatrix.GetLength(0); i++) 
            {
                for(int j = 0; j<gMatrix.GetLength(1); j++)
                {
                    switch(gMatrix[i,j])
                    {
                        case 1:
                            handler.grp.FillRectangle(Brushes.Gray, j * dW, i * dH, dW, dH);
                            handler.grp.DrawRectangle(Pens.Black, j * dW, i * dH, dW, dH);
                            break;
                    }
                }
            }

        }
        
        private static float dW, dH;
        public static void DoMath(MyGraphics handler)
        {
            dW = (float)handler.resX / gMatrix.GetLength(1);
            dH = (float)handler.resY / gMatrix.GetLength(0);
        }
    }
}
