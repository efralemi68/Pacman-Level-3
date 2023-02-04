namespace Nivel_3_Pacman
{
    public partial class Form1 : Form
    {

        Bitmap bmp;
        static Graphics g;

        int score, playerSpeed, enemie1speed, enemie2speed, enemie3speed, enemie4speed;
        bool up, down, left, right, over;
        private void PACMAN_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                up = true;
            }

            if (e.KeyCode == Keys.Down)
            {
                down = true;
            }

            if (e.KeyCode == Keys.Left)
            {
                left = true;
            }

            if (e.KeyCode == Keys.Right)
            {
                right = true;
            }

            if (e.KeyCode == Keys.Enter && over == true)
            {
                reset();
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                up = false;
            }

            if (e.KeyCode == Keys.Down)
            {
                down = false;
            }

            if (e.KeyCode == Keys.Left)
            {
                left = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                right = false;
            }

        }

        public Form1()
        {
            InitializeComponent();

            bmp = new Bitmap(250, 250);
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;
            DrawMap();

            reset();
        }
        private void DrawMap()
        {
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.DeepPink);

            for (int x = 0; x < Mapa.map0.GetLength(0); x++)
            {
                for (int y = 0; y < Mapa.map0.GetLength(1); y++)
                {
                    if (Mapa.map0[x, y] != 0)
                    {
                        g.FillRectangle(new SolidBrush(Color.FromArgb(35, 35, 35)), x * 10, y * 10, 10, 10);
                    }
                    else
                    {
                        g.DrawRectangle(Pens.Gray, x * 10, y * 10, 10, 10);
                    }
                }
            }


        }




        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "SCORE: " + score;
            if (left == true)
            {
                PACMAN.Left -= playerSpeed;
                PACMAN.Image = Properties.Resources.left;

            }
            if (right == true)
            {
                PACMAN.Left += playerSpeed;
                PACMAN.Image = Properties.Resources.right;

            }

            if (down == true)
            {
                PACMAN.Top += playerSpeed;
                PACMAN.Image = Properties.Resources.down;

            }

            if (up == true)
            {
                PACMAN.Top -= playerSpeed;
                PACMAN.Image = Properties.Resources.Up;

            }

            if (PACMAN.Left < -2)
            {
                PACMAN.Left = 300;

            }

            if (PACMAN.Left > 300)
            {
                PACMAN.Left = -2;
            }

            if (PACMAN.Top < -2)
            {
                PACMAN.Top = 300;

            }

            if (PACMAN.Top > 300)
            {
                PACMAN.Top = -2;
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    if ((string)x.Tag == "coin" && x.Visible == true) // score 
                    {
                        if (PACMAN.Bounds.IntersectsWith(x.Bounds))
                        {
                            score += 1;
                            x.Visible = false;
                        }
                    }

                    if ((string)x.Tag == "enem")
                    {
                        if (PACMAN.Bounds.IntersectsWith(x.Bounds))
                        {
                            Game_over("YOU LOOSE :( ");
                        }


                    }
                }
            }

            enemie1.Left += enemie1speed;
            if (enemie1.Bounds.IntersectsWith(pictureBox42.Bounds) || enemie1.Bounds.IntersectsWith(pictureBox41.Bounds))
            {
                enemie1speed = -enemie1speed;
            }
            enemie2.Left += enemie2speed;
            if (enemie2.Bounds.IntersectsWith(pictureBox37.Bounds) || enemie2.Bounds.IntersectsWith(pictureBox38.Bounds))
            {
                enemie2speed = -enemie2speed;
            }

            enemi3.Left += enemie3speed;
            if (enemi3.Bounds.IntersectsWith(pictureBox39.Bounds) || enemi3.Bounds.IntersectsWith(pictureBox40.Bounds))
            {
                enemie3speed = -enemie3speed;
            }

            enemie4.Left += enemie4speed;


            if (enemie4.Bounds.IntersectsWith(pictureBox2.Bounds) || enemie4.Bounds.IntersectsWith(pictureBox43.Bounds))
            {
                enemie4speed = -enemie4speed;
            }

            if (score == 39)
            {
                Game_over("AMAZING! YOU WIN! ");
            }
        }


        private void reset()
        {
            label1.Text = "SCORE: 0";
            score = 0;

            enemie1speed = 1;
            enemie2speed = 1;
            enemie3speed = 1;
            enemie4speed = 1;

            playerSpeed = 2;

            over = false;

            PACMAN.Left = 8;
            PACMAN.Top = 23;

            enemie1.Left = 51;
            enemie1.Top = 184;

            enemie2.Left = 205;
            enemie2.Top = 183;

            enemi3.Left = 124;
            enemi3.Top = 23;

            enemie4.Left = 205;
            enemie4.Top = 6;



            gameTimer.Start();

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    x.Visible = true;
                }
            }


        }

        private void Game_over(string m)
        {
            over = true;

            gameTimer.Stop();

            label1.Text = "SCORE:" + score + Environment.NewLine + m;
        }
    }

}





