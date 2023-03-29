using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AlgFund_08._03
{
    public static class Engine
    {
        public static int[,] gMatrix;
        public static List<MonsterMechanics> monsters = new List<MonsterMechanics>();
        public static Player player1;
        public static Point f;
        public static string crtLevel;
        public static int nrDiamonds = 0;
        public static Campaign campaign;
        public static bool isCampaign;
        public static bool isWin;
        public static MyGraphics t = new MyGraphics();
        public static void Load(string fileName)
        {
            monsters.Clear();
            TextReader load = new StreamReader(@"..\..\Resources\Maps\" + fileName);
            List<string> data = new List<string>();
            string buffer;
            while ((buffer = load.ReadLine()) != null)
                data.Add(buffer);
            load.Close();
            gMatrix = new int[data.Count, data[0].Split(' ').Length];
            for (int i = 0; i < data.Count; i++)
            {
                string[] local = data[i].Split(' ');
                for (int j = 0; j < local.Length; j++)
                {
                    gMatrix[i, j] = int.Parse(local[j]);
                    if (gMatrix[i, j] == 5 || gMatrix[i, j] == 6 || gMatrix[i, j] == 7)
                        monsters.Add(new MonsterMechanics(i, j, gMatrix[i, j]));
                    else if (gMatrix[i, j] == 2)
                        player1 = new Player(i, j);
                    else if (gMatrix[i, j] == 3)
                        f = new Point(i, j);
                    else if (gMatrix[i, j] == 9)
                        nrDiamonds++;
                }
            }
            isWin = false;
        }
        public static void Draw(MyGraphics handler)
        {
            for (int i = 0; i < gMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < gMatrix.GetLength(1); j++)
                {
                    switch (gMatrix[i, j])
                    {
                        case 1: //pereti
                            handler.grp.FillRectangle(Brushes.Gray, j * dW, i * dH, dW, dH);
                            handler.grp.DrawRectangle(Pens.Black, j * dW, i * dH, dW, dH);
                            break;
                        case 3: //final
                            handler.grp.DrawEllipse(new Pen(Color.Green, 5), j * dW, i * dH, dW, dH);
                            break;
                        case 9: //diamonds
                            handler.grp.FillEllipse(Brushes.Turquoise, j * dW, i * dH, dW, dH);
                            handler.grp.DrawEllipse(Pens.Black, j * dW, i * dH, dW, dH);
                            break;

                    }
                }
            }
            foreach (MonsterMechanics m in monsters)
            {
                m.Draw(handler);
            }
            handler.grp.DrawString(Engine.player1.lives.ToString(), new Font("Arial", 30, FontStyle.Bold), Brushes.Red, new Point(10, 10));
            handler.grp.DrawString(nrDiamonds.ToString(), new Font("Arial", 30, FontStyle.Bold), Brushes.LightBlue, new Point(50, 10));
            player1.Draw(handler);

        }
        public static void Tick()
        {
            foreach (MonsterMechanics m in monsters)
                m.Tick();
            if (HasCollided(player1))
            {
                player1.lives--;
            }
        }
        public static bool CheckForGameOver()
        {
            if (player1.lives <= 0)
            {
                return true;
            }
            return false;
        }
        public static float dW, dH;
        public static void DoMath(MyGraphics handler)
        {
            dW = (float)handler.resX / gMatrix.GetLength(1);
            dH = (float)handler.resY / gMatrix.GetLength(0);
        }
        public static bool CanMove(int locX, int locY)
        {
            if (gMatrix[locX, locY] != 1)
                return true;
            return false;
        }
        public static bool IsMonster(int locX, int locY)
        {
            foreach(MonsterMechanics mon in monsters)
            {
                if(mon.locX == locX && mon.locY == locY)
                    return true;   
            }
            return false;
        }

        public static bool HasCollided(Player plyr)
        {
            foreach(MonsterMechanics mon in monsters)
            {
                if(plyr.locX == mon.locX && plyr.locY == mon.locY)
                    return true;
            }
            
            return false;
        }
        public static void CheckForWin(Player plyr)
        {
            if (gMatrix[plyr.locX, plyr.locY] == 3)
            {
                if (nrDiamonds == 0)
                {
                    if (isCampaign)
                    {
                        Engine.campaign.crtLevel++;
                        if(Engine.campaign.crtLevel >= Engine.campaign.files.Count)
                        {
                            isWin = true;
                        }
                        else
                        {
                            crtLevel = Engine.campaign.GetCurrentFile();
                            Load(crtLevel);
                            DoMath(t);
                        }
                    }
                    else
                    {
                        isWin = true;
                    }
                }
            }
        }
    }
}
