//#define My_Debug //za sakrivanje i prikazivanje koordinata

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FirstApp.Properties;
using System.Media;

namespace FirstApp
{
    public partial class Bitcoiner : Form
    {

#if My_Debug
        int cursX = 0;
        int cursY = 0;
#endif

        const int frame = 8;
        const int shoot = 3;

        int hit = 0;
        int miss = 0;
        int sum = 0;
        double avg = 0.00;

        int time = 0;
        bool shootCoin = false;
        int i = 0;
        private CCoin coin;
        private CSign sign;
        private CHeart heart;
        private CResult result;
        Random rand = new Random();

        public Bitcoiner()
        {
            InitializeComponent();

            this.SetStyle(
                System.Windows.Forms.ControlStyles.UserPaint |
                System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
                true);


            coin = new CCoin() {Left = 10, Top = 300}; 
            result = new CResult() {Left = 10, Top = 10};
            sign = new CSign() {Left = 340, Top = 10};
            heart = new CHeart();


            Bitmap b = new Bitmap(Resources.Shootgun);
            this.Cursor = FirstApp.Cursor.CreateCursor(b, b.Width / 2, b.Height / 2);

        }

        private void Tajmer_Tick(object sender, EventArgs e)
        {
            if (i >= frame) 
            {
                change();
                i = 0;
            }

            if(shootCoin)
            {
                if (time >= shoot)
                {
                    shootCoin = false;
                    time = 0;
                    change();
                }
                time++;
            }

            i++;

            this.Refresh();
        }

        private void change() 
        {
            coin.Update(
                    rand.Next(Resources.Bitcoin.Width, this.Width - Resources.Bitcoin.Width),
                    rand.Next(this.Height / 2, this.Height - Resources.Bitcoin.Height * 2)
                    );
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            Graphics g = e.Graphics;

            if (shootCoin == true)
            {
                heart.DrawImage(g);
            }
            else
            {
                coin.DrawImage(g);
            }
            

       
            sign.DrawImage(g); 
            result.DrawImage(g);
#if My_Debug
            TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.EndEllipsis;
            Font f = new System.Drawing.Font("Stencil", 12, FontStyle.Regular);
            TextRenderer.DrawText
                (e.Graphics, "X=" + cursX.ToString() + ":" + "Y=" + cursY.ToString(), 
                    f, new Rectangle(30, 20, 120, 20), SystemColors.ControlText, flags);
#endif


            TextFormatFlags flags = TextFormatFlags.Left;
            Font f = new System.Drawing.Font("Cambria", 10, FontStyle.Italic);
            
            TextRenderer.DrawText(e.Graphics, "Hit: " + hit.ToString() , f, new Rectangle(50, 42, 120, 60), SystemColors.ControlText, flags);
            TextRenderer.DrawText(e.Graphics, "Miss: " +miss.ToString(), f, new Rectangle(50, 62, 120, 60), SystemColors.ControlText, flags);
            TextRenderer.DrawText(e.Graphics, "Average: " + avg.ToString() + " %" , f, new Rectangle(50, 82, 120, 60), SystemColors.ControlText, flags);


            
            base.OnPaint(e);
        }




        private void Bitcoiner_MouseMove(object sender, MouseEventArgs e)
        {
#if My_Debug
            cursX = e.X;
            cursY = e.Y;
#endif
            this.Refresh();
        }

        private void Bitcoin_Load(object sender, EventArgs e)
        {

        }

        private void Bitcoin_MouseClick(object sender, MouseEventArgs e)
        {
           
             if (e.X > 430 && e.X < 528 && e.Y > 37 && e.Y < 76) 
             {
                Tajmer.Start();
            }
                
             else if(e.X > 430 && e.X < 528  && e.Y > 90 && e.Y < 124) 
             {
              
                Tajmer.Stop();

                hit = 0;
                miss = 0;
                avg = 0;

                Tajmer.Start();
            }
             
             else if(e.X > 430 && e.X < 528  && e.Y > 150 && e.Y < 174) 
             {

                Tajmer.Stop();
             }


             else if (e.X > 430 && e.X < 528 && e.Y > 182 && e.Y < 218) 
             {
                 Tajmer.Stop();

                 DialogResult result = MessageBox.Show(this, " Do you really want to exit?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                 if (result == DialogResult.Yes)
                 {
                     this.Close();
                 }

             }

             else
             {
                 if (coin.Shoot(e.X, e.Y))
                 {
                     shootCoin = true;

                     heart.Left = coin.Left - Resources.Heart.Width / 3;
                     heart.Top = coin.Top - Resources.Heart.Height / 3;

                     hit++;
                 }

                 if (!coin.Shoot(e.X, e.Y))
                 {
                     miss++;
                 }

                 sum = hit + miss;

                 avg = Math.Round(((double)hit / sum) * 100.0, 2);
             }



             Shootgun();
             
        }

        private void Shootgun()
        {
            SoundPlayer sount = new SoundPlayer(Resources.ShootgunSound);
            sount.Play();
        }

    }
}
