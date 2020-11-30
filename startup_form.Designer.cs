namespace TargetSeeker_PathFinderDemo
{
    partial class startup_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(startup_form));
            this.openGame = new System.Windows.Forms.Button();
            this.closeGame = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // openGame
            // 
            this.openGame.Location = new System.Drawing.Point(33, 191);
            this.openGame.Name = "openGame";
            this.openGame.Size = new System.Drawing.Size(139, 40);
            this.openGame.TabIndex = 0;
            this.openGame.Text = "Open App Game";
            this.openGame.UseVisualStyleBackColor = true;
            this.openGame.Click += new System.EventHandler(this.openGame_Click);
            // 
            // closeGame
            // 
            this.closeGame.Location = new System.Drawing.Point(376, 191);
            this.closeGame.Name = "closeGame";
            this.closeGame.Size = new System.Drawing.Size(139, 40);
            this.closeGame.TabIndex = 1;
            this.closeGame.Text = "Close";
            this.closeGame.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(170, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(215, 139);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // startup_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(555, 261);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.closeGame);
            this.Controls.Add(this.openGame);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "startup_form";
            this.Text = "PathFinder App";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button openGame;
        private System.Windows.Forms.Button closeGame;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}