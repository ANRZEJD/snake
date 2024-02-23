using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace snake
{
    public partial class Form1 : Form
    {    
         private List<okrag> snake=new List<okrag> ();

         private okrag food=new okrag ();

         int maxwidth;

         int maxheight;

         int score;

         int highscore;

         Random rand=new Random ();

         bool goleft, godown, goup, goright;

        




        public Form1()
        {
            InitializeComponent();
            new opcje();
        }

        private void Keyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left && opcje.direction !="right")
            {
                goleft = true;
            }
            if(e.KeyCode == Keys.Right && opcje.direction != "left") 
            {
                goright = true;
            }
            if (e.KeyCode == Keys.Up && opcje.direction != "down") 
            {
                goup= true;
            }
            if ((e.KeyCode == Keys.Down && opcje.direction != "up"))
            {
                godown = true;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left )
            {
                goleft = false;
            }
            if (e.KeyCode == Keys.Right )
            {
                goright = false;
            }
            if (e.KeyCode == Keys.Up )
            {
                goup = false;
            }
            if ((e.KeyCode == Keys.Down))
            {
                godown = false;
            }
        }

        private void startgame(object sender, EventArgs e)
        {
            Restart();
        }

        private void snap(object sender, EventArgs e)
        {
            Label scr=new Label();
         
            scr.Text = "Mój wynik to :" + score + " a mój najlepszy to:" + highscore + "w grze Snake"; 
            scr.Font=new Font("Ariel",13,FontStyle.Bold);
            scr.ForeColor = Color.Black;
            scr.AutoSize = false;
            scr.Width=mapa.Width; 
            scr.Height=30;
            scr.TextAlign = ContentAlignment.MiddleCenter;
            mapa.Controls.Add(scr);

            SaveFileDialog scrr=new SaveFileDialog();
            scrr.FileName = "scr z snake";
            scrr.DefaultExt = "jpg";
            scrr.ValidateNames = true;

            if(scrr.ShowDialog() == DialogResult.OK)
            {
                int width=Convert.ToInt32(mapa.Width);
                int height=Convert.ToInt32(mapa.Height);
                Bitmap img=new Bitmap(width, height);
                mapa.DrawToBitmap(img,new Rectangle(0,0,width,height));
                img.Save(scrr.FileName,ImageFormat.Jpeg);
                mapa.Controls.Remove(scr);
            }



        }

        private void timerevent(object sender, EventArgs e)
        {
            if (goleft) { opcje.direction = "left"; }
            if (goright) { opcje.direction="right"; }
            if (godown) { opcje.direction = "down"; }
            if (goup) { opcje.direction = "up"; }

            if (snake[0].x < 0 || snake[0].x >= maxwidth || snake[0].y < 0 || snake[0].y >= maxheight)
            {
                gameover();
                return; 
            }

            for (int i = snake.Count-1; i >=0; i--)
            {
                if (i == 0)
                {
                    switch (opcje.direction)
                    {
                        case "left":
                            snake[i].x--;
                            break;
                        case"right":
                            snake[i].x++;
                            break;
                        case "down":
                            snake[i].y++;
                            break;
                        case "up":
                            snake[i].y--;
                            break;

                            
                    }
                    if (snake[i].x<0)
                    {
                        snake[i].x = maxwidth;
                    }
                    if (snake[i].x>maxwidth)
                    {
                        snake[i].x=0;
                    }
                    if (snake[i].y<0)
                    {
                        snake[i].y = maxheight;
                    }
                        if (snake[i].y>maxheight)
                    {
                        snake[i].y=0;
                    }

                    if (snake[i].x==food.x && snake[i].y==food.y)
                    {
                        eat();
                    }

                    for (int j=1; j < snake.Count; j++)
                    {
                        if (snake[i].x == snake[j].x && snake[i].y == snake[j].y )
                        {
                            gameover();
                        }
                    }

                }
                else
                {
                    snake[i].x = snake[i-1].x;
                    snake[i].y = snake[i-1].y;
                }
            }
            mapa.Invalidate();
        }

        private void uptadegrap(object sender, PaintEventArgs e)
        {
            Graphics mapa=e.Graphics;
            Brush snakecolour;

            for (int i = 0;i<snake.Count;i++)
            {
                if(i==0)
                {
                    snakecolour = Brushes.Black;

                }
                else
                {
                    snakecolour= Brushes.DarkGreen;
                }

                mapa.FillEllipse(snakecolour, new Rectangle
                    (
                    snake[i].x*opcje.width,
                    snake[i].y*opcje.height,
                    opcje.width,opcje.height
                    ));
            }
            mapa.FillEllipse(Brushes.Red, new Rectangle
                   (
                   food.x * opcje.width,
                   food.y * opcje.height,
                   opcje.width, opcje.height
                   ));


        }

        private void Restart() 
        {
            maxwidth = mapa.Width / opcje.width - 1;
            maxheight= mapa.Height / opcje.height - 1;

            snake.Clear();

            Start.Enabled = false;
            snapbutton.Enabled = false;

            score = 0;

            Wynik.Text = "Wynik:" + score;

            okrag head =new okrag { x=10,y=5};
            snake.Add(head);

            for (int i = 0; i < 10; i++) 
            {
                okrag body = new okrag();
                snake.Add(body);
            }

            food = new okrag { x=rand.Next(2,maxwidth),y=rand.Next(2,maxheight)};

            gametimer.Start();


        }

        private void eat() 
        {
            score += 1;
            Wynik.Text = "Wynik: " + score;
            okrag body= new okrag();
            {
                body.x = snake[snake.Count - 1].x;
                body.y = snake[snake.Count - 1].y;
            };
            snake.Add(body);
            food = new okrag { x = rand.Next(2, maxwidth), y = rand.Next(2, maxheight) };
        }

        private void gameover() 
        {
            gametimer.Stop();
            Start.Enabled = true;
            snapbutton.Enabled = true;

            if (score > highscore)
            {
                highscore = score;
                Rekord.Text="Rekord: "+highscore;
                Rekord.TextAlign=ContentAlignment.MiddleCenter;


            }

        }
    }
}
