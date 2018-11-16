namespace FirstApp
{
    partial class Bitcoiner
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bitcoiner));
            this.Tajmer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Tajmer
            // 
            this.Tajmer.Tick += new System.EventHandler(this.Tajmer_Tick);
            // 
            // Bitcoiner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(596, 368);
            this.MaximumSize = new System.Drawing.Size(612, 407);
            this.MinimumSize = new System.Drawing.Size(612, 407);
            this.Name = "Bitcoiner";
            this.Text = "Bitcoiner";
            this.Load += new System.EventHandler(this.Bitcoin_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Bitcoin_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Bitcoiner_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer Tajmer;
    }
}

