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
            this.Start = new System.Windows.Forms.Button();
            this.DealerCard4 = new System.Windows.Forms.PictureBox();
            this.DealerCard3 = new System.Windows.Forms.PictureBox();
            this.DealerCard2 = new System.Windows.Forms.PictureBox();
            this.DealerCard1 = new System.Windows.Forms.PictureBox();
            this.PlayerDraw = new System.Windows.Forms.Button();
            this.Message = new System.Windows.Forms.TextBox();
            this.PlayerStand = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerCard2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerCard3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerCard4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DealerCard4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DealerCard3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DealerCard2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DealerCard1)).BeginInit();
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
            // Start
            // 
            this.Start.AutoSize = true;
            this.Start.BackColor = System.Drawing.Color.Transparent;
            this.Start.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Start.CausesValidation = false;
            this.Start.FlatAppearance.BorderSize = 0;
            this.Start.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Start.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Start.Font = new System.Drawing.Font("Unispace", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Start.ForeColor = System.Drawing.Color.Transparent;
            this.Start.Location = new System.Drawing.Point(218, 181);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(147, 49);
            this.Start.TabIndex = 4;
            this.Start.TabStop = false;
            this.Start.Text = "Spela!";
            this.Start.UseVisualStyleBackColor = false;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // DealerCard4
            // 
            this.DealerCard4.BackColor = System.Drawing.Color.Transparent;
            this.DealerCard4.Location = new System.Drawing.Point(925, 101);
            this.DealerCard4.Name = "DealerCard4";
            this.DealerCard4.Size = new System.Drawing.Size(150, 218);
            this.DealerCard4.TabIndex = 8;
            this.DealerCard4.TabStop = false;
            // 
            // DealerCard3
            // 
            this.DealerCard3.BackColor = System.Drawing.Color.Transparent;
            this.DealerCard3.Location = new System.Drawing.Point(850, 101);
            this.DealerCard3.Name = "DealerCard3";
            this.DealerCard3.Size = new System.Drawing.Size(150, 218);
            this.DealerCard3.TabIndex = 7;
            this.DealerCard3.TabStop = false;
            // 
            // DealerCard2
            // 
            this.DealerCard2.BackColor = System.Drawing.Color.Transparent;
            this.DealerCard2.Location = new System.Drawing.Point(775, 101);
            this.DealerCard2.Name = "DealerCard2";
            this.DealerCard2.Size = new System.Drawing.Size(150, 218);
            this.DealerCard2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DealerCard2.TabIndex = 6;
            this.DealerCard2.TabStop = false;
            // 
            // DealerCard1
            // 
            this.DealerCard1.BackColor = System.Drawing.Color.Transparent;
            this.DealerCard1.Location = new System.Drawing.Point(700, 101);
            this.DealerCard1.Name = "DealerCard1";
            this.DealerCard1.Size = new System.Drawing.Size(150, 218);
            this.DealerCard1.TabIndex = 5;
            this.DealerCard1.TabStop = false;
            // 
            // PlayerDraw
            // 
            this.PlayerDraw.BackColor = System.Drawing.Color.Transparent;
            this.PlayerDraw.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PlayerDraw.FlatAppearance.BorderSize = 0;
            this.PlayerDraw.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.PlayerDraw.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.PlayerDraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PlayerDraw.Font = new System.Drawing.Font("Unispace", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PlayerDraw.ForeColor = System.Drawing.Color.Transparent;
            this.PlayerDraw.Location = new System.Drawing.Point(281, 664);
            this.PlayerDraw.Name = "PlayerDraw";
            this.PlayerDraw.Size = new System.Drawing.Size(95, 47);
            this.PlayerDraw.TabIndex = 9;
            this.PlayerDraw.Text = "Dra";
            this.PlayerDraw.UseVisualStyleBackColor = false;
            this.PlayerDraw.Visible = false;
            this.PlayerDraw.Click += new System.EventHandler(this.PlayerDraw_Click_1);
            // 
            // Message
            // 
            this.Message.Location = new System.Drawing.Point(748, 37);
            this.Message.Name = "Message";
            this.Message.ReadOnly = true;
            this.Message.Size = new System.Drawing.Size(264, 23);
            this.Message.TabIndex = 10;
            this.Message.Visible = false;
            // 
            // PlayerStand
            // 
            this.PlayerStand.AutoSize = true;
            this.PlayerStand.BackColor = System.Drawing.Color.Transparent;
            this.PlayerStand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PlayerStand.CausesValidation = false;
            this.PlayerStand.FlatAppearance.BorderSize = 0;
            this.PlayerStand.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.PlayerStand.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.PlayerStand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PlayerStand.Font = new System.Drawing.Font("Unispace", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PlayerStand.ForeColor = System.Drawing.Color.Transparent;
            this.PlayerStand.Location = new System.Drawing.Point(412, 662);
            this.PlayerStand.Name = "PlayerStand";
            this.PlayerStand.Size = new System.Drawing.Size(147, 49);
            this.PlayerStand.TabIndex = 11;
            this.PlayerStand.TabStop = false;
            this.PlayerStand.Text = "Stanna";
            this.PlayerStand.UseVisualStyleBackColor = false;
            this.PlayerStand.Visible = false;
            this.PlayerStand.Click += new System.EventHandler(this.PlayerStand_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Blackjack.Properties.Resource1.background;
            this.ClientSize = new System.Drawing.Size(1684, 861);
            this.Controls.Add(this.PlayerStand);
            this.Controls.Add(this.Message);
            this.Controls.Add(this.PlayerDraw);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.PlayerCard4);
            this.Controls.Add(this.DealerCard4);
            this.Controls.Add(this.PlayerCard3);
            this.Controls.Add(this.DealerCard3);
            this.Controls.Add(this.DealerCard2);
            this.Controls.Add(this.DealerCard1);
            this.Controls.Add(this.PlayerCard2);
            this.Controls.Add(this.PlayerCard1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.PlayerCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerCard2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerCard3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerCard4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DealerCard4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DealerCard3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DealerCard2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DealerCard1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox PlayerCard1;
        private PictureBox PlayerCard2;
        private PictureBox PlayerCard3;
        private PictureBox PlayerCard4;
        private Button Start;
        private PictureBox DealerCard4;
        private PictureBox DealerCard3;
        private PictureBox DealerCard2;
        private PictureBox DealerCard1;
        private Button PlayerDraw;
        private TextBox Message;
        private Button PlayerStand;
    }
}