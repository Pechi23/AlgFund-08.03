using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgFund_08._03
{
    public class Player
    {
        public int locX, locY;
        public Player(int locX, int locY)
        {
            this.locX = locX; 
            this.locY = locY;
        }
        public void MoveUp()
        {
            if (Engine.CanMove(locX - 1, locY))
                this.locX--;
        }
        public void MoveDown()
        {
            if(Engine.CanMove(locX + 1, locY))
                this.locX++;
        }
        public void MoveLeft()
        {
            if (Engine.CanMove(locX, locY - 1))
                this.locY--;
        }
        public void MoveRight()
        {
            if(Engine.CanMove(locX, locY +1))
                this.locY++;
        }
        public void Draw(MyGraphics handler)
        {
            Color fillColor = Color.Yellow;
            Color drawColor = Color.Orange;
            handler.grp.FillEllipse(new SolidBrush(fillColor), locY * Engine.dW + 5, locX * Engine.dH + 5, Engine.dW - 10, Engine.dH - 10);
            handler.grp.DrawEllipse(new Pen(drawColor, 3), locY * Engine.dW + 5, locX * Engine.dH + 5, Engine.dW - 10, Engine.dH - 10);
        }
    }
}
