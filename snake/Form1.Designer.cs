namespace snake
{
    partial class Form1
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
            this.Start = new System.Windows.Forms.Button();
            this.snapbutton = new System.Windows.Forms.Button();
            this.mapa = new System.Windows.Forms.PictureBox();
            this.Wynik = new System.Windows.Forms.Label();
            this.Rekord = new System.Windows.Forms.Label();
            this.gametimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mapa)).BeginInit();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(591, 12);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(137, 55);
            this.Start.TabIndex = 0;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.startgame);
            // 
            // snapbutton
            // 
            this.snapbutton.Location = new System.Drawing.Point(591, 73);
            this.snapbutton.Name = "snapbutton";
            this.snapbutton.Size = new System.Drawing.Size(137, 55);
            this.snapbutton.TabIndex = 1;
            this.snapbutton.Text = "Snap";
            this.snapbutton.UseVisualStyleBackColor = true;
            this.snapbutton.Click += new System.EventHandler(this.snap);
            // 
            // mapa
            // 
            this.mapa.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.mapa.Location = new System.Drawing.Point(12, 12);
            this.mapa.Name = "mapa";
            this.mapa.Size = new System.Drawing.Size(580, 680);
            this.mapa.TabIndex = 2;
            this.mapa.TabStop = false;
            this.mapa.Paint += new System.Windows.Forms.PaintEventHandler(this.uptadegrap);
            // 
            // Wynik
            // 
            this.Wynik.AutoSize = true;
            this.Wynik.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Wynik.Location = new System.Drawing.Point(598, 140);
            this.Wynik.Name = "Wynik";
            this.Wynik.Size = new System.Drawing.Size(130, 42);
            this.Wynik.TabIndex = 3;
            this.Wynik.Text = "Wynik:";
            // 
            // Rekord
            // 
            this.Rekord.AutoSize = true;
            this.Rekord.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Rekord.Location = new System.Drawing.Point(598, 201);
            this.Rekord.Name = "Rekord";
            this.Rekord.Size = new System.Drawing.Size(149, 42);
            this.Rekord.TabIndex = 4;
            this.Rekord.Text = "Rekord:";
            // 
            // gametimer
            // 
            this.gametimer.Interval = 90;
            this.gametimer.Tick += new System.EventHandler(this.timerevent);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 704);
            this.Controls.Add(this.Rekord);
            this.Controls.Add(this.Wynik);
            this.Controls.Add(this.mapa);
            this.Controls.Add(this.snapbutton);
            this.Controls.Add(this.Start);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Keyisdown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyisup);
            ((System.ComponentModel.ISupportInitialize)(this.mapa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button snapbutton;
        private System.Windows.Forms.PictureBox mapa;
        private System.Windows.Forms.Label Wynik;
        private System.Windows.Forms.Label Rekord;
        private System.Windows.Forms.Timer gametimer;
    }
}

