using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgFund_08._03
{
    public enum MonsterType
    {
        Vertical, Horizontal, AllDirections
    }
    public class MonsterMechanics
    {
        public int locX,locY;
        public int dX, dY;
        public static Random rnd = new Random();
        public MonsterType type;
        public MonsterMechanics(int locX, int locY, int type)
        {
            this.locX = locX;
            this.locY = locY;
            int t;
            switch (type)
            {
               
                case 5:
                    this.type = MonsterType.Vertical; 
                    t = rnd.Next(2);
                    if (t == 0)
                        dX = -1;
                    else 
                        dX = 1;
                    dY = 0;
                    break;
                case 6:
                    this.type = MonsterType.Horizontal;
                    t = rnd.Next(2);
                    if (t == 0)
                        dY = -1;
                    else
                        dY = 1;
                    dX = 0;
                    break;
                case 7:
                    this.type = MonsterType.AllDirections;
                    t = rnd.Next(2);
                    int x;
                    if (t == 0)
                        x = -1;
                    else
                        x = 1;
                    t = rnd.Next(2);
                    if (t == 0)
                    {
                        dX = x;
                        dY = 0;
                    }
                    else
                    {
                        dY = x;
                        dX = 0;
                    }
                        
                    break;
            }
            

        }

        public void Tick()
        {
           
            if (Engine.gMatrix[locX + dX, locY + dY] == 1 ) 
            {
                switch(type)
                {
                    case MonsterType.Vertical:
                        dX *= -1;
                        break;
                    case MonsterType.Horizontal:
                        dY *= -1;
                        break;
                    case MonsterType.AllDirections:
                        int t = rnd.Next(2);
                        int x;
                        if (t == 0)
                            x = -1;
                        else
                            x = 1;
                        t = rnd.Next(2);
                        if (t == 0)
                        {
                            dX = x;
                            dY = 0;
                        }
                        else
                        {
                            dY = x;
                            dX = 0;
                        }
                        break;
                }
                
            }
            else
            {
                
                locX += dX;
                locY += dY;
            }

        }

        public void Draw(MyGraphics handler)
        {
            Color fillColor = Color.Black;
            Color drawColor = Color.Black;
            switch(type)
            {
                case MonsterType.Horizontal:
                    fillColor = Color.Green;
                    drawColor = Color.LightGreen;
                    break;
                case MonsterType.Vertical: 
                    fillColor = Color.Blue;
                    drawColor = Color.LightBlue;
                    break;
                case MonsterType.AllDirections:
                    fillColor = Color.DarkRed;
                    drawColor = Color.Red;
                    break;
            }
            handler.grp.FillEllipse(new SolidBrush(fillColor), locY * Engine.dW, locX * Engine.dH, Engine.dW, Engine.dH);
            handler.grp.DrawEllipse(new Pen(drawColor), locY * Engine.dW, locX * Engine.dH, Engine.dW, Engine.dH);
        }
    }
}
