using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using FirstApp.Properties;

namespace FirstApp
{
    class CCoin : CImage
    {

  
        private Rectangle coinPosition = new Rectangle();

        public CCoin() : base(Resources.Bitcoin)
        {
            coinPosition.X = Left + 20;
            coinPosition.Y = Top - 1;
            coinPosition.Width = 100; 
            coinPosition.Height = 100; 
        }

  
        public void Update(int X, int Y)
        {
            Left = X;
            Top = Y;
            
            coinPosition.X = Left + 20;
            coinPosition.Y = Top - 1;
        }

        public bool Shoot(int X, int Y)
        {
            Rectangle r = new Rectangle(X, Y, 1, 1);

            if(coinPosition.Contains(r))
            {
                return true;
            }
            return false;
        }
      
    }
}
