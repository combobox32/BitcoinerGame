using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace FirstApp
{
    class CImage
    {
        bool disposed = false;

        Bitmap bitmap;

        private int x;
        private int y;

        public int Left
        {
            get { return x; }
            set { x = value; }
        }

        public int Top
        {
            get { return y; }
            set { y = value; }
        }

        public CImage(Bitmap res)
        {
            bitmap = new Bitmap(res);
        }

        public void DrawImage(Graphics g)
        {
            g.DrawImage(bitmap,x,y);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if (disposing)
            {
                bitmap.Dispose();
            }
            disposed = true;
        }
    }
}
