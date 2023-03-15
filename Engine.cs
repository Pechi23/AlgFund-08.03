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
        public static List<MonsterMechanics> monsters = new List<MonsterMechanics>();
        public static void Load(string fileName)
        {
            monsters.Clear();
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
                    if (gMatrix[i,j] == 5 || gMatrix[i,j] == 6 || gMatrix[i,j] == 7)
                        monsters.Add(new MonsterMechanics(i, j, gMatrix[i,j]));

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
                        case 1: //pereti
                            handler.grp.FillRectangle(Brushes.Gray, j * dW, i * dH, dW, dH);
                            handler.grp.DrawRectangle(Pens.Black, j * dW, i * dH, dW, dH);
                            break;
                        case 2: //start
                        case 3: //final
                            break;
                        case 9: //diamonds
                            handler.grp.FillEllipse(Brushes.Turquoise, j * dW, i * dH, dW, dH);
                            handler.grp.DrawEllipse(Pens.Black, j * dW, i * dH, dW, dH);
                            break;

                    }
                }
            }
            foreach(MonsterMechanics m in monsters) 
            { 
                m.Draw(handler);
            }

        }
        public static void Tick()
        {
            foreach (MonsterMechanics m in monsters)
                m.Tick();
        }
        public static float dW, dH;
        public static void DoMath(MyGraphics handler)
        {
            dW = (float)handler.resX / gMatrix.GetLength(1);
            dH = (float)handler.resY / gMatrix.GetLength(0);
        }
    }
}
