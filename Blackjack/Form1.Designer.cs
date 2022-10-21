namespace Blackjack
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PlayerCard1 = new System.Windows.Forms.PictureBox();
            this.PlayerCard2 = new System.Windows.Forms.PictureBox();
            this.PlayerCard3 = new System.Windows.Forms.PictureBox();
            this.PlayerCard4 = new System.Windows.Forms.PictureBox();
            this.PlayerDraw = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerCard2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerCard3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerCard4)).BeginInit();
            this.SuspendLayout();
            // 
            // PlayerCard1
            // 
            this.PlayerCard1.BackColor = System.Drawing.Color.Transparent;
            this.PlayerCard1.Location = new System.Drawing.Point(700, 500);
            this.PlayerCard1.Name = "PlayerCard1";
            this.PlayerCard1.Size = new System.Drawing.Size(150, 218);
            this.PlayerCard1.TabIndex = 0;
            this.PlayerCard1.TabStop = false;
            // 
            // PlayerCard2
            // 
            this.PlayerCard2.BackColor = System.Drawing.Color.Transparent;
            this.PlayerCard2.Location = new System.Drawing.Point(775, 500);
            this.PlayerCard2.Name = "PlayerCard2";
            this.PlayerCard2.Size = new System.Drawing.Size(150, 218);
            this.PlayerCard2.TabIndex = 1;
            this.PlayerCard2.TabStop = false;
            // 
            // PlayerCard3
            // 
            this.PlayerCard3.BackColor = System.Drawing.Color.Transparent;
            this.PlayerCard3.Location = new System.Drawing.Point(850, 500);
            this.PlayerCard3.Name = "PlayerCard3";
            this.PlayerCard3.Size = new System.Drawing.Size(150, 218);
            this.PlayerCard3.TabIndex = 2;
            this.PlayerCard3.TabStop = false;
            // 
            // PlayerCard4
            // 
            this.PlayerCard4.BackColor = System.Drawing.Color.Transparent;
            this.PlayerCard4.Location = new System.Drawing.Point(925, 500);
            this.PlayerCard4.Name = "PlayerCard4";
            this.PlayerCard4.Size = new System.Drawing.Size(150, 218);
            this.PlayerCard4.TabIndex = 3;
            this.PlayerCard4.TabStop = false;
            // 
            // PlayerDraw
            // 
            this.PlayerDraw.Location = new System.Drawing.Point(828, 744);
            this.PlayerDraw.Name = "PlayerDraw";
            this.PlayerDraw.Size = new System.Drawing.Size(78, 54);
            this.PlayerDraw.TabIndex = 4;
            this.PlayerDraw.Text = "button1";
            this.PlayerDraw.UseVisualStyleBackColor = true;
            this.PlayerDraw.Click += new System.EventHandler(this.PlayerDraw_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Blackjack.Properties.Resource1.background;
            this.ClientSize = new System.Drawing.Size(1684, 861);
            this.Controls.Add(this.PlayerDraw);
            this.Controls.Add(this.PlayerCard4);
            this.Controls.Add(this.PlayerCard3);
            this.Controls.Add(this.PlayerCard2);
            this.Controls.Add(this.PlayerCard1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.PlayerCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerCard2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerCard3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerCard4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox PlayerCard1;
        private PictureBox PlayerCard2;
        private PictureBox PlayerCard3;
        private PictureBox PlayerCard4;
        private Button PlayerDraw;
    }
}